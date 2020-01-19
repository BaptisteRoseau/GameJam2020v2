using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmenusound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<audioManager>().Play("mainmenu");
    }
}
