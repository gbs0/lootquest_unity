using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMonstros : MonoBehaviour
{
    public GameObject BruxaDialogo;
    public GameObject Slime1;
    public GameObject Slime2;
    public GameObject Gatos;
    public GameObject Bruxa;
    public int g;

    // Start is called before the first frame update
    void Start()
    {
        Slime1.SetActive(false);
        Slime2.SetActive(false);
        Gatos.SetActive(false);
        Bruxa.SetActive(false);

        if (PlayerPrefs.GetInt("ConversaMonstros") == 1)
        {
            if (PlayerPrefs.GetInt("Monstro1") == 0)
            {
                Slime1.SetActive(true);

            }
            if (PlayerPrefs.GetInt("Monstro2") == 0)
            {
                Slime2.SetActive(true);

            }

            Gatos.SetActive(false);
            Bruxa.SetActive(false);
        }
       
    }
    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("ConversaMonstros") == 2)
        {
            if (PlayerPrefs.GetInt("Gatos") == 0)
            {
                Gatos.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Bruxa") == 0)
            {
                Bruxa.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Monstro1") == 1)
        {
            Slime1.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Monstro2") == 1)
        {
            Slime2.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Gatos") == 1)
        {
            Gatos.SetActive(false);
            BruxaDialogo.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Bruxa") == 1)
        {
            Bruxa.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Monstro1") == 1 )
        {
            PlayerPrefs.SetInt("DialogoGuilda", 5);
        }
    }
}
