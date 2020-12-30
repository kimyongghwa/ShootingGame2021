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
            Debug.Log("Mover");
            transform.position = Vector3.MoveTowards(transform.position, mokpyo, time * Time.deltaTime);
            if (transform.position == mokpyo)
            {
                if (moverPos[0] == mokpyo)
                    mokpyo = moverPos[1];
                else if (moverPos[1] == mokpyo)
                    mokpyo = moverPos[0];
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moverPos[1], time * Time.deltaTime);
        }
    }


}
