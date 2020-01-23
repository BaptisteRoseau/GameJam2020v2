using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonPlay : MonoBehaviour
{
    public GameObject video_credits;
    public GameObject video_fond;
    public GameObject retour;
    public GameObject retour2;
    public GameObject logo;
    public GameObject Command;

    void Start()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(true);
        }
        video_credits.SetActive(false);
        video_fond.SetActive(true);
        retour.SetActive(false);
        Command.SetActive(false);
        retour2.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Advice");
    }

    public void Commandes()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }

        logo.SetActive(true);
        Command.SetActive(true);
        retour2.SetActive(true);
    }

    public void Retour2()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(true);
        }
        Command.SetActive(false);
        retour2.SetActive(false);
        retour.SetActive(false);
    }

    public void Credits()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }
        video_credits.SetActive(true);
        video_fond.SetActive(false);
        retour.SetActive(true);
    }

    public void Retour()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(true);
        }
        video_credits.SetActive(false);
        video_fond.SetActive(true);
        retour.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("QUIT !");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
