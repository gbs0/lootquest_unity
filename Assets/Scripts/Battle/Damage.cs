using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public bool DD;
    private RoundManager RM;
    public GameObject PainelVitoria;
    public GameObject Selection;
    private GameObject player;
    public Image LifeBar;
    PlayerMove playerMove;
    public Animator PlayerAnim;
    public Animator GS;

    public float TimeAnimation;
    public bool Morte = false;
    public UndoLoot Undo;
    private float distX;
    private float distZ;
    private float PEdist;
    private float distTotal;
    private float PositivizadorX;
    private float PositivizadorZ;
    private float DX;
    private float DZ;


    bool selectable = false;
    public bool selected = false;

    float tempLife;
    
    private void Awake()
    {
        RM = FindObjectOfType<RoundManager>();
        Undo = FindObjectOfType<UndoLoot>();
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        tempLife = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        
    }

    void Attack()
    {
        if (playerMove.LootGenTest == 0 && distTotal < 6 && TempDistCheckSucubus.charm ==false)
        {
            selectable = true;
            if (Input.GetMouseButtonDown(0)&& Selection.activeSelf)
            {
                PlayerAnim.SetTrigger("Attack");
                //GS.SetTrigger("Damage");
                StartCoroutine("DamageAnim");
                if (DD)
                {
                    tempLife -= playerMove.HitForce*10*2;
                }
                else
                {
                    tempLife -= playerMove.HitForce*10;
                }
                float barra = tempLife / 100;
                LifeBar.fillAmount = barra;
                if (tempLife <= 0)
                {

                    Morte = true;

                    GS.SetBool("Morto", true);
                    RM.EnimKilled();
                }
                playerMove.LootGenTest = 99;
                Undo.CleanBtn();
                DD = false;
                //RoundManager.EndTurn();
            }
        }
    }

    IEnumerator DamageAnim()
    {
        yield return new WaitForSeconds(0.5f);
        GS.SetTrigger("Damage");
    }

    public void DistCheck()
    {
        distX = (player.transform.position.x - transform.position.x)/1;
        distZ = (player.transform.position.z - transform.position.z)/1;

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

    private void OnMouseEnter()
    {
        if (selectable == true)
        {
            Selection.SetActive(true);
            selected = true;
        }
    }

    private void OnMouseExit()
    {
        Selection.SetActive(false);
        selected = false;
    }
    

}
