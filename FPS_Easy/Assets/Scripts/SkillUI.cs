using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public Image guardImage;
    public Image boomImage;
    public BulletShot bulletShot;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.level >= 3)
            guardImage.color = new Color(255, 255, 255, 255);
        if (PlayerController.instance.level >= 5)
            boomImage.color = new Color(255, 255, 255, 255);
        guardImage.fillAmount = bulletShot.canGuard;
        boomImage.fillAmount = bulletShot.canBoom;
    }
}
