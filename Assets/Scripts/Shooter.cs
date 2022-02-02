using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int MaxShotPower = 5;
    const int RecoverySeconds = 3;
    int shotPower = MaxShotPower;
    AudioSource shotSound;

    public GameObject[] candyPrefab;
    public Transform candyParentTransform;
    //public GameObject candyParent;
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        shotSound = GetComponent<AudioSource>();
    }
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
        if (shotPower <= 0)
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

        ConsumePower();

        shotSound.Play();
    }

    private void OnGUI()
    {
        //GUI.matrix = Matrix4x4.Scale(Vector3.one * 2);
        GUI.color = Color.blue;

        string label = "";
        for(int i = 0; i < shotPower; i++)
        {
            label = label + "Shot!";
        }

        GUI.Label(new Rect(50, 65, 100, 50), label);
    }

    void ConsumePower()
    {
        shotPower--;
        StartCoroutine(RecoverPower());
    }

    IEnumerator RecoverPower()
    {
        yield return new WaitForSeconds(RecoverySeconds);
        shotPower++;
    }
}
