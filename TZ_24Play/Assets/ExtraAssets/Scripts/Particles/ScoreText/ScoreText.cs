using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    RectTransform rectTransform;
    Vector3 up = Vector3.up;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectTransform.transform.position += up * Time.deltaTime * 5f;
    }

    [SerializeField] private float timer = 5f;
    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}
