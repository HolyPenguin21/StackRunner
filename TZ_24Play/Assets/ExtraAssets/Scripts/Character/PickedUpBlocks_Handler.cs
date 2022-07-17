using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpBlocks_Handler
{
    GameObject prefab;

    PickedUpBlock[] blocksPool;
    Transform blocksHolder;

    public PickedUpBlocks_Handler(GameObject prefab, Transform blocksHolder, ICollisionEvent collisionEvent, IBoostEvent boostEvent)
    {
        this.prefab = prefab;
        this.blocksHolder = blocksHolder;

        PreparePool(20, collisionEvent, boostEvent);
    }

    private void PreparePool(int count, ICollisionEvent collisionEvent, IBoostEvent boostEvent)
    {
        blocksPool = new PickedUpBlock[count];

        for (int i = 0; i < blocksPool.Length; i++)
        {
            GameObject block_obj = MonoBehaviour.Instantiate(prefab, blocksHolder);
            block_obj.SetActive(false);

            PickedUpBlock block_sc = block_obj.GetComponent<PickedUpBlock>();
            block_sc.Init(blocksHolder, collisionEvent, boostEvent);

            blocksPool[i] = block_sc;
        }
    }

    public void SpawnBlock(int blockCount)
    {
        GameObject block = Get_FreeBlock();
        block.transform.localPosition = Set_SpawnPosition(blockCount);
        block.transform.ResetRotation();

        block.SetActive(true);
    }

    private GameObject Get_FreeBlock()
    {
        foreach (PickedUpBlock block in blocksPool)
        {
            if (!block.gameObject.activeInHierarchy)
                return block.gameObject;
        }

        Debug.LogError("Missing blocks, add more into pool");
        return null;
    }

    private Vector3 Set_SpawnPosition(int blockCount)
    {
        Vector3 resultPos = blocksHolder.localPosition;
        resultPos.y = blockCount;

        return resultPos;
    }
}
