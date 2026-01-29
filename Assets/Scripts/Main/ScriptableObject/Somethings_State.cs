using UnityEngine;

[CreateAssetMenu(fileName = "Something's_State", menuName = "Scriptable Objects/Something's_State")]
public class Somethings_State : ScriptableObject
{
    public enum Speed
    {
        TooFast,
        Fast,
        Soso,
        Slow,
        TooSlow
    }
    public Speed speed;

    public enum Gauge_State
    {
        Normal,
        Gold
    }
    public Gauge_State gauge_state;
}
