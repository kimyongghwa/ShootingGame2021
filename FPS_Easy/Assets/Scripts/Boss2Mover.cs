using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Mover : MobMover
{
    public bool moverOn;
    private void Start()
    {
        moverPos[1] = new Vector3(transform.position.x, transform.position.y);
    }
    void Update()
    {
        if(moverOn)
            transform.position = Vector3.MoveTowards(transform.position, mokpyo, time * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, moverPos[1], time * Time.deltaTime);

    }
}
