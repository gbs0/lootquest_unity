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
    
	public float m_ExperienceValue;
   // Gato Sessenta xp
   // Bruxa Cem xp
   // Cogumelo Sessenta XP
   // Dragao Cem XP
   // Ghoul Sessenta XP 
   // Sucubus Cem XP

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
        
    }

    public static void StartTurn()
    {
 	
		if (_allCaracters.Count > 0)
		{
			if (_allCaracters.Peek().gameObject.GetComponent<PlayerMove>())
			{
				PlayerTurn = true;
				_enemyPainel.SetActive(false);
				// Debug.Log("Vez do player");

				return;
			}

			PlayerTurn = false;
			_enemyPainel.SetActive(true);
			_allCaracters.Peek().BeginTurn();
			
		}
    }

    public static void EndTurn()
    {
    	TaticsMove unit = _allCaracters.Dequeue();
    	unit.EndTurn();
		// Debug.Log(_allCaracters.Count);

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
	    
	    enemies.RemoveAt(0);

	 	/* foreach(NPCMove e in enemies)
        {
            enemies.RemoveAt(e);
        } */

	    if (enemies.Count == 0)
	    {
		    StartCoroutine(nameof(EndScene));
			m_ExperienceValue = PlayerPrefs.GetFloat("CurrentXP") + m_ExperienceValue;
        	PlayerPrefs.GetFloat("CurrentXP", m_ExperienceValue);
	    }

		
    }
    IEnumerator EndScene()
    {
	    _allCaracters.Clear();
	    safelist.Clear();
	    test.Clear();
	    yield return new WaitForSeconds(2f);
	    PlayerPrefs.SetString("_sceneName", nextSceneName);
	    LoadingSisten.LoadLevel(nextSceneName);
    }

    public void Clean()
    {
	    _allCaracters.Clear();
	    safelist.Clear();
	    test.Clear();
    }
}