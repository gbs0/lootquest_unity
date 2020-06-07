using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPlayerHp : MonoBehaviour
{
    public string NextCenaName;

    public float totalHP;
    public float PlayerHealth;
    public Image LifeBar;
    float waitForSec = 5.0f;
    
    public ParticleSystem particulaAura;
     
    
    void Start()
    {
        if (PlayerPrefs.GetInt("SlimceCrown", 0) >= 2)
        {
            totalHP = totalHP + 50;
        }
        if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 2)
        {
            totalHP = totalHP + 50;
        }
        PlayerHealth = totalHP;
        particulaAura.Emit(1);
    }

    private void Update()
    {
        
    }

    public void LifeCheck(float dam)
    {
        
        PlayerHealth -= dam;
        LifeBar.fillAmount = PlayerHealth / totalHP;
        

    }
}
