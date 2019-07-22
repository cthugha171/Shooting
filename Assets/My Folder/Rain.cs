using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0, -0.1f);

        if (transform.position.z < -8.0f)
        {
            Destroy(gameObject);
        }
    }
}
