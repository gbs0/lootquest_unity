using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChecker : MonoBehaviour
{
    public GameObject menuprefab;

    public OptionsMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<OptionsMenu>();
        if (menu==null)
        {
            Instantiate(menuprefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
