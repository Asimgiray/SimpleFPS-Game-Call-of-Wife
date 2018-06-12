using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }


    public Slider healthbar;
    public static CharacterHealth instance = null;  


	// Use this for initialization

    void Awake()
    {
        //SINGLETON 
        if (instance == null)  //check and see dowe have a gm yet, if not set it
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
     

    }
	void Start () {
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        healthbar.value = CalculateHealth();
		
	}
	
	// Update is called once per frame
	public void Update () {
           // DealDamage(1);
	}
    public void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthbar.value = CalculateHealth();
        if (CurrentHealth <= 0)
            Die();
    }


    public void AddHealth()
    {
        if (CurrentHealth <= 90) { 
        CurrentHealth += 10;
        healthbar.value = CalculateHealth();
        if (CurrentHealth <= 0)
            Die();
    }
    }


    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
    void Die()
    {

        LevelManagerGame.instance.GameOver();
        CurrentHealth = 0;
        Debug.Log("You dead..");
    }
}
