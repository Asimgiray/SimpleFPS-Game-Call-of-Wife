using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    float lifespan = 3.0f;
    public int d;




    void Start()
    {

            d = 10;

    }


    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;

        if (lifespan <= 0)
        {
            Explode();
        }
    }

    void OnCollisionEnter(Collision collision){

          if (collision.gameObject.tag == "Dusman"){
            //  collision.gameObject.tag= "Done";
              collision.gameObject.GetComponent<DusmanZeka>().can -= d;
            }
}

    
    void Explode()
    {
        //if(gameObject.tag == "Done")
         // Destroy(gameObject);
    }
}