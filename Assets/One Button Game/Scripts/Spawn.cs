using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawn = Resources.Load("Prefab/2") as GameObject;
            spawn = Instantiate(spawn, gameObject.transform.position, Quaternion.identity);
        }
    }
}
