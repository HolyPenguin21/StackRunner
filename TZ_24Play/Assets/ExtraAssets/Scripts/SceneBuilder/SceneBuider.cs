using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuider
{
    const float posIterator = 30f;
    int currentPlatformCount = 0;

    Transform trackHolder;
    Transform cameraTransform;

    GameObject platformPrefab;
    GameObject[] wallPrefabs;

    public SceneBuider(ICollisionEvent collisionEvent, GameObject platformPrefab, GameObject[] wallPrefabs)
    {
        cameraTransform = Camera.main.transform;

        this.platformPrefab = platformPrefab;
        this.wallPrefabs = wallPrefabs;

        trackHolder = new GameObject("TrackHolder").transform;

        collisionEvent.Add_OnWallCollision_Listener(SpawnPlatform);

        Spawn_InitialPlatforms();
    }

    private void Spawn_InitialPlatforms()
    {
        GameObject platform = MonoBehaviour.Instantiate(platformPrefab, Vector3.zero, Quaternion.identity, trackHolder);

        currentPlatformCount++;

        SpawnPlatform();
    }

    private void SpawnPlatform()
    {
        Vector3 startPos = Get_SpawnPosition();
        Vector3 resultPos = Get_ResultPosition();

        GameObject platform = MonoBehaviour.Instantiate(platformPrefab, startPos, Quaternion.identity, trackHolder);
        PlatformMover platformMover = platform.GetComponent<PlatformMover>();
        platformMover.Init(resultPos);

        currentPlatformCount++;
    }

    private Vector3 Get_ResultPosition()
    {
        return new Vector3(0, 0, posIterator * currentPlatformCount);
    }

    private Vector3 Get_SpawnPosition()
    {
        Vector3 camPosition = cameraTransform.position;

        return new Vector3(0, -10, camPosition.z - 5);
    }
}
