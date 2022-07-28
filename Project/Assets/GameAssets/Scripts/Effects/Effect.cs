using UnityEngine;

public abstract class Effect
{
    protected ICharacter character;

    protected GameObject objectPrefab;
    GameObject[] objectsPool;
    Transform objectsHolder;

    public void SpawnObject()
    {
        GameObject someObject = Get_FreeObject();
        someObject.transform.position = character.Get_CurrentMeshPosition();

        someObject.SetActive(true);
    }

    protected void PreparePool(int count)
    {
        objectsPool = new GameObject[count];
        objectsHolder = new GameObject("--Effects_Pool").transform;

        for (int i = 0; i < objectsPool.Length; i++)
        {
            GameObject someObject = MonoBehaviour.Instantiate(objectPrefab, objectsHolder);
            someObject.SetActive(false);

            objectsPool[i] = someObject;
        }
    }

    private GameObject Get_FreeObject()
    {
        foreach (GameObject someObject in objectsPool)
        {
            if (!someObject.activeInHierarchy)
                return someObject;
        }

        Debug.LogError("Missing prefabs, add more into pool");
        return null;
    }
}
