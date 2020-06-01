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
    public GameObject BruxaCombate;
    public GameObject BruxaDialogoPosCombate;
    public GameObject Batloot;
    public GameObject Cogumelo1;
    public GameObject DragaoCombate;
    public GameObject DragaoDialogo;
    public GameObject DragaoDialogoPosComb;
    public GameObject DialogoCidadePosDragao;
    public GameObject DialogoCemiterio;
    public GameObject Berseker;

    public GameObject GhoulDialogo;
    public GameObject Ghoul1;
    public GameObject Ghoul1Dialogo;
    public GameObject Ghoul2;
    public GameObject Ghoul2Dialogo;

    public GameObject Sucubus;
    public GameObject AntSucubus;
    public GameObject PosSucubus;


    public GameObject EventoCidadeVoltando;


    public int cot;





    // Start is called before the first frame update
    void Start()
    {
        Slime1.SetActive(true);
        Slime2.SetActive(true);
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
        if (PlayerPrefs.GetInt("BruxaCombate") == 1)
        {
            BruxaCombate.SetActive(false);
            if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 9)
            {
                BruxaDialogoPosCombate.SetActive(true);
            }

        }
        if (PlayerPrefs.GetInt("Gatos") == 1)
        {
            Gatos.SetActive(false);
            if ( PlayerPrefs.GetInt("DialogoGuilda", 0) ==  8)
            {
                
                    BruxaDialogo.SetActive(true);
                
            }
        }
        if (PlayerPrefs.GetInt("Dragao") ==1)
        {
            DragaoCombate.SetActive(false);
            if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 11)
            {

                DragaoDialogoPosComb.SetActive(true);

            }
        }



    }
    // Update is called once per frame
    void Update()
    {
        cot = PlayerPrefs.GetInt("DialogoGuilda", 0);
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
        if (PlayerPrefs.GetInt("Gatos") == 1)
        {
            Gatos.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Monstro1") == 1)
        {
            Slime1.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Monstro2") == 1)
        {
            Slime2.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Ghoul1") == 1)
        {
            GhoulDialogo.SetActive(false);
            Ghoul1Dialogo.SetActive(true);

            if (PlayerPrefs.GetInt("Ghoul2") == 1)
            {
                Ghoul1.SetActive(false);

            }
        }
        if (PlayerPrefs.GetInt("Ghoul2") == 1)
        {
            Ghoul1.SetActive(false);
            Ghoul2Dialogo.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Sucubus") == 1)
        {
            AntSucubus.SetActive(false);
            PosSucubus.SetActive(true);

        }

        if (PlayerPrefs.GetInt("Bruxa") == 1)
        {
            Bruxa.SetActive(false);

        }
        
        
        if (PlayerPrefs.GetInt("Batloot") == 1)
        {
            Batloot.SetActive(false);


        }
        if (PlayerPrefs.GetInt("Cogumelo1") == 1)
        {
            Cogumelo1.SetActive(false);           
        }
        if (PlayerPrefs.GetInt("Dragao") == 1)
        {
            DragaoCombate.SetActive(false);
        }
        if (PlayerPrefs.GetInt("BruxaCombate") == 1)
        {
            BruxaCombate.SetActive(false);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 9)
        {
            BruxaDialogoPosCombate.SetActive(true);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 10)
        {
            Bruxa.SetActive(false);

            PlayerPrefs.SetInt("Bruxa", 1);
            DragaoDialogo.SetActive(true);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 11 && PlayerPrefs.GetInt("Dragao") == 0)
        {
            DragaoCombate.SetActive(true);
            DragaoDialogoPosComb.SetActive(true);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 12)
        {
            DragaoDialogoPosComb.SetActive(false);
            EventoCidadeVoltando.SetActive(true);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 14)
        {
            DragaoDialogoPosComb.SetActive(false);
            DialogoCemiterio.SetActive(true);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 15)
        {
            Ghoul1.SetActive(true);
            Ghoul2.SetActive(true);
            Berseker.SetActive(true);

        }

        if (PlayerPrefs.GetInt("DialogoGuilda", 0) >= 16)
        {
            Ghoul1.SetActive(false);
            Ghoul2.SetActive(false);
            Berseker.SetActive(false);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 17)
        {
            Sucubus.SetActive(true);

        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 18)
        {
            Application.LoadLevel("Vitoria");
        }
    }
}
