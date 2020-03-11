using UnityEngine;
using UnityEngine.UI;

    public class Loot: MonoBehaviour
    {
        public int BadDrop = 50, MidDrop= 75, GoodDrop =90;
        public int TypeLoot;
        public bool CanUse;
        private TaticsMove player;
        public int _rarit;
        public Button botao;
        public Image m_Image;
        
        public Sprite Run_Sprite;

        public Sprite Fight_Sprite;

        public Transform text;

        public GameManager gameManager;


        //private Animator PlayerAnim;


        private void Awake()
        {
            //PlayerAnim = gameObject.GetComponent<Animator>();

            // text = transform.GetChild(0);
            GameManager gameManagerItemsList = gameManager.GetComponent<GameManager>();
            listCount = gameManagerItemsList.itemList.Count;

            CanUse = true;
            m_Image = GetComponent<Image>();
            botao = transform.GetComponent<Button>();
            botao.onClick.AddListener(SpendLoot);
            int prob = Random.Range(0, 100);
            SelectRarit(prob);
            player = RoundManager.turnTeam.Peek();
            
            if (TypeLoot == 1)
            {
                // Instancio novo item de movimento no inventário
                Item newItem = gameManagerItemsList.itemList[Random.Range(0, gameManagerItemsList.itemList.Count)];
                InventoryManager.instance.AddItem(Instantiate(newItem));
            }
            else
            {
                Item newItem = gameManagerItemsList.itemList[Random.Range(0, gameManagerItemsList.itemList.Count)];
                InventoryManager.instance.AddItem(Instantiate(newItem));
            }
            text.GetComponent<Text>().text = _rarit.ToString();
        }

        

        public void SpendLoot()
        {
            if (CanUse)
            {
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
                m_Image.sprite = Run_Sprite;
            }
            else
            {

                m_Image.sprite = Fight_Sprite;
            }
            text.GetComponent<Text>().text = _rarit.ToString();
        }
        
    }
    