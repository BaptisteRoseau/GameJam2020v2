using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigMenu : MonoBehaviour
{
    // Player commands
    public string menuCommand = "Menu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(menuCommand))
        {
            Debug.Log("jjkh");
        }
    }
}
