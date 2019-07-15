using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    void Update()
    {
        this.transform.position += transform.forward * speed;
        Destroy(this.gameObject, 5);
    }
}
