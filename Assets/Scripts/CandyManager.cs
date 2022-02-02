using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//仕様。
//・制限時間内にエフェクトしたキャンディーの数が一定の数を超えたら祝の文字を出してエフェクトさせる。
//・飛んでる鳥がキャンディーの邪魔をする。

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;

    public int candy = DefaultCandyAmount;
    int counter;

    public void ConsumeCandy()
    {
        if (candy > 0)
        {
            candy--;
        }
    }

    public int GetCandyAmount()
    {
        return candy;
    }

    public void AddCandy(int amount)
    {
        candy += amount;
    }

    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.Scale(Vector3.one * 2);
        GUI.color = Color.black;
        //string label = "Candy : " + candy;
        //以下テンプレートリテラルのやり方
        string label = $"Candy : {candy}";
        if (counter > 0)
        {
            label = $"{label}({counter}s)";
        }
        GUI.Label(new Rect(50, 50, 100, 30), label);
    }

    private void Update()
    {
        if (candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy());
        }
    }

    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;
        while (counter > 0)
        {
            //１秒まって以降を処理
            yield return new WaitForSeconds(1.0f);
            counter--;
        }

        candy++;
    }
}
