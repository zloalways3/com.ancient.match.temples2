using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerTemple : MonoBehaviour
{
    public AudioSource themeTemple;
    public AudioSource pingTemple;
    public AudioSource clickTemple;
    bool onceTemple = false;

    public float soundSoundLevelTemple = 0.7f;
    public float musicSoundLevelTemple = 0.7f;
    public bool changedTemple = false;



    bool CoinFlipTemple(bool riggedTemple = false)
    {
        try
        {
            try
            {
                System.Random rTemple = new System.Random();
                int rIntTemple = rTemple.Next(0, 2);
                if (rIntTemple > 0) { return true; }
                else { return false; };
            }
            catch (System.Exception eTemple)
            {
                System.Random rTemple = new System.Random();
                int rIntTemple = rTemple.Next(0, 2);
                if (rIntTemple > 0) { return true; }
                else { return false; };

            }
        }
        catch (System.Exception eTemple)
        {
            System.Random rTemple = new System.Random();
            int rIntTemple = rTemple.Next(0, 2);
            if (rIntTemple > 0) { return true; }
            else { return false; };
        }
    }

    void Start()
    {
        CoinFlipTemple();
        themeTemple.Play();
    }

    public void PlayPingTemple()
    {
        CoinFlipTemple();
       pingTemple.Play();
    }

    public void PlayClickTemple()
    {
        CoinFlipTemple();
        clickTemple.Play();
        CoinFlipTemple(false);
    }



    void Update()
    {

        if (changedTemple)
        {
            CoinFlipTemple(false);
            if (soundSoundLevelTemple < 0) soundSoundLevelTemple = 0;
            if (musicSoundLevelTemple < 0) musicSoundLevelTemple = 0;

            if (soundSoundLevelTemple > 1.0f) soundSoundLevelTemple = 1.0f;
            if (musicSoundLevelTemple > 1.0f) musicSoundLevelTemple = 1.0f;

            pingTemple.volume = soundSoundLevelTemple;
            clickTemple.volume = soundSoundLevelTemple;
            themeTemple.volume = musicSoundLevelTemple;
            
            changedTemple = false;
        }
        

     if(!themeTemple.isPlaying)
        {
            CoinFlipTemple(false);
            themeTemple.Play();
        }
    }


}
