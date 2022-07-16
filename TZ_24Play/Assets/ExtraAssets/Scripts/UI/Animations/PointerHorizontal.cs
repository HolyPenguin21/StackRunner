using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointerHorizontal : MonoBehaviour
{
    private void Start()
    {
        transform.DOLocalMoveX(transform.position.x - 5f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
