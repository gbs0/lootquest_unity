using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempDistCheck : MonoBehaviour
{
    public AudioSource attackSword;
    // Elementos do Gameplay
    public AudioSource EnimDamageSound;
    public RoundManager RM;

    public string NextCenaName;
    public GameObject PainelVitoria;
    
    // Elementos dos Personagens
    public GameObject player;
    public PlayerMove playerMove;
    public Animator GS;
    public Animator PlayerAnim;
    public GameObject Selection;
    public Image LifeBar;

    // Elementos do Combate
    public float atkDistance = 1.5f;
    public float distX;
    public float distZ;
    public float PEdist;
    public float distTotal;
    public float PositivizadorX;
    public float PositivizadorZ;
    public float DX;
    public float DZ;
    public UndoLoot Undo;
    public bool selectable = false;
    
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
    
    public virtual void Start()
    {
        // LifeBar = GameObject.Find("sprite slime");
        // LifeBar = this.GetComponentInChildren<InputField>();
        // LifeBar = this.GameObject.Find("personagem canvas").GetComponentInChildren<InputField>();
        vida = tempLife;
        RM = FindObjectOfType<RoundManager>();
        Undo = FindObjectOfType<UndoLoot>();
        // player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();

        canHit = true;
        hitCount = 0;
        SkipButton.onClick.AddListener(SkipTurn);
    }

    // Update is called once per frame
    public virtual void Update()
    {


        if (!Morte)
        {
            Attack();
            DistCheck();
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

    public virtual void SkipTurn()
    {
        canHit = true;
        print(canHit);

    }

    public virtual void Attack()
    {
        if (playerMove.LootGenTest == 0 && distTotal < 6)
        {
            selectable = true;
            if (Input.GetMouseButtonDown(0)&& Selection.activeSelf)
            {
                attackSword.Play();
                PlayerAnim.SetTrigger("Attack");
                //GS.SetTrigger("Damage");
                StartCoroutine("DamageAnim");
                tempLife -= playerMove.HitForce*10;
                float barra = tempLife / vida;
                LifeBar.fillAmount = barra;
                if (tempLife <= 0)
                {

                    Morte = true;

                    GS.SetBool("Morto", true);
                    RM.EnimKilled();
                    


                }
                Undo.CleanBtn();
                playerMove.LootGenTest = 99;
                //RoundManager.EndTurn();
            }
        }
        else
        {
            selectable = false;
        }
    }

    public virtual void TestDamage()
    {
        GS.SetTrigger("Attack");
        PlayerAnim.SetTrigger("Damage");
        EnimDamageSound.Play();
        hitCount++;
        canHit = false;
        if (TempPlayerHp.PlayerHealth <=0)
        {
            StartCoroutine("DeathAnim");
        }
    }

    public virtual IEnumerator DeathAnim()
    {
        PlayerAnim.SetBool("Morto", true);
        yield return new WaitForSeconds(2.0f);

        PlayerPrefs.SetString("_sceneName", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }

    public virtual IEnumerator DamageAnim()
    {
        yield return new WaitForSeconds(0.5f);
        GS.SetTrigger("Damage");
    }

    public virtual void DistCheck() 
    {
        distX = (player.transform.position.x - transform.position.x) / 1;
        distZ = (player.transform.position.z - transform.position.z) / 1;

        if (distX < 0)
        {
            PositivizadorX = -1f;
        }
        else
        {
            PositivizadorX = 1f;
        }

        if (distZ < 0)
        {
            PositivizadorZ = -1f;
        }
        else
        {
            PositivizadorZ = 1f;
        }
        DX = distX * PositivizadorX;
        DZ = distZ * PositivizadorZ;
        distTotal = DX + DZ;
    }

    public virtual void OnMouseEnter()
    {
        if (selectable)
        {
            Selection.SetActive(true);
            selected = true;
        }
    }

    public virtual void OnMouseExit()
    {
        Selection.SetActive(false);
        selected = false;
    }

    public virtual void OnDestroy()
    {
        Selection.SetActive(false);
        GetComponent<NPCMove>().morto = true;
    }
}
