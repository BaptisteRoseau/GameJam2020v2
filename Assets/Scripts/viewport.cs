using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewport : MonoBehaviour
{
    public Camera cam;
    public Camera cam2;

    void Start()
    {
        cam.rect = new Rect(0, 0, 0.5f, 1f);
        cam2.rect = new Rect(0.5f, 0, 0.5f, 1);
    }
}
