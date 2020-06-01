using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject PortalMap;
    public Rigidbody2D PlayerRigi;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigi = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {



        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("DialogoGuilda", 0) == 7)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerRigi.constraints = RigidbodyConstraints2D.FreezePosition;
                PortalMap.SetActive(true);

            }

        }
    }
    public void Sair()
    {
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        PlayerRigi.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        PlayerRigi.constraints = RigidbodyConstraints2D.FreezeRotation;
        PortalMap.SetActive(false);

    }

}
