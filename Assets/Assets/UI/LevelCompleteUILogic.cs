using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelCompleteUILogic : MonoBehaviour
{
    [SerializeField] Button _nextLevelButton;
    [SerializeField] Button _restartLevelButton;
    [HideInInspector] public GameManager GameManager;

    public void Init(GameManager gameManager)
    {
        GameManager = gameManager;
    }
    
    void OnEnable()
    {
        var onNextLevelClick = new Button.ButtonClickedEvent();
        onNextLevelClick.AddListener(() =>
        {
            GameManager.LoadNextScene();
        });
        
        var onRestartClick = new Button.ButtonClickedEvent();
        onRestartClick.AddListener(() =>
        {
            GameManager.RestartScene();
        });
        
        _nextLevelButton.onClick = onNextLevelClick;
        _restartLevelButton.onClick = onRestartClick;
    }
}
