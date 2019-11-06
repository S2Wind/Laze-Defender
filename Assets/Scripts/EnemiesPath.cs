using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPath : MonoBehaviour
{
    ConfigWave waveConfig;
    List<Transform> wayPoint;
    int wayPointIndex = 0;
    Rigidbody2D rb;
    void Start()
    {
        wayPoint = waveConfig.GetPathPrefab();
        rb = GetComponent<Rigidbody2D>();
        transform.position = wayPoint[wayPointIndex].position;
    }

    void Update()
    {
        Move();
    }

    public void GetConfigWave(ConfigWave waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (wayPointIndex <= wayPoint.Count - 1)
        {
            var targetPos = wayPoint[wayPointIndex].position;
            var moveThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
                targetPos,
                moveThisFrame);
            if (transform.position == targetPos)
            {
                wayPointIndex++;
            }
        }
        else
            Destroy(gameObject);
    }
}
