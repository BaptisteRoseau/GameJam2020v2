using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRender : MonoBehaviour
{
    public string cameraDisabledName = "null";
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void OnWillRenderObject()
    {
        if (Camera.current.name == cameraDisabledName)
        {
            //gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.SetActive(false);
        }
        else
        {
            //gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.SetActive(true);
        }
        Debug.Log(Camera.current.name);
    }
}
