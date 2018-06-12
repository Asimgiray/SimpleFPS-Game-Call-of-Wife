using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanZeka : MonoBehaviour {

	public float hiz, mesafe, mermi, zaman, shoottime, firerate, can, canplayer;
	public bool yurume, ates;
	public Transform karakter;
	Vector3 poz;
	public ParticleEmitter muzzleflash;
	public GameObject oluasker;
	//public GameObject namlu;
	//RaycastHit hit;
    public GameObject bullet_prefab;

    float bulletImpulse = 20f;


	void Start () {
		can = 100;
	}

 
	void Update () {
		poz = new Vector3 (karakter.position.x, transform.position.y, karakter.position.z);
		mesafe = Vector3.Distance (transform.position, karakter.position);	
		if (mesafe < 10 && mesafe > 5f) {
			yurume = true;
			ates = false;
		}
		if (mesafe < 5f) {
			yurume = false;
			ates = true;
		}
		if (mesafe > 10) {
			yurume = false;
			ates = false;
		}
		if (yurume) {
			hiz = 4;
			transform.position = Vector3.MoveTowards (transform.position, karakter.position, hiz * Time.deltaTime);
			transform.LookAt (poz);
			GetComponent<Animation> ().Play ("Run");
			muzzleflash.emit = false;
		}
		if (ates) {

			transform.LookAt (poz);
			if (mermi > 0 && shoottime <= Time.time) {
				shoottime = Time.time + firerate;
			
				GetComponent<Animation> ().Play ("StandingFire");
				GetComponent<AudioSource> ().Play ();
				muzzleflash.emit = true;
				mermi--;
                canplayer--;
                CharacterHealth.instance.DealDamage(1);

              
			}
			if (mermi <= 0) {
				zaman -= Time.deltaTime;
				GetComponent<Animation> ().Play ("StandingReloadM4");
				muzzleflash.emit = false;
				if (zaman < 0) {
					mermi = 30;
					zaman = 2.3f;
				}
			}

		}



		if (yurume == false && ates== false) {
			GetComponent<Animation> ().Play ("Idle");
			muzzleflash.emit = false;
		}
		if (can <= 0) {
            Instantiate(oluasker, transform.position, transform.rotation);
            Destroy(gameObject);
            LevelManagerGame.instance.wallControl += 1;
            LevelManagerGame.instance.DeathSound();
	}
	}
}
