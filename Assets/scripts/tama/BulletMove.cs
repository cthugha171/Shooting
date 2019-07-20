using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float Firstspeed = 1.0f;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Firstspeed * Time.deltaTime;
        Debug.Log(speed);
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            transform.Translate(new Vector3(0, 0, speed));
            //    transform.position +=);
        }
        if (SceneManager.GetActiveScene().name=="TopView")
        {
            transform.position += new Vector3(0, speed, 0);
        }
    }
}
