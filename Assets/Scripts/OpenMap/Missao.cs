﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missão : MonoBehaviour
{
    public GameObject PapelMissao;
    public string Nome;
    public string Descriçao;
    public string Dificuldade;
    public Text TextoNome;
    public Text TextoDescriçao;
    public Text TextoDificuldade;



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
<<<<<<< HEAD
        TextoDescriçao.text = "" + Descriçao;
        TextoDificuldade.text = "" + Dificuldade;
=======
        TextoDescriçao.text = "" + TextoDescriçao;
        TextoDificuldade.text = "" + TextoDificuldade;
>>>>>>> Salvando cena e modificações
    }
    public void Aceitar()
    {
        PlayerPrefs.SetString("Missao", Nome);
<<<<<<< HEAD

=======
>>>>>>> Salvando cena e modificações
    }


}
