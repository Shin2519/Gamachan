using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Sound", menuName = "Scriptable Objects/Sound")]
public class Sound : ScriptableObject
{
    [Header("押したときの音")]
    public AudioClip Buttondown;

    [Header("終わりの音")]
    public AudioClip SEofFinish;

    [Header("評価による音の種類")]
    public AudioClip Perfect;
    public AudioClip Great;
    public AudioClip Good;
    public AudioClip Bad;

    [Header("正解")]
    public AudioClip Circle;
    [Header("不正解")]
    public AudioClip Cross;

    [Header("クリック音")]
    public AudioClip Click;

    [Header("小銭が落ちてきた時の音")]
    public AudioClip CoinFall;

    [Header("戻るときの音")]
    public AudioClip Back;

    [Header("常に流れている音楽")]
    public AudioResource resource;
}
