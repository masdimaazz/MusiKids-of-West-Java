using UnityEngine;
using UnityEngine.UI;  // Tambahkan ini untuk menggunakan UI elements

public class VoiceOverManager : MonoBehaviour
{
    public AudioSource voiceOverSource;  // Referensi ke komponen AudioSource untuk voice over
    public AudioClip voiceOverClip;      // AudioClip untuk voice over
    public AudioSource backgroundMusicSource;  // Referensi ke komponen AudioSource untuk background music
    public Button playPauseButton;       // Referensi ke tombol Play/Pause
    public Button stopButton;            // Referensi ke tombol Stop
    public Button resetButton;           // Referensi ke tombol Reset

    private bool isPaused = false;       // Untuk melacak status pause
    private float originalMusicVolume;   // Untuk menyimpan volume asli dari background music

    void Start()
    {
        // Pastikan AudioSource ada dan voice over clip sudah diset
        if (voiceOverSource != null && voiceOverClip != null)
        {
            voiceOverSource.clip = voiceOverClip;
        }
        else
        {
            Debug.LogWarning("AudioSource atau AudioClip untuk voice over belum diset.");
        }

        // Pastikan background music source ada dan simpan volume aslinya
        if (backgroundMusicSource != null)
        {
            originalMusicVolume = backgroundMusicSource.volume;
        }
        else
        {
            Debug.LogWarning("AudioSource untuk background music belum diset.");
        }

        // Pastikan tombol Play/Pause ada dan tambahkan event listener
        if (playPauseButton != null)
        {
            playPauseButton.onClick.AddListener(PlayPauseVoiceOver);
            playPauseButton.GetComponentInChildren<Text>().text = "Play";  // Set teks tombol awal
        }
        else
        {
            Debug.LogWarning("Button Play/Pause belum diset.");
        }

        // Pastikan tombol Stop ada dan tambahkan event listener
        if (stopButton != null)
        {
            stopButton.onClick.AddListener(StopVoiceOver);
        }
        else
        {
            Debug.LogWarning("Button Stop belum diset.");
        }

        // Pastikan tombol Reset ada dan tambahkan event listener
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetVoiceOver);
        }
        else
        {
            Debug.LogWarning("Button Reset belum diset.");
        }
    }

    // Method untuk memainkan atau pause voice over
    public void PlayPauseVoiceOver()
    {
        if (voiceOverSource.isPlaying && !isPaused)
        {
            voiceOverSource.Pause();
            if (backgroundMusicSource != null)
            {
                backgroundMusicSource.volume = originalMusicVolume;  // Kembalikan volume background music
            }
            isPaused = true;
            playPauseButton.GetComponentInChildren<Text>().text = "Play";  // Ganti teks tombol menjadi "Play"
        }
        else
        {
            voiceOverSource.Play();
            if (backgroundMusicSource != null)
            {
                backgroundMusicSource.volume = originalMusicVolume * 0.2f;  // Kecilkan volume background music
            }
            isPaused = false;
            playPauseButton.GetComponentInChildren<Text>().text = "Pause";  // Ganti teks tombol menjadi "Pause"
        }
    }

    // Method untuk menghentikan voice over
    public void StopVoiceOver()
    {
        if (voiceOverSource.isPlaying)
        {
            voiceOverSource.Stop();
            if (backgroundMusicSource != null)
            {
                backgroundMusicSource.volume = originalMusicVolume;  // Kembalikan volume background music
            }
            isPaused = false;
            playPauseButton.GetComponentInChildren<Text>().text = "Play";  // Ganti teks tombol menjadi "Play" saat audio dihentikan
        }
    }

    // Method untuk mereset voice over
    public void ResetVoiceOver()
    {
        voiceOverSource.Stop();
        voiceOverSource.time = 0;
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.volume = originalMusicVolume;  // Kembalikan volume background music
        }
        isPaused = false;
        playPauseButton.GetComponentInChildren<Text>().text = "Play";  // Ganti teks tombol menjadi "Play"
    }
}
