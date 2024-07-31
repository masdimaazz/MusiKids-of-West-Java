using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class StartStop : MonoBehaviour
{
    private VideoPlayer player;
    public Button button;
    public Sprite startSprite;
    public Sprite stopSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStartStop()
    {
        if (player.isPlaying == false)
        {
            player.Play();
            button.image.sprite = stopSprite;
        }
        else
        {
            // Menghentikan video dan mengatur waktu pemutaran ke awal
            player.Stop();
            player.time = 0;
            player.Play();
            button.image.sprite = stopSprite;
        }
    }
    public void ResetVideo()
    {
        player.Stop();
        player.time = 0;
    }
}
