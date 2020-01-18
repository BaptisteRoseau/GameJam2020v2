using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public float speed;
    public float crosshairSpeed;
    private float crosshairMovement = 0f;
    private float moveInputH;
    private float moveInputV;
    public GameObject crosshair;

    public Rigidbody2D rb;

    public GameObject ballPrefab;
    public float arrowSpeed;
    public int num_player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {


        if (num_player == 1)
        {
            if (Input.GetButtonDown("Fire"))
            {
                Shoot();
            }
            moveInputH = Input.GetAxis("Vertical");
            moveInputV = Input.GetAxis("Horizontal");
            crosshairMovement = Input.GetAxisRaw("CrosshairMove");
        }
        else if (num_player == 2)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Shoot();
            }
            moveInputH = -Input.GetAxis("Vertical2");
            moveInputV = -Input.GetAxis("Horizontal2");
            crosshairMovement = Input.GetAxisRaw("CrosshairMove2");
        }

        rb.velocity = new Vector2(moveInputH * speed, rb.velocity.y);
        rb.velocity = new Vector2(moveInputV * speed, rb.velocity.x);

        crosshair.transform.RotateAround(this.transform.position, Vector3.forward, crosshairMovement * Time.fixedDeltaTime * -crosshairSpeed);
    }

    void Shoot()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        GameObject ball = Instantiate(ballPrefab, crosshair.transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowSpeed;
        Destroy(ball, 1f);
    
    }
}
