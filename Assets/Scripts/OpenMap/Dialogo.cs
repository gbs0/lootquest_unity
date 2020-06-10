using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public GameObject panelBox;
    public GameObject Maga;
    public GameObject Interrogaçao;
    public GameObject Conversa;
    public bool podeFalar = false;
    public bool Guilda = false;
    public bool jafoi = false;


    [SerializeField]
    private int linhaAtual;
    public TextMeshProUGUI textoMensagem;
    public string[] texto;
    public int limitText;
    public int NivelEntrando;


    //public float timer = 0;
    public static bool estaFalando = false;
    [SerializeField]
    private bool teste = false;
    [SerializeField]
    private bool jaComecaFalando;
    [SerializeField]
    // private bool[] Mike = 
    public GameObject img;
    public GameObject[] imgs;
    public int conta;
    public Rigidbody2D PlayerRigi;
    public GameObject Player;
    //[SerializeField]
    //private bool[] ray;
    public bool rodaCut = false;
    void Start()
    {

        textoMensagem.text = texto[linhaAtual].ToString();
        img = imgs[linhaAtual];
        conta = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigi = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (jafoi == false )
      {
        
        if (podeFalar)
        {
            //img.SetActive(false);
            //img = imgs[linhaAtual];
            estaFalando = true;
            

                img.SetActive(false);
                img = imgs[linhaAtual];
                if (img == imgs[linhaAtual])
                {
                    img.SetActive(true);
                }
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                //img.SetActive(false);
                if (linhaAtual >= limitText)
                {

                        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation;
                        Desabilitar();
                    podeFalar = false;
                    linhaAtual = 0;

                }
                linhaAtual++;
                textoMensagem.text = texto[linhaAtual].ToString();
                // img.SetActive(true);
               
            }
            if (linhaAtual == 40)
            {
                //img.SetActive(false);
                Maga.SetActive(true);

            }
            if (linhaAtual >= 43)
            {
                //img.SetActive(false);
                Maga.SetActive(false);

            }
        }
        teste = estaFalando;
      }
    }

    
    public void OnTriggerStay2D(Collider2D collision)
    {
        


            if (collision.gameObject.CompareTag("Player"))
            {
                if (jaComecaFalando)
                {
                PlayerRigi.constraints = RigidbodyConstraints2D.FreezePosition;

                podeFalar = true;
                    Habilitar();
                }
                else if (!jaComecaFalando && Input.GetKeyUp(KeyCode.E))
                {
                PlayerRigi.constraints = RigidbodyConstraints2D.FreezePosition;

                podeFalar = true;
                    Habilitar();

                }
            }
        
    }

    void Habilitar()
    {
        panelBox.SetActive(true);

        //estaFalando = true;
        img.SetActive(true);
    }
    void Desabilitar()
    {
        panelBox.SetActive(false);
            estaFalando = false;
        img.SetActive(false);

        if (Guilda == true)
        {
            PlayerPrefs.SetInt("DialogoGuilda", NivelEntrando);
        
        }

        jafoi = true;
        Interrogaçao.SetActive(false);
        Conversa.SetActive(false);


    }
    public void ativaSprite()
    {

    }
}
