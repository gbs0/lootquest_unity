using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaitNPC : NPCMove
{
    private float distance;
    public List<GameObject> TPTarguets;
    public override void Update()
    {
        if (!turn)
        {
            return;
        }
        if (!moving)
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
        else
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

                // Mudar a Rodada ou Terminar o turno;


                RoundManager.EndTurn();
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
