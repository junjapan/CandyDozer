using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestoyer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotation;
    public GameObject effectCeleb;
    int counter =0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            candyManager.AddCandy(reward);
            Destroy(other.gameObject);

            if (effectPrefab != null)
            {
                counter++;
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotation)
                );

                if (counter%5 == 0)
                {
                    Instantiate(effectCeleb);
                }
            }
        }
    }
    //キャンディーがエフェクトした数をカウント。
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.Scale(Vector3.one * 2);
        GUI.color = Color.black;
        //string label = "Candy : " + candy;
        //以下テンプレートリテラルのやり方
        string label = $"GetCandy : {counter}個";
        if (effectPrefab != null)
        {
            GUI.Label(new Rect(50, 70, 100, 30), label);
        }
    }

}
