using UnityEngine;

public class ScoreTextManager : Effect
{
    public ScoreTextManager(GameObject scorePrefab, ICharacter character, ICollisionEvent collisionEvent)
    {
        objectPrefab = scorePrefab;
        this.character = character;

        PreparePool(10);

        collisionEvent.Add_OnPickUp_Listener(SpawnObject);
    }
}
