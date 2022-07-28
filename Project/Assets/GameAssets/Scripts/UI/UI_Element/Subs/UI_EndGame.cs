using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : UI_Element
{
    Canvas endGame_canvas;
    Button restart_button;

    public UI_EndGame(IGameStateEvents gameStateEvents)
    {
        endGame_canvas = Get_SceneObject(endGame_canvas, "EndGame");
        Setup_RestartButton(gameStateEvents);

        gameStateEvents.Add_GameEndListener(Show);
        gameStateEvents.Add_GameRestartListener(Hide);
    }

    public override void Hide()
    {
        endGame_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        endGame_canvas.gameObject.SetActive(true);
    }

    private void Setup_RestartButton(IGameStateEvents gameStateEvents)
    {
        restart_button = Get_SceneObject(restart_button, "Restart");
        restart_button.onClick.AddListener(() => gameStateEvents.Invoke_GameRestart());
    }
}
