using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoCombate : MonoBehaviour
{
    public GameObject panelBox;
    public GameObject Combate;
    public Rigidbody2D PlayerRigi;
    public GameObject Player;

    public GameObject Interrogaçao;
    public GameObject Conversa;
    public bool podeFalar = false;
    [SerializeField]
    private int linhaAtual;
    public TextMeshProUGUI textoMensagem;
    public string[] texto;
    public int limitText;
    public bool jafoi = false;

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
    public bool vit;
    //[SerializeField]
    //private bool[] ray;
    public bool rodaCut = false;
    void Start()
    {

        textoMensagem.text = texto[linhaAtual].ToString();
        img = imgs[linhaAtual];
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigi = Player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (jafoi == false)
        {
            if (podeFalar)
            {
                estaFalando = true;


                img.SetActive(false);
                img = imgs[linhaAtual];
                if (img == imgs[linhaAtual])
                {
                    img.SetActive(true);
                }


                if (Input.GetKeyDown(KeyCode.E))
                {
                    linhaAtual++;

                    if (linhaAtual >= limitText)
                    {
                        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation; Desabilitar();
                        podeFalar = false;
                        linhaAtual = 0;

                    }
                    textoMensagem.text = texto[linhaAtual].ToString();

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
            else if (!jaComecaFalando)
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
        img.SetActive(false);

        panelBox.SetActive(false);
        estaFalando = false;
        Interrogaçao.SetActive(false);
        Combate.SetActive(true);
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation;
        Conversa.SetActive(false);
        if (vit == true)
        {
            Application.LoadLevel("Vitoria");

        }
    }

}
