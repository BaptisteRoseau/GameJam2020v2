using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : PowerUp
{
    //public GameObject crosshair;
    public GameObject belettePrefab;
    public float arrowSpeed;
    

    // Shoot a ball from the object
    public override void applyEffect(GameObject player)
    {
        if (Input.GetButtonDown(player.GetComponent<Player>().fireCommand))
        {
            Player playerComponenent = player.GetComponent<Player>();
            GameObject crosshair = playerComponenent.crosshair;
            Vector2 shootingDirection = crosshair.transform.position - player.transform.position;
            shootingDirection.Normalize();

            Belette ball = Instantiate(belettePrefab, crosshair.transform.position, Quaternion.identity).GetComponent<Belette>();
            ball.fromPlayer = playerComponenent.num_player;
            ball.transform.rotation = playerComponenent.transform.rotation;
            ball.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowSpeed;
            Destroy(ball, 1f);
        }
    }
}
