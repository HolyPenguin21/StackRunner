using UnityEngine;

public class ParticleManager : Effect
{
    public ParticleManager(GameObject particlePrefab, ICharacter character, ICollisionEvent collisionEvent)
    {
        objectPrefab = particlePrefab;
        this.character = character;

        PreparePool(10);

        collisionEvent.Add_OnPickUp_Listener(SpawnObject);
    }
}
