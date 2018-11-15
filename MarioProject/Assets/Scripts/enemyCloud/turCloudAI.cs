using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turCloudAI : MonoBehaviour {

    public float speed = 0.5f;
    public Transform Player;
    public GameObject dropBomb;
    float posX = 0;
    float LocateTime = 0;
    float LocateNeedTime = 3;
    float ShootingTime = 1.0f;
    float ShootingNeedTime = 1.0f;
    public Sprite[] spr;
    private SpriteRenderer rend;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = spr[0];
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        
        if (Vector2.Distance(Player.position, transform.position) < 2.0f)
        {
            //transform.position += (displacement * speed * Time.deltaTime);
            rend.sprite = spr[1];
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, transform.position.y), speed * Time.deltaTime);
            AITime();
            AIShooting();
        }
        else
        {
            rend.sprite = spr[0];
        }
        
    }

    void AITime()
    {
        if (LocateTime <= 0)  //if LocateTime <= 0
        {
            LocateTime = LocateNeedTime;  //set LocateTime to LocateNeedTime
            posX = Random.Range(-3, 3); 
        }
        else //
        {
            LocateTime -= Time.deltaTime;
        }
    }

    void AIShooting()
    {
        if (ShootingTime <= 0)  //ShootingTime <= 0
        {
            ShootingTime = ShootingNeedTime;
            Instantiate(dropBomb, transform.position, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            ShootingTime -= Time.deltaTime;
        }
    }
}
