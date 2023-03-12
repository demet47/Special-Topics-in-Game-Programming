using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
     
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            this.gameObject.GetComponent<Rigidbody>().AddForce(-0.5f,0,0,ForceMode.Impulse);
        }
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            this.gameObject.GetComponent<Rigidbody>().AddForce(0.5f,0,0,ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.UpArrow)){
            this.gameObject.GetComponent<Rigidbody>().AddForce(0,0,-0.5f,ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            this.gameObject.GetComponent<Rigidbody>().AddForce(0,0,0.5f,ForceMode.Impulse);
        }

    }
}
