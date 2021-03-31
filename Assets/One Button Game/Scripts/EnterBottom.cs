using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBottom : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spawn")
        {
            Destroy(collision.gameObject);
        }
    }

}
