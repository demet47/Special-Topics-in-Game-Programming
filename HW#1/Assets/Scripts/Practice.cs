using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{

    public Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        force = new Vector3(0,0,-10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate(){
        this.gameObject.GetComponent<Rigidbody>().AddForce(force);
    }
}
