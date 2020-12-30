using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoss2Mover : MobMover
{
    public bool moverOn;
    // Start is called before the first frame update
    void Start()
    {
        moverPos[0] = new Vector3(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (moverOn)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(this.transform.position.x, PlayerController.instance.transform.position.y,0), time * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moverPos[0], time * Time.deltaTime);
        }
    }


}
