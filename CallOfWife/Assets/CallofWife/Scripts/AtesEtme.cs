using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtesEtme : MonoBehaviour
{

    public float hasar, mermi, sarjorsayi, sarjor, shoottime, firerate, zaman;

    DusmanZeka dz;
    RaycastHit hit;

    public bool reload;
    public ParticleEmitter muzzleflash;

    public AudioClip shootSound, reloadSound;
    private AudioSource soundSource;

    public GameObject bullet_prefab;
    public Text bulletText;

    float bulletImpulse = 20f;

    void Awake()
    {

        soundSource = GetComponent<AudioSource>();


    }
    void Start()
    {
        hasar = Random.Range(5, 15);
    }




    void Update()
    {

        if (Time.timeScale != 0)
        {

            if (Input.GetButtonDown("Fire1") && mermi > 0 && shoottime <= Time.time)
            {
                soundSource.PlayOneShot(shootSound);

                shoottime = Time.time + firerate;
                mermi--;
                bulletText.text = "" + mermi + " / 20";

                Camera cam = Camera.main;
                GameObject thebullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);
                thebullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);



                //    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 30))
                //    {
                //        if (hit.transform.tag == "Dusman")
                //        {
                //            dz = hit.transform.gameObject.GetComponent<DusmanZeka>();
                //
                //            // dz = hit.transform.gameObject.GetComponent<DusmanZeka>();
                //            dz.can -= hasar;
                //        }
                //    }

            }

            else
            {
                muzzleflash.emit = false;
            }




            if (Input.GetKeyDown(KeyCode.R) && mermi == 0 && sarjorsayi > 0 && reload == false)
            {
                soundSource.PlayOneShot(reloadSound);

                // GetComponent<Animation> ().Play ("Reload");
                Invoke("reload", 3);
                zaman = 2;
                reload = true;
            }
            if (reload)
            {

                zaman -= Time.deltaTime;
                if (zaman <= 0)
                {
                    mermi = sarjor;
                    sarjorsayi -= 1;
                    zaman = 3;
                    bulletText.text = "" + mermi + " / 20";

                    reload = false;
                }
            }

        }
    }
}

