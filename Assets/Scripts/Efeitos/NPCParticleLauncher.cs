using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCParticleLauncher : MonoBehaviour
{
    public static NPCParticleLauncher instance;
    
    public List<GameObject> particulasList = new List<GameObject>();

    public ParticleSystem particulaInicio;
    public ParticleSystem particulaDano;

    public void StartParticle()
    {
        GameObject particula = particulasList[0];
        particula.SetActive(true);
        particulaInicio.Emit(1);
    }

    public void DamageParticle()
    {
        GameObject particula = particulasList[1];
        particula.SetActive(true);
        particulaDano.Emit(1);
    }

    public void SetFalse(GameObject particleObject)
    {
        particleObject.SetActive(false);
        return;
    }

    public void SetTrue(GameObject particleObject)
    {
        particleObject.SetActive(true);
        return;
    }

}