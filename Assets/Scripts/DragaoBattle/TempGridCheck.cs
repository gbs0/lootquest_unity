using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempGridCheck : MonoBehaviour
{
    // **Bugs Atuais:**
    // - Barra de Vida do jogador não diminui;
    // - Player ataca o NPC, porém espada buga

    // **OK:**
    // - Barra de Vida do NPC;
    // - Ataque do NPC

    // Elementos do Gameplay
    private RoundManager RM;

    public string NextCenaName;
    public GameObject PainelVitoria;
    
    // Elementos dos Personagens
    private GameObject player;
    PlayerMove playerMove;
    public Animator GS;
    public Animator PlayerAnim;
    
    public Image LifeBar;

    // Elementos do Combate
    public float atkDistance = 1.5f;
    private float distX;
    private float distZ;
    private float PEdist;
    public float distTotal;
    private float PositivizadorX;
    private float PositivizadorZ;
    private float DX;
    private float DZ;

    bool selectable = false;
    
    public bool Morte = false;
    public bool selected = false;
    
    public bool canHit;
    public float hitTime;
    public int hitCount;
    public float tempLife = 100;
    public float vida;
    public Button SkipButton;
    public float TimeAnimation;
    
    // Start is called before the first frame update
    
    public void Start()
    {
        // LifeBar = GameObject.Find("sprite slime");
        // LifeBar = this.GetComponentInChildren<InputField>();
        // LifeBar = this.GameObject.Find("personagem canvas").GetComponentInChildren<InputField>();
        vida = tempLife;
        RM = FindObjectOfType<RoundManager>();
        // player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();

        canHit = true;
        hitCount = 0;
        SkipButton.onClick.AddListener(SkipTurn);
    }

    // Update is called once per frame
    public void Update()
    {
        if (gameObject.GetComponent<TaticsMove>().turn)
        {
            Attack();
        
            if (distTotal <= atkDistance && canHit == true)
            {
                TestDamage(); // Toggle Death Method
                //GS.ResetTrigger("Attack");
            }
        
            if (Input.GetMouseButtonDown(1))
            {
                hitCount = 0;
            }
        }
        
    }

    private void SkipTurn()
    {
        canHit = true;
    }

    private void Attack()
    {
        if (playerMove.LootGenTest == 3 && distTotal < 6)
        {
            selectable = true;
            if (Input.GetMouseButtonDown(0))
            {
                PlayerAnim.SetTrigger("Attack");
                //GS.SetTrigger("Damage");
                StartCoroutine("DamageAnim");
                tempLife -= playerMove.HitForce*10;
                float barra = tempLife / vida;
                Debug.Log(barra);
                LifeBar.fillAmount = barra;
                if (tempLife <= 0)
                {

                    Morte = true;

                    // GS.SetBool("Morto", true);
                    RM.EnimKilled();
                    


                }
                playerMove.LootGenTest = 0;
                //RoundManager.EndTurn();
            }
        }
    }

    private void TestDamage()
    {
        // GS.SetTrigger("Attack");
        PlayerAnim.SetTrigger("Damage");
        hitCount++;
        canHit = false;
        if (hitCount == 5)
        {
            StartCoroutine("DeathAnim");
        }
    }

    IEnumerator DeathAnim()
    {
        PlayerAnim.SetBool("Morto", true);
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetString("Scene", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }

    IEnumerator DamageAnim()
    {
        yield return new WaitForSeconds(0.5f);
        // GS.SetTrigger("Damage");
    }

    
    private void OnMouseEnter()
    {
        if (selectable == true)
        {
            selected = true;
        }
    }

    private void OnMouseExit()
    {
        selected = false;
    }

}
