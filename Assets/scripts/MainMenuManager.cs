using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject optionsPanel;  // Options Paneli
    private bool isPaused = false;   // Oyunun duraklatılıp duraklatılmadığını kontrol eder

    void Start()
    {
        optionsPanel.SetActive(false);  // Başlangıçta panel gizli
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Escape tuşuna basıldığında
        {
            if (isPaused)
            {
                ResumeGame();  // Oyunu devam ettir
            }
            else
            {
                PauseGame();   // Oyunu duraklat
            }
        }
    }

    // Oyunu duraklatma fonksiyonu
    public void PauseGame()
    {
        optionsPanel.SetActive(true);  // Options Paneli aç
        Time.timeScale = 0f;           // Oyunu durdur (Zamanı durdur)
        isPaused = true;
    }

    // Oyunu devam ettirme fonksiyonu
    public void ResumeGame()
    {
        optionsPanel.SetActive(false); // Options Panelini kapat
        Time.timeScale = 1f;           // Zamanı başlat (Oyunu devam ettir)
        isPaused = false;
    }

    // Options Panelini kapatma fonksiyonu (örneğin bir butonla)
    public void CloseOptions()
    {
        optionsPanel.SetActive(false); // Options Panelini kapat
        Time.timeScale = 1f;           // Oyunu devam ettir
        isPaused = false;
    }
}
