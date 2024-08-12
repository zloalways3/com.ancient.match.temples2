using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellHolderTemple : MonoBehaviour
{

    public Sprite trueSpriteTemple;

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

    public void OnClickTemple()
    {
        CoinFlipTemple();
        GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().PlayClickTemple();
        if (!GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().randomizedTemple)
        {
            CoinFlipTemple(false);
            GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().RandomizeTemple();
        }


        if (!(GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().firstPickedTemple && GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().secondPickedTemple))
        {
            GetComponent<Image>().sprite = trueSpriteTemple;
            if (!GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().firstPickedTemple)
            {
                GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().cell1Temple = this;
                GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().firstPickedTemple = true;
            }
            else
            {
                if (GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().cell1Temple != this)
                {
                    CoinFlipTemple();
                    GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().cell2Temple = this;
                    GameObject.Find("GameCanvasTemple").GetComponent<GameLogicTemple>().secondPickedTemple = true;
                }
            }
        }
    }

    public void RefreshTemple(Sprite blackboxTemple)
    {
        CoinFlipTemple();
        GetComponent<Image>().sprite = blackboxTemple;
        GetComponent<Button>().interactable = true;
    }
    void Start()
    {
        CoinFlipTemple();
        GetComponent<Button>().interactable = true;
    }


}
