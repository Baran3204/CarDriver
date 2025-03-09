using UnityEngine;

public class DirekManager : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject _direk;
    private Rigidbody2D _direkRb;
    private void Awake() 
    {
      GameObject CurrentDirek = Instantiate(_direk, transform.position, Quaternion.Euler(0f, 0f, -90f));
     _direkRb = CurrentDirek.GetComponent<Rigidbody2D>();  
    }

    private void Update() 
    {
        if(_direkRb == null) { return; }
        else { _direkRb.AddForce(new Vector2(-1.2f, 0f) * 10f, ForceMode2D.Force);}
    }
}
