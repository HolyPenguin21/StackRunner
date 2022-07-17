using UnityEngine;

public class Scene_Input
{
    IGameStateEvents gameStateEvents;
    IInputEvent inputEvent;

    Vector3 start_InputPos;
    Vector3 current_InputPos;

    bool gameStarted = false;
    bool gameEnded = false;

    public Scene_Input(IGameStateEvents gameStateEvents, IInputEvent inputEvent)
    {
        this.gameStateEvents = gameStateEvents;
        this.inputEvent = inputEvent;

        gameStateEvents.Add_GameStartListener(StartGame);
        gameStateEvents.Add_GameEndListener(EndGame);
    }

    public void SceneInput()
    {
        if (gameEnded) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!gameStarted) gameStateEvents.Invoke_GameStart();

            start_InputPos = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            current_InputPos = Input.mousePosition;

            float delta = current_InputPos.x - start_InputPos.x;
            inputEvent.Invoke_OnInput(delta);
        }
    }

    private void StartGame()
    {
        gameStarted = true;
        gameEnded = false;
    }

    private void EndGame()
    {
        gameStarted = false;
        gameEnded = true;
    }
}
