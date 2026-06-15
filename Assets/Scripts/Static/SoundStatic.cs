using UnityEngine;
using UnityEngine.Audio;

public static class SoundStatic
{
    public static void SE(this AudioSource audiosource ,AudioClip sound)
    {
        audiosource.PlayOneShot(sound);
        Debug.Log("サウンド再生");
    }
}
