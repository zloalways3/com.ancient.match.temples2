using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasTemple : MonoBehaviour
{

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


    public void JumpTemple(string destinationTemple)
    {
        CoinFlipTemple(true);
        GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().PlayClickTemple();
        GameObject.Find("MainCameraTemple").GetComponent<CanvasHolderTemple>().MoveTemple(destinationTemple,false);
    }


    public void JumpBackTemple()
    {
        CoinFlipTemple();
        GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().PlayClickTemple();
        GameObject.Find("MainCameraTemple").GetComponent<CanvasHolderTemple>().MoveBackTemple();
        CoinFlipTemple(false);
    }

    public void JumpOKTemple()
    {
        CoinFlipTemple(true);
        GameObject.Find("MainCameraTemple").GetComponent<SoundManagerTemple>().PlayClickTemple();
        GameObject.Find("MainCameraTemple").GetComponent<CanvasHolderTemple>().MoveToOKTemple();
        CoinFlipTemple(false);
    }

    public void CloseTemple()
    {
        CoinFlipTemple();
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }
}
