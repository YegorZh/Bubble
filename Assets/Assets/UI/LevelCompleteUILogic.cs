using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteUILogic : MonoBehaviour
{
    [SerializeField] Button _nextLevelButton;
    [SerializeField] Button _restartLevelButton;
    [SerializeField] Text _timeText;
    [SerializeField] GameManager _gameManager;

    public void SetTimeText(TimeSpan totalTime)
    {
        var text = $"Completion time: {totalTime.Minutes} : {totalTime.Seconds}";
        _timeText.text = text;
    }
    
    void OnEnable()
    {
        var onNextLevelClick = new Button.ButtonClickedEvent();
        onNextLevelClick.AddListener(() =>
        {
            _gameManager.LoadNextScene();
        });
        
        var onRestartClick = new Button.ButtonClickedEvent();
        onRestartClick.AddListener(() =>
        {
            _gameManager.RestartScene();
        });
        
        _nextLevelButton.onClick = onNextLevelClick;
        _restartLevelButton.onClick = onRestartClick;
    }
}
