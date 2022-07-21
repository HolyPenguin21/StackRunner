using UnityEngine;
using DG.Tweening;

public class PointerHorizontal : MonoBehaviour
{
    [SerializeField] RectTransform sliderImage;
    RectTransform rectTransform;

    [SerializeField] private float offset = 20f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        float x_Pos = rectTransform.localPosition.x + sliderImage.rect.width - offset;
        rectTransform.DOLocalMoveX(x_Pos, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
