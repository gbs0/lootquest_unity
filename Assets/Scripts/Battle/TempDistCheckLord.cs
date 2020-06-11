﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempDistCheckLord : TempDistCheck
{
 
    public Animator Charm;
    public GameObject CharmeImagem;
    public static bool charm;
    public int attack;

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
        if (charm == false)
        {
            hitCount = 0;
        }
    }

    public override void SkipTurn()
    {
        CharmeImagem.SetActive(false);

        charm = false;
        canHit = true;
       // CharmeImagem.SetActive(false);


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

    public override void TestDamage()
    {

        attack = Random.Range(0, 6);
        switch (attack)
        {
            switch (intelligence)
        {
        case 5:
            print ("Why hello there good sir! Let me teach you about Trigonometry!");
            break;
        case 4:
            print ("Hello and good day!");
            break;
        case 3:
            print ("Whadya want?");
            break;
        case 2:
            print ("Grog SMASH!");
            break;
        case 1:
            print ("Ulg, glib, Pblblblblb");
            break;
        default:
            print ("Incorrect intelligence level.");
            break;
        }
        }
        if (attack < 3)
        {
            if (distTotal <= 1.5f)
            {

                GS.SetTrigger("AttackMele");
                PlayerAnim.SetTrigger("Damage");
                hitCount++;

                canHit = false;
                if (TempPlayerHp.PlayerHealth <= 0)
                {
                    StartCoroutine("DeathAnim");
                }
            }
            if (distTotal > 1.5f)
            {

                GS.SetTrigger("Attack");
                PlayerAnim.SetTrigger("Damage");
                hitCount++;

                canHit = false;
                if (TempPlayerHp.PlayerHealth <= 0)
                {
                    StartCoroutine("DeathAnim");
                }
            }
        }
          else //(atack == 3)
        {


            GS.SetTrigger("Charm");
            charm = true;
            CharmeImagem.SetActive(true);
            canHit = false;

        }
    }
    


    public override IEnumerator DeathAnim()
    {
        PlayerAnim.SetBool("Morto", true);
        yield return new WaitForSeconds(3.0f);
        m_ExperienceValue = PlayerPrefs.GetFloat("CurrentXP") + m_ExperienceValue;
        PlayerPrefs.GetFloat("CurrentXP", m_ExperienceValue);
        PlayerPrefs.SetString("_sceneName", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }
    
    IEnumerator CharAnim()
    {
        yield return new WaitForSeconds(0.5f);
        GS.SetTrigger("Charm");
        
    }
    IEnumerator CharmExp()
    {
        Charm.SetTrigger("Explode");

        yield return new WaitForSeconds(1.2f);


    }
   

}