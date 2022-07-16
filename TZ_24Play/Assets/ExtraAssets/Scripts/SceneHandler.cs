using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private GameObject pickedBlockPrefab;
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private GameObject[] platformVariants;

    ParticleManager particleManager;
    TrackBuilder sceneBuider;

    IGameStateEvents gameStateEvents;
    ICollisionEvent collisionEvent;

    private void Awake()
    {
        gameStateEvents = new GameStateEvents();
        collisionEvent = new CollisionEvent();

        particleManager = new ParticleManager(particlePrefab, character, collisionEvent);
        sceneBuider = new TrackBuilder(collisionEvent, platformVariants);
    }

    private void Start()
    {
        character.Init(pickedBlockPrefab, gameStateEvents, collisionEvent);

        gameStateEvents.Invoke_GameStart(); // Test
    }

    private void OnDisable()
    {
        gameStateEvents.Remove_Listeners();
        collisionEvent.Remove_Listeners();
    }
}
