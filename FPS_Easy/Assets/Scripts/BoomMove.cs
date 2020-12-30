using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomMove : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        Vector3 point = PlayerController.instance.mainCam.WorldToViewportPoint(transform.position);
        if (!(point.x > 0 && point.x < 1 && point.y > 0 && point.y < 1))
        {
            Destroy(this.gameObject);
        }
    }

}
