using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2Controller : MiddleBoss2Controller
{
    Boss2Mover mover;
    public float randomValue;
    public float nansaBulletSpeed = 8;
    public float randomGakValue;
    public float zBulletSpeed = 20;
    public bool zMove;
    private void OnEnable()
    {
        StartCoroutine(ShotCoroutine());
        hp = maxHp;
        mover = this.GetComponent<Boss2Mover>();
    }
    public void ShotCoroutineStarter()
    {
        StartCoroutine(ShotCoroutine());
    }
    void Update()
    {
        if (hp <= 0)
        {
            PlayerPrefs.SetInt("nowPlayerScore", PlayerController.instance.score);
            SceneManager.LoadScene(2);
            parents.nowMob--;
            Destroy(this.gameObject);
        }
    }
    IEnumerator ShotCoroutine()
    {
        Debug.Log(isShooting);
        while (isShooting)
        {
            yield return new WaitForSeconds(60 / shotTime + (Random.Range(0, bonusTime)));
            if ((mover.mokpyo == transform.position && mover.moverOn ) || (mover.moverPos[1] == transform.position && !mover.moverOn))
            {
                float gap = bulletNum > 1 ? angle / (float)(bulletNum - 1) : 0;
                float startAngle = -angle / 2.0f;
                float rangak = Random.Range(-randomGakValue, randomGakValue);
                for (int i = 0; i < bulletNum; i++)
                {
                    float gak = startAngle + gap * i;
                    gak *= Mathf.Deg2Rad;
                    if (isNansa)
                    {
                        gak = 0;
                        yield return new WaitForSeconds(nansaTime);
                    }
                    if (unUsedBullets.Count == 0)
                    {
                        MBulletMove _bullet = Instantiate(bullet, this.gameObject.transform).GetComponent<MBulletMove>();
                        if (isNansa)
                            _bullet.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Random.Range(-randomValue, randomValue), 0);
                        _bullet.gameObject.transform.parent = null;
                        _bullet.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        if (zMove)
                        {
                            _bullet.zBullet = true;
                            _bullet.speed = zBulletSpeed;
                            _bullet.SetDirection(new Vector3(Mathf.Cos(gak + rangak), Mathf.Sin(gak + rangak), _bullet.gameObject.transform.position.z - PlayerController.instance.transform.position.z).normalized);
                        }
                        else
                            _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                        _bullet.controller = gameObject.GetComponent<MobController>();
                    }
                    else
                    {
                        MBulletMove _bullet = unUsedBullets[0].GetComponent<MBulletMove>();

                        unUsedBullets[0].transform.position = this.transform.position;
                        if (isNansa)
                            _bullet.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Random.Range(-randomValue, randomValue), 0);
                        unUsedBullets[0].SetActive(true);
                        _bullet.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        unUsedBullets.RemoveAt(0);
                        _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                        if (zMove)
                        {
                            _bullet.zBullet = true;
                            _bullet.speed = zBulletSpeed;
                            _bullet.SetDirection(new Vector3(Mathf.Cos(gak + rangak), Mathf.Sin(gak + rangak), _bullet.gameObject.transform.position.z - PlayerController.instance.transform.position.z).normalized);
                        }
                        else
                        {
                            _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                            _bullet.speed = nansaBulletSpeed;
                        }
                        _bullet.controller = gameObject.GetComponent<MobController>();
                    }
                }
            }
        }
    }
}
