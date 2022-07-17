using UnityEngine;
using DG.Tweening;
using TMPro;

public class UI_Score : UI_Element
{
    Canvas score_canvas;
    TextMeshProUGUI score_text;

    int score = 0;

    public UI_Score(IGameStateEvents gameStateEvents, ICollisionEvent collisionEvent)
    {
        score_canvas = Get_SceneObject(score_canvas, "Score");
        score_text = Get_SceneObject(score_text, "ScoreValue");

        collisionEvent.Add_OnPickUp_Listener(Animate);
        collisionEvent.Add_OnPickUp_Listener(AddScore);

        gameStateEvents.Add_GameStartListener(ResetText);
        gameStateEvents.Add_GameStartListener(ResetVars);

        gameStateEvents.Add_GameEndListener(ResetVars);
    }

    public override void Hide()
    {
        score_canvas.gameObject.SetActive(false);
    }

    public override void Show()
    {
        score_canvas.gameObject.SetActive(true);
    }

    private void Animate()
    {
        score_text.transform.DOShakeScale(0.5f, 1, 10, 90, true);
    }

    private void AddScore()
    {
        score++;
        score_text.text = $"{score}";
    }

    private void ResetVars()
    {
        DOTween.Kill(score_text.transform);
    }
    private void ResetText()
    {
        score = 0;
        score_text.text = "" + score;
    }
}
