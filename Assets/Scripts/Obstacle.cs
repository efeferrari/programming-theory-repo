using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int hitValue;
    GameManager GM;

    private void Start()
    {
        GM = GameManager.Instance;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GM.AddScore(hitValue);
        }
    }
}
