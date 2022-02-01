﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestoyer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            candyManager.AddCandy(reward);
            Destroy(other.gameObject);
        }
    }
}
