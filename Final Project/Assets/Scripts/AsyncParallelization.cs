using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Diagnostics;



public class AsyncParallelization : MonoBehaviour
{
    bool atomicLock = false;
    private int width = 1920;
    private int height = 1080;
    private Camera camera;

    // Start is called before the first frame update
    void Start(){
        camera = GameObject.FindObjectOfType<Camera>();
        width = camera.pixelWidth;
        height = camera.pixelHeight;
    }

    async Task CaptureScene()
    {   
        atomicLock = true;
        RenderTexture rt = new RenderTexture(width, height, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        ScreenShot.screenshotBytes = screenShot.EncodeToPNG();
        await Task.Run(() => ScreenShot.Save());
        atomicLock = false;
    }


    // Update is called once per frame
    async void Update()
    {
        if(!atomicLock){
            Stopwatch stopwatch = Stopwatch.StartNew();
            await CaptureScene();
            stopwatch.Stop();
        }
    }
}




