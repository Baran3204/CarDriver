using TMPro;
using UnityEngine;

public class ScoreManagerUI : MonoBehaviour
{
   [Header("References")]
   [SerializeField] private PlayerController _playerController;
   [SerializeField] private TMP_Text _scoreText;
   private float _currentTime = 0f;
   private float _score = 0f;

   private void Update() 
   {
    UpdateScore(); 
   }
   private void UpdateScore()
   {
     var IsGameOver = _playerController.GetIsGameOver();

     if(!IsGameOver)
     {
        _currentTime += Time.deltaTime;
        if(_currentTime >= 1f)
        {
            _score++;
            _scoreText.text = _score.ToString();
            _currentTime = 0f;
        }
     }
   }

   public void ResetScore()
   {
      _score = 0f;
   }
}
