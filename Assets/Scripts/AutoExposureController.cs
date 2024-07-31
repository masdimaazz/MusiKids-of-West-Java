using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AutoExposureController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private AutoExposure autoExposure;

    void Start()
    {
        if (postProcessVolume != null)
        {
            postProcessVolume.profile.TryGetSettings(out autoExposure);
        }
    }

    void Update()
    {
        // Atur nilai exposure berdasarkan kebutuhan
        // Misalnya, meningkatkan exposure untuk membuat kamera lebih terang
        if (autoExposure != null)
        {
            autoExposure.minLuminance.value = 1.0f;  // Set minimum luminance
            autoExposure.maxLuminance.value = 2.0f;  // Set maximum luminance
        }
    }
}
