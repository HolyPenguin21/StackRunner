using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent
{
    Transform transform;

    float baseSpeed = 7.5f;
    float currentSpeed;
    float boostSpeed = 10f;

    bool canMove = false;
    bool isBoosted = false;

    public MoveComponent(Transform transform, float baseSpeed, float boostSpeed, IGameStateEvents gameStateEvents, IBoostEvent boostEvent)
    {
        this.transform = transform;

        this.baseSpeed = baseSpeed;
        this.boostSpeed = boostSpeed;
        currentSpeed = baseSpeed;

        gameStateEvents.Add_GameStartListener(Allow_Movement);
        gameStateEvents.Add_GameEndListener(Disallow_Movement);
        gameStateEvents.Add_GameRestartListener(Disallow_Movement);

        boostEvent.Add_OnBoost_Listener(Boost);
    }

    public void Allow_Movement()
    {
        canMove = true;
    }

    public void Disallow_Movement()
    {
        canMove = false;
    }

    public void Move()
    {
        if (!canMove) return;
        if (isBoosted) Reduce_BoostEffect();

        transform.position += transform.forward * Time.deltaTime * currentSpeed;
    }

    private void Boost()
    {
        currentSpeed = boostSpeed;
        isBoosted = true;
    }

    private void Reduce_BoostEffect()
    {
        currentSpeed -= Time.deltaTime;

        if (currentSpeed > baseSpeed) return;

        currentSpeed = baseSpeed;
        isBoosted = false;
    }
}
