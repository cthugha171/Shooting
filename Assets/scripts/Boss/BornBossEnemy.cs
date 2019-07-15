using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BornBossEnemy : MonoBehaviour
{
    BossMoveTest BossMoveScript;
    float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        //スクリプト非アクティブ
        BossMoveScript = GetComponent<BossMoveTest>();
        BossMoveScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            if (this.transform.position.z < 10.0f)
            {
                speed = 0;
                BossMoveScript.enabled = true;//スクリプトをアクティブ
                Destroy(this);//自身のコンポーネントを削除
            }
            //右から左へ
            this.transform.position += new Vector3(0, 0, -speed);
        }
        else if(SceneManager.GetActiveScene().name=="TopView")
        {

            if (this.transform.position.y < 10.0f)
            {
                speed = 0;
                BossMoveScript.enabled = true;//スクリプトをアクティブ
                Destroy(this);//自身のコンポーネントを削除
            }
            //上から下へ
            this.transform.position += new Vector3(0, -speed, 0);
        }
    }
}
