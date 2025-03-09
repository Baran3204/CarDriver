using UnityEngine;

public class DeleteEnemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.CompareTag("Direk"))
         {
            Destroy(collision.gameObject);
         }
    }
}
