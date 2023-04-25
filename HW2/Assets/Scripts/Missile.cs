using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(5);
    }

    void OnTriggerEnter(Collider collider){
        //Debug.Log("Collided");
        if(collider.gameObject == GameObject.Find("Player")){
            //Debug.Log("Collided quit");
            StartCoroutine(wait());
            Application.Quit();
        }
    }
}
