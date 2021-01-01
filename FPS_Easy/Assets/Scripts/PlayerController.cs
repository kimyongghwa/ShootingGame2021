using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerController>();
            }
            return _instance;
        }
    }
    public Renderer renderer;
    public Material normalMarterial;
    public Material hitMarterial;
    public float moveSpeed;
    public int level = 1;
    public int exp = 0;
    public int score = 0;
    public int maxHp = 100;
    public int[] needExp = new int[5];
    public int hp = 0;
    public BulletShot bulletShot;
    public Camera mainCam;
    public bool canHurt = true;

    void Awake()
    {
        hp = maxHp;
        bulletShot = GetComponent<BulletShot>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (exp >= needExp[level] && level < 5)
            LevelUp();

    }

    void Move()
    {
        Vector3 point = mainCam.WorldToViewportPoint(gameObject.transform.position);
        if (point.x < 1 && Input.GetAxisRaw("Horizontal") > 0) transform.position += Vector3.right * moveSpeed * Time.deltaTime ;
        if (point.x > 0 && Input.GetAxisRaw("Horizontal") < 0) transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (point.y < 1 && Input.GetAxisRaw("Vertical") > 0) transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        if (point.y > 0 && Input.GetAxisRaw("Vertical") < 0) transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    public void LevelUp()
    {
        exp = 0;
        level++;
        maxHp = (int)(maxHp * 1.2f);
        hp = maxHp;
        bulletShot.radialAtk = (int)(bulletShot.radialAtk * 1.1f);
        bulletShot.lineAtk = (int)(bulletShot.lineAtk * 1.1f);
        bulletShot.lineShotTime = (int)(bulletShot.lineShotTime * 1.1f);
        bulletShot.radialShotTime = (int)(bulletShot.radialShotTime * 1.1f);
        bulletShot.SetShotTime();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mob" && canHurt)
        {
            Debug.Log("Hurt");
            hp -= 20;
            StartCoroutine(HurtCoroutine());
            if (hp <= 0)
                Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "mob" && canHurt)
        {
            Debug.Log("Hurt");
            hp -= 20;
            StartCoroutine(HurtCoroutine());
            if (hp <= 0)
                Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "m_Bullet" && canHurt)
        {
            Debug.Log("Hurt");
            StartCoroutine(HurtCoroutine());
            if (hp <= 0)
                SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "i_HP")
        {
            hp += (int)(maxHp * 0.2f);
            if (hp > maxHp)
                hp = maxHp;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "i_LV")
        {
            if (level < 5)
            {
                LevelUp();
            }
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "EXP")
        {
            exp += 1;
            score += 50;
            if (exp >= needExp[level] && level < 5)
                LevelUp();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "i_Guard")
        {
            StopCoroutine(bulletShot.Guard2Coroutine());
            StopCoroutine(bulletShot.BoomCoroutine());
            bulletShot.canBoom = 1;
            bulletShot.canGuard = 1;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "m_Bullet" && canHurt)
        {
            Debug.Log("Hurt");
            StartCoroutine(HurtCoroutine());
            if (hp <= 0)
                SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "i_HP")
        {
            hp += (int)(maxHp * 0.2f);
            if (hp > maxHp)
                hp = maxHp;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "i_LV")
        {
            if (level < 5)
            {
                LevelUp();
            }
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "EXP")
        {
            exp += 1;
            score += 50;
            if (exp >= needExp[level] && level < 5)
                    LevelUp();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "i_Guard")
        {
            StopCoroutine(bulletShot.Guard2Coroutine());
            StopCoroutine(bulletShot.BoomCoroutine());
            bulletShot.canBoom = 1;
            bulletShot.canGuard = 1;
            Destroy(collision.gameObject);
        }
    }
    
    IEnumerator HurtCoroutine()
    {
        renderer.material = hitMarterial;
        Debug.Log("Hc");
        canHurt = false;
        yield return new WaitForSeconds(0.2f);
        renderer.material = normalMarterial;
        Debug.Log("Hd");
        canHurt = true;
        
    }
}
