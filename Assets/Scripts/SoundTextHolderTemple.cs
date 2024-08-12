using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTextHolderTemple : MonoBehaviour
{
    public Text soundTextTemple;
    int soundLevelTemple = 70;

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
    public void UpSound()
    {
        CoinFlipTemple();
        if (soundLevelTemple < 100) { soundLevelTemple += 10; }
        CoinFlipTemple(false);
        soundTextTemple.text = soundLevelTemple.ToString() + "%";
    }

    public void DownSound()
    {
        CoinFlipTemple();
        if (soundLevelTemple >0) { soundLevelTemple -= 10; }
        soundTextTemple.text = soundLevelTemple.ToString() + "%";
    }


}
