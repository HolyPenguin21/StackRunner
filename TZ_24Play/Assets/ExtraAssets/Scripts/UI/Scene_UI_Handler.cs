public class Scene_UI_Handler
{
    UI_Score uI_Score;
    UI_StartGame startGame;
    UI_EndGame endGame;

    public Scene_UI_Handler(IGameStateEvents gameStateEvents, ICollisionEvent collisionEvent)
    {
        uI_Score = new UI_Score(gameStateEvents, collisionEvent);

        startGame = new UI_StartGame(gameStateEvents);

        endGame = new UI_EndGame(gameStateEvents);
        endGame.Hide();
    }
}
