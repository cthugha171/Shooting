using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            transform.position += new Vector3(0, 0, speed);
        }
        if(SceneManager.GetActiveScene().name=="TopView")
        {
            transform.position += new Vector3(0, speed, 0);
        }
    }
}
