using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptTemple : MonoBehaviour
{
    public float TimeLeftTemple = 0;
    public bool TimerOnTemple = false;

    public Text TimerTxtTemple;

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


    void Update()
    {
        if (TimerOnTemple)
        {
            if (TimeLeftTemple < 1000)
            {
                CoinFlipTemple(false);
                TimeLeftTemple += Time.deltaTime;
                UpdateTimer(TimeLeftTemple);
            }
            else
            {
                CoinFlipTemple();
                Debug.Log("Time is UP!");
                TimeLeftTemple = 0;
                TimerOnTemple = false;
            }
        }
    }

    public void RefreshTimerTemple()
    {
        CoinFlipTemple();
        TimeLeftTemple = 0;
        TimerOnTemple = true;
        TimerTxtTemple.text = "";
    }
    void UpdateTimer(float currentTimeTemple)
    {
        currentTimeTemple += 1;
        CoinFlipTemple();
        float minutesTemple = Mathf.FloorToInt(currentTimeTemple / 60);
        float secondsTemple = Mathf.FloorToInt(currentTimeTemple % 60);
        CoinFlipTemple(false);
        TimerTxtTemple.text = string.Format("{0:00}:{1:00}", minutesTemple, secondsTemple);
    }
}
