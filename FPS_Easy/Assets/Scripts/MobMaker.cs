using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMaker : MonoBehaviour
{
    private static MobMaker _instance;
    public static MobMaker instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<MobMaker>();
            }
            return _instance;
        }
    }
    public int nowMob = 0;
    public int bossLevel = 0;
    public bool isSpawn = true;
    public bool isBoss = false;
    public float spawnTime = 3f;
    public float iSpawnTime = 7f;
    public List<GameObject> mobData = new List<GameObject>();
    public List<GameObject> itemData = new List<GameObject>();
    public List<GameObject> unUsedMob1 = new List<GameObject>();
    public List<GameObject> unUsedMob2 = new List<GameObject>();
    public GameObject expObject;
    public float expMoveRand;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MobCoroutine());
        StartCoroutine(BossCoroutine(20, 3));
        StartCoroutine(ItemCoroutine());
    }
    public void BossCoroutineStarter(float a, int b)
    {
        StartCoroutine(BossCoroutine(a, b));
    }
    public void SpawnExp(Vector3 _pos, int expNum)
    {
        for (int i = 0; i < expNum; i++) {
            GameObject _expObject = Instantiate(expObject);
            _expObject.transform.position = _pos;
            Vector3 _newPos = new Vector3(_pos.x + Random.Range(-expMoveRand, expMoveRand), _pos.y + Random.Range(-expMoveRand, expMoveRand), 0);
            _expObject.GetComponent<ExpMove>().mobPos = _newPos;
        }
    }
    public void SpawnCoroutine()
    {
        StartCoroutine(MobCoroutine());
        StartCoroutine(ItemCoroutine());
    }
    IEnumerator MobCoroutine()
    {
        Debug.Log("MobCoroutine ReOn");
        while (isSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            if (nowMob < 3) {
                int mobNum = Random.Range(1, 3);
                switch (mobNum)
                {
                    case 1:
                        if (unUsedMob1.Count != 0)
                        {
                            MobController _mob = unUsedMob1[0].GetComponent<MobController>();
                            _mob.hp = _mob.maxHp;
                            unUsedMob1[0].transform.position = new Vector3(7, Random.Range(-4, 5), 0);
                            unUsedMob1[0].SetActive(true);
                            _mob.parents = this;
                            nowMob++;
                            unUsedMob1.RemoveAt(0);

                        }
                        else
                        {
                            MobController _mob = Instantiate(mobData[mobNum]).GetComponent<MobController>(); ;
                            _mob.transform.position = new Vector3(7, Random.Range(-4, 5), 0);
                            _mob.gameObject.transform.parent = null;
                            _mob.parents = this;
                            nowMob++;
                        }
                        break;
                    case 2:
                        if (unUsedMob2.Count != 0)
                        {
                            MobController _mob = unUsedMob2[0].GetComponent<MobController>();
                            _mob.hp = _mob.maxHp;
                            unUsedMob2[0].transform.position = new Vector3(7, Random.Range(-4, 5), 0);
                            unUsedMob2[0].SetActive(true);
                            _mob.parents = this;
                            nowMob++;
                            unUsedMob2.RemoveAt(0);

                        }
                        else
                        {
                            MobController _mob = Instantiate(mobData[mobNum]).GetComponent<MobController>(); ;
                            _mob.transform.position = new Vector3(7, Random.Range(-4, 5), 0);
                            _mob.gameObject.transform.parent = null;
                            _mob.parents = this;
                            nowMob++;
                        }
                        break;
                }
            }

        }
    }

    IEnumerator ItemCoroutine()
    {
        Debug.Log("ItemCoroutine ReOn");
        while (isSpawn)
        {
            yield return new WaitForSeconds(iSpawnTime);
            int a = Random.Range(0, 10);
            GameObject b;
            if (a == 0) {
                b = Instantiate(itemData[0]);
                b.transform.position = new Vector3(7, Random.Range(-5, 6), 0);
            }
            else if (a ==1)
            {
                b = Instantiate(itemData[1]);
                b.transform.position = new Vector3(7, Random.Range(-5, 6), 0);
            }
            else if (a == 2)
            {
                b = Instantiate(itemData[2]);
                b.transform.position = new Vector3(7, Random.Range(-5, 6), 0);
            }
        }

     }
    public IEnumerator BossCoroutine(float time, int bossNum)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            Debug.Log("BossCoroutine While");
            isSpawn = false;
            yield return new WaitForSeconds(1f);
            Debug.Log(nowMob);
            if (nowMob <= 0)
            {
                Debug.Log("BossCoroutine inif");
                isBoss = true;
                nowMob++;
                GameObject b = Instantiate(mobData[bossNum]);
                b.transform.position = new Vector3(7, 0, 0);
                b.GetComponent<MobController>().parents = this;
                break;
            }
        }
    }
}
