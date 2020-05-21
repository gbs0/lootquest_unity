using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCenario : MonoBehaviour
{
     
    SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;  // Retorno da cor em float m_r, m_g, m_b

    Color corFinal = new Color(0f ,0f, 0f, 0f);
    private GameObject[] arvores;
    private GameObject[] particulasFogo;
    private ParticleSystem particula;

    void Awake()
    {  
       // Pegar <Component> Cor
       // m_SpriteRenderer = GetComponent<SpriteRenderer>();
       // SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
       // Color spriteColor = gameObject.GetComponent<SpriteRenderer>().color;

    } 

    void Start()
    {
        if (arvores == null)
        {
           arvores = GameObject.FindGameObjectsWithTag("Trees");      
        } 

        if (particulasFogo == null)
        {
            particulasFogo = GameObject.FindGameObjectsWithTag("FireParticles");
        }
	    
        if (arvores.Length == 0)
	    {
           Debug.Log("Nenhuma Arvore no Array[]");
        }

        foreach (GameObject arvore in arvores) 
        {
            // m_SpriteRenderer.color = Color.blue;
            // spriteColor = Color.blue;
            // spriteColor = corFinal;
        }

        foreach (GameObject particulaFogo in particulasFogo) // Mudar a cor das arvores && Iniciar particula de fogo
        {  
            particula = particulaFogo.GetComponent<ParticleSystem>();
            particula.Emit(1);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
