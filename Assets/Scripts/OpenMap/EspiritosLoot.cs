using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspiritosLoot : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public GameObject Espirito;
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
    void OnTriggerStay2D(Collider2D theCollision)
    {
        if (theCollision.gameObject.tag == "Player")
        {
            if (timeStart1 >= TempoAnimacao)
            {
                if (PlayerPrefs.GetInt("WhispersofLoot", 0) == 0)
                {
                    Espirito.SetActive(true);
                }
            }
        }
    }
}