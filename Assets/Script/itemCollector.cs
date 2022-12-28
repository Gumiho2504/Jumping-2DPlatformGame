using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;
    private int cherries = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("cherry"))
        {
            collectSoundEffect.Play();  
            Destroy(collision.gameObject);
            cherries++;
           cherriesText.text = "Cherries : " + cherries;
        }
    }
}
