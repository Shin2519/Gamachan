using System;
using UnityEngine;

public class GamachanRendererChange : MonoBehaviour
{
    [SerializeField]
    Gama_SpriteRenderer Gama_SpriteRenderer;

    SpriteRenderer GamaRenderer;

    Func<StateMashine.GamaState> GetGamaState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GamaRenderer = GetComponent<SpriteRenderer>();
        GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Normal(0);
    }

    public void NomalAndGold()
    {
        StateMashine.GamaState l_gamastate = GetGamaState();
        switch (l_gamastate)
        {
            case StateMashine.GamaState.Nomal:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Normal(0);
                break;
            case StateMashine.GamaState.Gold:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Gold(0);
                break;
        }
    }

    void GradeAtNormal(StateMashine.Grade l_grade)
    {
        switch (l_grade)
        {
            case StateMashine.Grade.Perfect:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Normal(1);
                break;
            case StateMashine.Grade.Great:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Normal(0);
                break;
            case StateMashine.Grade.Good:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Normal(0);
                break;
            case StateMashine.Grade.Bad:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Normal(2);
                break;
            case StateMashine.Grade.Miss:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Normal(2);
                break;
        }
    }
    void GradeAtGold(StateMashine.Grade l_grade)
    {
        switch (l_grade)
        {
            case StateMashine.Grade.Perfect:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Gold(1);
                break;
            case StateMashine.Grade.Great:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Gold(0);
                break;
            case StateMashine.Grade.Good:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Gold(0);
                break;
            case StateMashine.Grade.Bad:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Gold(2);
                break;
            case StateMashine.Grade.Miss:
                GamaRenderer.sprite = Gama_SpriteRenderer.GetGamaEmotion_Gold(2);
                break;
        }
    }

    public void NormalOrGold_GradeEmotion(StateMashine.Grade l_grade)
    {
        StateMashine.GamaState l_gamastate = GetGamaState();
        switch (l_gamastate)
        {
            case StateMashine.GamaState.Nomal:
                GradeAtNormal(l_grade);
                break;
            case StateMashine.GamaState.Gold:
                GradeAtGold(l_grade);
                break;
        }
    }

    public void SetGamaState(Func<StateMashine.GamaState> l_gamastate)
    {
        GetGamaState = l_gamastate;
    }
}
