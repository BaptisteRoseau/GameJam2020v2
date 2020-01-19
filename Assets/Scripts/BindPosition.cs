using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindPosition : MonoBehaviour
{
    public Transform Obj;
    public Transform Cam;
    void Update()
    {
        transform.position = Obj.position;
        transform.rotation = Quaternion.Euler(0, Cam.rotation.eulerAngles.y, 0);
    }
}
