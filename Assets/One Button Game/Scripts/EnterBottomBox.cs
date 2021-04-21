using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterBottomBox : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] int point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spawn")
        {
            Destroy(collision.gameObject);
            point++;
        }
    }

    private void Update()
    {
        text.text = "Point : " + point;
    }
}
