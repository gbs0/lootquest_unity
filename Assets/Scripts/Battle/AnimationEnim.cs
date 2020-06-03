using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnim : MonoBehaviour
{
    public TempPlayerHp PHP;
    public float Hitforce = 10;
    private void Start()
    {
        PHP = FindObjectOfType<TempPlayerHp>();
    }

    public void DamegePlayer()
    {
        PHP.LifeCheck(Hitforce);
    }
}
