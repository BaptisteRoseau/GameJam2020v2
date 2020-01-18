using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public float speed;
    private float moveInputH;
    private float moveInputV;

    public Rigidbody2D rb;

    /*public GameObject ballPrefab;
    public GameObject crosshair;
    public float arrowSpeed;*/
    public int num_player;

    //public bool shooted;

    void Start()
    {
        //shooted = false;
        rb = GetComponent<Rigidbody2D>();
    }

    /*private void Update()
    {
        if (Input.GetButtonDown("Fire") && shooted == false)
        {
            shooted = true;
            Shoot();
        }
    }*/

    void FixedUpdate()
    {
        if (num_player == 1)
        {
            moveInputH = Input.GetAxis("Vertical");
            moveInputV = Input.GetAxis("Horizontal");
        }
        else if (num_player == 2)
        {
            moveInputH = -Input.GetAxis("Vertical2");
            moveInputV = -Input.GetAxis("Horizontal2");
        }

        rb.velocity = new Vector2(moveInputH * speed, rb.velocity.y);
        rb.velocity = new Vector2(moveInputV * speed, rb.velocity.x);
    }

    /*void Shoot()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowSpeed;
        Destroy(ball, 2.0f);
    
    }*/
}
