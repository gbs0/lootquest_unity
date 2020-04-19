﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

    public class Loot: MonoBehaviour
    {
        public int BadDrop = 50, MidDrop= 75, GoodDrop =90;
        public int TypeLoot;
        public bool CanUse;
        private TaticsMove player;
        public int _rarit;
        public Button botao;
        public Image m_Image;
        private UndoLoot UL;
        public Sprite Run_Sprite;

        public Sprite Fight_Sprite;

        public Transform text;


        //private Animator PlayerAnim;

        private void Awake()
        {
            //PlayerAnim = gameObject.GetComponent<Animator>();

            text = transform.GetChild(0);

            UL = FindObjectOfType<UndoLoot>();            
            CanUse = true;
            m_Image = GetComponent<Image>();
            botao = transform.GetComponent<Button>();
            botao.onClick.AddListener(SpendLoot);
            int prob = Random.Range(0, 100);
            SelectRarit(prob);
            player = RoundManager.TurnTeam.Peek();
            
            
            if(TypeLoot == 2)
            {
                m_Image.sprite = Run_Sprite;
            }
            else if(TypeLoot == 3)
            {
                m_Image.sprite = Fight_Sprite;
            }
            text.GetComponent<Text>().text = _rarit.ToString();
        }

        private void Start()
        {
            if (m_Image.sprite == null)
            {
                if(TypeLoot == 2)
                {
                    m_Image.sprite = Run_Sprite;
                }
                else if(TypeLoot == 3)
                {
                    m_Image.sprite = Fight_Sprite;
                }
                
            }
        }


        public void SpendLoot()
        {
            if (CanUse)
            {
                UL.sLoot = this;
                UL.btn.gameObject.SetActive(true);
                player.LootGenTest = TypeLoot;
                player.move = _rarit;
                player.HitForce = _rarit;
                player.BeginTurn();
                Destroy(gameObject);
            }
            else
            {
                FindObjectOfType<PassiveManager>().ChoseOne(this);
            }
        }

        private void SelectRarit(int prob)
        {
            if (prob>GoodDrop)
            {
                _rarit = 4;
                //PlayerAnim.SetTrigger("PositiveReact");
            }
            else if (prob>MidDrop)
            {
                _rarit = 3;
            }
            else if (prob>BadDrop)
            {
                _rarit = 2;
            }
            else if (prob<=BadDrop)
            {
                _rarit = 1;
                //PlayerAnim.SetTrigger("NegativeReact");
            }
        }
        public void Chose()
        {
            FindObjectOfType<PassiveManager>().SelectLoot(gameObject);
        }

        public void SetValue(bool b, int r, int t)
        {
            TypeLoot = t;
            _rarit = r;
            CanUse = b;
            if (TypeLoot == 2)
            {
                m_Image.sprite = Run_Sprite;
            }
            else
            {

                m_Image.sprite = Fight_Sprite;
            }
            text.GetComponent<Text>().text = _rarit.ToString();
        }

        public void SetLoot(Loot VL)
        {
            var loot = this;
            loot = VL;
        }

    }
    