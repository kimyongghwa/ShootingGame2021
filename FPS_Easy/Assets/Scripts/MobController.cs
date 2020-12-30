using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public int exp = 2;
    public int mobNum;
    public int hp;
    public int maxHp;
    public int atk;
    public float bonusTime;
    public bool isShooting;
    public float shotTime;
    public int bulletNum;
    public GameObject bullet;
    public MobMaker parents;
    public float angle;

    public List<GameObject> unUsedBullets = new List<GameObject>();

    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(ShotCoroutine());
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            this.gameObject.SetActive(false);
            parents.nowMob--;
            parents.SpawnExp(transform.position, exp);
            switch (mobNum)
            {
                case 1:
                    parents.unUsedMob1.Add(this.gameObject);
                    break;
                case 2:
                    parents.unUsedMob2.Add(this.gameObject);
                    break;
                default:
                    Destroy(this.gameObject);
                    break;
            }
 
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")
        {
            hp -= 30;
            CameraShake.instance.Shake(0.4f, 0.1f);
            Destroy(other.gameObject);
        }
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
                        _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                        _bullet.controller = gameObject.GetComponent<MobController>();
                    }
                    else
                    {
                        MBulletMove _bullet = unUsedBullets[0].GetComponent<MBulletMove>();
                        unUsedBullets[0].transform.position = this.transform.position;
                        unUsedBullets[0].SetActive(true);
                        _bullet.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        unUsedBullets.RemoveAt(0);
                        _bullet.SetDirection(new Vector3(Mathf.Cos(gak), Mathf.Sin(gak)));
                        _bullet.controller = gameObject.GetComponent<MobController>();
                    }
                }
            }
    }
}

