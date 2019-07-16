using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }

        #region ここに回転のを書いたよ
        //if (SceneManager.GetActiveScene().name == "SideView") { }

        //elseif (SceneManager.GetActiveScene().name == "TopView") { }
        #endregion
    }
}
