using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParticleLauncher : MonoBehaviour
{
    public ParticleSystem particula;
    // Start is called before the first frame update
    void Start()
    {
        particula.Emit(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
