using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SESlider;
    [SerializeField] Slider MasterSlider;
    void Start()
    {
        BGMSlider.value = AudioManager.Instance.GetBGMVolume();
        SESlider.value = AudioManager.Instance.GetSEVolume();
        MasterSlider.value = AudioManager.Instance.GetMasterVolume();

        BGMSlider.onValueChanged.AddListener(AudioManager.Instance.SetBGMVolume);
        SESlider.onValueChanged.AddListener(AudioManager.Instance.SetSEVolume);
        MasterSlider.onValueChanged.AddListener(AudioManager.Instance.SetMasterVolume);
    }

}
