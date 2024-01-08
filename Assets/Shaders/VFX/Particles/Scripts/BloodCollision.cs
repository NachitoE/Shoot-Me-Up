using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCollision : MonoBehaviour
{
    private ParticleSystem part;

    public List<ParticleCollisionEvent> currentParticles = new();

    private void OnParticleCollision(GameObject other)
    {
        part = GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> collisionEvents = new();

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            for(int e = 0; e < currentParticles.Count; e++)
            {
                if (collisionEvents[i] .intersection == currentParticles[e].intersection)
                    return;
            }
            currentParticles.Add(collisionEvents[i]);
            BloodPoolController.instance.SetNewStain(collisionEvents[i].intersection, collisionEvents[i].normal);
            Vector3 collisionPosition = collisionEvents[i].intersection;

            Debug.Log("Partícula colisionó en la posición: " + collisionPosition);
        }
    }
}