﻿using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Battle;
using UnityEngine;
using UnityEngine.UI;

public class PassiveManager : MonoBehaviour
{
    private PlayerStats _player;
    public Button closeButton;
    public GameObject SpeelsPainel;
    public List<GameObject> passivePainel;
    private int i, l;
    private LootBoxPainel LBpainel;
    private Transform lastParent;
    private GameObject selectLoot;
    public Loot[] loots;
    public Passive Passiva;
    public bool FirstTime = true;
    public GameObject TutorialPainel;

    private void Start()
    {
        closeButton.onClick.AddListener(ClosePainel);
        LBpainel = FindObjectOfType<LootBoxPainel>();
    }

    private void ClosePainel()
    {
        FirstTime = false;
        if (selectLoot)
        {
            selectLoot.transform.parent = lastParent;
            selectLoot.transform.localScale = Vector3.one;
        }

        passivePainel[i].SetActive(false);
        Passiva.CleanPainel();
        LBpainel.Add();

        foreach (var loot in loots)
        {
            loot.botao.onClick.RemoveListener(loot.Chose);
            loot.botao.onClick.AddListener(loot.SpendLoot);
        }
    }

    public void OpenPainel()
    {
        
            if (FirstTime)
            {
                TutorialPainel.SetActive(true);
            }
            loots = FindObjectsOfType<Loot>();
            
                _player = RoundManager._allCaracters.Peek().gameObject.GetComponent<PlayerStats>();
                i = _player.passivaIndex;
                passivePainel[i].SetActive(true);
                foreach (var loot in loots)
                {
                
                    loot.botao.onClick.RemoveListener(loot.SpendLoot);
                    loot.botao.onClick.AddListener(loot.Chose);
                }
            
        
        
        
    }


    public void SelectLoot(GameObject o)
    {
        selectLoot = o;
        lastParent = o.transform.parent;
        o.transform.SetParent(passivePainel[i].GetComponent<Passive>().ChoseTransfom.transform, false); 
        o.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(101,-82);
        Passiva.CheckChange(o);
    }

    public void ChoseOne(Loot l)
    {
        
        var lootstats = selectLoot.GetComponent<Loot>();
        lootstats.SetValue(true, l._rarit, l.TypeLoot);
        ClosePainel();
    }
}
