using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
public class PlayerController : MonoBehaviour
{

    public event Action OnTrapActived;
    public event Action OnDamage;
    
    [Header("References")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private HealManager _healManager;

    [Header("Settings")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _startCooldown;
    private Rigidbody2D _playerRigidbody;
    private Vector2 _playerMovementDirection;
    private float _horizontal, _vertical;
    private bool _isGameOver;
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
        if(!_isGameOver) { SetMovement(); }         
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            OnDamage?.Invoke();      
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Trap"))
        {
            AudioManager.Instance.Play(SoundType.PickupBadSound);
            OnTrapActived += SpeedDown;
            OnTrapActived?.Invoke();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Direk"))
        {
            OnDamage?.Invoke();
            Destroy(other.gameObject);
        } 
        else if(other.gameObject.CompareTag("Heal"))
        {
            _healManager.AddHeal();
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
    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(_startCooldown);

        _playerSpeed += 100f;

        OnTrapActived -= SpeedDown;
    }

    private void SpeedDown()
    { 
      _playerSpeed -= 100f;
      StartCoroutine(CooldownCoroutine());
    }
    public void ChangeGameOver(bool value)
    {
        _isGameOver = value;
    }

    public bool GetIsGameOver()
    {
        return _isGameOver;
    }
}
