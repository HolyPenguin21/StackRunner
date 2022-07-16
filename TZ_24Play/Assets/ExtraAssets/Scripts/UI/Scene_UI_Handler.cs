using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_UI_Handler
{
    UI_StartGame startGame;
    UI_EndGame endGame;

    public Scene_UI_Handler(IGameStateEvents gameStateEvents)
    {
        startGame = new UI_StartGame(gameStateEvents);
        endGame = new UI_EndGame(gameStateEvents);
    }
}
