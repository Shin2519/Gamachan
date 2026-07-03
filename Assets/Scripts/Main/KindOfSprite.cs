using UnityEngine;
[System.Serializable]
public class KindOfSprite
{
    [SerializeField]
    Gama_SpriteRenderer Gama;
    [SerializeField]
    AnythingSprite anything;
    public Sprite GamaEmotion(StateMashine.Grade l_grade, StateMashine.GamaState l_gamaState)
    {
        Sprite l_gamasprite = null;
        switch (l_grade)
        {
            case StateMashine.Grade.Perfect:
            case StateMashine.Grade.Great:
            l_gamasprite = (l_gamaState == StateMashine.GamaState.Gold) ? Gama.GetGamaEmotion_Gold(1) : Gama.GetGamaEmotion_Normal(1);
                break;
            case StateMashine.Grade.Good:
            l_gamasprite = (l_gamaState == StateMashine.GamaState.Gold) ? Gama.GetGamaEmotion_Gold(0) : Gama.GetGamaEmotion_Normal(0);
                break;
            case StateMashine.Grade.Bad:
            l_gamasprite = (l_gamaState == StateMashine.GamaState.Gold) ? Gama.GetGamaEmotion_Gold(2) : Gama.GetGamaEmotion_Normal(2);
                break;
            case StateMashine.Grade.Miss:
            l_gamasprite = (l_gamaState == StateMashine.GamaState.Gold) ? Gama.GetGamaEmotion_Gold(2) : Gama.GetGamaEmotion_Normal(2);
                break;
        }
        return l_gamasprite;
    }

    public Sprite Grade_Sp(StateMashine.Grade l_grade)
    {
        Sprite l_grade_sp = null;
        switch (l_grade)
        {
            case StateMashine.Grade.Perfect:
                l_grade_sp = anything.GetGrade(4);
                break;
            case StateMashine.Grade.Great:
                l_grade_sp = anything.GetGrade(3);
                break;
            case StateMashine.Grade.Good:
                l_grade_sp = anything.GetGrade(2);
                break;
            case StateMashine.Grade.Bad:
                l_grade_sp = anything.GetGrade(1);
                break;
            case StateMashine.Grade.Miss:
                l_grade_sp = anything.GetGrade(0);
                break;
        }
        return l_grade_sp;
    }

    public Sprite GradeEfect_sp(StateMashine.Grade l_grade)
    {
        Sprite l_gradeEfect_sp = null;
        switch (l_grade)
        {
            case StateMashine.Grade.Perfect:
                l_gradeEfect_sp = anything.GetGradeEfect(0);
                Debug.Log("イメージ変更perfect");
                break;
            case StateMashine.Grade.Great:
                l_gradeEfect_sp = anything.GetGradeEfect(1);
                Debug.Log("イメージ変更great");

                break;
            case StateMashine.Grade.Good:
                l_gradeEfect_sp = anything.GetGradeEfect(2);
                Debug.Log("イメージ変更good");

                break;
        }
        return l_gradeEfect_sp;
    }

    public Sprite Combo_Sp(int l_comboCount)
    {
        if (l_comboCount > 3&& l_comboCount % 3 != 0) return null;
        int stage = Mathf.Min((l_comboCount/3) - 1, anything.ComboNum - 1);
        return anything.GetCombo(stage);
    }
}
