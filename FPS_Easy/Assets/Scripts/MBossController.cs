using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBossController :  MobController  
{
    void Update()
    {
        if (hp <= 0)
        {
            parents.isBoss = false;
            parents.SpawnExp(transform.position, exp);
            parents.BossCoroutineStarter(20, mobNum + 1);
            parents.isSpawn = true;
            parents.SpawnCoroutine();
            parents.nowMob--;
            Destroy(this.gameObject);
        }
    }
}
