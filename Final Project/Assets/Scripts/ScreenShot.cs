using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class ScreenShot
{
    public static byte[] screenshotBytes;
    private static int counter = 0;
    // Start is called before the first frame update
    public static void Save(){
        var fileName = "Capture_" + counter++ + ".png";
        TimeTracker.totalCaptures = counter;
        string prepath = Directory.GetCurrentDirectory();
        File.WriteAllBytes(prepath + "\\Captures\\AsyncCapture\\" + fileName, screenshotBytes);
    }
}
