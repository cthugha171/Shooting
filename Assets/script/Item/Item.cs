using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float speed = 0.05f;
    void Update()
    {
        //右から左へ
        //this.transform.position += new Vector3(0, 0, -speed);
        //Destroy(this.gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
