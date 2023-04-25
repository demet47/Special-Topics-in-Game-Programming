using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{


    protected Transform stuckTo = null;
    protected Vector3 offset = new Vector3(0f,-1f,-0.5f);
    bool getStuck = false;

    public void LateUpdate()
    {

            if(Input.GetKey(KeyCode.S)){
                getStuck = false;
                StartCoroutine(disableCollisionTemporarily());
            }		

        if (stuckTo != null && getStuck)
            transform.position = stuckTo.position - offset;
    }

    void OnCollisionEnter(Collision col)
    {
        getStuck = true;
        var rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;
        if(col.gameObject == GameObject.Find("Player")){
            stuckTo = col.gameObject.transform;
            Physics.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider>(), GameObject.Find("rust_key").GetComponent<Collider>());
        }
    }


    IEnumerator disableCollisionTemporarily(){
        stuckTo = null;
        yield return new WaitForSeconds(3);
        Physics.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider>(), GameObject.Find("rust_key").GetComponent<Collider>(), false);
    }


}

