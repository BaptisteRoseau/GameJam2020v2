using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutoScript : MonoBehaviour
{

    private GameObject score ;
    private GameObject moon ;
    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void run()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
