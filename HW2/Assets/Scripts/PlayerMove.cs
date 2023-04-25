using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    AudioSource audioSrc;
    void Start(){
        audioSrc = GetComponent<AudioSource>();
    }
     
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            this.gameObject.GetComponent<Rigidbody>().AddForce(-0.2f,0,0,ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            this.gameObject.GetComponent<Rigidbody>().AddForce(0.2f,0,0,ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            this.gameObject.GetComponent<Rigidbody>().AddForce(0,0,-0.2f,ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            this.gameObject.GetComponent<Rigidbody>().AddForce(0,0,0.2f,ForceMode.Impulse);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space)){
            audioSrc.mute = !audioSrc.mute;
        }

    }

    

}