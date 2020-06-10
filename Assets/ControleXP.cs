using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleXP : MonoBehaviour
{
    int m_XP;
    // Start is called before the first frame update
    void Start()
    {
        m_XP = PlayerPrefs.GetInt("_xp", 0);
        SetXP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetXP()
    {
        while(m_XP < 200)
        {
            return;
        }

        
    }
}
