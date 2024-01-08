using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleElement : MonoBehaviour
{
    public string P_ELEMENT_ID;

    public bool isMultiple;
    [SerializeField] private ParticleData[] particles;
    
    public ParticleData GetByID(string ID)
    {
        return particles.First(x => x.PARTICLE_ID == ID);
    }
    public ParticleData[] GetAll() => particles;


}
[System.Serializable]
public class ParticleData
{
    public string PARTICLE_ID;
    public ParticleSystem particle;

    public void Play() { particle.Play(); }
    public void Stop() { particle.Stop(); }

}
