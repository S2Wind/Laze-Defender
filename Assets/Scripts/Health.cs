using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] public int health = 500;
    [SerializeField] GameObject explosion;
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
            Destroy(gameObject);
        else
            health -= 100;
        OutOfHP();
    }

    void OutOfHP()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            GameObject explose = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            explose.transform.position = gameObject.transform.position;
            GetComponent<AudioControl>().PlayExplosion();
            Destroy(explose, 0.3f);
            Destroy(gameObject, 0.6f);
        }
    }
}
