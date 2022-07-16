using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : ICollisionEvent
{
    event ICollisionEvent.OnWallPass onWallPass;
    event ICollisionEvent.OnWallCollision onWallCollision;
    event ICollisionEvent.OnPickUp onPickUp;

    public void Add_OnWallPass_Listener(ICollisionEvent.OnWallPass method)
    {
        onWallPass += method;
    }

    public void Invoke_OnWallPass()
    {
        onWallPass?.Invoke();
    }

    public void Add_OnWallCollision_Listener(ICollisionEvent.OnWallCollision method)
    {
        onWallCollision += method;
    }

    public void Invoke_OnWallCollision()
    {
        onWallCollision?.Invoke();
    }

    public void Add_OnPickUp_Listener(ICollisionEvent.OnPickUp method)
    {
        onPickUp += method;
    }

    public void Invoke_OnPickUp()
    {
        onPickUp?.Invoke();
    }

    public void Remove_Listeners()
    {
        onWallCollision = null;
        onPickUp = null;
    }
}
