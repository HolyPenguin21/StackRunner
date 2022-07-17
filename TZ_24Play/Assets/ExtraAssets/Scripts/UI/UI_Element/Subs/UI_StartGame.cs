using UnityEngine;

public class UI_StartGame : UI_Element
{
    Canvas startGame_canvas;

    public UI_StartGame(IGameStateEvents gameStateEvents)
    {
        startGame_canvas = Get_SceneObject(startGame_canvas, "StartGame");

        gameStateEvents.Add_GameStartListener(Hide);
    }

    public override void Hide()
    {
        startGame_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        startGame_canvas.gameObject.SetActive(true);
    }
}
