using UnityEngine;

[CreateAssetMenu(fileName = "SkillDescription", menuName = "Scriptable Objects/SkillDescription")]
public class SkillDescripsion : ScriptableObject
{
    [SerializeField] string[] SkillDetail;

    public string GetSkillDetail(int num) => SkillDetail[num];
}
