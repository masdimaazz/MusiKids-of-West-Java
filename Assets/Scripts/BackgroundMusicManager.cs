    using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    private static BackgroundMusicManager instance;

    public static BackgroundMusicManager Instance
    {
        get { return instance; }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern implementation
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Play the background music
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // Subscribe to scene load event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from scene load event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure the background music keeps playing when a new scene is loaded
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
