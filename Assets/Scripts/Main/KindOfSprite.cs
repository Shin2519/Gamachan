using UnityEngine;
[System.Serializable]
public class KindOfSprite
{
    [SerializeField]
    UI KindSprite;
    public Sprite GamaEmotion(Statestate.Grade l_grade, Statestate.GamaState l_gamaState)
    {
        Sprite l_gamasprite = null;
        switch (l_grade)
        {
            case Statestate.Grade.Perfect:
            case Statestate.Grade.Great:
            l_gamasprite = (l_gamaState == Statestate.GamaState.Gold) ? KindSprite.GoldenKindofemotion[1] : KindSprite.Kindofemotion[1];
                break;
            case Statestate.Grade.Good:
            l_gamasprite = (l_gamaState == Statestate.GamaState.Gold) ? KindSprite.GoldenKindofemotion[0] : KindSprite.Kindofemotion[0];
                break;
            case Statestate.Grade.Bad:
            l_gamasprite = (l_gamaState == Statestate.GamaState.Gold) ? KindSprite.GoldenKindofemotion[2] : KindSprite.Kindofemotion[2];
                break;
            case Statestate.Grade.Miss:
            l_gamasprite = (l_gamaState == Statestate.GamaState.Gold) ? KindSprite.GoldenKindofemotion[2] : KindSprite.Kindofemotion[2];
                break;
        }
        return l_gamasprite;
    }
    public Sprite GamaChange(Statestate.GamaState l_gamastate)
    {
        Sprite NomalorGold = (l_gamastate==Statestate.GamaState.Gold) ? KindSprite.GoldenKindofemotion[0] : KindSprite.Kindofemotion[0];

        return NomalorGold;
    }

    public Sprite Grade_Sp(Statestate.Grade l_grade)
    {
        Sprite l_grade_sp = null;
        switch (l_grade)
        {
            case Statestate.Grade.Perfect:
                l_grade_sp = KindSprite.Grade[3];
                break;
            case Statestate.Grade.Great:
                l_grade_sp = KindSprite.Grade[2];
                break;
            case Statestate.Grade.Good:
                l_grade_sp = KindSprite.Grade[1];
                break;
            case Statestate.Grade.Bad:
                l_grade_sp = KindSprite.Grade[0];
                break;
            case Statestate.Grade.Miss:
                l_grade_sp = null;
                break;
        }
        return l_grade_sp;
    }

    public Sprite Combo_Sp(int l_comboCount)
    {
        if (l_comboCount > 3&& l_comboCount % 3 != 0) return null;
        int stage = Mathf.Min((l_comboCount/3) - 1,KindSprite.Kindofcombo.Length - 1);
        return KindSprite.Kindofcombo[stage];
    }
}
