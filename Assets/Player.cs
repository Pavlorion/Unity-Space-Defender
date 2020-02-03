using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movespeed = 10f;
    [SerializeField] GameObject laser = null;
    [SerializeField] float laserSpeed = 0.1f;

    Coroutine fireCor;

    float xpadding = 1f;
    float ypadding = 1.6f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start()
    {
        MoveInSizeOfCamera();
    }

    private  void MoveInSizeOfCamera()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3 (0, 0, 0)).x + xpadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xpadding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + ypadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - ypadding;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        
    }

    

    private  void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           fireCor = StartCoroutine(FireCorountine());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCor);
        }
    }

    IEnumerator FireCorountine()
    {
        while (true)
        {
            GameObject laserProjectile = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
            laserProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x, 20f);
            yield return new WaitForSeconds(laserSpeed);
        }
    }

    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos =Mathf.Clamp (transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
