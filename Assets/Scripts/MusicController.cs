using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource musicSource;  // Referensi ke komponen AudioSource untuk musik
    private bool isPlaying = false;  // Untuk melacak status musik
    private bool hasStarted = false; // Untuk melacak apakah musik sudah dimulai

    public void TogglePlayPause()
    {
        if (musicSource != null)
        {
            if (isPlaying)
            {
                musicSource.Pause();
            }
            else
            {
                if (!hasStarted)
                {
                    musicSource.Play();
                    hasStarted = true; // Tandai bahwa musik telah dimulai
                }
                else
                {
                    musicSource.UnPause();
                }
            }
            isPlaying = !isPlaying;  // Balik status pemutaran musik
        }
    }
}
