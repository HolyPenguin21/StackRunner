using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    [SerializeField] private float x_range = 1.75f;

    private void OnEnable()
    {
        Vector3 position = transform.localPosition;
        position.x = Random.Range(-x_range, x_range);

        transform.localPosition = position;
    }
}
