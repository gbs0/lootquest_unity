﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objetivo : MonoBehaviour
{
    public GameObject PapelMissao;
    public string Nome;
    public string Descriçao;
    public string Dificuldade;
    public Text TextoNome;
    public Text TextoDescriçao;
    public Text TextoDificuldade;
<<<<<<< HEAD
    public int monstros;
=======

>>>>>>> Salvando cena e modificações


    // Start is called before the first frame update
    void Start()
    {
        PapelMissao.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void Escolher()
    {
        PapelMissao.SetActive(true);
        TextoNome.text = "" + Nome;
        TextoDescriçao.text = "" + TextoDescriçao;
        TextoDificuldade.text = "" + TextoDificuldade;
    }
    public void Aceitar()
    {
        PlayerPrefs.SetString("Missao", Nome);
<<<<<<< HEAD
        PlayerPrefs.SetInt("ConversaMonstros", monstros);
        PlayerPrefs.SetInt("DialogoGuilda", 4);

=======
>>>>>>> Salvando cena e modificações
    }


}
