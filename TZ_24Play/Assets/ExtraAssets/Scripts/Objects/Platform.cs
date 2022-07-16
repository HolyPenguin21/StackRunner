using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    [SerializeField] private float bottomMoveTime = 1f;
    [SerializeField] private float topMoveTime = 0.25f;

    Transform poolHolder;
    Transform camTransform;

    public void Init(Transform camTransform, Transform poolHolder)
    {
        this.camTransform = camTransform;
        this.poolHolder = poolHolder;
    }

    public void Move(Vector3 moveToPosition)
    {
        StartCoroutine(Movement(moveToPosition));
    }

    private IEnumerator Movement(Vector3 moveToPosition)
    {
        Vector3 endPos = moveToPosition;
        endPos.y = -10;
        yield return PartialMove(bottomMoveTime, endPos);

        endPos = moveToPosition;
        yield return PartialMove(topMoveTime, endPos);
    }

    private IEnumerator PartialMove(float timer, Vector3 endPos)
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < timer)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / timer));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
    }

    private void Update()
    {
        DisableDistanceCheck();
    }

    private void DisableDistanceCheck()
    {
        float dist = camTransform.position.z - transform.position.z;
        if (dist > 30)
            Disable();
    }

    private void Disable()
    {
        transform.parent = poolHolder;
        gameObject.SetActive(false);
    }
}
