using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if(PlayerPrefs.GetFloat("Tutorial")<1)
            Time.timeScale = 0;
        else
        {
            EndTutorial();
        }
        
    }

    public void EndTutorial()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("Tutorial",1);
        Persistence.SaveData();
        RoundManager.Tutorial = true;
    }
    
}
