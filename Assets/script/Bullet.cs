using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
   // [SerializeField] private GameObject homing;
    [SerializeField] public float timeOut;
    [SerializeField] public float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= timeOut)
            {
                timeElapsed = 0.0f;
            var _bullet = Instantiate(bullets,
                transform.position, transform.rotation);
            Destroy(_bullet,30);
            }
        }
       
    }
}
