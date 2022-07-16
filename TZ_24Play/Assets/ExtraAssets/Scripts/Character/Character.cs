using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float boostSpeed = 10f;

    Transform _transform;
    Transform meshTransform;
    Transform blocksHolder;

    AnimatorComponent animatorComponent;
    RagdollComponent ragdollComponent;
    MoveComponent moveComponent;
    MeshColliderHandler meshColliderHandler;

    CharacterBlocksManager pickedBlocksManager;

    IBoostEvent boostEvent;
    ICollisionEvent collisionEvent;
    IGameStateEvents gameStateEvents;

    int blockCount = 0;

    private void Awake()
    {
        _transform = transform;
        meshTransform = transform.Find("Stickman").GetComponent<Transform>();
        blocksHolder = transform.Find("BlocksHolder").transform;

        meshColliderHandler = meshTransform.GetComponent<MeshColliderHandler>();

        boostEvent = new BoostEvent();
    }

    public void Init(GameObject pickedBlockPrefab, IGameStateEvents gameStateEvents, ICollisionEvent collisionEvent)
    {
        this.gameStateEvents = gameStateEvents;
        this.collisionEvent = collisionEvent;

        animatorComponent = new AnimatorComponent(meshTransform, collisionEvent);
        ragdollComponent = new RagdollComponent(meshTransform, gameStateEvents);
        moveComponent = new MoveComponent(_transform, moveSpeed, boostSpeed, gameStateEvents, boostEvent);
        meshColliderHandler.Init(gameStateEvents, collisionEvent);

        pickedBlocksManager = new CharacterBlocksManager(pickedBlockPrefab, blocksHolder, collisionEvent);

        collisionEvent.Add_OnWallCollision_Listener(Remove_Block);
        collisionEvent.Add_OnPickUp_Listener(Add_Block);

        Add_Block();
    }

    private void FixedUpdate()
    {
        moveComponent.Move();
    }

    private void Add_Block()
    {
        pickedBlocksManager.SpawnBlock(blockCount);
        meshTransform.localPosition += Vector3.up;
        blockCount++;
    }

    private void Remove_Block()
    {
        blockCount--;

        if (blockCount <= 0)
        {
            gameStateEvents.Invoke_GameEnd();
            return;
        }
    }

    public Vector3 Get_CurrentMeshPosition()
    {
        return meshTransform.position;
    }

    private void OnDisable()
    {
        boostEvent.Remove_Listeners();

        DOTween.Kill(meshTransform);
    }
}
