using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using TMPro;
using TMPro.EditorUtilities;
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
    [SerializeField] private RectTransform[] _transforms;
    private int _currentİndexTransform;
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
        StartCoroutine(nameof(StartTimer));
        
    }

    public IEnumerator StartTimer()
    {
        for(int i = 0; i <= 3; i++)
        {
          RectTransform currentTransform = _transforms[_currentİndexTransform];

          currentTransform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);

          yield return new WaitForSeconds(1f);

          currentTransform.DOScale(0f, 0.5f).SetEase(Ease.InBack);
     
          _currentİndexTransform++;          
        }
        _playerController.ChangeGameOver(false);   
    }
}
