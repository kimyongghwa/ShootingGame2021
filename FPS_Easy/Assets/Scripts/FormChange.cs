using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormChange : MonoBehaviour
{
    protected MobController mc;
    public float changeTime;
    public float bonusTime;
    public float[] ChangerSetting = new float[5]; // 초, 초변화량 ,각, 갯수, 공격력 
    protected float[] StartSetting = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        mc = GetComponent<MobController>();
        StartSetting[0] = mc.shotTime; StartSetting[1] = mc.bonusTime;
        StartSetting[2] = mc.angle; StartSetting[3] = mc.bulletNum; StartSetting[4] = mc.atk;
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
                    mc.shotTime = StartSetting[0]; mc.bonusTime = StartSetting[1];
                    mc.angle = StartSetting[2]; mc.bulletNum = (int)StartSetting[3]; mc.atk = (int)StartSetting[4]; 
                    break;
                case 1:
                    mc.shotTime = ChangerSetting[0]; mc.bonusTime = ChangerSetting[1];
                    mc.angle = ChangerSetting[2]; mc.bulletNum = (int)ChangerSetting[3]; mc.atk = (int)ChangerSetting[4];
                    break;
            }
        }
    }
}
