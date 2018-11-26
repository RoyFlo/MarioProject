using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBlock : MonoBehaviour {
    private GameObject temp;
    public int power_type;
    void Start()
    {
        power_type = Power_up.power_type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            temp = gameObject.transform.parent.Find("OpenedQBlock").gameObject;
            temp.transform.SetParent(null);
            temp.SetActive(true);
            if(gameObject.transform.parent.Find("Coin")!= null)
            {
                temp = gameObject.transform.parent.Find("Coin").gameObject;
            }
            else if (gameObject.transform.parent.Find("Star") != null)
            {
                temp = gameObject.transform.parent.Find("Star").gameObject;
            }
            else
            {
                power_type = Power_up.power_type;
                switch (power_type)
                {
                    case 0:
                        if (gameObject.transform.parent.Find("Red Mushroom") != null)
                            temp = gameObject.transform.parent.Find("Red Mushroom").gameObject;
                        break;
                    case 1:
                        if (gameObject.transform.parent.Find("Flower") != null)
                            temp = gameObject.transform.parent.Find("Flower").gameObject;
                        break;
                }
            }

            if(temp != null)
            {
                temp.transform.SetParent(null);
                temp.SetActive(true);
            }
            

            gameObject.transform.parent.gameObject.SetActive(false);            
        }
    }

}
