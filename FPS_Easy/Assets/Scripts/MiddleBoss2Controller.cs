using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoss2Controller : MBossController
{
    public bool isNansa;
    public float nansaTime;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(ShotCoroutine());
        hp = maxHp;
        Debug.Log("onEnablemoon");
    }

    IEnumerator ShotCoroutine()
    {
        Debug.Log(isShooting);
        while (isShooting)
        {
            Debug.Log("WhileMoon");
            float gap = bulletNum > 1 ? angle / (float)(bulletNum - 1) : 0;
            float startAngle = -angle / 2.0f;
            Debug.Log(bulletNum);
            for (int i = 0; i < bulletNum; i++)
            {
                float gak = startAngle + gap * i;
                gak *= Mathf.Deg2Rad;
                Debug.Log("formoon");
                if (isNansa)
                {
                    gak = 0;
                    yield return new WaitForSeconds(nansaTime);
                }
                if (unUsedBullets.Count == 0)
                {
                    MBulletMove _bullet = Instantiate(bullet, this.gameObject.transform).GetComponent<MBulletMove>();
                    _bullet.gameObject.transform.parent = null;
                    _bullet.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    _bullet.transform.position = new Vector3(_bullet.transform.position.x, _bullet.transform.position.y + addShotAimY);
                    _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                    _bullet.controller = gameObject.GetComponent<MobController>();
                }
                else
                {
                    MBulletMove _bullet = unUsedBullets[0].GetComponent<MBulletMove>();
                    unUsedBullets[0].transform.position = this.transform.position;
                    unUsedBullets[0].SetActive(true);
                    _bullet.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    _bullet.transform.position = new Vector3(_bullet.transform.position.x, _bullet.transform.position.y + addShotAimY);
                    unUsedBullets.RemoveAt(0);
                    _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                    _bullet.controller = gameObject.GetComponent<MobController>();
                }
            }
            yield return new WaitForSeconds(60 / shotTime + (Random.Range(0, bonusTime)));
        }
    }
}
