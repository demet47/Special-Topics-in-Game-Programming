using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script is to be attached to the camera object that is to be used for tracing the player we give the name of
public class AttachedCamera : MonoBehaviour
{

    [SerializeField]
    private string objectNameToBeTraced = "";

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("/"+ objectNameToBeTraced);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+4f, player.transform.position.z-2.5f);
        this.transform.rotation = Quaternion.Euler(new Vector3(50,0,0));

    }
}