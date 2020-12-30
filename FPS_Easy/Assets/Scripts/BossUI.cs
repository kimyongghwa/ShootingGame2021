using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public Image hpImg;
    public MobController boss;
    // Update is called once per frame
    void Update()
    {
        hpImg.fillAmount = (float)boss.hp / boss.maxHp;
    }
}
