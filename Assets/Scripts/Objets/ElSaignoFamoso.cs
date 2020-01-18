using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElSaignoFamoso : MonoBehaviour
{
    public float lifetime;
    private float lifeLength = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.lifeLength += Time.fixedDeltaTime;
        if (lifeLength > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
