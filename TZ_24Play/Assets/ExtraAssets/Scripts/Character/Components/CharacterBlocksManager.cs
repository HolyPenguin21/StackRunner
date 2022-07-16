using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBlocksManager
{
    GameObject prefab;

    CharacterBlock[] blocksPool;
    Transform blocksHolder;

    public CharacterBlocksManager(GameObject prefab, Transform blocksHolder, ICollisionEvent collisionEvent)
    {
        this.prefab = prefab;
        this.blocksHolder = blocksHolder;

        PreparePool(20, collisionEvent);
    }

    private void PreparePool(int count, ICollisionEvent collisionEvent)
    {
        blocksPool = new CharacterBlock[count];

        for (int i = 0; i < blocksPool.Length; i++)
        {
            GameObject block_obj = MonoBehaviour.Instantiate(prefab, blocksHolder);
            block_obj.SetActive(false);

            CharacterBlock block_sc = block_obj.GetComponent<CharacterBlock>();
            block_sc.Init(blocksHolder, collisionEvent);

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
        foreach (CharacterBlock block in blocksPool)
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
