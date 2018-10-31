using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesMoveUp : MonoBehaviour {
    private Vector3 newPosition;
    private void Start()
    {
        newPosition = new Vector3(transform.position.x, transform.position.y + 0.16f, 0);
    }
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, 0.07f * Time.deltaTime);
        if(transform.position == newPosition)
        {
            gameObject.GetComponent<MushroomMovement>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<CollectiblesMoveUp>().enabled = false;
        }
    }
}
