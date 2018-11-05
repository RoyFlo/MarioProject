using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesMoveUp : MonoBehaviour {
    private Vector3 newPosition;
    private void Start()
    {
        newPosition = new Vector3(transform.position.x, transform.position.y + 0.164f, 0);
    }
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, 0.08f * Time.deltaTime);
        if(transform.position == newPosition)
        {
            if (gameObject.name.Contains("Mushroom"))
            {
                gameObject.GetComponent<MushroomMovement>().enabled = true;
            }
            if(gameObject.name.Contains("Star"))
            {
                gameObject.GetComponent<StarMovement>().enabled = true;
            }
            if(gameObject.GetComponent<Rigidbody2D>() != null)
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            }
            if(gameObject.GetComponent<BoxCollider2D>() != null)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            //           gameObject.transform.SetParent(null);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<CollectiblesMoveUp>().enabled = false;
        }
    }
}
