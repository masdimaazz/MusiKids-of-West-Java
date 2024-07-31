using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    public GameObject popupPanel;   // Referensi ke panel pop-up
    public Button infoButton;       // Referensi ke tombol Info
    public Button nextButton;       // Referensi ke tombol "Next" di panel pop-up
    public Button cancelButton;     // Referensi ke tombol "Cancel" di panel pop-up

    void Start()
    {
        // Pastikan popupPanel, nextButton, dan cancelButton sudah diset
        if (popupPanel == null)
        {
            Debug.LogWarning("Panel pop-up belum diset.");
        }
        else
        {
            popupPanel.SetActive(false);  // Sembunyikan panel pop-up pada awalnya
        }

        if (infoButton != null)
        {
            infoButton.onClick.AddListener(ShowPopup);
        }
        else
        {
            Debug.LogWarning("Tombol Info belum diset.");
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextButtonClick);
        }
        else
        {
            Debug.LogWarning("Tombol Next belum diset.");
        }

        if (cancelButton != null)
        {
            cancelButton.onClick.AddListener(OnCancelButtonClick);
        }
        else
        {
            Debug.LogWarning("Tombol Cancel belum diset.");
        }
    }

    // Method untuk menampilkan panel pop-up
    void ShowPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);  // Tampilkan panel pop-up
        }
    }

    // Method untuk menangani klik tombol "Next"
    void OnNextButtonClick()
    {
        Debug.Log("Next button clicked.");
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);  // Sembunyikan panel pop-up
        }
    }

    // Method untuk menangani klik tombol "Cancel"
    void OnCancelButtonClick()
    {
        Debug.Log("Cancel button clicked.");
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);  // Sembunyikan panel pop-up
        }
    }
}
