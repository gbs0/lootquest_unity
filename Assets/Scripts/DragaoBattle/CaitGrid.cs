﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaitGrid : NPCMove
{
    private float distance;
    public List<GameObject> TPTarguets;
    
    public static AtaqueGrid ataqueGrid; // referecia do script da grid
    
    private void Awake ()
    {
        ataqueGrid = GetComponent<AtaqueGrid>();
    }
    
    public override void Update()
    {
        if (!turn) // Se não for o turno ainda
        {
            return;
        }
        if (!moving) // Se ñ estiver movendo
        {
            FindNearestTarget();
            if (distance<2)
            {
                Teleport();
            }
            else
            {
                FindSelectableTiles(); // Still show the movement from NPC
                CalculatePath();
                actualTargetTile.target = true;
            }
            
        }
        else // Vez da Grid
        {
            if (tempDistCheck.distTotal >= tempDistCheck.atkDistance)
            {
                if (tempDistCheck.distTotal >= 6f)
                {
                    StartCoroutine("MoveAnim");
                }
            Move();
            }
            else
            {
                RemoveSelectableTiles();
                moving = false;

                RoundManager.EndTurn(); // Mudar a Rodada ou Terminar o turno;
            }

        }
    }

    public override void FindNearestTarget()
    {GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        // Put simple AI
        GameObject nearest = null;
        distance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);

            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }
        }

        target = nearest;
       
    }

    private void Teleport()
    {
        var i = Random.Range(0, 4);
        gameObject.transform.position = TPTarguets[i].transform.position;
        
    }
}
