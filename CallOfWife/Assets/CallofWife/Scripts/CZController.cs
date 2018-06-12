using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CZController : MonoBehaviour
{

       void Start()
    {


    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animation>().Play("Fire");
        } if (Input.GetKeyDown(KeyCode.R) )
        {
            GetComponent<Animation> ().Play ("Reload");
        }
    
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wife")
        {
            SceneManager.LoadScene("WinScene");
            Cursor.visible = true;

        }
        if (collision.gameObject.tag == "Health")
        {
            CharacterHealth.instance.AddHealth();
            Destroy(collision.gameObject);
        }

    }

}

