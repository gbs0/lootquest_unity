﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagens : MonoBehaviour
{
    public GameObject Bruxa;
    public GameObject Maga;
    public GameObject Berseker;
    public GameObject Ninja;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 10)
        {
            PlayerPrefs.SetInt("Bruxa", 1);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 1)
        {
            PlayerPrefs.SetInt("Maga", 1);
        }
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 16)
        {
            PlayerPrefs.SetInt("Berseker", 1);
        }

        if (PlayerPrefs.GetInt("Bruxa", 0) == 1)
        {
            Bruxa.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Maga", 0) == 1)
        {
            Maga.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Berseker", 0) == 1)
        {
            Berseker.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Ninja", 0) == 1)
        {
            Ninja.SetActive(true);

        }
    }
}
