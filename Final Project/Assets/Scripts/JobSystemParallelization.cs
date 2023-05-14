using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using System.IO;


public class JobSystemParallelization : MonoBehaviour
{

    public static bool done = true;
    JobHandle handle;
    public static int counter = 0;
    public static byte[] bytes;


    public struct MyJob : IJob
    {
        public void Execute()
        {
            var fileName = "Capture_" + counter++ + ".png";
            TimeTracker.totalCaptures = counter;
            string prepath = Directory.GetCurrentDirectory();
            File.WriteAllBytes(prepath + "\\Captures\\JobCapture\\" + fileName, bytes);
            done = true;
        }
    }


    void Update(){
        if(!done) return;
        done = false;
        Camera camera = GameObject.FindObjectOfType<Camera>();
        int width = camera.pixelWidth;
        int height = camera.pixelHeight;
        RenderTexture rt = new RenderTexture(width, height, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        bytes = screenShot.EncodeToPNG();
        MyJob jobData = new MyJob{};

        handle = jobData.Schedule();
    }

}
