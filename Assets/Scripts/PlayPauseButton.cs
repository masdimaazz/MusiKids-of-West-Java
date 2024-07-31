using UnityEngine;
using UnityEngine.UI;

public class PlayPauseButton : MonoBehaviour
{
    public Button playPauseButton;   // Referensi ke tombol Play/Pause
    public MusicPlayer musicPlayer;  // Referensi ke skrip MusicPlayer

    void Start()
    {
        // Pastikan tombol Play/Pause sudah diset dan tambahkan event listener
        if (playPauseButton != null)
        {
            playPauseButton.onClick.AddListener(OnButtonClick);
            playPauseButton.GetComponentInChildren<Text>().text = "Play";  // Set teks tombol awal
        }
        else
        {
            Debug.LogWarning("Button Play/Pause belum diset.");
        }

        // Pastikan MusicPlayer sudah diset
        if (musicPlayer == null)
        {
            Debug.LogWarning("MusicPlayer belum diset.");
        }
    }

    // Method yang dipanggil saat tombol diklik
    void OnButtonClick()
    {
        if (musicPlayer != null)
        {
            musicPlayer.TogglePlayPause();
            UpdateButtonText();
        }
    }

    // Update teks tombol berdasarkan status pemutaran musik
    void UpdateButtonText()
    {
        if (musicPlayer != null)
        {
            if (musicPlayer.GetComponent<AudioSource>().isPlaying)
            {
                playPauseButton.GetComponentInChildren<Text>().text = "Pause";  // Ganti teks tombol menjadi "Pause"
            }
            else
            {
                playPauseButton.GetComponentInChildren<Text>().text = "Play";  // Ganti teks tombol menjadi "Play"
            }
        }
    }
}
