using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPlayerHp : MonoBehaviour
{
    public string NextCenaName;

   
    public float PlayerHealth;
    public Image LifeBar;
    float waitForSec = 5.0f;
    
    public ParticleSystem particulaAura;
     
    
    void Start()
    {
        PlayerHealth = 100;
        particulaAura.Emit(1);
    }

    private void Update()
    {
        
    }

    public void LifeCheck(float dam)
    {
        // Debug.LogError("cheguei aq");
        // Debug.LogError(dam);
        PlayerHealth -= dam;
        LifeBar.fillAmount = PlayerHealth / 100;
        // Debug.LogError(PlayerHealth);

    }
}
