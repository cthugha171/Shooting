using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBulletMove : MonoBehaviour
{
    [SerializeField] private float firstspeed = 5;
    private Vector3 plpos;
    private float speed;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        speed = firstspeed * Time.deltaTime;

        if (SceneManager.GetActiveScene().name == "SideView")
        {
            this.transform.localPosition += transform.forward * speed;
        }
        else if (SceneManager.GetActiveScene().name == "TopView")
        {
            this.transform.localPosition += transform.forward * speed;
        }
    }
}
