using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneItem : MonoBehaviour
{
    private float speed = 0.05f;
    void Update()
    {
        //上から下へ
        this.transform.position += new Vector3(0, 0, -speed);
        Destroy(this.gameObject, 10);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
