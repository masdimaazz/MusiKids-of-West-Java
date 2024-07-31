using UnityEngine;
using UnityEngine.UI;  // Tambahkan ini untuk menggunakan UI elements

public class MuteBackgroundMusic : MonoBehaviour
{
    public AudioSource backgroundMusicSource;  // Referensi ke komponen AudioSource untuk background music
    public Button muteButton;                  // Referensi ke tombol Mute/Unmute
    public Sprite muteSprite;                  // Sprite untuk tombol Mute
    public Sprite unmuteSprite;                // Sprite untuk tombol Unmute

    private bool isMuted = false;              // Untuk melacak status mute

    void Start()
    {
        // Pastikan background music source ada
        if (backgroundMusicSource == null)
        {
            Debug.LogWarning("AudioSource untuk background music belum diset.");
        }

        // Pastikan tombol Mute ada dan tambahkan event listener
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMute);
            muteButton.image.sprite = unmuteSprite;  // Set sprite tombol awal
        }
        else
        {
            Debug.LogWarning("Button Mute belum diset.");
        }
    }

    // Method untuk memute atau meng-unmute background music
    public void ToggleMute()
    {
        if (backgroundMusicSource != null)
        {
            isMuted = !isMuted;
            backgroundMusicSource.mute = isMuted;
            muteButton.image.sprite = isMuted ? muteSprite : unmuteSprite;  // Ganti sprite tombol
        }
    }
}
