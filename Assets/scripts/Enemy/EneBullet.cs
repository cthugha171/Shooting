﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneBullet : MonoBehaviour
{
    [SerializeField] float speed=5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.localPosition -= new Vector3(0, 0, speed * Time.deltaTime);
    }
}
