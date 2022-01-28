using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 0, 0.1f);
        transform.Rotate(5f, 5f, 5f);
        transform.position = new Vector3(3f*Mathf.Cos(Time.time*10f),3f*Mathf.Sin(Time.time*10f),Time.time*1f);
    }
}
