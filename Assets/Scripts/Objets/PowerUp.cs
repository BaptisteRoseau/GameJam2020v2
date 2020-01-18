using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public bool isHolded = false; // Whether the object has been picked up by a player or not
    public bool isPickable = true; // Whether the object can be hold by another object or not (ex: weapon (true), buff (false))

    public Collider2D collider;
    
    private GameObject holdingPlayer = null; // The player holding the object. Initially set to null

    // Utils to change the sprite
    public Sprite spriteTop  = null; // Sprite view from top
    public Sprite spriteSide = null; // Sprite view from side
    private bool viewFromTop = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initializing sprite to spriteSide
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteSide;
        viewFromTop = false;

        // Default name of PowerUp object (should be changed for other subclasses)
        gameObject.name = "PowerUp";
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
        if (!isHolded && otherObj.gameObject.tag == "Player")
        {
            if (isPickable)
            {
                // For weapons
                otherObj.gameObject.GetComponent<Player>().pickUpObject(gameObject);
            }
            holdingPlayer = otherObj.gameObject; // Player holds object to constently apply the effect
            collider.enabled = false;
            isHolded = true;
            changeSprite();
        }
    }

    // Attach the effect of the object to the player
    public abstract void applyEffect(GameObject player);

    // Changes the sprite of the PowerUp
    public void changeSprite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (viewFromTop)
        {
            Debug.Log("Changing sprite from top to side view");
            spriteRenderer.sprite = spriteSide;
            viewFromTop = false;
        }
        else
        {
            Debug.Log("Changing sprite from side to top view");
            spriteRenderer.sprite = spriteTop;
            viewFromTop = true;
        }
    }

    // Comparison is done on the name of the PowerUp
    public bool Equals(PowerUp other)
    {
        if (other == null) return false;
        return (this.name.Equals(other.name));
    }
}
