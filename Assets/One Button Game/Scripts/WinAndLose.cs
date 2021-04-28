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
    EnterBottomBox enterBottomBox;
    Spawn spawn;
    BottomMove bottomMove;
    TopMove topMove;
    bool win;
    bool lv1;
    bool lv2;
    bool lv3;

    // Start is called before the first frame update
    void Start()
    {
        enterBottomBox = pointGameObject.GetComponent<EnterBottomBox>();
        spawn = heartGameObject.GetComponent<Spawn>();
        bottomMove = bottomMove.GetComponent<BottomMove>();
        topMove = topGameObject.GetComponent<TopMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lv1)
        {
            if (enterBottomBox.point >= 0 && spawn.heart >= 4)
                win = true;
            else
                win = false;
        }

        if(lv2)
        {
            if (enterBottomBox.point >= 0 && spawn.heart >= 6)
                win = true;
            else
                win = false;
        }

        if(lv3)
        {
            if (enterBottomBox.point >= 0 && spawn.heart >= 8)
                win = true;
            else
                win = false;
        }

        if (win == false)
            loseMenu.SetActive(true);

        if (win == true)
            winMenu.SetActive(true);
    }
}
