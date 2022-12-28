using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlattform : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.name == "player")
            {
                collision.gameObject.transform.SetParent(transform);// set player to a child of moving platform so the positon of player is following Movingplatform
            }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(null);//layer to a child of moving platform so the positon of player is following Movingplatform
        }
    }
}
