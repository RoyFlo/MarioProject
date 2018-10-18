using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_up : MonoBehaviour {

    // Use this for initialization
    public int power_type;
    public GameObject normal_mario;
    public GameObject big_mario;
    public Sprite fire_power;
    public Sprite invincible_power;
    public float power_up_timer;
	void Start () {
        power_type = 0;
        power_up_timer = 10;
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Power Up")
        {

            if(col.gameObject.name.Contains("Red Mushroom"))
            {
                power_type = 1;
            }
            if (col.gameObject.name.Contains("Flower"))
            {
                power_type = 2;
            }
            if(col.gameObject.name.Contains("Star"))
            {
                power_type += 3;
            }
            Destroy(col.gameObject);
            getPower();
        }
        if (col.gameObject.tag == "Enemy")
        {
            power_type = 0;
            Destroy(col.gameObject);
            getPower();
        }
    }
    private void getPower()
    {
        if(power_type == 0)
        {
            normal_mario.transform.position = big_mario.transform.position;
            big_mario.SetActive(false);
            normal_mario.SetActive(true);
        }
        if(power_type == 1)
        {
            big_mario.transform.position = normal_mario.transform.position;
            big_mario.SetActive(true);
            normal_mario.SetActive(false);
        }
        if(power_type == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = fire_power;
        }
        if(power_type == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = invincible_power;
            this.gameObject.GetComponent<Animator>().runtimeAnimatorController = 
                Resources.Load("small Mario invincible") as RuntimeAnimatorController;
            while(power_up_timer > 0.0)
            {
                power_up_timer -= Time.deltaTime;
            }
            if (power_up_timer == 0)
            {
                power_type -= 3;
                getPower();
            }
        }
    }
}
