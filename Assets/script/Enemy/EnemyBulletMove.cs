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
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = firstspeed * Time.deltaTime;

        if (SceneManager.GetActiveScene().name == "SideView")
        {
            this.transform.localPosition -= transform.forward * speed;
        }
        else if (SceneManager.GetActiveScene().name == "TopView")
        {
            switch (num)
            {
                case 0:
                    plpos = GameObject.FindGameObjectWithTag("Player").transform.position;
                    transform.localPosition -= new Vector3(0, speed, 0);
                    num = 1;
                    break;
                case 1:
                    gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, plpos, speed);
                    num = 2;
                    break;
                default:
                    transform.localPosition -= new Vector3(0, speed, 0);
                    num = 0;
                    break;
            }
        }
    }
}
