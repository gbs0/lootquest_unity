using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject missao0;
    public GameObject missao1;
    public GameObject missao2;
    public GameObject missao3;
    public GameObject missao4;

    // Start is called before the first frame update
    void Start()
    {
        missao0.SetActive(true);
        missao1.SetActive(false);
        missao2.SetActive(false);
        missao3.SetActive(false);
        missao4.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 1)
        {
            missao0.SetActive(false);
            missao1.SetActive(true);
            missao2.SetActive(false);
            missao3.SetActive(false);
            missao4.SetActive(false);

        }

        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 4)
        {
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(true);
            missao3.SetActive(false);
            missao4.SetActive(false);

        }
        

        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 5)
        {
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(true);
            missao4.SetActive(false);


        }

        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 6)
        {
            missao0.SetActive(false);
            missao1.SetActive(false);
            missao2.SetActive(false);
            missao3.SetActive(false);
            missao4.SetActive(true);

        }
    }
}
