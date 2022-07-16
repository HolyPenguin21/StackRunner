using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateEvents : IGameStateEvents
{
    event IGameStateEvents.OnGameStart onGameStart;
    event IGameStateEvents.OnGameEnd onGameEnd;
    event IGameStateEvents.OnGameRestart onGameRestart;

    public void Add_GameStartListener(IGameStateEvents.OnGameStart method)
    {
        onGameStart += method;
    }

    public void Invoke_GameStart()
    {
        Debug.Log("onGameStart");
        onGameStart?.Invoke();
    }

    public void Add_GameEndListener(IGameStateEvents.OnGameEnd method)
    {
        onGameEnd += method;
    }

    public void Invoke_GameEnd()
    {
        Debug.Log("onGameEnd");
        onGameEnd?.Invoke();
    }

    public void Add_GameRestartListener(IGameStateEvents.OnGameRestart method)
    {
        onGameRestart += method;
    }

    public void Invoke_GameRestart()
    {
        Debug.Log("onGameRestart");
        onGameRestart?.Invoke();
    }

    public void Remove_Listeners()
    {
        onGameStart = null;
        onGameEnd = null;
        onGameRestart = null;
    }
}
