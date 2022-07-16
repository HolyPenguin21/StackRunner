using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    Vector3 resultPos;

    public void Init(Vector3 resultPos)
    {
        this.resultPos = resultPos;

        StartCoroutine(Move_ToEndPosition(3f));
    }

    private IEnumerator Move_ToEndPosition(float time)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = resultPos;
        endPos.y = -10;

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
