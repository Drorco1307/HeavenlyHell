using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetnesMeter : MonoBehaviour
{
    public List<float> distList;
    [SerializeField] private EnemyAITeddy enemyAiTeddy;
    void Start()
    {
        distList=new List<float>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        distList.Add(enemyAiTeddy.dist);
    }
}
