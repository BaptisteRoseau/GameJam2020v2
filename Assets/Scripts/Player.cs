using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
    
    public List<GameObject> holdedObjects;
    public Transform child;

    // Player commands
    public string fireCommand = "Fire";
    public string moveHorizontallyCommand = "Horizontal";
    public string moveVerticalyCommand = "Vertical";
    public string crosshairMovementCommand = "CrosshairMove";
    public int playerFactor = 1; // or -1 for player 2

    public int hp;
    public int bleedingThreshold;
    public GameObject bloodStainPrefab;
    public float period;
    private float time = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInputV = playerFactor*Input.GetAxis(moveVerticalyCommand);
        moveInputH = playerFactor*Input.GetAxis(moveHorizontallyCommand);
        crosshairMovement = Input.GetAxisRaw(crosshairMovementCommand);

        rb.velocity = new Vector2(moveInputV * speed, rb.velocity.y);
        rb.velocity = new Vector2(moveInputH * speed, rb.velocity.x);

        gameObject.transform.RotateAround(this.transform.position, Vector3.forward, crosshairMovement * Time.fixedDeltaTime * -crosshairSpeed);

        if(this.hp <= this.bleedingThreshold)
        {
            this.time += Time.fixedDeltaTime;
            if (this.time >= this.period) {
                this.time = 0;
                ElSaignoFamoso stains = Instantiate(bloodStainPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<ElSaignoFamoso>();
            }
        }
    }

    // Attach the object to the player
    public void pickUpObject(GameObject obj)
    {
        // Linking power up 
        obj.transform.parent = gameObject.transform;

        // Adding obj to the holded objects of the 
        holdedObjects.Add(obj);

        // Replacing the sprite on the crosshair
        obj.transform.position = crosshair.transform.position;
        obj.transform.rotation = transform.rotation;

    }

    // Drop the object from the player and destroy it
    public void dropObject(GameObject obj)
    {
        // Droping power up 
        holdedObjects.Remove(obj);
        Destroy(obj);
    }

    public void gotHit() 
    {
        this.hp--;
        if (this.hp <= 0) 
        {
            Destroy(gameObject);
        }
    }

    // Drops all the objects of the current player
    public void dropAllObject()
    {
        foreach(GameObject obj in holdedObjects)
        {
            dropObject(obj);
        }
    }
}
