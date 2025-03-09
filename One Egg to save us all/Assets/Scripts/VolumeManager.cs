using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}