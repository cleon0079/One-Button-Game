using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Spawn : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Animator anim;
    public int heart = 10;
 
    // Update is called once per frame
    void Update()
    {
        // Spawn a heart when we press space and play the anim
        anim.SetBool("NotDo", true);
        text.text = "Heart : " + heart;
        if(Input.GetKeyDown(KeyCode.Space) && heart >= 1)
        {
            heart--;
            GameObject spawn = Resources.Load("Prefab/Heart") as GameObject;
            spawn = Instantiate(spawn, gameObject.transform.position, Quaternion.identity);
            anim.SetTrigger("Do");
        }
    }
}
