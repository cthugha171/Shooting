using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Item;
    int count;
    float posX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        Spawn();
    }

    void Spawn()
    {
        if (count % 1000 == 0)
        {
            posX = Random.Range(-5, 5);
            var _Item = Instantiate(Item, transform.position + new Vector3(posX, 0, 0), transform.rotation);

            Destroy(_Item, 25.0f);
        }
    }
}
