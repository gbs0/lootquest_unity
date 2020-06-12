
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TaticsMove
{
	public bool morto;
	public bool Stuned;
	public GameObject NPC;
	public GameObject target;
    public Animator GS;
    public TempDistCheck tempDistCheck;

    public int Stuncount=0;
    // Start is called before the first frame update

    public virtual void Start()
    {
	    NPC = gameObject;
        tempDistCheck = NPC.GetComponent<TempDistCheck>();
        Init();
    }

    // Update is called once per frame
    public virtual void Update()
    {
	    
		    if (!turn)
		    {
			    return;
		    }

		    if (Stuned)
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
			    if (tempDistCheck.distTotal >= 1.5f)
			    {
				    StartCoroutine("MoveAnim");
			    }

			    Move();
		    }

    }
    public override void BeginTurn()
    {
	    tempDistCheck.canHit = true;
	    if (morto)
	    {
		    RoundManager.EndTurn();
		    return;
	    }
	    if (Stuned)
	    {
		    // roda anima de bixo stunado e passa
		    RoundManager.EndTurn();
		    Stuncount++;
		    if (Stuncount>1)
		    {
			    Stuned = false;
			    var stun = FindObjectsOfType<StunAnim>();
			    foreach (var anim in stun)
			    {
				    anim.LiveStun();
			    }
		    }
		    return;
	    }
	    if (LootGenTest == 1)
	    {	    
		    FindSelectableTiles();
	    }

	    if (LootGenTest == 0)
	    {
		    var enimi = FindObjectsOfType<Damage>();
		    foreach (var objDamage in enimi)
		    {
			    objDamage.DistCheck();
		    }
	    }
	    turn = true;
    }

   public virtual IEnumerator MoveAnim()
    {
        GS.SetTrigger("Move");
        yield return new WaitForSeconds(0.9f);
        GS.ResetTrigger("Move");
    }

    public virtual void CalculatePath() 
    {
    	Tile targetTile = GetTargetTile(target);
    	FindPath(targetTile); // Perform A*
    }

    public virtual void FindNearestTarget()
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
