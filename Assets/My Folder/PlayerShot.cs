using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private GameObject PlayerBullet;
    [SerializeField] private GameObject[] FirePos;
    [SerializeField] private float FireDelay;
    float FireTimer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FireTimer += Time.deltaTime;
            if (FireTimer >FireDelay)
            {
                FireTimer = 0.0f;
                var bullet1 = Instantiate(PlayerBullet, FirePos[0].transform.position, transform.rotation);
                var bullet2 = Instantiate(PlayerBullet, FirePos[1].transform.position, transform.rotation);
            }
        }
    }
}
