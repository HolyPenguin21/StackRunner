using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBuilder
{
    const float posIterator = 30f;
    int currentPlatformCount = 3;

    Transform cameraTransform;

    GameObject[] platformVariants;

    Transform poolHolder;
    Platform[] platformsPool;

    public TrackBuilder(ICollisionEvent collisionEvent, GameObject[] platformVariants)
    {
        cameraTransform = Camera.main.transform;
        poolHolder = new GameObject("--PlatformsPool").transform;

        this.platformVariants = platformVariants;

        PreparePool(10);
        SpawnPlatform();

        collisionEvent.Add_OnWallPass_Listener(SpawnPlatform);
    }

    private void PreparePool(int count)
    {
        platformsPool = new Platform[count];

        for (int i = 0; i < platformsPool.Length; i++)
        {
            GameObject platform_obj = MonoBehaviour.Instantiate(platformVariants[Random.Range(0, platformVariants.Length)], Vector3.zero, Quaternion.identity, poolHolder);
            platform_obj.SetActive(false);

            Platform platform_sc = platform_obj.GetComponent<Platform>();
            platform_sc.Init(cameraTransform, poolHolder);

            platformsPool[i] = platform_sc;
        }
    }

    private void SpawnPlatform()
    {
        Vector3 startPos = Get_SpawnPosition();
        Vector3 endPos = Get_ResultPosition();

        Platform platform_sc = Get_RandomPlatform_FromPool();
        platform_sc.transform.localPosition = startPos;
        platform_sc.gameObject.SetActive(true);

        platform_sc.MoveOrder(endPos);

        currentPlatformCount++;
    }

    private Platform Get_RandomPlatform_FromPool()
    {
        Platform platform_sc = platformsPool[Random.Range(0, platformsPool.Length)];

        if (platform_sc.gameObject.activeInHierarchy)
        {
            return Get_RandomPlatform_FromPool();
        }
        else
        {
            return platform_sc;
        }
    }

    private Vector3 Get_ResultPosition()
    {
        return new Vector3(0, 0, posIterator * currentPlatformCount);
    }

    private Vector3 Get_SpawnPosition()
    {
        Vector3 camPosition = cameraTransform.position;

        return new Vector3(0, -100, camPosition.z - 5);
    }
}
