﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoss1FormChanger : FormChange
{
    public MiddleBoss1Mover mover;
    MiddleBoss1Controller mbc;
    // Start is called before the first frame update
    void Start()
    {
        mbc = GetComponent<MiddleBoss1Controller>();
        StartSetting[0] = mbc.shotTime; StartSetting[1] = mbc.bonusTime;
        StartSetting[2] = mbc.angle; StartSetting[3] = mbc.bulletNum; StartSetting[4] = mbc.atk;
        StartCoroutine(ChangeForm(changeTime));
    }

    IEnumerator ChangeForm(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time + Random.Range(0, bonusTime));
            switch (Random.Range(0, 2))
            {
                case 0:
                    mbc.shotTime = StartSetting[0]; mbc.bonusTime = StartSetting[1];
                    mbc.angle = StartSetting[2]; mbc.bulletNum = (int)StartSetting[3]; mbc.atk = (int)StartSetting[4];
                    mover.moverOn = true;
                    mbc.rotationShooting = true;
                    break;
                case 1:
                    mbc.shotTime = ChangerSetting[0]; mbc.bonusTime = ChangerSetting[1];
                    mbc.angle = ChangerSetting[2]; mbc.bulletNum = (int)ChangerSetting[3]; mbc.atk = (int)ChangerSetting[4];
                    mover.moverOn = false;
                    mbc.rotationShooting = false;
                    break;
            }
        }
    }
}
