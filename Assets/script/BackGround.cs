using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround: MonoBehaviour
{
    [SerializeField] private float scrollSpead;
    [SerializeField] private float tileSize;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;//最初の位置を保存
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpead, tileSize);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
