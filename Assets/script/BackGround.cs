using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpead, tileSize);
            transform.position = startPosition + Vector3.forward * newPosition;
        }
        if(SceneManager.GetActiveScene().name=="TopView")
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpead, tileSize);
            transform.position = startPosition + Vector3.down * newPosition;
        }
    }
}
