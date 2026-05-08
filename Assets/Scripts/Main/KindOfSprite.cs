using UnityEngine;
[System.Serializable]
public class KindOfSprite
{
    [SerializeField]
    UI KindSprite;
    public Sprite GamaEmotion(int GradeNum,bool change)
    {
        if(GradeNum==5)
        {
            Sprite NomalorGold = change ? KindSprite.GoldenKindofemotion[1] : KindSprite.Kindofemotion[1];
            return NomalorGold;
        }
        else if(GradeNum==4)
        {
            Sprite NomalorGold = change ? KindSprite.GoldenKindofemotion[1] : KindSprite.Kindofemotion[1];
            return NomalorGold;
        }
        else if(GradeNum==3)
        {
            Sprite NomalorGold = change ? KindSprite.GoldenKindofemotion[0] : KindSprite.Kindofemotion[0];
            return NomalorGold;
        }
        else if(GradeNum==2)
        {
            Sprite NomalorGold = change ? KindSprite.GoldenKindofemotion[2] : KindSprite.Kindofemotion[2];
            return NomalorGold;
        }
        else
        {
            Sprite NomalorGold = change ? KindSprite.GoldenKindofemotion[2] : KindSprite.Kindofemotion[2];
            return NomalorGold;
        }
    }
    public Sprite GamaChange(bool change)
    {
        Sprite NomalorGold = change ? KindSprite.Kindofemotion[0] : KindSprite.GoldenKindofemotion[0];

        return NomalorGold;
    }

    public Sprite Grade_Sp(int GradeNum)
    {
        if (GradeNum == 4)
        {
            return KindSprite.Grade[3];
        }
        else if (GradeNum == 3)
        {
            return KindSprite.Grade[2];
        }
        else if (GradeNum == 2)
        {
            return KindSprite.Grade[1];
        }
        else
        {
            return KindSprite.Grade[0];
        }
    }

    public Sprite Combo_Sp(int ComboCount)
    {
        if(ComboCount>=3)
        {
            return KindSprite.Kindofcombo[0];
        }
        else if(ComboCount>=6)
        {
            return KindSprite.Kindofcombo[1];
        }
        else if(ComboCount>=9)
        {
            return KindSprite.Kindofcombo[2];
        }
        else if(ComboCount>=12)
        {
            return KindSprite.Kindofcombo[3];
        }
        else if(ComboCount>=15)
        {
            return KindSprite.Kindofcombo[4];
        }
        else if(ComboCount>=18)
        {
            return KindSprite.Kindofcombo[5];
        }
        else if(ComboCount>=21)
        {
            return KindSprite.Kindofcombo[6];
        }
        else if(ComboCount>=24)
        {
            return KindSprite.Kindofcombo[7];
        }
        else if(ComboCount>=27)
        {
            return KindSprite.Kindofcombo[8];
        }
        else if(ComboCount>=30)
        {
            return KindSprite.Kindofcombo[9];
        }
        return null;
    }
}
