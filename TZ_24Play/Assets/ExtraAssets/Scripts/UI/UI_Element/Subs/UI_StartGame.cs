using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartGame : UI_Element
{
    Canvas startGame_canvas;

    public UI_StartGame()
    {
        startGame_canvas = Get_SceneObject(startGame_canvas, "StartGame");
    }

    public override void Hide()
    {
        throw new System.NotImplementedException();
    }

    public override void Show()
    {
        throw new System.NotImplementedException();
    }
}
