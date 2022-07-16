using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ShakeCamera
{
    Transform transform;
    bool isMobile = false;

    public ShakeCamera(Transform transform, ICollisionEvent collisionEvent, IGameStateEvents gameStateEvents, SceneSettings.InputType inputType)
    {
        this.transform = transform;

        if (inputType == SceneSettings.InputType.mobile) isMobile = true;

        collisionEvent.Add_OnWallCollision_Listener(Shake);
        gameStateEvents.Add_GameEndListener(ClearDotween);
    }

    private void Shake()
    {
        transform.DOShakePosition(0.75f, 1f, 1, 90, false, true);

        if (isMobile)
            Handheld.Vibrate();
    }

    private void ClearDotween()
    {
        DOTween.Kill(transform);
    }
}
