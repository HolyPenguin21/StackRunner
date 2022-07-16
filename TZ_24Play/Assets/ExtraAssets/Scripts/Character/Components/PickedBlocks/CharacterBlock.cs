using System.Collections;
using UnityEngine;

public class CharacterBlock : MonoBehaviour
{
    Transform _transform;
    Transform parent;

    bool canCollide = true;
    float raycastLength = 0.6f;
    RaycastHit hit;

    ICollisionEvent collisionEvent;

    private void Awake()
    {
        _transform = transform;
        raycastLength = _transform.localScale.x / 2 + 0.05f;
    }

    private void OnEnable()
    {
        canCollide = true;
    }

    public void Init(Transform parent, ICollisionEvent collisionEvent)
    {
        this.parent = parent;
        this.collisionEvent = collisionEvent;
    }

    private void FixedUpdate()
    {
        CollisionCheck();
    }

    private void CollisionCheck()
    {
        if (!canCollide) return;

        if (Physics.Raycast(_transform.position, _transform.forward, out hit, raycastLength))
        {
            if (hit.collider.CompareTag("wallBlock"))
                StartCoroutine(HandleCollision());
        }
    }

    private IEnumerator HandleCollision()
    {
        canCollide = false;
        _transform.parent = null;

        collisionEvent.Invoke_OnWallCollision();

        yield return new WaitForSeconds(10f);

        _transform.parent = parent;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("pickableBlock")) return;

        collisionEvent.Invoke_OnPickUp();

        collider.gameObject.SetActive(false);
    }
}
