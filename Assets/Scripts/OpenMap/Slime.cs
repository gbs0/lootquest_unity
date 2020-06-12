using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int Monstros;
    public string NextCenaName;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        {
           

            if (Monstros == 1)
            {
                PlayerPrefs.SetInt("indexSpam", 1);

                PlayerPrefs.SetInt("Monstro1", 1);

                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");

            }
            if (Monstros == 2)
            {
                PlayerPrefs.SetInt("Monstro2", 1);
                PlayerPrefs.SetInt("indexSpam", 3);

                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 3)
            {
                PlayerPrefs.SetInt("indexSpam", 4);
                PlayerPrefs.SetInt("Gatos",1);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 4)
            {
                PlayerPrefs.SetInt("indexSpam", 4);
                PlayerPrefs.SetInt("BruxaCombate", 1);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 5)
            {
                PlayerPrefs.SetInt("indexSpam", 4);
                PlayerPrefs.SetInt("Cogumelo1", 1);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 6)
            {
                PlayerPrefs.SetInt("indexSpam", 5);
                PlayerPrefs.SetInt("Dragao", 1);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }

            if (Monstros == 10)
            {
                PlayerPrefs.SetInt("indexSpam", 5);
                PlayerPrefs.SetInt("Ghoul1", 1);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 11)
            {
                PlayerPrefs.SetInt("indexSpam", 5);
                PlayerPrefs.SetInt("Ghoul2", 1);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 12)
            {
                PlayerPrefs.SetInt("indexSpam", 5);
                PlayerPrefs.SetInt("Beserker", 1);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 13)
            {
                PlayerPrefs.SetInt("indexSpam", 5);
                PlayerPrefs.SetInt("Sucubus", 1);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
            if (Monstros == 14)
            {
                PlayerPrefs.SetInt("indexSpam", 5);
                PlayerPrefs.SetInt("indexSpam", Monstros);
                PlayerPrefs.SetString("_sceneName", NextCenaName);
                Application.LoadLevel("LoadingScene");
            }
        }
    }
}
