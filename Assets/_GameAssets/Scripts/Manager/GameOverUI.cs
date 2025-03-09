using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private RectTransform _gameOverPopup;
    [SerializeField] private MainMenuUI _mainMenuUI;
    [SerializeField] private ScoreManagerUI _scoreManagerUI;

    private void Awake() 
    {
        _quitButton.onClick.AddListener(QuitButtonClicked);    
        _tryAgainButton.onClick.AddListener(TryAgainButtonClicked);    
    }

    private void QuitButtonClicked()
    {
        Application.Quit();
    }

    private void TryAgainButtonClicked()
    {
        _gameOverPopup.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack);
        _scoreManagerUI.ResetScore();
       StartCoroutine(nameof(_mainMenuUI.StartTimer));
    }
}
