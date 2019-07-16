using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    //ファンネル1
    private GameObject fannel1;
    //ファンネル２
    private GameObject fannel2;

    int state;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        //受け取り
        fannel1 = transform.GetChild(0).gameObject;
        fannel2 = transform.GetChild(1).gameObject;

        fannel1.SetActive(false);
        fannel2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("アイテムを取得   アイテム番号:"+state);
        if (other.gameObject.tag == "Item")
        {
            if (state == 0)
            {
                fannel1.SetActive(true);
                state = 1;
                
                return;
            }
        }
        if (other.gameObject.tag == "Item")
        {
            if (state == 1)
            {
                fannel2.SetActive(true);
                state = 2;
                
            }
        }
    }
}
