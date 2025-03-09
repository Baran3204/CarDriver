using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private RectTransform _gameOverPopup;

    private void Awake() 
    {
        _quitButton.onClick.AddListener(QuitButtonClicked);    
        _mainMenuButton.onClick.AddListener(MainMenuButtonClicked);    
    }

    private void QuitButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        Application.Quit();
    }

    private void MainMenuButtonClicked()
    {
       AudioManager.Instance.Play(SoundType.ButtonClickSound);
       SceneManager.LoadScene("SampleScene");
    }
}
