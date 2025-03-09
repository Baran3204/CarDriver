using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _howToPlayButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private RectTransform _mainMenuTransform;
    [SerializeField] private PlayerController _playerController;

    [Header("References Texts")]
    [SerializeField] private TMP_Text[] _texts;

    private void Awake() 
    {
        _startButton.onClick.AddListener(StartButtonClicked);    
        _howToPlayButton.onClick.AddListener(HowToPlayButtonClicked);    
        _quitButton.onClick.AddListener(QuitButtonClicked);
        _playerController.ChangeGameOver(true);    
    }

    private void QuitButtonClicked()
    {
       Debug.Log("Game Quited...");
       Application.Quit();
    }

    private void HowToPlayButtonClicked()
    {
        
    }

    private void StartButtonClicked()
    {
        _mainMenuTransform.DOScale(0f, 0.5f).SetEase(Ease.InBack);
        _playerController.ChangeGameOver(false);
    }
}
