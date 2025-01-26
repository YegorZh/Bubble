using System;
using Cinemachine;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Health _bubblePrefab;
    Camera _cachedCamera;
    [SerializeField] CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] LevelCompleteUILogic _winLevelUI;
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _respawnText;
    Health _bubble;
    [SerializeField] CheckpointLogic _startingCheckpoint;
    Transform _activeCheckpointTransform;
    [SerializeField] string _nextLevel;
    bool _hasLevelEnded;
    TimeSpan _totalTime;
    DateTime _startTime;

    void OnEnable()
    {
        var player = GameObject.FindWithTag("Player"); 
        if (player == null) return;
        _bubble = player.GetComponent<Health>();
        _bubble.onDeath += HandlePlayerDeath;
    }

    void HandlePlayerDeath()
    {
        if (_hasLevelEnded) return; 
        _respawnText.SetActive(true);
    }

    void Update()
    {
        if (_hasLevelEnded) return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayerAtCheckpoint();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            _cachedCamera ??= Camera.main;
            var targetPos = _cachedCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            _bubble = Instantiate(_bubblePrefab, targetPos, new Quaternion());
            _bubble.onDeath += HandlePlayerDeath;
            _cinemachineVirtualCamera.Follow = _bubble.transform;
            _respawnText.SetActive(false);
        }
    }

    public void SetActiveCheckpointTransform(Transform activeCheckpointTransform)
    {
        _activeCheckpointTransform = activeCheckpointTransform;
    }

    void Start()
    {
        _startTime = DateTime.Now;
        _startingCheckpoint.BecomeActive();
        SetActiveCheckpointTransform(_startingCheckpoint.transform);
        RespawnPlayerAtCheckpoint(true);
    }

    public void RespawnPlayerAtCheckpoint(bool bruteForceLevelOneRespawn = false)
    {
        if (!bruteForceLevelOneRespawn && SceneManager.GetActiveScene().name == "Level1") return;
        if(_bubble != null )_bubble.ApplyDamage(1);
        _bubble = Instantiate(_bubblePrefab, _activeCheckpointTransform);
        _bubble.transform.parent = null;
        _bubble.onDeath += HandlePlayerDeath;
        _cinemachineVirtualCamera.Follow = _bubble.transform;
        _respawnText.SetActive(false);
    }

    public void WinLevel()
    {
        _bubble.ApplyDamage(1);
        _winLevelUI.gameObject.SetActive(true);
        _hasLevelEnded = true;
        _respawnText.SetActive(false);

        var endTime = DateTime.Now;
        _totalTime = endTime - _startTime;
        _winLevelUI.SetTimeText(_totalTime);
    }

    public void RestartScene()
    {
        _startingCheckpoint.ClearCheckpoints();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        
        _startingCheckpoint.ClearCheckpoints();
        SceneManager.LoadScene(_nextLevel);
        TotalTimeMemory.TotalTime += _totalTime;
    }
}
