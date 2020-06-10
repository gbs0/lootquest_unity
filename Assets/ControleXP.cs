﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ControleXP : MonoBehaviour
{
    float m_XP;

    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        
        m_XP = PlayerPrefs.GetFloat("CurrentXP");
        SetXP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetXP()
    {
        if(m_XP < 200)
        {
            img.fillAmount = m_XP / 200;
            return;
        }

        m_XP = 0;
        

    }
}
