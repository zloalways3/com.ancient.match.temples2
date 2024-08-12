using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicTemple : MonoBehaviour
{

    public Sprite blackBoxTemple;
    public bool firstPickedTemple = false;
    public bool secondPickedTemple = false;
    bool needToCheckTemple = true;
    public bool randomizedTemple = false;
    public CellHolderTemple cell1Temple;
    public CellHolderTemple cell2Temple;
    Timer tTemple;
 
    List<Sprite> spritesTemple;


    int scoreTemple = 0;
    int moves = 0;

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

    public void RefreshTemple()
    {
        CoinFlipTemple();
        scoreTemple = 0;
        moves = 0;
        GameObject.Find("MovesTextTemple").GetComponent<Text>().text = "Moves:" + moves.ToString();
        GameObject.Find("GameCanvasTemple").GetComponent<TimerScriptTemple>().RefreshTimerTemple();
        CoinFlipTemple();
        RandomizeTemple();

    }


    void CheckTemple()
    {
        
        if(cell1Temple.GetComponent<Image>().sprite== cell2Temple.GetComponent<Image>().sprite)
        {
            CoinFlipTemple();
            cell1Temple.GetComponent<Button>().interactable = false;
            cell2Temple.GetComponent<Button>().interactable = false;
            firstPickedTemple = false;
            secondPickedTemple = false;
            needToCheckTemple = true;
            scoreTemple += 1;
            CoinFlipTemple();           
            GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().PlayPingTemple();
            if (scoreTemple >= 8)
            {
                CoinFlipTemple();
                GameObject.Find("MainCameraTemple").GetComponent<CanvasHolderTemple>().MoveTemple("winTemple");
                GameObject.Find("WinCanvasTemple").GetComponent<WinScriptTemple>().WinScreenTemple();
            }

        }
        else
        {
            CoinFlipTemple();
            HideTimerTemple();
        }
    }

    public void HideTimerTemple()
    {
        CoinFlipTemple();
        tTemple = new Timer(1000);
        tTemple.AutoReset = false;
        CoinFlipTemple(false);
        tTemple.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tTemple.Start();

    }



    public void RandomizeTemple()
    {


        spritesTemple = new List<Sprite>();

        for (int iTemple = 1; iTemple<17; iTemple++)
        {
            spritesTemple.Add(GameObject.Find("CellTemple" + iTemple.ToString() ).GetComponent<CellHolderTemple>().trueSpriteTemple);
            GameObject.Find("CellTemple" + iTemple.ToString() ).GetComponent<CellHolderTemple>().RefreshTemple(blackBoxTemple);
        }

        CoinFlipTemple();
        System.Random rTemple = new System.Random();

        for (int iTemple = 1; iTemple < 17; iTemple++)
        {
            int rIntTemple = rTemple.Next(0, spritesTemple.Count);
            GameObject.Find("CellTemple" + iTemple.ToString() ).GetComponent<CellHolderTemple>().trueSpriteTemple = spritesTemple[rIntTemple];
            spritesTemple.RemoveAt(rIntTemple);
        }
        CoinFlipTemple();
        randomizedTemple = true;
    }

    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
        CoinFlipTemple();
        try
        {
            cell1Temple.GetComponent<Image>().sprite = blackBoxTemple;
            cell2Temple.GetComponent<Image>().sprite = blackBoxTemple;
            firstPickedTemple = false;
            secondPickedTemple = false;
            needToCheckTemple = true;
            CoinFlipTemple();
        }
        finally
        {
            CoinFlipTemple();
            tTemple.Enabled = false;
        }
    }



    void Update()
    {
        if(firstPickedTemple && secondPickedTemple && needToCheckTemple) {
            needToCheckTemple = false;
            moves++;
            GameObject.Find("MovesTextTemple").GetComponent<Text>().text = "Moves:" + moves.ToString();
            CheckTemple();
        }
      
    }
}
