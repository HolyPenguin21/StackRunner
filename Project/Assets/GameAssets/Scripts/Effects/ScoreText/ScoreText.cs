using System.Collections;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    [SerializeField] private float speed = 5f;

    RectTransform rectTransform;
    Vector3 up = Vector3.up;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        float curTime = 0;

        while (curTime < timer)
        {
            MoveUp();

            curTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }

    private void MoveUp()
    {
        rectTransform.transform.position += up * Time.deltaTime * speed;
    }
}
