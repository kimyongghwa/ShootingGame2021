using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Vector3 dir;
    public float speed;
    public BulletShot controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
        Vector3 point = controller.GetComponent<PlayerController>().mainCam.WorldToViewportPoint(transform.position);
        if (!(point.x > 0 && point.x < 1 && point.y > 0 && point.y < 1))
        {
            this.gameObject.SetActive(false);
            controller.unUsedBullets.Add(this.gameObject);
        }
    }
    public void SetDirection(Vector3 _dir)
    {
        dir = _dir;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mob")
        {
            CameraShake.instance.Shake(0.3f, 0.1f);
            collision.gameObject.GetComponent<MobController>().hp -= controller.atk;
            this.gameObject.SetActive(false);
            controller.unUsedBullets.Add(this.gameObject);
        }
    }
}
