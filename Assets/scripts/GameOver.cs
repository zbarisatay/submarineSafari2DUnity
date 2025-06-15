using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false); // Başlangıçta panel gizli
    }

    void Update()
    {
        // Eğer player yoksa, game over panelini aç
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Oyun durdurulur
        }
    }

    public void Restart()
    {
        Debug.Log("Restart butonuna basıldı!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Yeniden başlatıldığında oyun devam eder
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu butonuna basıldı!");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // Sıfırıncı sahneyi yükle (Ana Menü)
    }
}
