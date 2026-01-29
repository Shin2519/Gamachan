using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Scriptable Objects/Sound")]
public class Sound : ScriptableObject
{
    [Header("‰Ÿ‚µ‚½‚Æ‚«‚Ì‰¹")]
    public AudioClip Buttondown;

    [Header("I‚í‚è‚Ì‰¹")]
    public AudioClip SEofFinish;

    [Header("•]‰¿‚É‚æ‚é‰¹‚Ìí—Ş")]
    public AudioClip Perfect;
    public AudioClip Great;
    public AudioClip Good;
    public AudioClip Bad;
}
