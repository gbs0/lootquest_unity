using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasasDialogosFix : MonoBehaviour
{
    public int House = 0;

    public GameObject Dialogo1;
    public GameObject Dialogo2;
    public GameObject Dialogo3;
    public GameObject Dialogo4;
    public GameObject Dialogo5;
    public GameObject DialogoGeral;
    public GameObject conversa;

    // Start is called before the first frame update
    void Start()
    {
        Dialogo1.SetActive(false);
        Dialogo2.SetActive(false);
        Dialogo3.SetActive(false);
        Dialogo4.SetActive(false);
        Dialogo5.SetActive(false);
        DialogoGeral.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Houses")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Colocar aqui o código que aciona os respectivos diálogos.
                HouseDialog();
                House++;
            }
        }
        
    }

    private void HouseDialog()
    {
        if (House == 3)
        {
            Dialogo1.SetActive(true);
            Dialogo2.SetActive(false);
            Dialogo3.SetActive(false);
            Dialogo4.SetActive(false);
            Dialogo5.SetActive(false);
            DialogoGeral.SetActive(false);
        }
        else if (House == 6)
        {
            Dialogo1.SetActive(false);
            Dialogo2.SetActive(true);
            Dialogo3.SetActive(false);
            Dialogo4.SetActive(false);
            Dialogo5.SetActive(false);
            DialogoGeral.SetActive(false);
        }
        else if (House == 9)
        {
            Dialogo1.SetActive(false);
            Dialogo2.SetActive(false);
            Dialogo3.SetActive(true);
            Dialogo4.SetActive(false);
            Dialogo5.SetActive(false);
            DialogoGeral.SetActive(false);
        }
        else if (House == 12)
        {
            Dialogo1.SetActive(false);
            Dialogo2.SetActive(false);
            Dialogo3.SetActive(false);
            Dialogo4.SetActive(true);
            Dialogo5.SetActive(false);
            DialogoGeral.SetActive(false);
        }
        else if (House == 15)
        {
            Dialogo1.SetActive(false);
            Dialogo2.SetActive(false);
            Dialogo3.SetActive(false);
            Dialogo4.SetActive(false);
            Dialogo5.SetActive(true);
            DialogoGeral.SetActive(false);
        }
        else if (House >= 18)
        {
            Dialogo1.SetActive(false);
            Dialogo2.SetActive(false);
            Dialogo3.SetActive(false);
            Dialogo4.SetActive(false);
            Dialogo5.SetActive(false);
            DialogoGeral.SetActive(true);
        }
    }
}
