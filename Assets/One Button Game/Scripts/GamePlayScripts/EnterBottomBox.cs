using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class EnterBottomBox : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Animator anim;
    public int point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spawn")
        {
            // Get point when we catch a heart and play the anim
            Destroy(collision.gameObject);
            point++;
            anim.SetTrigger("Get");
        }
    }

    private void Update()
    {
        text.text = "Point : " + point;
        anim.SetBool("NotGet", true);
    }
}
