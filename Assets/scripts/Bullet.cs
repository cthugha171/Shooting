using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    void Update()
    {
        this.transform.position += new Vector3(0, 0, speed);
        Destroy(this.gameObject, 5);
    }
}
