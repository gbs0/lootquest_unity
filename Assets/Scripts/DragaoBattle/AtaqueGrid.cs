using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueGrid : MonoBehaviour
{
	public Slider dragaoHealthBar;
	
	public int vidaBoss;
	public int danoLateral;
	

	// public Animator ataqueBoss;
	// public Animator camAnim;
	// public Animator danoBoss;

	public ParticleSystem particulaAtaque;

	// Pegar Transform do Player
	public GameObject player;

	public List<GameObject> backTiles = new List<GameObject>();
	public List<GameObject> horizontalTiles = new List<GameObject>();
	public List<GameObject> verticalTiles = new List<GameObject>();
		
	// Dictionary<string, GameObject> myDictionaryObjects = new Dictionary<string, GameObject>();

	private void Start()
	{
		AtaqueTraseiro();
		AtaqueHorizontal();
	}

	private void Update()
	{
		// dragaoHealthBar.value = vidaBoss;
	}

 	public void AtaqueHorizontal()
	{
		// Sortear qual será o Objeto de Row.transform.position.z entre [-1 ... 4]
 		

		FogoNaTileAnim(horizontalTiles);
			
	}

	public void AtaqueTraseiro()
 	{
 		// Animate Dragon's attack
		

		
 		
		 
		foreach(GameObject tile in backTiles) // Comparar com posição atual do player nas tiles
		{
			// Debug.Log(tile.transform.position.x);

			if(player.transform.position.x == tile.transform.position.x)
			{
				// Dar dano ao player
				Debug.Log("Transform do player: " + player.transform.position.x);
				
				DanoNoPlayer(player);
			}
		}
		
		/*
		foreach(GameObject tile in backTiles)
 		{
 			// Quaternion rotationParticula = new Quaternion(tile.transform.rotation.x, tile.transform.rotation.y, tile.transform.rotation.z, 0f );
 			Quaternion rotationParticula = new Quaternion( -90f, tile.transform.rotation.y, tile.transform.rotation.z, 0f );
            // Instantiate(particulaFogo, tile.transform.position, tile.transform.rotation);
            Instantiate(particulaAtaque, tile.transform.position, rotationParticula);
 		}
		*/
		
 	}

 	public void FogoNaTileAnim(List<GameObject> GOlist)
 	{
		foreach(GameObject tile in GOlist)
 		{
 			// Quaternion rotationParticula = new Quaternion(tile.transform.rotation.x, tile.transform.rotation.y, tile.transform.rotation.z, 0f );
 			Quaternion rotationParticula = new Quaternion( -90f, tile.transform.rotation.y, tile.transform.rotation.z, 0f );
            // Instantiate(particulaFogo, tile.transform.position, tile.transform.rotation);
            Instantiate(particulaAtaque, tile.transform.position, rotationParticula);
 		}
 	}
	
	public void DanoNoPlayer(GameObject GO)
	{
		// playTransform playerTrans = GO.transform.position.x;
	}
}