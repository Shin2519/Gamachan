using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Sound", menuName = "Scriptable Objects/Sound")]
public class Sound : ScriptableObject
{
    [Header("SEの配列")]
    public AudioClip[] searray;

    [Header("BGMの配列")]
    public AudioClip[] bgmarray;
}
