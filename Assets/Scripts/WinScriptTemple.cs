using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinScriptTemple : MonoBehaviour
{
    public Text TimerTxtTemple;
    public Text ScoreTxtTemple;

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

    public void WinScreenTemple()
    {
        CoinFlipTemple(true);
        GameObject.Find("LevelChoiceCanvasTemple").GetComponent<LevelActivatorTemple>().ActivateButtonsTemple();
        ScoreTxtTemple.text = GameObject.Find("MovesTextTemple").GetComponent<Text>().text;
        CoinFlipTemple(true);
        TimerTxtTemple.text = GameObject.Find("TimeTextTemple").GetComponent<Text>().text;
    }

}
