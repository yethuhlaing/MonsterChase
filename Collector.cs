using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
