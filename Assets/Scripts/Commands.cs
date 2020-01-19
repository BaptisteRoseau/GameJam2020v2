using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Commands : MonoBehaviour
{
    public float speed;
    public float crosshairSpeed;
    public int playerFactor = 1; // or -1 for player 2
    
    // Type of input
    public bool isKeybord = true;
    public bool isJoystick = false;

    public GameObject player;
    public GameObject player_cpy;

    // Command binding for the current player
    public string keyboardFireCommand              = "Fire";
    public string keyboardMoveHorizontallyCommand = "Horizontal";
    public string keyboardMoveVerticalyCommand = "Vertical";
    public string keyboardCrosshairMovementCommand = "CrosshairMove";
    public string keyboardGamePauseCommand = "escape";

    public string joystickFireCommand = "X";
    public string joystickGamePauseCommand = "escape";

    // PRivate attributes
    private Rigidbody2D rb;
    private Rigidbody2D rb_cpy;
    private float moveInputH;
    private float moveInputV;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Player>().GetComponent<Rigidbody2D>();
        rb_cpy = player_cpy.GetComponent<Player>().GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (isKeybord)
        {
            moveKeyboard();
            rotateKeyboard();
        }
        else if (isJoystick)
        {
            moveJoystick();
            rotateJoystick();
        }
        else
        {
            Debug.Log("Invalid type of command");
        }
    }

    // KEYBOARD INPUTS
    public void moveKeyboard()
    {
        moveInputV = playerFactor * Input.GetAxis(keyboardMoveVerticalyCommand);
        moveInputH = playerFactor * Input.GetAxis(keyboardMoveHorizontallyCommand);
        rb.velocity = new Vector2(moveInputV * speed, rb.velocity.y);
        rb.velocity = new Vector2(moveInputH * speed, rb.velocity.x);

        rb_cpy.velocity = new Vector2(moveInputV * speed, rb_cpy.velocity.y);
        rb_cpy.velocity = new Vector2(moveInputH * speed, rb_cpy.velocity.x);
    }
     
    public void rotateKeyboard()
    {
        player.GetComponent<Player>().center.transform.RotateAround(player.transform.position, Vector3.forward, Input.GetAxisRaw(keyboardCrosshairMovementCommand) * Time.fixedDeltaTime * -crosshairSpeed);
        player_cpy.GetComponent<Player>().center.transform.RotateAround(player_cpy.transform.position, Vector3.forward, Input.GetAxisRaw(keyboardCrosshairMovementCommand) * Time.fixedDeltaTime * -crosshairSpeed);
    }


    // JOYSTICK INPUTS
    public void moveJoystick()
    {
        moveInputV = playerFactor * Gamepad.current.leftStick.y.ReadValue();//Input.GetAxis("HorizontalJoystick");
        moveInputH = playerFactor * Gamepad.current.leftStick.x.ReadValue();

        rb.velocity = new Vector2(moveInputV * speed, rb.velocity.y);
        rb.velocity = new Vector2(moveInputH * speed, rb.velocity.x);

        rb_cpy.velocity = new Vector2(moveInputV * speed, rb_cpy.velocity.y);
        rb_cpy.velocity = new Vector2(moveInputH * speed, rb_cpy.velocity.x);
    }

    public void rotateJoystick()
    {
        Vector3 lookDirection = new Vector3(Gamepad.current.rightStick.x.ReadValue(), Gamepad.current.rightStick.y.ReadValue(), 0.0f);
        if (lookDirection.x != 0 && lookDirection.y != 0)
        {
            Debug.Log(lookDirection);
            player.GetComponent<Player>().transform.rotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.back);
            player_cpy.GetComponent<Player>().transform.rotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.back);
        }
    }

    // MISC
    public bool isMoving()
    {
        return moveInputH != 0 || moveInputV != 0;
    }
}
