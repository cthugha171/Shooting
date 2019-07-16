using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxMove : MonoBehaviour
{
    [SerializeField] private float speed=0.05f;
    Vector3 deathPoint;
    // Start is called before the first frame update
    void Start()
    {
        deathPoint = GameObject.FindGameObjectWithTag("DeathPoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(GameObject.FindGameObjectWithTag("Boss"))
        {
            if (deathPoint.z <= transform.position.z)
            {
                transform.localPosition -= new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
    }
}
