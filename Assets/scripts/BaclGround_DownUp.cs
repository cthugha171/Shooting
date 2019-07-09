using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaclGround_DownUp : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] float tileSizeZ;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        var pos = transform.position;
        startPosition = new Vector3(pos.x, pos.y, tileSizeZ);
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.back * newPosition;
    }
}
