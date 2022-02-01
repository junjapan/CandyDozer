using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefab;
    public Transform candyParentTransform;
    //public GameObject candyParent;
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();
        
    }

    GameObject SampleCandy()
    {
        int index = Random.Range(0,candyPrefab.Length);
        return candyPrefab[index];
    }

    Vector3 GetInstantiatePosition()
    {
        //baseWidthは、baseオブジェクトの幅。オブジェクトはすでに幅が設定されてるが、
        //このPGMは外部入力で５を固定で設定している。
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }
    public void Shot()
    {
        if (candyManager.GetCandyAmount() <= 0)
        {
            return;
        }
        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),
            Quaternion.identity
            //Quaternion.Euler(0,0,0)
            );

        candy.transform.parent = candyParentTransform;
        //candy.transform.parent = candyParent.tranceform;

        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce);
        //forwardは、z軸方向。全てのオブジェクトに持ってる値。
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

        candyManager.ConsumeCandy();
    }
}
