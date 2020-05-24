using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaitGrid : NPCMove
{
    // private float distance;
    public List<GameObject> TPTarguets;

    // Posiveis posições de ataques de tile
    public List<GameObject> backTiles = new List<GameObject>();
	
	public List<GameObject> verticalTiles = new List<GameObject>();
    
    public static AtaqueGrid ataqueGrid; // Referecia do script da grid
    
    private void Awake ()
    {
        ataqueGrid = GetComponent<AtaqueGrid>();
    }
    
    public override void Update()
    {
        if (!turn) // Se não for o turno ainda
        {
            return;
        }

        
        if (!moving) // Se ñ estiver movendo
        {
            // Marca na Grid qual será o proximo ataque de tiles
            
            // Debug.Log("!moving Caitgrid)");
            // ataqueGrid.MarcarTiles(backTiles);
            Move();
        }

        else // Vez da Grid
        {
            // ataqueGrid.AtaqueHorizontal(backTiles);
            // RemoveSelectableTiles();
            // Sorteia qual sera o proximo ataque e marca nas tiles
            // ataqueGrid.MarcarTiles(backTiles);
            moving = false;
            
            Debug.Log("Vez da grid!");
            
            /* Se o npc puder atacar
            if (tempDistCheck.distTotal >= tempDistCheck.atkDistance)
            {
                if (tempDistCheck.distTotal >= 6f)
                {
                    StartCoroutine("MoveAnim");
                }
            Move();
            }
            else
            {
           
            }
            */
        }

        
    }
    public override void FindNearestTarget()
    {
        
    }

}
