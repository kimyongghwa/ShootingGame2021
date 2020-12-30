using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!MobMaker.instance.isBoss)
            transform.position += Vector3.left * 5 * Time.deltaTime;
        if (transform.position.x < -40.1 )
            transform.position = new Vector3(81.92f, 0f);
    }
}
