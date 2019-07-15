using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            this.transform.localPosition -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        else if (SceneManager.GetActiveScene().name == "TopView")
        {
            this.transform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
