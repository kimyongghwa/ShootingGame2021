using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoss1Controller : MBossController
{
    public GameObject target;
    public bool rotationShooting;
    public float randomAngle;
    private void OnEnable()
    {
        StartCoroutine(ShotCoroutine());
        hp = maxHp;
    }
    IEnumerator ShotCoroutine()
    {
        while (isShooting)
        {
            yield return new WaitForSeconds(60 / shotTime + (Random.Range(0, bonusTime)));
            float gap = bulletNum > 1 ? angle / (float)(bulletNum - 1) : 0;
            float startAngle = -angle / 2.0f;
            for (int i = 0; i < bulletNum; i++)
            {
                float gak = startAngle + gap * i;
                gak *= Mathf.Deg2Rad;
                if (unUsedBullets.Count == 0)
                {
                    MBulletMove _bullet = Instantiate(bullet, this.gameObject.transform).GetComponent<MBulletMove>();
                    _bullet.gameObject.transform.parent = null;
                    _bullet.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    _bullet.transform.position = new Vector3(_bullet.transform.position.x, _bullet.transform.position.y + addShotAimY);
                    if (rotationShooting)
                        _bullet.SetDirection(new Vector3(transform.position.x - target.transform.position.x + Random.Range(-randomAngle, randomAngle), transform.position.y - target.transform.position.y + Random.Range(-randomAngle, randomAngle)).normalized);
                    else
                        _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                    _bullet.controller = gameObject.GetComponent<MiddleBoss1Controller>();
                }
                else
                {
                    MBulletMove _bullet = unUsedBullets[0].GetComponent<MBulletMove>();
                    unUsedBullets[0].transform.position = this.transform.position;
                    unUsedBullets[0].SetActive(true);
                    _bullet.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    _bullet.transform.position = new Vector3(_bullet.transform.position.x, _bullet.transform.position.y + addShotAimY);
                    unUsedBullets.RemoveAt(0);
                    if (rotationShooting)
                        _bullet.SetDirection(new Vector3(transform.position.x - target.transform.position.x + Random.Range(-randomAngle, randomAngle), transform.position.y - target.transform.position.y + Random.Range(-randomAngle, randomAngle)).normalized);
                    else
                        _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                    _bullet.controller = gameObject.GetComponent<MiddleBoss1Controller>();
                }
            }
        }
    }
}
