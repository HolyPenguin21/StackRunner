using UnityEngine;
using DG.Tweening;

public class PointerHorizontal : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOLocalMoveX(transform.position.x + 100, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
