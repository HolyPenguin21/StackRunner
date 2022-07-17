using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOScale(3, 2f);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
