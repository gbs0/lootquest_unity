﻿using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Battle
{
    public class LootBox: MonoBehaviour
    {
        Animator animator;
        public float timeStart;
        public bool tempo = false;
        private TaticsMove player;      
        public GameObject PainelLootBox;
        public GameObject PrefabLoots;

        public GameObject inventorySlot;
        
        private void Awake()
        {
            //cache the animator component
            animator = GetComponent<Animator>();
            inventorySlot = FindObjectOfType<inventorySlotParent>().gameObject;
        }
        void Start()
        {
            PainelLootBox = FindObjectOfType<LootBoxPainel>().gameObject;
            transform.GetComponent<Button>().onClick.AddListener(RunLoot);
            GetActualPlayer();
        }
        void Update()
        {
            if(tempo == true)
            {
                timeStart += Time.deltaTime;

            }
            if (timeStart >= 1.5f)
            {

                var index = Random.Range(1, 3);
                item = PrefabLoots.transform.SetParent( Grid.transform, false );
                var loot = Instantiate(PrefabLoots, Vector3.zero, Quaternion.identity, item);
                loot.GetComponent<Loot>().TypeLoot = index;
                Destroy(transform.gameObject);
            }
        }

        private void RunLoot()
        {
            animator.Play("LootAnimation");
            tempo = true;
           
        }


        public void GetActualPlayer()
        {
            player = RoundManager.turnTeam.Peek();
        }
    }
}