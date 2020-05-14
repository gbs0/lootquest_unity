using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoundManager : MonoBehaviour
{
	public static bool PlayerTurn;
    static readonly Dictionary<string, List<TaticsMove>> Units = new Dictionary<string, List<TaticsMove>>(); 
    static readonly Queue<string> TurnKey = new Queue<string>();
    public static readonly Queue<TaticsMove> TurnTeam = new Queue<TaticsMove>();
    private static GameObject _enemyPainel;
    public string nextSceneName = "ilha1";
    public GameObject enemyPainel;
    public static bool Tutorial;
    public List<NPCMove> enemies;

    private void Start()
    {
	    _enemyPainel = enemyPainel;
	    var v = FindObjectsOfType<NPCMove>();
	    
		foreach (var npc in v)
	    {
		    enemies.Add(npc);
	    }
    }

    void Update()
    {
	    if (TurnTeam.Count == 0)
	    {

		    InitTeamTurnQueue();
	    }
		
	
    }
    
	static void InitTeamTurnQueue()
    {
    	List<TaticsMove> teamList = Units[TurnKey.Peek()];

    	foreach (TaticsMove unit in teamList)
    	{
    		TurnTeam.Enqueue(unit);
    	}
    	StartTurn();
        Debug.Log(TurnTeam.Count);
		// Console.Write("Number of elements in the Queue(StartTurn()) are : "); 
		// Console.WriteLine(TurnTeam.Count);
    }

    public static void StartTurn()
    {
 	
	if (TurnTeam.Count > 0)
    	{
		    if (TurnTeam.Peek().gameObject.GetComponent<PlayerMove>() != null)
		    {
			    PlayerTurn = true;
			    _enemyPainel.SetActive(false);
			    return;
		    }

		    PlayerTurn = false;
		    _enemyPainel.SetActive(true);
    		TurnTeam.Peek().BeginTurn();
    	}
    }

    public static void EndTurn()
    {
    	TaticsMove unit = TurnTeam.Dequeue();
    	unit.EndTurn();
	    
    	if (TurnTeam.Count > 0)
    	{
    		StartTurn();
    	}
    	else
    	{
    		string team = TurnKey.Dequeue();
    		TurnKey.Enqueue(team);
    		InitTeamTurnQueue();
    	}
    }

    public static void AddUnit(TaticsMove unit)
    {
    	List<TaticsMove> list;

    	if (!Units.ContainsKey(unit.tag))
    	{
    		list = new List<TaticsMove>(); // Nova lista de TacticsMove
    		Units[unit.tag] = list;

    		if (!TurnKey.Contains(unit.tag))
    		{
    			TurnKey.Enqueue(unit.tag);
    		}
    	}
    	else
    	{
    		list = Units[unit.tag];
    	}
    	
    	list.Add(unit);
    }

    public void EnimKilled()
    {
	    enemies.RemoveAt(0);
	    if (enemies.Count == 0)
	    {
		    StartCoroutine(nameof(EndScene));
			
			// for (var i = 0; i < teamList.Count; i++) //Apagando teamList assim que os inimigos morrem
 			// {
     			//teamList.RemoveAt(i);
 			// }
	    }

		
    }
    IEnumerator EndScene()
    {
	    yield return new WaitForSeconds(0.7f);
	    PlayerPrefs.SetString("_sceneName", nextSceneName);
	    LoadingSisten.LoadLevel(nextSceneName);
    }
}
