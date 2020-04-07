using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrega : MonoBehaviour
{
    public GameObject Dialogo1;
    public int M;
    public GameObject Dialogo2;

    // Start is called before the first frame update
    void Start()
    {

        BemVindo.SetActive(false);
        Quadro.SetActive(false);
        Missao.SetActive(false);
        Entregra.SetActive(false);
        Portal.SetActive(false);


        Dialogo1.SetActive(false);
        Dialogo2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Missao",0) == 0)
        {
            Dialogo1.SetActive(true);

        }

       
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 1)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(true);
            Missao.SetActive(false);
            Entregra.SetActive(false);
            Portal.SetActive(false);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 2)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(false);
            Missao.SetActive(true);
            Entregra.SetActive(false);
            Portal.SetActive(false);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 3)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(false);
            Missao.SetActive(false);
            Entregra.SetActive(false);
            Portal.SetActive(false);
            

        }
        if (PlayerPrefs.GetInt("DialogoGuilda") == 5)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(false);
            Missao.SetActive(false);
            Entregra.SetActive(true);
            Portal.SetActive(false);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 6)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(false);
            Missao.SetActive(false);
            Entregra.SetActive(false);
            Portal.SetActive(true);
            Application.LoadLevel("Vitoria");


        }
    }
}
