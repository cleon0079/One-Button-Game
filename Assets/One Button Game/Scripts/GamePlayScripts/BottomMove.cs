using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMove : MonoBehaviour
{
    public float speed;
    float screenLeft;
    float screenRight;
    float distanceZ = 10f;
    Vector2 dir = new Vector2(1, 0);
    BoxCollider2D collider2d;
    // Start is called before the first frame update
    void Start()
    {
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        collider2d = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the bottom object left and right within the screen
        transform.Translate(dir * speed * Time.deltaTime);
        if (transform.position.x - collider2d.size.x / 2 <= screenLeft)
        {
            dir = new Vector2(1, 0);
        }
        if (transform.position.x + collider2d.size.x / 2 >= screenRight)
        {
            dir = new Vector2(-1, 0);
        }
    }
}
