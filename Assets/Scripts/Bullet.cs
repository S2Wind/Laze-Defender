using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Aldready in!");
        Destroy(gameObject);
    }

}
