using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [SerializeField] Text text;
    public int heart = 10;
 
    // Update is called once per frame
    void Update()
    {
        text.text = "Heart : " + heart;
        if(Input.GetKeyDown(KeyCode.Space) && heart >= 1)
        {
            heart--;
            GameObject spawn = Resources.Load("Prefab/2") as GameObject;
            spawn = Instantiate(spawn, gameObject.transform.position, Quaternion.identity);
        }
    }
}
