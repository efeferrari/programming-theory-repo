using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // POLYMORPHISM: Every obstacle has teir own value
    [SerializeField] private int hitValue;
    LevelManager LM;

    private void Start()
    {
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            LM.AddScore(hitValue);
        }
    }
}
