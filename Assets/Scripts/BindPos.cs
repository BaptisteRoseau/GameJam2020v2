using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindPos : MonoBehaviour
{
    public Transform Obj;
    public Transform Cam;
    public float offsetX = 0;
    public float offsetY = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position = Obj.position + new Vector3(offsetX, offsetY, 0.0f);
        transform.rotation = Quaternion.Euler(0, Cam.rotation.eulerAngles.y, 0);
    }
}
