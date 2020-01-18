using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : PowerUp
{
    //public GameObject crosshair;
    public GameObject belettePrefab;
    public float arrowSpeed;
    public int ammoLeft = 3;
    public float shotDelayTimeSec = 0.5f; // seconds
    public float nextShotTime = 0.0f; // seconds



    // Shoot a ball from the object
    public override void applyEffect(GameObject player)
    {
        if (Input.GetButtonDown(player.GetComponent<Player>().fireCommand))
        {
            if (ammoLeft > 0 && Time.time > nextShotTime)
            {
                Player playerComponenent = player.GetComponent<Player>();
                GameObject crosshair = playerComponenent.crosshair;
                Vector2 shootingDirection = crosshair.transform.position - player.transform.position;
                shootingDirection.Normalize();

                Belette ball = Instantiate(belettePrefab, crosshair.transform.position, Quaternion.identity).GetComponent<Belette>();
                ball.fromPlayer = playerComponenent.num_player;
                ball.transform.rotation = playerComponenent.transform.rotation;
                ball.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowSpeed;

                ammoLeft--;
                Debug.Log(ammoLeft);

                nextShotTime = Time.time + shotDelayTimeSec;

                Destroy(ball, 1f);
            }
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shotDelayTimeSec);
        //canShoot = ammoLeft > 0 ? true : false;
    }
}
