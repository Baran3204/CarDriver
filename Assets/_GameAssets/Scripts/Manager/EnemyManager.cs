using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   [Header("References")]

   [SerializeField] private GameObject _enemy1;
   [SerializeField] private GameObject _enemy2;
   [SerializeField] private GameObject _enemy3;
   [SerializeField] private GameObject _enemy4;

   [Header("Settings")]

   [SerializeField] private float _spawnCooldown;
   [SerializeField] private float _startCooldown;
   [SerializeField] private float _enemySpeed;
    private void Awake() 
    {
        _startCooldown = _spawnCooldown;    
    }
    private void Update() 
    {
        SpawnEnemy();    
    }
   private void SpawnEnemy()
   {
        _startCooldown -= Time.deltaTime;

        if(_startCooldown <= 0f)
        {
            GameObject SelectedEnemy = _enemy1;
            Rigidbody2D SelectedRigidbody = GetComponent<Rigidbody2D>();

            int rnd = Random.Range(1, 5);
            int rnd2 = Random.Range(1, 4);
            float randomY = 0f;
            switch (rnd2)
            {
                case 1:
                    randomY = 0.366f;
                    break;
                case 2:
                    randomY = -1.569f;
                    break;
                case 3:
                    randomY = -3.64f;
                    break;
            }
            
            switch(rnd)
            {
                case 1:
                SelectedEnemy = Instantiate(_enemy1, new Vector3(11f, randomY, 0f), Quaternion.identity);
                    break;
                case 2:
                SelectedEnemy = Instantiate(_enemy2, new Vector3(11f, randomY, 0f), Quaternion.identity);
                   break;
                case 3:
                SelectedEnemy = Instantiate(_enemy3, new Vector3(11f, randomY, 0f), Quaternion.identity);
                    break;
                case 4:
                SelectedEnemy =  Instantiate(_enemy4, new Vector3(11f, randomY, 0f), Quaternion.identity);
                    break;  
            }

            SelectedRigidbody = SelectedEnemy.GetComponent<Rigidbody2D>();

            SelectedRigidbody.AddForce(new Vector2(-1.2f, 0f) * _enemySpeed, ForceMode2D.Force);
                  
            _startCooldown += _spawnCooldown;
        }
   }
}
