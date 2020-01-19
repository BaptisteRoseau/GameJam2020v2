using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonPlay : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT !");
        Application.Quit(); 
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
