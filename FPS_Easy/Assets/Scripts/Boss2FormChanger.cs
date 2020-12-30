﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2FormChanger : FormChange
{
    protected Boss2Controller mbc;
    public Boss2Mover mover;
    public float addTime;
    void Start()
    {
        mbc = GetComponent<Boss2Controller>();
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
                    mbc.zMove = true;
                    mbc.isShooting = false;
                    mover.moverOn = true;
                    yield return new WaitForSeconds(addTime);
                    mbc.shotTime = StartSetting[0]; mbc.bonusTime = StartSetting[1];
                    mbc.angle = StartSetting[2]; mbc.bulletNum = (int)StartSetting[3]; mbc.atk = (int)StartSetting[4];
                    mbc.isNansa = false;
                    mbc.isShooting = true;
                    mbc.ShotCoroutineStarter();
                    break;
                case 1:
                    mbc.zMove = false;
                    mbc.isShooting = false;
                    mover.moverOn = false;
                    yield return new WaitForSeconds(addTime);
                    mbc.shotTime = ChangerSetting[0]; mbc.bonusTime = ChangerSetting[1];
                    mbc.angle = ChangerSetting[2]; mbc.bulletNum = (int)ChangerSetting[3]; mbc.atk = (int)ChangerSetting[4];
                    mbc.isNansa = true;
                    mbc.isShooting = true;
                    mbc.ShotCoroutineStarter();
                    break;
            }
        }
    }
}
