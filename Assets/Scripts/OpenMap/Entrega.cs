using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrega : MonoBehaviour
{
    public GameObject BemVindo;
    public GameObject Quadro;
    public GameObject Missao;
    public GameObject Entregra;
    public GameObject Portal;
    public GameObject DragonRetrun;
    public GameObject Irmaos;
    public GameObject HistoriaAria;

    public int valor;



    // Start is called before the first frame update
    void Start()
    {
        BemVindo.SetActive(false);
        Quadro.SetActive(false);
        Missao.SetActive(false);
        Entregra.SetActive(false);
        Portal.SetActive(false);





    }

    // Update is called once per frame
    void Update()
    {
        valor = PlayerPrefs.GetInt("DialogoGuilda");

        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 0)
        {
            BemVindo.SetActive(true);
            Quadro.SetActive(false);
            Missao.SetActive(false);
            Entregra.SetActive(false);
            Portal.SetActive(false);

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
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 13)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(false);
            Missao.SetActive(false);
            Entregra.SetActive(false);
            DragonRetrun.SetActive(true);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 16)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(false);
            Missao.SetActive(false);
            Entregra.SetActive(false);
            DragonRetrun.SetActive(false);
            Irmaos.SetActive(true);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 17)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(false);
            Missao.SetActive(false);
            Entregra.SetActive(false);
            DragonRetrun.SetActive(false);
            Irmaos.SetActive(false);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 18)
        {
            BemVindo.SetActive(false);
            Quadro.SetActive(false);
            Missao.SetActive(false);
            Entregra.SetActive(false);
            DragonRetrun.SetActive(false);
            Irmaos.SetActive(false);
            HistoriaAria.SetActive(true);

        }
    }
}
