using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatEather : MonoBehaviour
{
    public float TourneSpide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         gameObject.transform.RotateAround(this.transform.position, Vector3.forward, Time.fixedDeltaTime * TourneSpide);
    }
}
