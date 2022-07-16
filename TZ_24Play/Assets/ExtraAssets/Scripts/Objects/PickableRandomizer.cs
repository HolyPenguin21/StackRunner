using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableRandomizer : MonoBehaviour
{
    [SerializeField] private float x_range = 1.75f;

    private void Awake()
    {
        transform.localPosition = new Vector3(Random.Range(-x_range, x_range), transform.localPosition.y, transform.localPosition.z);
    }
}
