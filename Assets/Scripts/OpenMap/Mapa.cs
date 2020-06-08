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

    public Rigidbody2D PlayerRigi;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigi = Player.GetComponent<Rigidbody2D>();

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
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public void Floresta()
    {
        Player.transform.position = Locais[1].transform.position;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation; 
    }
    public void Caverna()
    {
        Player.transform.position = Locais[2].transform.position;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation; 
    }
    public void Cemiterio()
    {
        Player.transform.position = Locais[3].transform.position;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation; 
    }
    public void Deserto()
    {
        Player.transform.position = Locais[4].transform.position;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation; 
    }
}
