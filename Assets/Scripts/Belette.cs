using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belette : MonoBehaviour
{
    public int fromPlayer = -1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kill player if it is not his own bullet. Oh my bad, his own Belette.
        if (collision.gameObject.tag == "Player"
            && fromPlayer != collision.gameObject.GetComponent<Player>().num_player)
        {
            collision.gameObject.GetComponent<Player>().gotHit();
        }
        // else if (collision.gameObject.tag == "wall")
        Destroy(gameObject);
    }
}
