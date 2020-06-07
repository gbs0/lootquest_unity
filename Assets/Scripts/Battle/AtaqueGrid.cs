using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;

public class AtaqueGrid : TaticsMove
{
	public AnimationEnim healthPlayer;
	public bool onFire = false;
	public Slider dragaoHealthBar;
	public int vidaBoss;
	public int danoLateral;
	
	int gridTurnN;
	public List<GameObject> backTiles = new List<GameObject>();
	public List<GameObject> sideTiles = new List<GameObject>();
	public List<GameObject> centerTiles = new List<GameObject>();
	// public Animator ataqueBoss;
	// public Animator camAnim;
	// public Animator danoBoss;
	public ParticleSystem particulaAtaque;
	public GameObject player; // Pegar Transform do Player
		
	// Dictionary<string, GameObject> myDictionaryObjects = new Dictionary<string, GameObject>();
	private void Start()
	{
		Init();
		gridTurnN = 0;
	}

	public void SorteioAtaque()
	{
		int num = Random.Range(-1, 4);
	
		if(gridTurnN % 2 == 0)
		{
			switch (num)
			{
			case 4:
				print("IMPOSSIVEL");
				break;
			case 3:
				print("Sorteio Raro");
				break;
			case 2:
				AtaqueTiles(backTiles);
				break;
			case 1:
				AtaqueTiles(sideTiles);
				break;
			case 0:
				AtaqueTiles(centerTiles);
				break;
			default:
				// Esperar um Round;
				print ("Nao tem ataque");
				break;
			}
			RoundManager.EndTurn();
		}
		else {
			Debug.Log("Esperei um round");
			RoundManager.EndTurn();
		}
		
		
		

 	}

	public void AtaqueTiles(List<GameObject> tilesList)
	{
		MarcarTiles(tilesList);
		Debug.Log("AtaqueLateral()");
 	}
	
 	public void DanoNoPlayer(List<GameObject> GO)
	{
		// playTransform playerTrans = GO.transform.position.x;
		// Debug.Log(player.transform.position.x);

		foreach(GameObject tile in GO) // Comparar com posição atual do player nas tiles
		{
			if(player.transform.position.x == tile.transform.position.x)
			{
				Debug.Log(tile.transform.position.x);
				// Dar dano ao player
				// Debug.Log("Transform do player: " + player.transform.position.x);
				healthPlayer.DamegePlayer();
			}
			// Debug.Log(tile.transform.position.x);

		}
		DesmarcarTiles(GO);		
		RoundManager.EndTurn();
	}
	public void FogoNaTile(List<GameObject> g)
 	{
		foreach(GameObject tile in g)
 		{
 			// Quaternion rotationParticula = new Quaternion(tile.transform.rotation.x, tile.transform.rotation.y, tile.transform.rotation.z, 0f );
 			Quaternion rotationParticula = new Quaternion( -90f, tile.transform.rotation.y, tile.transform.rotation.z, 0f );
            // Instantiate(particulaFogo, tile.transform.position, tile.transform.rotation);
            //Instantiate(particulaAtaque, tile.transform.position, rotationParticula);
 		}
 	}
	
	public void DesmarcarTiles(List<GameObject> GOlist)
	{
		foreach(GameObject tile in GOlist)
		{
			// Remover efeitos da tile
			tile.GetComponent<Tile>().target = false;
		}
	}
	
	public void MarcarTiles(List<GameObject> GOlist)
	{
		
		foreach(GameObject tile in GOlist)
		{
			var actualTile = tile.GetComponent<Tile>();
			actualTile.target = true;
			
		}
		DanoNoPlayer(GOlist);
	}

    public override void GetCurrentTile()
    {		}

    public override Tile GetTargetTile(GameObject target)
    {
	    return target.AddComponent<Tile>();
    }

    public override void ComputeProximityList(float jumpHeight, Tile target)
    {		}

    public override void FindSelectableTiles() 
    {		}

    public override void MoveToTile(Tile tile)
    {		}

    public override void  Move() { // Quando é a vez da grid, este override não é chamado
		// moving = false;
		// Debug.Log("Move() da grid");
		// MarcarTiles(horizontalTiles);
    }

    public override void RemoveSelectableTiles()
    {		}

    public override void CalculatePointVector(Vector3 target)
    {		}

	public override void SetHorizotalVelocity()
    {    	}

	public override Tile FindLowestF(List<Tile> list)
    {
        Tile lowest = list[0]; // Get the first member for lowest Array

        foreach (Tile t in list)
        {
            if (t.f < lowest.f)
            {
                lowest = t;
            }
        }

        list.Remove(lowest);
        return lowest;
    }

	public override Tile FindEndTile(Tile t)
    {
	    return t;
    }

	public override void FindPath(Tile target)
    {		}

	public override void BeginTurn() // Ainda n troca o turno
	{
		gridTurnN += 1; 
		SorteioAtaque();
    }
}