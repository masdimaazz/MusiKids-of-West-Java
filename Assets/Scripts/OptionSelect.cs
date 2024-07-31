using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.EventSystems;

public class OptionSelect : MonoBehaviour
{
    public GameObject Model;
    public GameObject Deskripsi;
    public GameObject Video;

    public GameObject Opt1Window;
    public GameObject Opt2Window;
    public GameObject Opt3Window;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    public void OptOneButtonClicked()
    {
        // 1) Tampilkan Model Hewan
        Model.SetActive(true);
        Deskripsi.SetActive(false);
        Video.SetActive(false);
        // 2) Animasikan Model
        
    }
    public void OptTwoButtonClicked()
    {
        // 1) Tampilkan Window Deskripsi
        Model.SetActive(false);
        Deskripsi.SetActive(true);
        Video.SetActive(false);
        // 2) Animasikan Window
    }

    public void OptThreeButtonClicked()
    {
        // 1) Tampilkan Window Deskripsi
        Model.SetActive(false);
        Deskripsi.SetActive(false);
        Video.SetActive(true);
        // 2) Animasikan Window
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
