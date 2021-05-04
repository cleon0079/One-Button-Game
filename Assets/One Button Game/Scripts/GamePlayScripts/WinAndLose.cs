using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAndLose : MonoBehaviour
{
    [SerializeField] GameObject pointGameObject;
    [SerializeField] GameObject heartGameObject;
    [SerializeField] GameObject loseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject topGameObject;
    [SerializeField] GameObject bottomGameObject;
    public bool lv1 = true;
    public bool lv2 = false;
    public bool lv3 = false;
    public bool win = false;
    public bool lose = false;
    EnterBottomBox enterBottomBox;
    Spawn spawn;
    BottomMove bottomMove;
    TopMove topMove;

    private void Awake()
    {
        lv1 = true;
        lv2 = false;
        lv3 = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        enterBottomBox = pointGameObject.GetComponent<EnterBottomBox>();
        spawn = heartGameObject.GetComponent<Spawn>();
        bottomMove = bottomGameObject.GetComponent<BottomMove>();
        topMove = topGameObject.GetComponent<TopMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lv1)
        {
            // Lv1 speed
            topMove.speed = 5f;
            bottomMove.speed = 5f;

            // Win condition for lv1
            if (spawn.heart >= 0 && enterBottomBox.point >= 4 && winMenu.activeSelf == false)
            {
                win = true;
                lose = false;
            }            
            
            // Lose condition for lv1
            if (spawn.heart == 0 && enterBottomBox.point <= 4 && loseMenu.activeSelf == false)
            {
                win = false;
                lose = true;
            }
        }

        if (lv2)
        {
            // Lv2 speed
            topMove.speed = 8f;
            bottomMove.speed = 8f;

            // Win condition for lv2
            if (spawn.heart >= 0 && enterBottomBox.point >= 6 && winMenu.activeSelf == false)
            {
                win = true;
                lose = false;
            }

            // Lose condition for lv2
            if (spawn.heart == 0 && enterBottomBox.point <= 6 && loseMenu.activeSelf == false)
            {
                win = false;
                lose = true;
            }
        }

        if(lv3)
        {
            // Lv3 speed
            topMove.speed = 10f;
            bottomMove.speed = 10f;

            // Win condition for lv3
            if (spawn.heart >= 0 && enterBottomBox.point >= 8 && winMenu.activeSelf == false)
            {
                win = true;
                lose = false;
            }           
            
            // Lose condition for lv3
            if (spawn.heart == 0 && enterBottomBox.point <= 8 && loseMenu.activeSelf == false)
            {
                win = false;
                lose = true;
            }
        }

        // If win or lose then pull out the menu
        if (lose == true)
            loseMenu.SetActive(true);

        if (win == true)
            winMenu.SetActive(true);
    }
}
