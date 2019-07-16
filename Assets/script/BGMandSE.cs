using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMandSE : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip　A,B,C;
    // Start is called before the first frame update
    void Start()
    {
        //AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        AS.clip = A;
    //        AS.Play();
    //        Debug.Log("test");
            
    //    }
      
    //}
    void OnTriggerEnter(Collider other)
    {
       if(other.tag =="Player")
        {
            AS.clip = A;
            AS.Play();
            Debug.Log("test");
        }
       

    }
}
