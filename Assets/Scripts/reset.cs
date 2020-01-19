using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Player1Score", 0);
        PlayerPrefs.SetInt("Player2Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
