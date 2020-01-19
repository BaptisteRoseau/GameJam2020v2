using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoScript : MonoBehaviour
{

    private GameObject score ;
    private GameObject moon ;

    // Start is called before the first frame update
    void Start()
    {
        score =  GameObject.FindGameObjectWithTag("scoresUi");
        score.SetActive(false);
        moon = GameObject.FindGameObjectWithTag("moonUi");
        moon.SetActive(false);
        Time.timeScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void run()
    {
        score.SetActive(true);
        moon.SetActive(true);
        Time.timeScale = 1;

        gameObject.SetActive(false);
        
    }
}
