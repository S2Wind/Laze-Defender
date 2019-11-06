using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player details")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject playerbullet;
    [Header("Besides")]
    [SerializeField] float screenSizeUnitx = 11.25f;
    [SerializeField] float screenSizeUnity = 20f;

    Coroutine fireCo;
    float xMax, xMin, yMax, yMin;
    void Start()
    {
        SetUpMoveBoundaries();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }
    
    void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            fireCo = StartCoroutine(FireContinuely());
        }
        if(Input.GetMouseButtonUp(0))
        {
            StopCoroutine(fireCo);
        }
    }

    IEnumerator FireContinuely()
    {
        while (true)
        {
            GameObject bullet = GameObject.Instantiate(playerbullet,
                    transform.position,
                    Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1f) * moveSpeed * Time.deltaTime);
            GetComponent<AudioControl>().PlayFireSound();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera mainCamera = Camera.main;
        xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    Vector2 MouseMove()
    {
        return new Vector2(Mathf.Clamp(Input.mousePosition.x / Screen.width * screenSizeUnitx,xMin,xMax),
            Mathf.Clamp(Input.mousePosition.y / Screen.height * screenSizeUnity,yMin,yMax));
    }
    private void Move()
    {
        var getX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newPoX = Mathf.Clamp(transform.position.x + getX, xMin, xMax);
        var getY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        var newPoY = Mathf.Clamp(transform.position.y + getY, yMin, yMax);
        transform.position = new Vector2(newPoX, newPoY);
        transform.position = MouseMove();
    }

}
