using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;
    private float multiply = -1f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.parent == GameObject.Find("/InvisibleWall").transform){
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.right * speed * multiply;
            multiply *= -1f;
        }else{
            Debug.Log("Distorted!: "+ Time.realtimeSinceStartup + " " + gameObject.name);
        }
     
    }
}
