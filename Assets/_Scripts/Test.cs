using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text t;
    int totalHp = 1000;
    int currentHp = 1000;
    public Image img;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int hurt = -100;
            DynamicNumber.ChangeNum(t, hurt);
            currentHp += hurt;
            DynamicImage.MoveImageByFillAmount(img, currentHp / (float)totalHp, 1f);
        }
    }
}
