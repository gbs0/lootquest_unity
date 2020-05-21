using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridManager : MonoBehaviour
{
	public static bool PlayerTurn;

	public static Queue<TaticsMove> _allCaracters = new Queue<TaticsMove>();
    private static GameObject _enemyPainel;
    public GameObject enemyPainel;

    // Proxima cena setada no inspect
    public string nextSceneName = "ilha1";
    
    
    // public static bool Tutorial;
    public List<NPCMove> enemies;
    private static List<TaticsMove> safelist = new List<TaticsMove>();
    public List<TaticsMove> test;

    public AtaqueGrid ataqueGrid; // referecia do script da grid
    
    private void Awake ()
    {
        ataqueGrid = GetComponent<AtaqueGrid>();
    }

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
	    if (_allCaracters.Count == 0)
	    {

		    InitTeamTurnQueue();
	    }	
	
    }
    
	static void InitTeamTurnQueue()
    {
	    
    	foreach (TaticsMove unit in safelist)
    	{
    		_allCaracters.Enqueue(unit);
    	}
    	StartTurn();
        
        // Debug.Log("Numero de elementos na fila: "+ TurnTeam.Count);
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
		    }

		    PlayerTurn = false;
		    _enemyPainel.SetActive(true);
    		// _allCaracters.Peek().BeginTurn(); // Roda a vez do inimigo chamando função do TacticsMove
            
    	}
    }

    public static void EndTurn()
    {
    	TaticsMove unit = _allCaracters.Dequeue();
    	unit.EndTurn();
	    
    	if (_allCaracters.Count > 0)
    	{
    		StartTurn();
    	}
    	else
    	{
    		
    		InitTeamTurnQueue();
    	}
    }

    public static void AddUnit(TaticsMove unit)
    {
	    _allCaracters.Enqueue(unit);
	    safelist.Add(unit);
    }
/*
    public void EnimKilled()
    {
	     for(int i = 0; i < enemies.Count; i++)
        {
			enemies.RemoveAt(i);
        } 

	 	// foreach(NPCMove e in enemies)
        // {
            // enemies.RemoveAt(e);
        // }

	    if (enemies.Count == 0)
	    {
		    StartCoroutine(nameof(EndScene));
			
			// for (var i = 0; i < teamList.Count; i++) //Apagando teamList assim que os inimigos morrem
 			// {
     			//teamList.RemoveAt(i);
 			// }
	    }

		
    }
    */

    IEnumerator EndScene()
    {
	    // Limpando Listas no final do turno
        _allCaracters.Clear();
	    safelist.Clear();
	    
	    yield return new WaitForSeconds(0.7f);
	    PlayerPrefs.SetString("_sceneName", nextSceneName);
	    LoadingSisten.LoadLevel(nextSceneName);
    }
}
