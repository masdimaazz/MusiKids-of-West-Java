using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadSceneMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadSceneGuide()
    {
        SceneManager.LoadScene("Guide");
    }
    public void LoadSceneGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void LoadSceneAngklung()
    {
        SceneManager.LoadScene("Angklung");
    }

    public void LoadSceneGendang()
    {
        SceneManager.LoadScene("Gendang");
    }

    public void LoadSceneJenglong()
    {
        SceneManager.LoadScene("Jenglong");
    }

    public void LoadSceneKecapi()
    {
        SceneManager.LoadScene("Kecapi");
    }

    public void LoadSceneRebab()
    {
        SceneManager.LoadScene("Rebab");
    }

    public void LoadSceneSuling()
    {
        SceneManager.LoadScene("Suling");
    }
    public void LoadScenePostCard()
    {
        SceneManager.LoadScene("PostCard");
    }
    public void LoadSceneInformasi()
    {
        SceneManager.LoadScene("Informasi");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Jika sedang dijalankan di editor, berhenti dari mode play
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Jika sedang dijalankan di build, keluar dari aplikasi
        Application.Quit();
#endif
    }

}