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
	public bool vulneravel = false;
	public Slider dragaoHealthBar;
	public int vidaBoss;
	public int danoLateral;
	
	public AudioSource fireSound;
	int gridTurnN;
	public List<GameObject> backTiles = new List<GameObject>();
	public List<GameObject> sideTiles = new List<GameObject>();
	public List<GameObject> centerTiles = new List<GameObject>();

	List<List<GameObject>> sorteioAtual;
	
	// public GameObject[] sorteioAtual;

	// public Animator ataqueBoss;
	// public Animator camAnim;
	// public Animator danoBoss;

	public ParticleSystem particulaAtaque;
	public GameObject player; // Pegar Transform do Player
	private List<ParticleSystem> listP;

	public TempDistCheckDragao tempDistCheck;	
	// Dictionary<string, GameObject> myDictionaryObjects = new Dictionary<string, GameObject>();
	private void Start()
	{
		tempDistCheck.selectable = false;
		gridTurnN = 0;
		listP = new List<ParticleSystem>();
		sorteioAtual = new List<List<GameObject>>();
		Init();
	}

	public override void BeginTurn() // Ainda n troca o turno
	{
		if (gridTurnN == 0)
		{
			SorteioAtaque();
			gridTurnN += 1;
			vulneravel = true;
			tempDistCheck.canHit = true;
			MarcarTiles(sorteioAtual[0]); // Marca a tile a partir do sorteio da lista
			return;
		}

		if (gridTurnN == 1)
		{
			AtaqueTiles(sorteioAtual[0]);
			gridTurnN += 1;
			return;
		}

		if (gridTurnN >= 2)
		{
			turn = false;
			gridTurnN = 0;
			vulneravel = true;
			sorteioAtual.Clear();
			RoundManager.EndTurn();
			Debug.Log("Esperei um round");
		}
		else
		{
			Debug.Log("O round quebrou");

		}
	}

	public void SorteioAtaque()
	{
		int num = Random.Range(0, 3);
	
			switch (num)
			{
			case 3:
				print("IMPOSSIBLE");
				break;
			case 2:
				sorteioAtual.Add(sideTiles);
				break;
			case 1:
				sorteioAtual.Add(centerTiles);
				break;
			case 0:
				sorteioAtual.Add(backTiles);
				break;
			}	
		// }

		// else {
		// 	gridTurnN += 1; 
		// }
 	}

	public void AtaqueTiles(List<GameObject> tilesList)
	{
		DanoNoPlayer(tilesList);
		StartCoroutine("DesmarcarTiles", tilesList);		
 	}

	public void MarcarTiles(List<GameObject> GOlist)
	{
		
		foreach(GameObject tile in GOlist)
		{
			var actualTile = tile.GetComponent<Tile>();
			actualTile.target = true;
			
		}
		RoundManager.EndTurn();
	}

	public void DanoNoPlayer(List<GameObject> GOlist)
	{
		// playTransform playerTrans = GO.transform.position.x;
		// Debug.Log(player.transform.position.x);

		foreach(GameObject tile in GOlist) // Comparar com posição atual do player nas tiles
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
		fireSound.Play();
		StartCoroutine("FogoNaTile", GOlist);
	}

	IEnumerator FogoNaTile(List<GameObject> GOlist)
	{

		foreach(GameObject tile in GOlist)
		{
            // Quaternion rotationParticula = new Quaternion(tile.transform.rotation.x, tile.transform.rotation.y, tile.transform.rotation.z, 0f );
            Quaternion rotationParticula = new Quaternion( -45f, tile.transform.rotation.y, tile.transform.rotation.z, 0f);
            // Instantiate(particulaFogo, tile.transform.position, tile.transform.rotation);
            var p =Instantiate(particulaAtaque, tile.transform.position, Quaternion.Euler(-90f,0f,0f));
            listP.Add(p);
		}
		yield return new WaitForSeconds(2.0f);
	}

	IEnumerator DesmarcarTiles(List<GameObject> GOlist)
    {
		string[] fogos = new string[]{"CFX4 Fire(Clone)"};
		
		yield return new WaitForSeconds(2.0f);

		foreach(GameObject tile in GOlist)
		{
			// Remover efeitos da tile
			tile.GetComponent<Tile>().target = false;

			foreach (string name in fogos)
			{
            	GameObject go = GameObject.Find(name);
				// print(go);
                 //if the tree exist then destroy it
            	Destroy (go.gameObject);
				if (go)
				{
					Destroy(GameObject.Find(name));
					Destroy(go);	
				}
            }
		}

		foreach (var particle in listP)
		{
			Destroy(particle.gameObject);
		}
		listP.Clear();
		turn = false;
		RoundManager.EndTurn();
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

}