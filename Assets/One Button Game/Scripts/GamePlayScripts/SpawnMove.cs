using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        // Moving the heart down
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
