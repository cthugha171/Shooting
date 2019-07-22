using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueBossBullet : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    void Update()
    {
        this.transform.position += transform.forward * speed;
        Destroy(gameObject, 5);
    }
}
