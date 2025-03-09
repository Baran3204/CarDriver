using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayUI : MonoBehaviour
{
   [Header("References")]
   [SerializeField] private RectTransform _htpPopup;
   [SerializeField] private Button _backButton;

   private void Awake() 
   {
     _backButton.onClick.AddListener(HtpButtonClicked);
   }

    private void HtpButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        _htpPopup.DOScale(0F, 0.5F).SetEase(Ease.InBack);
    }
}
