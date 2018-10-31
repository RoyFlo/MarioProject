using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBlock : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            GameObject temp = gameObject.transform.parent.Find("OpenedQBlock").gameObject;
            temp.transform.SetParent(null);
            temp.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
