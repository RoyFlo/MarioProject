using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePower : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "Goomba")
        {
            Destroy(collision.gameObject);
        }
    }
}
