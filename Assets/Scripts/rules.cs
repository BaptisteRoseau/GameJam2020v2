using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rules : MonoBehaviour
{

    public GameObject moon;
    public GameObject player1;
    public GameObject player2;

    public GameObject Player1Score;
    public GameObject Player2Score;

    public GameObject Ending;
    private int scoreMax = 3;

    // Start is called before the first frame update
    void Start()
    {
        int sp1 = PlayerPrefs.GetInt("Player1Score");
        Player1Score.GetComponent<Text>().text = sp1.ToString();
        int sp2 =  PlayerPrefs.GetInt("Player2Score");
        Player2Score.GetComponent<Text>().text = sp2.ToString();
   
        if(sp1 >= scoreMax || sp2 >= scoreMax)
        {
            Time.timeScale = 0;
            int win = 1;
            int lose = 2;
            if(sp1 < scoreMax)
            {
                win = 2;
                lose = 1;
            }

            Ending.SetActive(true);
           GameObject.FindGameObjectWithTag("winText").GetComponent<Text>().text = "GOOD Game ! Player "+ win +" WIN !";
           GameObject.FindWithTag("loseText").GetComponent<Text>().text = "Player "+ lose +" You are DEAD";

        }
    }

    // Update is called once per frame
    void Update()
    {
     if(moon.GetComponent<RectTransform>().pivot.x <= -2.7f)
        {
            if(player1.GetComponent<Player>().hp > player2.GetComponent<Player>().hp)
            {
                PlayerPrefs.SetInt("Player1Score", PlayerPrefs.GetInt("Player1Score") + 1);
            }else if (player1.GetComponent<Player>().hp < player2.GetComponent<Player>().hp)
            {
                PlayerPrefs.SetInt("Player2Score", PlayerPrefs.GetInt("Player2Score") + 1);
            }
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void playerHited(GameObject yes)
    {
        if(player1 != null && player2 != null)
        {
            if(yes.GetComponent<Player>().num_player == 1)
            {
                PlayerPrefs.SetInt("Player2Score", PlayerPrefs.GetInt("Player2Score") + 1);
            }else if (yes.GetComponent<Player>().num_player == 2)
            {
                PlayerPrefs.SetInt("Player1Score", PlayerPrefs.GetInt("Player1Score") + 1);
            }
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void reset()
    {
        Time.timeScale = 1;
        Ending.SetActive(false);
        PlayerPrefs.SetInt("Player1Score", 0);
        PlayerPrefs.SetInt("Player2Score", 0);
        SceneManager.LoadScene("SampleScene");
    }


    public void MenuButton()
    {
        Time.timeScale = 1;
        Ending.SetActive(false);
        PlayerPrefs.SetInt("Player1Score", 0);
        PlayerPrefs.SetInt("Player2Score", 0);
        SceneManager.LoadScene("Menu");
    }

}
