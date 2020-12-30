using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoss1Mover : MobMover
{
    public bool moverOn;
    public float rotateTime;
    public float rotateValue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotationCoroutine(rotateTime, rotateValue));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator RotationCoroutine(float _rotateTime, float _rotateValue)
    {
        while (true)
        {
            yield return new WaitForSeconds(_rotateTime);
            Debug.Log(transform.rotation.eulerAngles.z);
            if (moverOn || (int)transform.rotation.eulerAngles.z % 180 != 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 15));
            }
        }
    }
}
