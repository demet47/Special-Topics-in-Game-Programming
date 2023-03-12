using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateObject : MonoBehaviour
{
    public static int numOfObjectsDuplicated = 0;
    bool duplicate = true;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) & duplicate){
            duplicate = false;
            Instantiate(GameObject.Find("/Sphere1"), new Vector3(GameObject.Find("/Sphere1").transform.position.x  + 0.8f, GameObject.Find("/Sphere1").transform.position.y, GameObject.Find("/Sphere1").transform.position.z), Quaternion.identity).name = "Sphere"+ numOfObjectsDuplicated++;
        }
    }
}
