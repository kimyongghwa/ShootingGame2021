using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1FormChange : FormChange
{
    public Boss1Mover mover;
    public int beforePlayerCheckTime = 1;

    void Start()
    {
        mc = GetComponent<MobController>();
        StartSetting[0] = mc.shotTime; StartSetting[1] = mc.bonusTime;
        StartSetting[2] = mc.angle; StartSetting[3] = mc.bulletNum; StartSetting[4] = mc.atk;
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
                    mc.shotTime = StartSetting[0]; mc.bonusTime = StartSetting[1];
                    mc.angle = StartSetting[2]; mc.bulletNum = (int)StartSetting[3]; mc.atk = (int)StartSetting[4];
                    mover.MokpyoOn();
                    yield return new WaitForSeconds(beforePlayerCheckTime);
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
