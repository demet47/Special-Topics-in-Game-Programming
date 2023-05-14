using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CoroutineParallelization : MonoBehaviour
{
    bool locked = false;
    private int width = 1920;
    private int height = 1080;
    private Camera camera;
    private int counter = 0;


    void Start(){
        camera = GameObject.FindObjectOfType<Camera>();
        width = camera.pixelWidth;
        height = camera.pixelHeight;
    }

    void Update(){
        if(!locked){
            StartCoroutine(CaptureScene());
        }
    }


    IEnumerator CaptureScene(){
        locked = true;
        RenderTexture rt = new RenderTexture(width, height, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] screenshotBytes = screenShot.EncodeToPNG();
        yield return null;
        var fileName = "Capture_" + counter++ + ".png";
        TimeTracker.totalCaptures = counter;
        string prepath = Directory.GetCurrentDirectory();
        File.WriteAllBytes(prepath + "\\Captures\\CoroutineCapture\\" + fileName, screenshotBytes);
        yield return null;
        locked = false;
    }

}
