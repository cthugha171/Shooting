using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private GameObject Rain;
    [SerializeField] private float DelayTimer;//雨ふりの間隔
    private float ReSetTimer;

    // Start is called before the first frame update
    void Start()
    {
        ReSetTimer = DelayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateRain();
    }

    void GenerateRain()
    {
        DelayTimer -= Time.deltaTime;
        if (DelayTimer < 0)
        {
            DelayTimer = ReSetTimer;

            var _rain = Instantiate(Rain, this.transform.position, this.transform.rotation);

            int px = Random.Range(-5, 5);
            _rain.transform.position = new Vector3(px, 0, this.transform.position.z);
        }
    }
}
