using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostEvent : IBoostEvent
{
    event IBoostEvent.OnBoost onBoost;

    public void Add_OnBoost_Listener(IBoostEvent.OnBoost method)
    {
        onBoost += method;
    }

    public void Invoke_OnBoost()
    {
        onBoost?.Invoke();
    }

    public void Remove_Listeners()
    {
        onBoost = null;
    }
}
