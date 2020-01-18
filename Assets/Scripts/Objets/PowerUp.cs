using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public bool isHolded = false; // Whether the object has been picked up by a player or not
    public bool isPickable = true; // Whether the object can be hold by another object or not (ex: weapon (true), buff (false))

    private GameObject holdingPlayer = null; // The player holding the object. Initially set to null
    public Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolded)
        {
            applyEffect(holdingPlayer);
        }
    }

    // Allow a player to pick up the object when touching it
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        Debug.Log("Collisions detected");
        if (!isHolded && otherObj.gameObject.tag == "Player")
        {
            Debug.Log("Not holded yet");
            if (isPickable)
            {
                // For weapons
                Debug.Log("Picking up");
                pickUp(otherObj.gameObject);
            }
            Debug.Log("Holding");
            holdingPlayer = otherObj.gameObject; // Player holds object to constently apply the effect
            collider.enabled = false;
            isHolded = true;
        }
    }
    
    // Attach the object to the player
    void pickUp(GameObject player)
    {
        transform.parent = player.transform;
    }

    // Attach the effect of the object to the player
    public abstract void applyEffect(GameObject player);
}
