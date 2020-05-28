using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject Portal;
    public GameObject BatalhaGatos;
    public GameObject DialogoBruxa;

    public int mon;
    public int NUMERO;
    public GameObject missao0;
    public GameObject missao1;
    public GameObject missao2;
    public GameObject missao3;
    public GameObject missao4;
    public GameObject missao5;
    public GameObject missao6;
    public GameObject missao7;
    public GameObject missao8;
    public GameObject missao9;
    public GameObject missao10;

    public GameObject BruxaCombate;
    public GameObject DragaoCombate;


    // Start is called before the first frame update
    void Start()
    {
       
       

    }

    // Update is called once per frame
    void Update()
    {
        
        
        mon = PlayerPrefs.GetInt("ConversaMonstros");


        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 0)
        {

            missao0.SetActive(true);
            missao1.SetActive(false);

        }


        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 1)
        {
            missao0.SetActive(false);
            missao1.SetActive(true);


        }
        
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 4)
        {
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(true);



        }
        if (PlayerPrefs.GetInt("DialogoGuilda") == 4)
        {
            if (PlayerPrefs.GetInt("Monstro1") == 1 )
            {
                PlayerPrefs.SetInt("DialogoGuilda", 5);


            }

        }

        if (PlayerPrefs.GetInt("DialogoGuilda") == 5)
        {
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(true);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 6)
        {
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(false);

            missao4.SetActive(true);

            Portal.SetActive(true);
        }

        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 7)
        {
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(false);
            missao4.SetActive(false);
            Portal.SetActive(false);
            missao5.SetActive(true);
            PlayerPrefs.SetInt("ConversaMonstros", 2);
            PlayerPrefs.SetInt("Gatos", 0);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 8)
        {
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(false);
            missao4.SetActive(false);
            Portal.SetActive(false);
            missao5.SetActive(false);
            BatalhaGatos.SetActive(true);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 9)
        {
                DialogoBruxa.SetActive(false);

            BruxaCombate.SetActive(true);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 10)
        {

            BruxaCombate.SetActive(false);
            PlayerPrefs.SetInt("Bruxa", 1);
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(false);
            missao4.SetActive(false);
            Portal.SetActive(false);
            missao5.SetActive(false);
            missao6.SetActive(true);
            PlayerPrefs.SetInt("Batloot",1);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 11)
        {

            BruxaCombate.SetActive(false);
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(false);
            missao4.SetActive(false);
            Portal.SetActive(false);
            missao5.SetActive(false);
            missao6.SetActive(true);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 12)
        {

            BruxaCombate.SetActive(false);
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(false);
            missao4.SetActive(false);
            Portal.SetActive(false);
            missao5.SetActive(false);
            missao6.SetActive(false);
            missao7.SetActive(true);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 13)
        {     
            missao7.SetActive(true);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 14)
        {
            missao8.SetActive(true);
        }
    }
}
