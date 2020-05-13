using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour
{
    public  Animator PlayerAnim;
    private static Animator Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = PlayerAnim;
    }
    public static void PositiveReact()
    {
        Player.SetTrigger("PositiveReact");

    }
    public static void NegativeReact()
    {
        Player.SetTrigger("NegativeReact");

    }
}
