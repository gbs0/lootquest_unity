using UnityEngine;
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
        public Sprite Run_Sprite2;
        public Sprite Run_Sprite3;
        public Sprite Run_Sprite4;

        public Sprite Fight_Sprite;
        public Sprite Fight_Sprite2;
        public Sprite Fight_Sprite3;
        public Sprite Fight_Sprite4;
        private GameObject PlayerAni;
        public Animator AnimePlayer;

        //private Animator PlayerAnim;


    private void Awake()
        {
            //PlayerAnim = gameObject.GetComponent<Animator>();

         
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

    //     if (TypeLoot == 1)
    //         {
    //             if (_rarit == 1)
    //             {
    //                 m_Image.sprite = Run_Sprite;
    //     
    //             }
    //             if (_rarit == 2)
    //             {
    //                 m_Image.sprite = Run_Sprite2;
    //             
    //     
    //             }
    //             if (_rarit == 3)
    //             {
    //                 //  AnimePlayer.SetTrigger("PositiveReact");
    //     
    //                 m_Image.sprite = Run_Sprite3;
    //     
    //             }
    //             if (_rarit == 4)
    //             {
    //                 //  AnimePlayer.SetTrigger("PositiveReact");
    //     
    //                 m_Image.sprite = Run_Sprite4;
    //             
    //     
    //             } 
    //         } 
    //     if(TypeLoot == 0) {
    //         if (_rarit == 1)
    //         {
    //             //AnimePlayer.SetTrigger("NegativeReact");
    //             m_Image.sprite = Fight_Sprite;
    //         }
    //         if (_rarit == 2)
    //         {
    //             m_Image.sprite = Fight_Sprite2;
    //         }
    //         if (_rarit == 3)
    //         {
    //             //  AnimePlayer.SetTrigger("PositiveReact");
    //     
    //             m_Image.sprite = Fight_Sprite3;
    //            
    //         }
    //         if (_rarit == 4)
    //         {
    //             // AnimePlayer.SetTrigger("PositiveReact");
    //             m_Image.sprite = Fight_Sprite4;
    //             
    //         }
    //     }
    //     text.GetComponent<Text>().text = _rarit.ToString();
    }

    private void Start()
    {
        

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
                if (PlayerPrefs.GetInt("Creatuurr’sGauntlet", 0) == 2)
                {
                    if (_rarit <= 3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
                if (_rarit == 1)
                {
                    //  AnimePlayer.SetTrigger("NegativeReact");

                    m_Image.sprite = Run_Sprite;
                }
                if (_rarit == 2)
                {
                    m_Image.sprite = Run_Sprite2;
                }
                if (_rarit == 3)
                {
                    //  AnimePlayer.SetTrigger("PositiveReact");

                    m_Image.sprite = Run_Sprite3;
                }
                if (_rarit == 4)
                {
                    //  AnimePlayer.SetTrigger("PositiveReact");

                    m_Image.sprite = Run_Sprite4;
                };
            }
            else if(TypeLoot == 0)
            {
                if (PlayerPrefs.GetInt("MonthlySardine", 0) == 2)
                {
                    if (_rarit <= 3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
                if (PlayerPrefs.GetInt("Creatuurr’sGauntlet", 0) == 2)
                {
                    if (_rarit <= 3)
                    {
                        _rarit = _rarit + 1;
                    }
                }
                if (_rarit == 1)
                {
                    //AnimePlayer.SetTrigger("NegativeReact");

                    m_Image.sprite = Fight_Sprite;
                }
                if (_rarit == 2)
                {
                    m_Image.sprite = Fight_Sprite2;
                }
                if (_rarit == 3)
                {
                    // AnimePlayer.SetTrigger("PositiveReact");

                    m_Image.sprite = Fight_Sprite3;
                }
                if (_rarit == 4)
                {
                    // AnimePlayer.SetTrigger("PositiveReact");

                    m_Image.sprite = Fight_Sprite4;
                }
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
        if (TypeLoot == 1)
        {
            if (PlayerPrefs.GetInt("MonthlySardine", 0) == 2)
            {
                if (_rarit <= 3)
                {
                    _rarit = _rarit + 1;
                }
            }
            if (PlayerPrefs.GetInt("Creatuurr’sGauntlet", 0) == 2)
            {
                if (_rarit <= 3)
                {
                    _rarit = _rarit + 1;
                }
            }
            if (_rarit == 1)
            {
                //AnimePlayer.SetTrigger("NegativeReact");

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
            if (PlayerPrefs.GetInt("MonthlySardine", 0) == 2)
            {
                if (_rarit == 0)
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

            if (PlayerPrefs.GetInt("Creatuurr’sGauntlet", 0) == 2)
            {
                if (_rarit == 0)
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

            if (_rarit == 0)
            {
                //AnimePlayer.SetTrigger("NegativeReact");

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
    