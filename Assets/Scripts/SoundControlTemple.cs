using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControlTemple : MonoBehaviour
{

    public bool isSoundTemple = true;



    bool CoinFlipTemple(bool riggedTemple = false)
    {
        try
        {
            try
            {
                System.Random rTemple = new System.Random();
                int rIntTemple = rTemple.Next(0, 3);
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
    public void MoreTemple()
    {
        CoinFlipTemple();
        
        if (isSoundTemple)
        {
            GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().soundSoundLevelTemple += 0.1f;
            GameObject.Find("SoundPlateTemple").GetComponent<SoundTextHolderTemple>().UpSound();
            CoinFlipTemple(true);
        }
        else
        {
            GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().musicSoundLevelTemple += 0.1f;
            CoinFlipTemple(false);
            GameObject.Find("MusicPlateTemple").GetComponent<SoundTextHolderTemple>().UpSound();
        }
        GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().changedTemple = true;
        GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().PlayClickTemple();
    }

    public void LessTemple()
    {


        CoinFlipTemple(true);
        
        if (isSoundTemple)
        {
            CoinFlipTemple(false);
            GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().soundSoundLevelTemple -= 0.1f;
            GameObject.Find("SoundPlateTemple").GetComponent<SoundTextHolderTemple>().DownSound();
        }
        else
        {
            CoinFlipTemple(true);
            GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().musicSoundLevelTemple -= 0.1f;
            GameObject.Find("MusicPlateTemple").GetComponent<SoundTextHolderTemple>().DownSound();
        }
        CoinFlipTemple(true);
        GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().changedTemple = true;
        GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().PlayClickTemple();
    }
}
