using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject Portal;
    public GameObject BatalhaGatos;
    public int mon;
    public int NUMERO;
    public GameObject missao0;
    public GameObject missao1;
    public GameObject missao2;
    public GameObject missao3;
    public GameObject missao4;
    public GameObject missao5;


    // Start is called before the first frame update
    void Start()
    {
       
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            NUMERO = PlayerPrefs.GetInt("ConversaMonstros", 0) + 1;
            PlayerPrefs.SetInt("ConversaMonstros", NUMERO);
        }
        
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
            PlayerPrefs.SetInt("Gatos", 0);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 9)
        {
            
            Application.LoadLevel("Vitoria");

        }
    }
}
