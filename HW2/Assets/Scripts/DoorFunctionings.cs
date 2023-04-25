using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFunctionings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void doorOpen(){
        GameObject.Find("Door/Plane").GetComponent<Rigidbody>().useGravity = true;
        GameObject.Find("Door/Plane").GetComponent<Collider>().enabled = false;
    }

    IEnumerator wait(int sec){
        yield return new WaitForSeconds(sec);
    }

    void OnCollusionEnter(Collision collision){
        if(collision.gameObject == GameObject.Find("rust_key")){
            Debug.Log("Unlocked Door, You Won!");
            doorOpen();
        }
        StartCoroutine(wait(3));
        Application.Quit();
    }
}
