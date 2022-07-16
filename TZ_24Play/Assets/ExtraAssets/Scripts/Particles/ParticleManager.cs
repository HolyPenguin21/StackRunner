using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager
{
    GameObject particlePrefab;

    GameObject[] particlesPool;
    Transform particlesHolder;

    Character character;

    public ParticleManager(GameObject particlePrefab, Character character, ICollisionEvent collisionEvent)
    {
        this.particlePrefab = particlePrefab;
        this.character = character;

        PreparePool(10, collisionEvent);

        collisionEvent.Add_OnPickUp_Listener(SpawnObject);
    }

    private void PreparePool(int count, ICollisionEvent collisionEvent)
    {
        particlesPool = new GameObject[count];
        particlesHolder = new GameObject("--Pool_Particles").transform;

        for (int i = 0; i < particlesPool.Length; i++)
        {
            GameObject particle_obj = MonoBehaviour.Instantiate(particlePrefab, particlesHolder);
            particle_obj.SetActive(false);

            particlesPool[i] = particle_obj;
        }
    }

    public void SpawnObject()
    {
        GameObject particle = Get_FreeParticle();
        particle.transform.position = character.Get_CurrentMeshPosition();

        particle.SetActive(true);
    }

    private GameObject Get_FreeParticle()
    {
        foreach (GameObject particle in particlesPool)
        {
            if (!particle.activeInHierarchy)
                return particle;
        }

        Debug.LogError("Missing particle prefabs, add more into pool");
        return null;
    }
}
