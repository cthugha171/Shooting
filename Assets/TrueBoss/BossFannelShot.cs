using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFannelShot : MonoBehaviour
{
    [SerializeField] private GameObject Normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ビームを撃つよ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var GObullet = Instantiate(Normal, this.transform.position + transform.forward, Quaternion.identity);
            Destroy(GObullet, 0.5f);
        }
    }
}
