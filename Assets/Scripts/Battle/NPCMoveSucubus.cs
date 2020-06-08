using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoveSucubus : NPCMove
{
    
    public TempDistCheckSucubus tempDistCheckS;
    // Start is called before the first frame update

    public override void Start()
    {
        NPC = gameObject;
        tempDistCheckS = NPC.GetComponent<TempDistCheckSucubus>();
        Init();
    }

    // Update is called once per frame
    public override void Update()
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
            if (tempDistCheckS.distTotal >= 1.5f)
            {
                StartCoroutine("MoveAnim");
            }

            Move();
        }
    }

    public override IEnumerator MoveAnim()
    {
        GS.SetTrigger("Move");
        yield return new WaitForSeconds(0.9f);
        GS.ResetTrigger("Move");
    }
    
    public override void CalculatePath()
    {
        Tile targetTile = GetTargetTile(target);
        FindPath(targetTile); // Perform A*
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
