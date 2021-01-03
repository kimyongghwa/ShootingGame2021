using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBossController :  MobController  
{
    public Material movingMaterial;

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
    public override void BeHurt()
    {
        Debug.Log("BehurtBoss");
        Debug.Log(movingMaterial.name);
        Debug.Log(renderer.material.name);
        Debug.Log(renderer.material.name );
        if (renderer.material.name != movingMaterial.name + " (Instance)")
        {
            Debug.Log("BehurtBoss2");
            StartCoroutine(HurtCoroutine());
        }
    }
    public override IEnumerator HurtCoroutine()
    {
        Debug.Log("BehurtBossCoroutine");
        renderer.material = hitMarterial;
        yield return new WaitForSeconds(0.08f);
        renderer.material = normalMarterial;
    }

}
