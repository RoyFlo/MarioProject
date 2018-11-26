using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaDead : MonoBehaviour {


    public Sprite[] deathSprites;
    
    public float frameRate = 12.0f;
    
    public AudioClip deathSound;

    private float counter = 0.0f;
    private int i = 0;
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
        GetComponent<AudioSource>().PlayOneShot(deathSound);
    }

    void Update()
    {
        
        counter += Time.deltaTime * frameRate;
        if (counter > i && i < deathSprites.Length)
        {
            rend.sprite = deathSprites[i];
            i += 1;
        }
        
        if (counter > deathSprites.Length)
        {
            Destroy(gameObject);
        }
    }
}
