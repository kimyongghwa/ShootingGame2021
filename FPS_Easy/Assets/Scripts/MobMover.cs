using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MobMover : MonoBehaviour
{    
    public bool upDownMove;
    public float move;
    public float time;
    public Vector3 mokpyo;
    protected Vector3[] moverPos = new Vector3[2];
    
    // Start is called before the first frame update
    void Start()
    {
        if (upDownMove)
        {
            moverPos[0] = new Vector3(transform.position.x, transform.position.y + move);
            moverPos[1] = new Vector3(transform.position.x, transform.position.y - move);
        }
        else
        {
            moverPos[0] = new Vector3(transform.position.x + move, transform.position.y);
            moverPos[1] = new Vector3(transform.position.x - move, transform.position.y);
        }
        mokpyo = moverPos[0];
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, mokpyo, time * Time.deltaTime);
        if(transform.position == mokpyo)
        {
            if (moverPos[0] == mokpyo)
                mokpyo = moverPos[1];
            else if (moverPos[1] == mokpyo)
                mokpyo = moverPos[0];
        }
    }
}
