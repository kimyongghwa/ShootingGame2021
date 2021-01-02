using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1FormChange : FormChange
{
    public Boss1Mover mover;
    MBossController mbc;
    public int beforePlayerCheckTime = 1;

    void Start()
    {
        mbc = GetComponent<MBossController>();
        mc = mbc;
        StartSetting[0] = mbc.shotTime; StartSetting[1] = mbc.bonusTime;
        StartSetting[2] = mbc.angle; StartSetting[3] = mbc.bulletNum; StartSetting[4] = mbc.atk;
        StartCoroutine(ChangeForm(changeTime));
    }
    IEnumerator ChangeForm(float time)
    {
        Debug.Log("ChangeForms0");
        while (true)
        {
            Debug.Log("ChangeForms1");
            switch (Random.Range(0, 2))
            {
                case 0:
                    mover.moverOn = false;
                    mc.shotTime = StartSetting[0]; mc.bonusTime = StartSetting[1];
                    mc.angle = StartSetting[2]; mc.bulletNum = (int)StartSetting[3]; mc.atk = (int)StartSetting[4];
                    mover.MokpyoOn();
                    mbc.renderer.material = mbc.movingMaterial;
                    yield return new WaitForSeconds(beforePlayerCheckTime);
                    mbc.renderer.material = mbc.normalMarterial;
                    Debug.Log(mover.mokpyo);
                    mover.moverOn = true;
                    break;
                case 1:
                    mc.shotTime = ChangerSetting[0]; mc.bonusTime = ChangerSetting[1];
                    mc.angle = ChangerSetting[2]; mc.bulletNum = (int)ChangerSetting[3]; mc.atk = (int)ChangerSetting[4];
                    mover.MokpyoOn();
                    mover.moverOn = false;
                    break;
            }
            Debug.Log("ChangeForms2");
            yield return new WaitForSeconds(time + Random.Range(0, bonusTime));
        }
    }
}
