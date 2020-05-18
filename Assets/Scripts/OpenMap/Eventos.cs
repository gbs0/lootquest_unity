using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    public GameObject MorteRainha;
    public bool evento1 = false;
    // Start is called before the first frame update
    void Start()
    {
        MorteRainha.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("DialogoGuilda") == 5   )
        {
            if (evento1 == false)
            {
                MorteRainha.SetActive(true);
                evento1 = true;
            }
        }
        if (PlayerPrefs.GetInt("DialogoGuilda") > 5)
        {

            MorteRainha.SetActive(false);
             evento1 = true;


}
    }
}
