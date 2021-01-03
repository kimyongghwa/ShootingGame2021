using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Mover : MobMover
{
    public bool moverOn;
    // Update is called once per frame
    public void Start()
    {
        moverPos[0] = PlayerController.instance.transform.position;
        moverPos[1] = this.transform.position;
        mokpyo = moverPos[0];
    }
    public void MokpyoOn()
    {
        mokpyo = PlayerController.instance.transform.position;
    }
    void Update()
    {
        if (moverOn)
        {
            transform.position = Vector3.MoveTowards(transform.position, mokpyo, time * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moverPos[1], time * Time.deltaTime);
        }
    }


}
