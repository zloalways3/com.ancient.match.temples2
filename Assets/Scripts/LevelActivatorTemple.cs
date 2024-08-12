using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class LevelActivatorTemple : MonoBehaviour
{



    public int currentLevelTemple = -1;


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

    public void ActivateButtonsTemple()
    {
        currentLevelTemple++;
        int tempTemple = currentLevelTemple;
        CoinFlipTemple();
        List<Button> buttonsTemple = new List<Button>();
        for (int iTemple = 2;iTemple<13; iTemple++)
        {
            buttonsTemple.Add(GameObject.Find("ButtonLevelTemple" + iTemple.ToString()).GetComponent<Button>());
        }

   
        while (tempTemple > -1)
        {
            CoinFlipTemple(false);
            buttonsTemple[tempTemple].GetComponent<Button>().interactable = true;
            tempTemple--;
        }
        CoinFlipTemple();
    }
}
