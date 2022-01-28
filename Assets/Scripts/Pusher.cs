using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;

    public float amplitude;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //localpositionは親からのポジション
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //mathf.Sinはサイン関数
        float z = amplitude * Mathf.Sin(Time.time * speed);
        transform.localPosition = startPosition + new Vector3(0, 0, z);
    }
}
