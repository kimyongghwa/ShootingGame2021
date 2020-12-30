using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpMove : MonoBehaviour
{
    public bool moverOn;
    public Vector3 mobPos;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (moverOn)
            transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, 30 * Time.deltaTime);
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, mobPos, 10 * Time.deltaTime);
            if (this.transform.position == mobPos)
                moverOn = true;
        }
    }
}
