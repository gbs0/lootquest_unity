using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Battle;

public class Loot: MonoBehaviour
    {
        public bool Spell;
        public int intSpell;
        public int BadDrop = 50, MidDrop= 75, GoodDrop =90;
        public int TypeLoot;
        public bool CanUse;
        private TaticsMove player;
        public int _rarit;
        public Button botao;
        public Image m_Image;
        private UndoLoot UL;
        public Sprite Run_Sprite;
        public Sprite Run_Sprite2;
        public Sprite Run_Sprite3;
        public Sprite Run_Sprite4;

        public Sprite Fight_Sprite;
        public Sprite Fight_Sprite2;
        public Sprite Fight_Sprite3;
        public Sprite Fight_Sprite4;
        private GameObject PlayerAni;
        public Animator AnimePlayer;

        public LootBoxPainel LBpainel;
        //private Animator PlayerAnim;


    private void Awake()
    {
        CheckLvl();
        UL = FindObjectOfType<UndoLoot>();            
        CanUse = true;
        m_Image = GetComponent<Image>();
        botao = transform.GetComponent<Button>();
        botao.onClick.AddListener(SpendLoot);
        int prob = Random.Range(0, 100);
        SelectRarit(prob);
        player = RoundManager._allCaracters.Peek();
        PlayerAni = GameObject.FindGameObjectWithTag("PlayerSprite");
        AnimePlayer = PlayerAni.GetComponent<Animator>();
        LBpainel = FindObjectOfType<LootBoxPainel>();


    }

    private void CheckLvl()
    {
        switch (PlayerPrefs.GetInt("Lvl"))
        {
            case 0:
                BadDrop = 50;
                MidDrop = 75;
                GoodDrop =90;
                break;
            case 1:
                BadDrop = 45;
                MidDrop = 70;
                GoodDrop = 85;
                break;
            case 2:
                BadDrop = 40;
                MidDrop = 65;
                GoodDrop = 80;
                break;
            case 3:
                BadDrop = 35;
                MidDrop = 60;
                GoodDrop = 75;
                break;
        }
    }

    private void Start()
    {
        if (Spell) return;
        
        if (TypeLoot == 1)
        {
            if (_rarit == 1) {
                m_Image.sprite = Run_Sprite;
            } 
            if (_rarit == 2) 
            {
                m_Image.sprite = Run_Sprite2;
            } 
            if (_rarit == 3) 
            { 
                AnimePlayer.SetTrigger("PositiveReact");
                m_Image.sprite = Run_Sprite3;
            } 
            if (_rarit == 4) 
            { 
                AnimePlayer.SetTrigger("PositiveReact");
                m_Image.sprite = Run_Sprite4;
            } 
        } 
        if(TypeLoot == 0) {
            if (_rarit == 1)
            {
                AnimePlayer.SetTrigger("NegativeReact");
                m_Image.sprite = Fight_Sprite;
            }
            if (_rarit == 2)
            {
                m_Image.sprite = Fight_Sprite2;
            }
            if (_rarit == 3)
            {
                AnimePlayer.SetTrigger("PositiveReact");
    
                m_Image.sprite = Fight_Sprite3;
           
            }
            if (_rarit == 4)
            {
                AnimePlayer.SetTrigger("PositiveReact");
                m_Image.sprite = Fight_Sprite4;
            }
        }

        if (m_Image.sprite == null)
        {
            if(TypeLoot == 1)
            {
                if( PlayerPrefs.GetInt("MonthlySardine", 0) == 2)
                {
                    if (_rarit <=3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
                if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) == 2)
                {
                    if (_rarit <= 3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
                if (_rarit == 1)
                {
                    AnimePlayer.SetTrigger("NegativeReact");

                    m_Image.sprite = Run_Sprite;
                }
                if (_rarit == 2)
                {
                    m_Image.sprite = Run_Sprite2;
                }
                if (_rarit == 3)
                {
                    AnimePlayer.SetTrigger("PositiveReact");

                    m_Image.sprite = Run_Sprite3;
                }
                if (_rarit == 4)
                {
                    AnimePlayer.SetTrigger("PositiveReact");

                    m_Image.sprite = Run_Sprite4;
                };
            }
            else if(TypeLoot == 0)
            {
                if (PlayerPrefs.GetInt("LovesWhip", 0) == 2)
                {
                    if (_rarit <= 3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
                if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) == 2)
                {
                    if (_rarit <= 3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
                if (_rarit == 1)
                {
                    AnimePlayer.SetTrigger("NegativeReact");

                    m_Image.sprite = Fight_Sprite;
                }
                if (_rarit == 2)
                {
                    m_Image.sprite = Fight_Sprite2;
                }
                if (_rarit == 3)
                {
                    AnimePlayer.SetTrigger("PositiveReact");

                    m_Image.sprite = Fight_Sprite3;
                }
                if (_rarit == 4)
                {
                    AnimePlayer.SetTrigger("PositiveReact");

                    m_Image.sprite = Fight_Sprite4;
                }
            }
                
        }
    }


    public void SpendLoot()
    {
        if (Spell)
        {
            switch (intSpell)
            {
                case 0:
                    SpellTP();
                    break;
                case 1:
                    SpellStun();
                    break;
                case 2:
                    SpellDD();
                    break;
                case 3:
                    SpellLuck();
                    break;
            }
            return;
        }
        if (CanUse)
        {
            UL.sLoot = this;
            UL.btn.gameObject.SetActive(true);
            player.LootGenTest = TypeLoot;
            player.move = _rarit;
            player.HitForce = _rarit;
            player.BeginTurn();
            LBpainel.Remove();
            Destroy(gameObject);
        }
        else
        {
            FindObjectOfType<PassiveManager>().ChoseOne(this);
        }
    }

    private void SpellLuck()
    {
        var loots = FindObjectsOfType<Loot>();
        foreach (var lot in loots)
        {
            lot._rarit = 4;
        }
        player.BeginTurn();
        Destroy(gameObject);
    }

    private void SpellDD()
    {
        var dam = FindObjectsOfType<Damage>();
        foreach (var damage in dam)
        {
            damage.DD = true;
        }
        player.BeginTurn();
        Destroy(gameObject);
    }

    private void SpellStun()
    {
        var enim = FindObjectsOfType<NPCMove>();
        foreach (var npc in enim)
        {
            npc.Stuned = true;
            npc.
        }
        player.BeginTurn();
        Destroy(gameObject);
    }

    private void SpellTP()
    {
        UL.sLoot = this;
        UL.btn.gameObject.SetActive(true);
        player.LootGenTest = 1;
        player.move = 100;
        player.BeginTurn();
        Destroy(gameObject);
    }

    private void SelectRarit(int prob)
    {
        if (Spell)
        {
            return;
        }
        if (prob>GoodDrop)
        {
            _rarit = 4;
            
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
            
        }
    }
    public void Chose()
    {
        FindObjectOfType<PassiveManager>().SelectLoot(gameObject);
        LBpainel.Remove();
    }

    public void SetValue(bool b, int r, int t)
    {
        TypeLoot = t;
        _rarit = r;
        CanUse = b;
        if (TypeLoot == 1)
        {
            if (PlayerPrefs.GetInt("MonthlySardine", 0) == 2)
            {
                if (_rarit <= 3)
                {
                    _rarit = _rarit + 1;
                }
            }
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) == 2)
            {
                if (_rarit <= 3)
                {
                    _rarit = _rarit + 1;
                }
            }
            if (_rarit == 1)
            {
                AnimePlayer.SetTrigger("NegativeReact");

                m_Image.sprite = Run_Sprite;
            }
            if (_rarit == 2)
            {
            
                m_Image.sprite = Run_Sprite2;
            }
            if (_rarit == 3)
            {
                m_Image.sprite = Run_Sprite3;
            }
            if (_rarit == 4)
            {
                m_Image.sprite = Run_Sprite4;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("LovesWhip", 0) == 2)
            {
                if (_rarit == 1)
                {
                    _rarit = _rarit + 2;
                }
                else
                {
                    if (_rarit <= 3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
            }

            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) == 2)
            {
                if (_rarit == 1)
                {
                    _rarit = _rarit + 2;
                }
                else
                {
                    if (_rarit <= 3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
            }

            if (_rarit == 1)
            {
                AnimePlayer.SetTrigger("NegativeReact");

                m_Image.sprite = Fight_Sprite;
            }

            if (_rarit == 2)
            {
                m_Image.sprite = Fight_Sprite2;
            }

            if (_rarit == 3)
            {
                m_Image.sprite = Fight_Sprite3;
            }

            if (_rarit == 4)
            {
                m_Image.sprite = Fight_Sprite4;
            }

        }
    }

    public void SetLoot(Loot VL)
    {
        var loot = this;
        loot = VL;
    }

    }
    