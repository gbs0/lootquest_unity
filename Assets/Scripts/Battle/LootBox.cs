using System.Collections.Generic;
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
        
        public GameManager gameManager;
        private void Awake()
        {
            //cache the animator component
            animator = GetComponent<Animator>();
            gameManager = FindObjectOfType<GameManager>();
        }
        void Start()
        {
            PainelLootBox = FindObjectOfType<LootBoxPainel>().gameObject;
            transform.GetComponent<Button>().onClick.AddListener(RunLoot);
            GetActualPlayer();
        }
        void Update()
        {
            if(tempo)
            {
                timeStart += Time.deltaTime;

            }
            if (timeStart >= 1.5f)
            {

                
            }
        }

        private void RunLoot()
        {
            animator.Play("LootAnimation");
            tempo = true;
            //var index = Random.Range(0, 2);
            
            var loot = Instantiate(PrefabLoots, Vector3.zero, Quaternion.identity, PainelLootBox.transform);
            //loot.GetComponent<Loot>().TypeLoot = index;
            Destroy(transform.gameObject);
        }


        public void GetActualPlayer()
        {
            player = RoundManager._allCaracters.Peek();
        }
    }
}