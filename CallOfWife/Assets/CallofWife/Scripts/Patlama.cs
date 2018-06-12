using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patlama : MonoBehaviour
{

    public GameObject bomba;
    public float power = 10.0f;//effect power
    public float radius = 5.0f;  //effect area
    public float upForce = 1.0f; //patlattığı nesneyi havaya kaldırıyor
    public GameObject bomba_prefab;
    public float bulletImpulse = 10f;
    public int d;

    // Use this for initialization
    void Start()
    {

    }

    /*void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Dusman")
        {
            collision.gameObject.GetComponent<DusmanZeka>().can -= d;
            Detonate();
        }
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.G)) 
        {
            Camera cam = Camera.main;
            GameObject bomba = (GameObject)Instantiate(bomba_prefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);
            bomba.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
            
                Invoke("Detonate", 2);
            
        }



    }
    void Detonate()
    {
        Vector3 explosionPosition = bomba.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }


        }
    }
}

