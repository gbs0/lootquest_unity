using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDistCheckDragao : TempDistCheck
{
    public Animator Roar;
    public GameObject CharmeImagem;
    

    // Start is called before the first frame update

    // Update is called once per frame
    public override void Update()
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

    public override void SkipTurn()
    {
        
        canHit = true;
    }

    public override void Attack()
    {
        if (playerMove.LootGenTest == 0 && distTotal < 6 && charm == false)
        {

            selectable = true;
            if (Input.GetMouseButtonDown(0) && Selection.activeSelf )
            {
                PlayerAnim.SetTrigger("Attack");
                //GS.SetTrigger("Damage");
                StartCoroutine("DamageAnim");
                tempLife -= playerMove.HitForce * 10;
                float barra = tempLife / vida;
                Debug.Log(barra);
                LifeBar.fillAmount = barra;
                if (tempLife <= 0)
                {

                    Morte = true;

                    GS.SetBool("Morto", true);
                    RM.EnimKilled();



                }
                playerMove.LootGenTest = 0;
                //RoundManager.EndTurn();
            }
        }
    }

    public override void TestDamage() // chance do dragao atacar -- NENHUMA
    {        
        if (TempPlayerHp.PlayerHealth <= 0)
        {
            StartCoroutine("DeathAnim");
        }
          else //(attack == 3)
        {

            canHit = false;
        }
    }\

    public override void DistCheck() {

    }
    
    public override IEnumerator DeathAnim()
    {
        PlayerAnim.SetBool("Morto", true);
        yield return new WaitForSeconds(3.0f);
        PlayerPrefs.SetString("_sceneName", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }
    
    IEnumerator RoarAnim()
    {
        yield return new WaitForSeconds(0.5f);
        GS.SetTrigger("Damage");
    }
}
