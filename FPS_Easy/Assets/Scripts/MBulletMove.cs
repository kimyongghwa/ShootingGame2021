using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBulletMove : MonoBehaviour
{
    Vector3 dir;
    public float speed;
    public bool yudo;
    public bool zBullet;
    Camera mainCam;
    public MobController controller;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z <= 0 && zBullet)
            SetDirection(new Vector3(dir.x, dir.y, 0));
        transform.position -= dir * speed * Time.deltaTime;
        Vector3 point = mainCam.WorldToViewportPoint(transform.position);
        if (!(point.x > 0 && point.x < 1 && point.y > 0 && point.y < 1))
        {
            this.gameObject.SetActive(false);
            controller.unUsedBullets.Add(this.gameObject);
        }
    }
    public void SetDirection(Vector3 _dir)
    {
        if (yudo)
        {
            dir = new Vector3(transform.position.x - PlayerController.instance.gameObject.transform.position.x, transform.position.y - PlayerController.instance.gameObject.transform.position.y).normalized;
        }
        else
            dir = _dir;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            CameraShake.instance.Shake(0.5f, 0.1f);
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            if (pc.canHurt)
                pc.hp -= controller.atk;
            this.gameObject.SetActive(false);
            controller.unUsedBullets.Add(this.gameObject);
        }
        if (collision.gameObject.tag == "Guard")
        {
            CameraShake.instance.Shake(0.1f, 0.1f);
            this.gameObject.SetActive(false);
            controller.unUsedBullets.Add(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boom")
        {
            CameraShake.instance.Shake(0.25f, 0.1f);
            this.gameObject.SetActive(false);
            controller.unUsedBullets.Add(this.gameObject);
        }
    }
}
