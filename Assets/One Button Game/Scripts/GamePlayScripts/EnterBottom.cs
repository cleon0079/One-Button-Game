using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBottom : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy all the heart that was out of the screen
        if(collision.gameObject.tag == "Spawn")
        {
            Destroy(collision.gameObject);
        }
    }

}
