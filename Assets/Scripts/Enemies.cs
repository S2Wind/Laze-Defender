using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    float timer = 1f;
    float bulletSpeed = 100f;
    void Awake()
    {
        Fire();
    }

    IEnumerator ShootTimer()
    {
        while (true)
        {
            GameObject enemyBullet = Instantiate(bullet,
            transform.position,
            Quaternion.identity) as GameObject;
            enemyBullet.GetComponent<Rigidbody2D>().velocity = 
                new Vector2(0f, -10f) * bulletSpeed * Time.deltaTime;
            GetComponent<AudioControl>().PlayFireSound();
            yield return new WaitForSeconds(timer);
        }
    }
    void Fire()
    {
        StartCoroutine(ShootTimer());
    }

}
