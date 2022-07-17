using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_UI_Handler
{
    UI_StartGame startGame;
    UI_EndGame endGame;
    UI_Score uI_Score;

    public Scene_UI_Handler(IGameStateEvents gameStateEvents, ICollisionEvent collisionEvent)
    {
        startGame = new UI_StartGame(gameStateEvents);
        endGame = new UI_EndGame(gameStateEvents);
        uI_Score = new UI_Score(gameStateEvents, collisionEvent);
    }
}
