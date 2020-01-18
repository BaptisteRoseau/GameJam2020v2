using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : PowerUp
{
    //public GameObject crosshair;
    public GameObject ballPrefab; // TODO: bullet prefab (destroy on collision)
    public float arrowSpeed;
    

    // Shoot a ball from the object
    public override void applyEffect(GameObject player)
    {
        if (Input.GetButtonDown(player.GetComponent<Player>().fireCommand))
        {
            GameObject crosshair = player.GetComponent<Player>().crosshair;
            Vector2 shootingDirection = crosshair.transform.position - player.transform.position;
            shootingDirection.Normalize();

            GameObject ball = Instantiate(ballPrefab, crosshair.transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowSpeed;
            Destroy(ball, 1f);
        }
    }
}
