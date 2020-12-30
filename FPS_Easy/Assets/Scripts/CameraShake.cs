using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private static CameraShake _instance;
    public static CameraShake instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CameraShake>();
            }
            return _instance;
        }
    }

    Vector3 originPos;

    public void Shake(float _amount, float _duration)
    {
        StartCoroutine(Shakes(_amount, _duration));
    }

    void Start()
    {
        originPos = transform.localPosition;
    }

    public IEnumerator Shakes(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;


    }
}
