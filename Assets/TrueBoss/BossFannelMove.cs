using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFannelMove : MonoBehaviour
{
    [SerializeField] private GameObject MovePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = 2.0f * Time.deltaTime;

        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            MovePos.transform.position,
            step);
    }
}
