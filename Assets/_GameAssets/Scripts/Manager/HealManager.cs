using System;
using System.Linq;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class HealManager : MonoBehaviour
{

  
   [Header("References")]

   [SerializeField] private GameObject[] _healObjects;
   [SerializeField] private PlayerController _playerController;
   [SerializeField] private RectTransform _gameOverUI;

   [Header("Settings")]
   [SerializeField] private float _maxHeal = 3f;
   private int _currentHeal = 0;
   private void Awake() 
   {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _playerController.OnDamage  += PlayerController_OnDamage;
   }

    private void PlayerController_OnDamage()
    {
        _maxHeal--;

        GameObject currentObject = _healObjects[_currentHeal];

        currentObject.transform.DOScale(0F, 0.2F).SetEase(Ease.InBack);

        _currentHeal++;

        if(_maxHeal <= 0f)
        {
           _playerController.ChangeGameOver(true);
            _gameOverUI.DOScale(1F, 0.5f).SetEase(Ease.OutBack);
        }
    }

    public void AddHeal()
    {
        if(_maxHeal >= 3f) { return; }      
       
        _currentHeal--;
        GameObject currentObject = _healObjects[_currentHeal];

        currentObject.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        _maxHeal++;
    }
}
