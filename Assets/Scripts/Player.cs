using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float crosshairMovement = 0f;
    public GameObject crosshair;

    public Rigidbody2D rb;
    public Commands command;

    public GameObject ballPrefab;
    public float arrowSpeed;
    public int num_player;
    
    public Animator player_animator;
    public List<GameObject> holdedObjects;
    public Transform child;
    public GameObject center;
    
    public int hp;
    public int bleedingThreshold;
    public GameObject bloodStainPrefab;
    public float period;
    private float time = 0;

    public bool firstGame = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Updating animator
        player_animator.SetBool("IsRunning", command.isMoving());

        if (Input.GetAxis(command.keyboardMoveHorizontallyCommand) < 0)
        {
            player_animator.SetFloat("speedX", 0.1f);
        } else if (Input.GetAxis(command.keyboardMoveHorizontallyCommand) > 0)
        {
            player_animator.SetFloat("speedX", -0.1f);
        }

        if (Input.GetAxis(command.keyboardMoveVerticalyCommand) < 0)
        {
            player_animator.SetFloat("speedY", -0.1f);
        }
        else if (Input.GetAxis(command.keyboardMoveVerticalyCommand) > 0)
        {
            player_animator.SetFloat("speedY", 0.1f);
        }


        if (this.hp <= this.bleedingThreshold)
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
        FindObjectOfType<audioManager>().Play("item");
        // Deleting previous instance of object if already present
        if (containsName(obj.name))
        {
            GameObject previousObject = holdedObjects.Find(r => r.name == obj.name);
            dropObject(previousObject);
            Debug.Log("Found and removed previous " + obj.name);
        }


        // Linking power up 
        obj.transform.parent = center.transform;

        // Adding obj to the holded objects of the 
        holdedObjects.Add(obj);

        // Replacing the sprite on the crosshair
        obj.transform.position = crosshair.transform.position;
        obj.transform.rotation = crosshair.transform.rotation;

        // Some debugg
        holdedObjects.ForEach(Debug.Log);
    }

    bool containsName(string s)
    {
        foreach(GameObject c in holdedObjects)
        {
            if(c.name == s)
                return true;
        }
        return false;
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
            if(firstGame && GameObject.FindWithTag("UI") != null && GameObject.FindWithTag("UI").GetComponent<rules>() != null){
                GameObject.FindWithTag("UI").GetComponent<rules>().playerHited(gameObject);
            }
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
