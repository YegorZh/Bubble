using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _bubblePrefab;
    Camera _cachedCamera;
    [SerializeField] CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] GameObject _winLevelUI;
    [SerializeField] GameObject _canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _cachedCamera ??= Camera.main;
            var targetPos = _cachedCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            var newBubble = Instantiate(_bubblePrefab, targetPos, new Quaternion());
            _cinemachineVirtualCamera.Follow = newBubble.transform;
        }
    }

    public void RespawnPlayerAtCheckpoint()
    {
        
    }

    public void WinLevel()
    {
        
    }
}
