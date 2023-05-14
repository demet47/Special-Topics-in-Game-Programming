using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public static int totalCaptures = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Main Camera/Elapsed").GetComponent<TextMeshPro>().text = "time elapsed (sec): " + Time.realtimeSinceStartup; 
        GameObject.Find("Main Camera/Elapsed (1)").GetComponent<TextMeshPro>().text = "number of total captures: " + totalCaptures;
        GameObject.Find("Main Camera/Elapsed (2)").GetComponent<TextMeshPro>().text = "capture rate (per sec): " + totalCaptures/Time.realtimeSinceStartup;


    }
}
