using UnityEngine;

public class MoveComponent
{
    Transform _transform;

    float baseSpeed = 7.5f;
    float currentSpeed;
    float boostSpeed = 10f;

    bool canMove = false;
    bool isBoosted = false;

    public MoveComponent(Transform transform, float baseSpeed, float boostSpeed, IGameStateEvents gameStateEvents, IBoostEvent boostEvent, IInputEvent inputEvent)
    {
        _transform = transform;

        this.baseSpeed = baseSpeed;
        this.boostSpeed = boostSpeed;
        currentSpeed = baseSpeed;

        gameStateEvents.Add_GameStartListener(Allow_Movement);
        gameStateEvents.Add_GameEndListener(Disallow_Movement);
        gameStateEvents.Add_GameRestartListener(Disallow_Movement);

        inputEvent.Add_OnInput_Listener(SideMove);

        boostEvent.Add_OnBoost_Listener(Boost);
    }

    private void Allow_Movement()
    {
        canMove = true;
    }

    private void Disallow_Movement()
    {
        canMove = false;
    }

    public void ForwardMove()
    {
        if (!canMove) return;
        if (isBoosted) Reduce_BoostEffect();

        _transform.position += _transform.forward * Time.deltaTime * currentSpeed;
    }

    private void SideMove(float delta)
    {
        if (!canMove) return;

        Vector3 curPos = _transform.position;
        curPos.x += delta / 300;
        curPos.x = Mathf.Clamp(curPos.x, -2.0f, 2.0f);

        _transform.position = curPos;
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
