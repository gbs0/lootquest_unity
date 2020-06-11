using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aliados : MonoBehaviour
{
    public GameObject Maga;
    public GameObject Bruxa;
    public GameObject Berseker;
    public GameObject Ninja;
    

    public Image VisualAliado;
    public Text Descricao;

    public GameObject DescricaoQuadro;

    public Sprite MagaSprite;
    public Sprite BruxaSprite;
    public Sprite SpriteBerseker;
    public Sprite SprintaNinja;
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {       
        
        
    }

    public void Aliado1()
    {
        if (PlayerPrefs.GetInt("Maga", 0) == 1)
        {
            DescricaoQuadro.SetActive(true);
            VisualAliado.sprite = MagaSprite;
            Descricao.text = "It is Mars, how can a mage help? Stun a enemy of course! ";


        }
    }
    public void Aliado2()
    {
        if (PlayerPrefs.GetInt("Bruxa", 0) == 1)
        {
            DescricaoQuadro.SetActive(true);
            VisualAliado.sprite = BruxaSprite;
            Descricao.text = "It is a ninja, rougue, whatever. Zen can turn the loots that you got better..";

        }
    }
    public void Aliado3()
    {
        if (PlayerPrefs.GetInt("Berseker", 0) == 1)
        {
            DescricaoQuadro.SetActive(true);
            VisualAliado.sprite = SpriteBerseker;
            Descricao.text = "It is small, but can rage like no one! It is Pluto, double your attack!";

        }
    }
    public void Aliado4()
    {
        if (PlayerPrefs.GetInt("Ninja", 0) == 1)
        {
            DescricaoQuadro.SetActive(true);
            VisualAliado.sprite = SprintaNinja;
            Descricao.text = "With this whip you can make some feel pain, others feel... love. ";

        }
    }
    
    
}
