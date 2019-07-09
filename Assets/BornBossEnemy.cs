using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornBossEnemy : MonoBehaviour
{
    BossMoveTest BossMoveScript;
    float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        //スクリプト非アクティブ
        BossMoveScript = GetComponent<BossMoveTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < 3.5f)
        {
            speed = 0;
            BossMoveScript.enabled = true;//スクリプトをアクティブ
            Destroy(this);//自身のコンポーネントを削除
        }
        //右から左へ
        this.transform.position += new Vector3(0, 0, -speed);
    }
}
