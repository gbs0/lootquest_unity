using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public OptionsMenu OM;

    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        
        btn.onClick.AddListener(MenuO);
    }

    private void MenuO()
    {
        OM = FindObjectOfType<OptionsMenu>();
        OM.OpenMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
