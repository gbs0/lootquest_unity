using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{

    private string NextCenaName;
    public string NovoJogo;
    public float timeStart;
    public bool time = false;
    // Start is called before the first frame update
    void Start()
    {
        NextCenaName = PlayerPrefs.GetString("Scene");
    }

// Update is called once per frame
void Update()
    {
        if (time == true)
        {
            timeStart += Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D theCollision) // C#, type first, name in second
    {
        if (theCollision.gameObject.tag == "Player")
        {
            NextScene();
        }
    }

    public void NextScene()
    {
        PlayerPrefs.SetString("Scene", NextCenaName);
        LoadingSisten.LoadLevel("LoadingScene");
    }
    public void IntroNextScene()
    {
        
        PlayerPrefs.SetString("Scene", NextCenaName);
        LoadingSisten.LoadLevel("LoadingScene");
        
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Int", 0);
        Persistence.ResetGame();
        PlayerPrefs.SetInt("DialogoGuilda", 0);
        PlayerPrefs.SetString("Scene", NovoJogo);
        PlayerPrefs.DeleteAll();
        LoadingSisten.LoadLevel(NovoJogo);

    }

    public void BackMenu()
    {
        PlayerPrefs.SetString("Scene", "MenuInicial");
        LoadingSisten.LoadLevel("MenuInicial");
        Time.timeScale = 1;
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }

}
