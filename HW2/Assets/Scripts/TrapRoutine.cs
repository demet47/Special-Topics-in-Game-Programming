using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRoutine : MonoBehaviour
{

    bool atomic = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Trap (1)/Missile (2)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (1)/Missile (3)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (1)/Missile (4)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (1)/Missile (5)").GetComponent<Collider>().enabled = false;

        GameObject.Find("Trap (2)/Missile (2)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (2)/Missile (3)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (2)/Missile (4)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (2)/Missile (5)").GetComponent<Collider>().enabled = false;

        GameObject.Find("Trap (3)/Missile (2)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (3)/Missile (3)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (3)/Missile (4)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (3)/Missile (5)").GetComponent<Collider>().enabled = false;

        GameObject.Find("Trap (4)/Missile (2)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (4)/Missile (3)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (4)/Missile (4)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (4)/Missile (5)").GetComponent<Collider>().enabled = false;

        GameObject.Find("Trap (5)/Missile (2)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (5)/Missile (3)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (5)/Missile (4)").GetComponent<Collider>().enabled = false;
        GameObject.Find("Trap (5)/Missile (5)").GetComponent<Collider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(atomic)
            StartCoroutine(fire());
    }

    IEnumerator fire(){
        atomic = false;
        GameObject missile00 = GameObject.Find("Trap (1)/Missile (2)");
        GameObject missile01 = GameObject.Find("Trap (1)/Missile (3)");
        GameObject missile02 = GameObject.Find("Trap (1)/Missile (4)");
        GameObject missile03 = GameObject.Find("Trap (1)/Missile (5)");
        Debug.Log("Object: ", missile00);

        GameObject m1 = Instantiate(missile00, missile00.transform.position, missile00.transform.rotation, missile00.transform);
        GameObject m2 = Instantiate(missile01, missile01.transform.position, missile01.transform.rotation, missile01.transform);
        GameObject m3 = Instantiate(missile02, missile02.transform.position, missile02.transform.rotation, missile02.transform);
        GameObject m4 = Instantiate(missile03, missile03.transform.position, missile03.transform.rotation, missile03.transform);
        
        m1.GetComponent<Collider>().enabled = true;
        m2.GetComponent<Collider>().enabled = true;
        m3.GetComponent<Collider>().enabled = true;
        m4.GetComponent<Collider>().enabled = true;


        m1.GetComponent<Rigidbody>().AddForce(2f,0,0,ForceMode.Impulse);
        m2.GetComponent<Rigidbody>().AddForce(2f,0,0,ForceMode.Impulse);
        m3.GetComponent<Rigidbody>().AddForce(2f,0,0,ForceMode.Impulse);
        m4.GetComponent<Rigidbody>().AddForce(2f,0,0,ForceMode.Impulse);

        yield return new WaitForSeconds(3);

        Destroy(m1);
        Destroy(m2);
        Destroy(m3);
        Destroy(m4);

        yield return new WaitForSeconds(2);



        var missile10 = GameObject.Find("Trap (2)/Missile (2)");
        var missile11 = GameObject.Find("Trap (2)/Missile (3)");
        var missile12 = GameObject.Find("Trap (2)/Missile (4)");
        var missile13 = GameObject.Find("Trap (2)/Missile (5)");
        
        m1 = Instantiate(missile10, missile10.transform.position, missile10.transform.rotation, missile10.transform);
        m2 = Instantiate(missile11, missile11.transform.position, missile11.transform.rotation, missile11.transform);
        m3 = Instantiate(missile12, missile12.transform.position, missile12.transform.rotation, missile12.transform);
        m4 = Instantiate(missile13, missile13.transform.position, missile13.transform.rotation, missile13.transform);

        m1.GetComponent<Collider>().enabled = true;
        m2.GetComponent<Collider>().enabled = true;
        m3.GetComponent<Collider>().enabled = true;
        m4.GetComponent<Collider>().enabled = true;

        m1.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m2.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m3.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m4.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);

        yield return new WaitForSeconds(3);

        Destroy(m1);
        Destroy(m2);
        Destroy(m3);
        Destroy(m4);

        yield return new WaitForSeconds(2);


        

        var missile20 = GameObject.Find("Trap (3)/Missile (2)");
        var missile21 = GameObject.Find("Trap (3)/Missile (3)");
        var missile22 = GameObject.Find("Trap (3)/Missile (4)");
        var missile23 = GameObject.Find("Trap (3)/Missile (5)");

        m1 = Instantiate(missile20, missile20.transform.position, missile20.transform.rotation, missile20.transform);
        m2 = Instantiate(missile21, missile21.transform.position, missile21.transform.rotation, missile21.transform);
        m3 = Instantiate(missile22, missile22.transform.position, missile22.transform.rotation, missile22.transform);
        m4 = Instantiate(missile23, missile23.transform.position, missile23.transform.rotation, missile23.transform);

        m1.GetComponent<Collider>().enabled = true;
        m2.GetComponent<Collider>().enabled = true;
        m3.GetComponent<Collider>().enabled = true;
        m4.GetComponent<Collider>().enabled = true;
        
        m1.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m2.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m3.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m4.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);

        yield return new WaitForSeconds(3);

        Destroy(m1);
        Destroy(m2);
        Destroy(m3);
        Destroy(m4);

        yield return new WaitForSeconds(2);





        var missile30 = GameObject.Find("Trap (4)/Missile (2)");
        var missile31 = GameObject.Find("Trap (4)/Missile (3)");
        var missile32 = GameObject.Find("Trap (4)/Missile (4)");
        var missile33 = GameObject.Find("Trap (4)/Missile (5)");

        m1 = Instantiate(missile30, missile30.transform.position, missile30.transform.rotation, missile30.transform);
        m2 = Instantiate(missile31, missile31.transform.position, missile31.transform.rotation, missile31.transform);
        m3 = Instantiate(missile32, missile32.transform.position, missile32.transform.rotation, missile32.transform);
        m4 = Instantiate(missile33, missile33.transform.position, missile33.transform.rotation, missile33.transform);

        m1.GetComponent<Collider>().enabled = true;
        m2.GetComponent<Collider>().enabled = true;
        m3.GetComponent<Collider>().enabled = true;
        m4.GetComponent<Collider>().enabled = true;
        
        m1.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m2.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m3.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);
        m4.GetComponent<Rigidbody>().AddForce(0,0,2f,ForceMode.Impulse);

        yield return new WaitForSeconds(3);

        Destroy(m1);
        Destroy(m2);
        Destroy(m3);
        Destroy(m4);

        yield return new WaitForSeconds(2);


        
        var missile40 = GameObject.Find("Trap (5)/Missile (2)");
        var missile41 = GameObject.Find("Trap (5)/Missile (3)");
        var missile42 = GameObject.Find("Trap (5)/Missile (4)");
        var missile43 = GameObject.Find("Trap (5)/Missile (5)");
        
        m1 = Instantiate(missile40, missile40.transform.position, missile40.transform.rotation, missile40.transform);
        m2 = Instantiate(missile41, missile41.transform.position, missile41.transform.rotation, missile41.transform);
        m3 = Instantiate(missile42, missile42.transform.position, missile42.transform.rotation, missile42.transform);
        m4 = Instantiate(missile43, missile43.transform.position, missile43.transform.rotation, missile43.transform);

        m1.GetComponent<Rigidbody>().AddForce(2f,0,0,ForceMode.Impulse);
        m2.GetComponent<Rigidbody>().AddForce(2f,0,0,ForceMode.Impulse);
        m3.GetComponent<Rigidbody>().AddForce(2f,0,0,ForceMode.Impulse);
        m4.GetComponent<Rigidbody>().AddForce(2f,0,0,ForceMode.Impulse);

        yield return new WaitForSeconds(3);

        Destroy(m1);
        Destroy(m2);
        Destroy(m3);
        Destroy(m4);

        yield return new WaitForSeconds(5);

        atomic = true;

    }
}
