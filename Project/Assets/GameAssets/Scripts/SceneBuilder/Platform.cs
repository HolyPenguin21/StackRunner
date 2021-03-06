using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    const float hideDistance = 45f;

    [SerializeField] private float bottomMoveTimer = 1f;
    [SerializeField] private float topMoveTimer = 0.25f;

    Transform poolHolder;
    Transform camTransform;

    PositionRandomizer[] pickableObjects;

    private void Awake()
    {
        pickableObjects = GetComponentsInChildren<PositionRandomizer>();
    }

    public void Init(Transform camTransform, Transform poolHolder)
    {
        this.camTransform = camTransform;
        this.poolHolder = poolHolder;
    }

    public void MoveOrder(Vector3 moveToPosition)
    {
        StartCoroutine(Movement(moveToPosition));
    }

    private IEnumerator Movement(Vector3 moveToPosition)
    {
        Vector3 endPos = moveToPosition;
        endPos.y = -10;
        yield return PartialMove(bottomMoveTimer, endPos);

        endPos = moveToPosition;
        yield return PartialMove(topMoveTimer, endPos);
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
        if (dist > hideDistance)
            DisablePlatform();
    }

    private void DisablePlatform()
    {
        transform.parent = poolHolder;
        EnablePickables();

        gameObject.SetActive(false);
    }

    private void EnablePickables()
    {
        foreach (PositionRandomizer obj in pickableObjects)
        {
            obj.gameObject.SetActive(true);
        }
    }
}
