using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public Button playPauseButton;
    public Button resetButton;
    public Sprite playSprite;
    public Sprite stopSprite;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Tambahkan listener untuk tombol reset
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetAudio);
        }
        else
        {
            Debug.LogWarning("Reset button belum diset.");
        }
    }

    public void PlayPauseAudio()
    {
        if (!isPlaying)
        {
            audioSource.Play();
            playPauseButton.image.sprite = stopSprite;
            isPlaying = true;
        }
        else
        {
            audioSource.Pause();
            playPauseButton.image.sprite = playSprite;
            isPlaying = false;
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
        isPlaying = false;
        playPauseButton.image.sprite = playSprite;
    }

    public void ResetAudio()
    {
        audioSource.Stop();
        audioSource.time = 0;
        isPlaying = false;
        playPauseButton.image.sprite = playSprite;
    }
}
