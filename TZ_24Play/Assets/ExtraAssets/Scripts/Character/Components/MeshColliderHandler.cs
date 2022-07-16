using UnityEngine;
using System.Collections;

public class MeshColliderHandler : MonoBehaviour
{
    IGameStateEvents gameStateEvents;
    ICollisionEvent collisionEvent;

    public void Init(IGameStateEvents gameStateEvents, ICollisionEvent collisionEvent)
    {
        this.gameStateEvents = gameStateEvents;
        this.collisionEvent = collisionEvent;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("wallBlock")) return;

        gameStateEvents.Invoke_GameEnd();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("wallPass")) return;
        Debug.Log("asdasd");
        collisionEvent.Invoke_OnWallPass();
    }
}
