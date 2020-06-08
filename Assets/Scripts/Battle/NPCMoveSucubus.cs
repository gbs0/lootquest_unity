using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoveSucubus : NPCMove
{

    private GameObject NPC;
    public TempDistCheckSucubus tempDistCheckk;
    // Start is called before the first frame update

    public void start()
    {
        NPC = gameObject;
        tempDistCheckk = NPC.GetComponent<TempDistCheckSucubus>();
        Init();
    }

    // Update is called once per frame
    public override  void Update()
    {
        if (!turn)
        {
            return;
        }
        if (!moving)
        {
            FindNearestTarget();
            FindSelectableTiles(); // Still show the movement from NPC
            CalculatePath();
            actualTargetTile.target = true;
        }
        else
        {
            if (tempDistCheckk.distTotal >= 1.5f)
            {
                StartCoroutine("MoveAnim");
            }

            Move();
        }
    }

    public override void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        // Put simple AI
        GameObject nearest = null;
        float distance = Mathf.Infinity;

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
}
