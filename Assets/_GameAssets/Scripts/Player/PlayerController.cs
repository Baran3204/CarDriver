using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;

    [Header("Settings")]
    [SerializeField] private float _playerSpeed;
    private Rigidbody2D _playerRigidbody;
    private Vector2 _playerMovementDirection;
    private float _horizontal, _vertical;
    private void Awake() 
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();    
    }
    private void Update() 
    {
        Setİnputs();    
    }

    private void FixedUpdate() 
    {
        SetMovement();    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Trap"))
        {
            SpeedDown();
            Destroy(other.gameObject);
        }    
    }
    private void SetMovement()
    {
        _playerMovementDirection = _playerTransform.up * _vertical + _playerTransform.right * _horizontal;

        _playerRigidbody.linearVelocity = _playerMovementDirection * _playerSpeed * Time.deltaTime;
    }

    private void Setİnputs()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void SpeedDown()
    {
        _playerSpeed -= 100f;
        float coolDown = 3f;
        coolDown -= Time.deltaTime;
        if(coolDown <= 0f)
        {
            Debug.Log("Speed Boosted!");
            _playerSpeed += 100f;
        }
    }
}
