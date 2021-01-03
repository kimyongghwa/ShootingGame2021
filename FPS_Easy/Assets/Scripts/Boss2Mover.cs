using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Mover : MobMover
{
    public bool moverOn;
    public new Vector3 []moverPos = new Vector3[2];
    private void Start()
    {
        moverPos[1] = new Vector3(transform.position.x, transform.position.y);
    }
    void Update()
    {
        if (moverOn)
        {
            transform.position = Vector3.MoveTowards(transform.position, mokpyo, time * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moverPos[1], time * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

    }
}
