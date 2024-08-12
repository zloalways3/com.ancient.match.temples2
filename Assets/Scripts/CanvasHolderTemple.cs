using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderTemple : MonoBehaviour
{
    public Canvas loadingCanvasTemple;
    public Canvas pressOkCanvasTemple;
    public Canvas menuCanvasTemple;
    public Canvas settingsCanvasTemple;
    public Canvas exitCanvasTemple;
    public Canvas policyCanvasTemple;
    public Canvas gameCanvasTemple;
    public Canvas winCanvasTemple;
    public Canvas levelChoiceCanvasTemple;

    public Slider sliderTemple;
    float sliderValueTemple = 0;

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


    public bool activeTemple = true;

    Timer tTemple;

    public Stack<string> currentStackTemple;


    void Start()
    {
        pressOkCanvasTemple.enabled = false;
        menuCanvasTemple.enabled = false; 
        settingsCanvasTemple.enabled = false;
        exitCanvasTemple.enabled = false;
        CoinFlipTemple(false);
        policyCanvasTemple.enabled = false;
        gameCanvasTemple.enabled = false;
        winCanvasTemple.enabled = false;
        levelChoiceCanvasTemple.enabled = false;
        CoinFlipTemple();
        currentStackTemple = new Stack<string>();

        HideTimerTemple();
    }

 
    public void EndLoadTemple()
    {
        CoinFlipTemple();
        loadingCanvasTemple.enabled = false;
        pressOkCanvasTemple.enabled = true;
    }


    public void MoveToOKTemple()
    {
        CoinFlipTemple();
        if (activeTemple)
        {
            pressOkCanvasTemple.enabled = true;
            policyCanvasTemple.enabled = false;
        }
        else MoveBackTemple();
    }

    public void HideTimerTemple()
    {
        tTemple = new Timer(1500);
        tTemple.AutoReset = false;
        CoinFlipTemple();
        tTemple.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tTemple.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
            CoinFlipTemple(false);
            EndLoadTemple();
        }
        finally
        {
            CoinFlipTemple(false);
            tTemple.Enabled = false;
        }
    }

    public void MoveBackTemple()
    {
        currentStackTemple.Pop();
        CoinFlipTemple(false);
        MoveTemple(currentStackTemple.Peek(), true);
    }
    public void MoveTemple(string destinationTemple, bool backmoveTemple = false)
    {

        pressOkCanvasTemple.enabled = false;
        menuCanvasTemple.enabled = false;
        settingsCanvasTemple.enabled = false;
        CoinFlipTemple(false);
        exitCanvasTemple.enabled = false;
        policyCanvasTemple.enabled = false;
        gameCanvasTemple.enabled = false;
        winCanvasTemple.enabled = false;
        levelChoiceCanvasTemple.enabled = false;

        if (destinationTemple == "winTemple")
        {
            winCanvasTemple.enabled = true;
            backmoveTemple = true;
        }


        CoinFlipTemple();

        if (destinationTemple == "menuTemple")
        {
            menuCanvasTemple.enabled = true;
            activeTemple = false;
        }
        else if (destinationTemple == "settingsTemple")
        {
            settingsCanvasTemple.enabled = true;
        }
        else if (destinationTemple == "levelsTemple")
        {
            levelChoiceCanvasTemple.enabled = true;
        }
        else if (destinationTemple == "policyTemple")
        {
            policyCanvasTemple.enabled = true;
        }
        else if (destinationTemple == "gameTemple")
        {
            CoinFlipTemple(false);
            gameCanvasTemple.enabled = true;
            if (!backmoveTemple) gameCanvasTemple.GetComponent<GameLogicTemple>().RefreshTemple();
        }
        else if (destinationTemple == "exitTemple")
        {
            exitCanvasTemple.enabled = true;
        }
        if (!backmoveTemple) { currentStackTemple.Push(destinationTemple); }
        CoinFlipTemple();
     
    }

    void Update()
    {

        if (loadingCanvasTemple.enabled)
        {
            float time = sliderValueTemple + Time.time;
            if (time < 101)
            {
              
                sliderTemple.value = time;
            }
        }


        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackTemple.Count == 1)
                    {
                        CoinFlipTemple();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackTemple();
                    }

                }
            }
            catch (Exception eTemple)
            {

            }
        }
    }


}
