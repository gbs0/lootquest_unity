using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrucaoAnimacao : MonoBehaviour
{ 
    // Start is called before the first frame update
    Animator animator;

    public float timeStart1;
    public int TempoAnimacao;
// Start is called before the first frame update
private void Awake()
{
    //cache the animator component
    animator = GetComponent<Animator>();
}
void Start()
{

}

// Update is called once per frame
void Update()
{
    timeStart1 += Time.deltaTime;

    if (timeStart1 >= TempoAnimacao)
    {
        animator.Play("Idle");
        timeStart1 = 0;
    }
   
}
}