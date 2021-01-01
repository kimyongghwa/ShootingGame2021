using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public int atk;
    public int lineAtk = 20;
    public int radialAtk = 10;
    public int maxBullets;
    public int useBullets = 1;
    int nowBullets;
    public int GetNBullet
    {
        get
        {
            return nowBullets;
        }
    }
    public bool lineMode;
    public bool isShooting;
    public float shotTime;
    public float lineShotTime = 60f;
    public float radialShotTime = 40f;
    public int bulletNum;
    public PlayerController pc;
    public GameObject bullet;
    public GameObject guard;
    public GameObject boom;
    public bool canShot = true;
    public bool canReload = true;
    public float canGuard = 1;
    public float canBoom = 1;
    public float angle;

    Animator anim;

    public List<GameObject> unUsedBullets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(ShotCoroutine());
        nowBullets = maxBullets;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            lineMode = !lineMode;
            SetShotTime();
        }
        if (Input.GetKey(KeyCode.Z) && canShot && nowBullets > 0)
        {
            Shot();
            nowBullets -= useBullets;
            StartCoroutine(ShotCoroutine());
        }
        else if (Input.GetKey(KeyCode.Z) && nowBullets <= 0 && canReload)
        {
            canReload = false;
            anim.SetBool("isReload", true);
            StartCoroutine(ReloadCoroutine());
        }
        if (Input.GetKeyDown(KeyCode.A) && canGuard==1 && pc.level >= 3)
        {
            guard.SetActive(true);
            StartCoroutine(GuardCoroutine());
        }
        if (Input.GetKeyDown(KeyCode.S) && canBoom==1 && pc.level >= 5)
        {
            GameObject _boom = Instantiate(boom, this.transform);
            _boom.transform.parent = null;

            StartCoroutine(BoomCoroutine());
        }
        if (Input.GetKeyDown(KeyCode.C) && canReload)
        {
            canReload = false;
            anim.SetBool("isReload", true);
            StartCoroutine(ReloadCoroutine());
        }

    }

    public void SetShotTime()
    {
        if (lineMode)
        {
            shotTime = lineShotTime;
            bulletNum = 1;
            useBullets = 1;
            angle = 0;
            atk = lineAtk;
        }
        else
        {
            shotTime = radialShotTime;
            bulletNum = 5;
            useBullets = 5;
            angle = 30;
            atk = radialAtk;
        }
    }
    void Shot()
    {
        if (isShooting)
        {

            float gap = bulletNum > 1 ? angle / (float)(bulletNum - 1) : 0;
            float startAngle = -angle / 2.0f;
            for (int i = 0; i < bulletNum; i++)
            {
                float gak = startAngle + gap * i;
                gak *= Mathf.Deg2Rad;
                if (unUsedBullets.Count == 0)
                {
                    BulletMove _bullet = Instantiate(bullet, this.gameObject.transform).GetComponent<BulletMove>();
                    
                    _bullet.gameObject.transform.parent = null;
                    _bullet.transform.position = new Vector3(_bullet.transform.position.x + 0.66f, _bullet.transform.position.y + 0.5f);
                    _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                    _bullet.controller = gameObject.GetComponent<BulletShot>();
                }
                else
                {
                    BulletMove _bullet = unUsedBullets[0].GetComponent<BulletMove>();
                    unUsedBullets[0].transform.position = this.transform.position;
                    unUsedBullets[0].SetActive(true);
                    unUsedBullets.RemoveAt(0);
                    _bullet.transform.position = new Vector3(_bullet.transform.position.x + 0.66f, _bullet.transform.position.y + 0.5f);
                    _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                    _bullet.controller = gameObject.GetComponent<BulletShot>();
                }
            }
            ShotCoroutine();

        }
    }

    IEnumerator ShotCoroutine()
    {
        canShot = false;
        yield return new WaitForSeconds(60/shotTime);
        canShot = true;
    
    }

    public IEnumerator GuardCoroutine()
    {
        canGuard = 0;
        yield return new WaitForSeconds(3f);
        guard.SetActive(false);
        StartCoroutine(Guard2Coroutine());

    }
    public IEnumerator Guard2Coroutine()
    {

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.05f);
            canGuard += 0.01f;
        }
        canGuard = 1;

    }
    public IEnumerator BoomCoroutine()
    {
        canBoom = 0;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.1f);
            canBoom += 0.01f;
        }
        canBoom = 1;

    }

    public IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(1.5045f);
        anim.SetBool("isReload", false);
        canReload = true;
        nowBullets = maxBullets;
    }
}
