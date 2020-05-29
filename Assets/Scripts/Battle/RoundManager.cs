using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoundManager : MonoBehaviour
{
	public static bool PlayerTurn;

	public static Queue<TaticsMove> _allCaracters = new Queue<TaticsMove>();
    private static GameObject _enemyPainel;
    public string nextSceneName = "ilha1";
    public GameObject enemyPainel;
    public static bool Tutorial;
    public List<NPCMove> enemies; // CaitGrid tbm faz parte
    private static List<TaticsMove> safelist = new List<TaticsMove>();
    public List<TaticsMove> test;
    
	private void Start()
    {
	    _enemyPainel = enemyPainel;
	    // var v = FindObjectsOfType<NPCMove>();
	    
		// foreach (var npc in v)
	    // {
		    //enemies.Add(npc);
	    // }
    }

    void Update()
    {
	    test = safelist;
	    if (_allCaracters.Count == 0)
	    {

		    InitTeamTurnQueue();
	    }

		// Debug.Log(safelist[1]); // #=> Return object: Grid(CaitGrid)/NPCMove;
		// Debug.Log(_allCaracters.Count); // #=> 2 objects in the list
    }
    
	static void InitTeamTurnQueue()
    {
	
    	foreach (TaticsMove unit in safelist)
    	{
    		_allCaracters.Enqueue(unit); // Inclui todas as unidades na fila
    	}
    	StartTurn();
        
		// Console.Write("Number of elements in the Queue(StartTurn()) are : "); 
		// Console.WriteLine(TurnTeam.Count);
    }

    public static void StartTurn()
    {
 	
		if (_allCaracters.Count > 0)
		{
			if (_allCaracters.Peek().gameObject.GetComponent<PlayerMove>())
			{
				PlayerTurn = true;
				_enemyPainel.SetActive(false);
				return;

				Debug.Log("Vez do player");
				
			}

			PlayerTurn = false;
			_enemyPainel.SetActive(true);
			_allCaracters.Peek().BeginTurn();
			var grid = _allCaracters.Peek().gameObject.GetComponent<AtaqueGrid>();
			
		}

		// if (_allCaracters.Peek().gameObject.GetComponent<AtaqueGrid>())
		// {
			
		// 	// grid.AtaqueHorizontal();
		// 	// PlayerTurn = false;
			
		// 	Debug.Log("Vez da grid");
			
		// 	return;
		// }
    }

    public static void EndTurn()
    {
    	TaticsMove unit = _allCaracters.Dequeue();
    	unit.EndTurn();
		Debug.Log(_allCaracters.Count);

    	if (_allCaracters.Count > 0)
    	{
			StartTurn();
    	}
    	else
    	{
    		InitTeamTurnQueue(); // Ao terminar o turno, so entra a grid
    	}
    }

    public static void AddUnit(TaticsMove unit)
    {
	    _allCaracters.Enqueue(unit);
	    safelist.Add(unit);
    }

    public void EnimKilled()
    {
	     for(int i = 0; i < enemies.Count; i++)
        {
			enemies.RemoveAt(i);
        } 

	 	/* foreach(NPCMove e in enemies)
        {
            enemies.RemoveAt(e);
        } */

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
	    _allCaracters.Clear();
	    safelist.Clear();
	    test.Clear();
	    yield return new WaitForSeconds(0.7f);
	    PlayerPrefs.SetString("_sceneName", nextSceneName);
	    LoadingSisten.LoadLevel(nextSceneName);
    }
}