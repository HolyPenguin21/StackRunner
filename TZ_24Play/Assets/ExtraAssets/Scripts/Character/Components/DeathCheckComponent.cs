using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheckComponent : MonoBehaviour
{
    IGameStateEvents gameStateEvents;

    public void Init(IGameStateEvents gameStateEvents)
    {
        this.gameStateEvents = gameStateEvents;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("wallBlock")) return;

        gameStateEvents.Invoke_GameEnd();
    }
}
