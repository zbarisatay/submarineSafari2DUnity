using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource backgroundMusic;

    

    void Start()
    {
        

        // Oyuncunun tercihini kontrol et (Eğer müzik daha önce kapatıldıysa, kapalı bırak)
        if (PlayerPrefs.GetInt("MusicMuted", 0) == 1)
        {
            backgroundMusic.mute = true;
        }
    }

    public void MuteMusic()
    {
        backgroundMusic.mute = true;
        PlayerPrefs.SetInt("MusicMuted", 1); // Ayarı kaydet
    }

    public void UnmuteMusic()
    {
        backgroundMusic.mute = false;
        PlayerPrefs.SetInt("MusicMuted", 0); // Ayarı kaydet
    }
}
