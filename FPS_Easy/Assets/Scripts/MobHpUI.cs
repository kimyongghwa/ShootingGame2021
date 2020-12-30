using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobHpUI : MonoBehaviour
{
    public Image HpImage;
    public MobController mob;

    void Update()
    {
        HpImage.fillAmount = (float)mob.hp / mob.maxHp;
    }
}
