using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextManager
{
    Canvas scorePrefab;

    Canvas[] scoreTextPool;
    Transform scoreTextHolder;

    Character character;

    public ScoreTextManager(Canvas scorePrefab, Character character, ICollisionEvent collisionEvent)
    {
        this.scorePrefab = scorePrefab;
        this.character = character;

        PreparePool(10);

        collisionEvent.Add_OnPickUp_Listener(SpawnObject);
    }

    private void PreparePool(int count)
    {
        scoreTextPool = new Canvas[count];
        scoreTextHolder = new GameObject("--Pool_ScoreText").transform;

        for (int i = 0; i < scoreTextPool.Length; i++)
        {
            Canvas scoreText_obj = MonoBehaviour.Instantiate(scorePrefab, scoreTextHolder);
            scoreText_obj.gameObject.SetActive(false);

            scoreTextPool[i] = scoreText_obj;
        }
    }

    public void SpawnObject()
    {
        Canvas scoreText = Get_FreeText();
        scoreText.transform.position = character.Get_CurrentMeshPosition();

        scoreText.gameObject.SetActive(true);
    }

    private Canvas Get_FreeText()
    {
        foreach (Canvas scoreText in scoreTextPool)
        {
            if (!scoreText.gameObject.activeInHierarchy)
                return scoreText;
        }

        Debug.LogError("Missing Canvas prefabs, add more into pool");
        return null;
    }
}
