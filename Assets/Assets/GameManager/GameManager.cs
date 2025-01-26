using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Health _bubblePrefab;
    Camera _cachedCamera;
    [SerializeField] CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] LevelCompleteUILogic _winLevelUI;
    [SerializeField] GameObject _canvas;
    Health _bubble;
    Transform _startingCheckpoint;
    Transform _activeCheckpoint;
    Scene _nextLevel;
    bool _hasLevelEnded;

    void OnEnable()
    {
        _bubble = GameObject.FindWithTag("Player").GetComponent<Health>();
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
            _cinemachineVirtualCamera.Follow = _bubble.transform;
        }
    }

    public void SetActiveCheckpoint()
    {
        
    }

    public void RespawnPlayerAtCheckpoint()
    {
        _bubble.ApplyDamage(1);
        _bubble = Instantiate(_bubblePrefab, _activeCheckpoint);
        _cinemachineVirtualCamera.Follow = _bubble.transform;
    }

    public void WinLevel()
    {
        _bubble.ApplyDamage(1);
        var winLevelUi = Instantiate(_winLevelUI, _canvas.transform);
        winLevelUi.Init(this);
        _hasLevelEnded = true;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_nextLevel.buildIndex);
    }
}
