using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucao : MonoBehaviour
{
    public GameObject Instru;
    public GameObject Instru1;
    public GameObject Instru2;
    public int IntNumero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Instru == false ) 

        {
            if (IntNumero == 1)
            {
                PlayerPrefs.SetInt("Int", 1);

            }
            if (IntNumero == 2)
            {
                PlayerPrefs.SetInt("Int2", 1);

            }
        }
        if (PlayerPrefs.GetInt("Int") == 1)

        {
            Instru.SetActive(false);

        }
        if (PlayerPrefs.GetInt("Int2") == 1)

        {
            Instru2.SetActive(false);

        }

    }
    public void fechar()
    {
        if (IntNumero == 1)
        {
            PlayerPrefs.SetInt("Int", 1);
        }
        if (IntNumero == 2)
        {
            PlayerPrefs.SetInt("Int2", 1);
        }
        Instru.SetActive(false);

    }
    public void Proxima()
    {
        Instru1.SetActive(false);
        Instru2.SetActive(true);

    }
}
