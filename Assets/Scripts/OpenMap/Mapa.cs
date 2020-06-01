using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    public GameObject[] Locais;
    public GameObject Player;
    public GameObject FloresT;
    public GameObject Cave;
    public GameObject Cemitery;
    public GameObject Desert;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Floresta", 0) == 1)
        {
            FloresT.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Cave", 0) == 1)
        {
            Cave.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Cemitery", 0) == 1)
        {
            Cemitery.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Desert", 0) == 1)
        {
            Desert.SetActive(true);

        }
    }
    public void Cidade()
    {
        Player.transform.position = Locais[0].transform.position;
    }
    public void Floresta()
    {
        Player.transform.position = Locais[1].transform.position;
    }
    public void Caverna()
    {
        Player.transform.position = Locais[2].transform.position;
    }
    public void Cemiterio()
    {
        Player.transform.position = Locais[3].transform.position;
    }
    public void Deserto()
    {
        Player.transform.position = Locais[4].transform.position;
    }
}
