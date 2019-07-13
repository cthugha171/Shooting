using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CameraState
{
    Vertical,//縦
    Horizontal,//横
}

public class GameManager : MonoBehaviour
{

    [SerializeField] Camera MainCamera;
    CameraState Cstate;
    Vector3 angle;

    int state;
    int BossCount;
    public int ICsta = 0;

    float mian = 0.0f;
    float maan = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        //角度は自分で計算しないといけないよ
        angle = MainCamera.transform.localEulerAngles;
        BossCount = 0;
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            Cstate = CameraState.Horizontal;//初期は横状態
        }
        else if (SceneManager.GetActiveScene().name == "TopView")
        {
            Cstate = CameraState.Vertical;//初期は横状態
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotCamera();
        switch(BossCount)
        {
            case 0:
                if (GameObject.FindGameObjectWithTag("Boss"))
                {
                    BossCount = 1;
                }
                break;
            case 1:
                if(!GameObject.FindGameObjectWithTag("Boss"))
                {
                    BossCount = 2;
                }
                break;
            case 2:
                {
                    SceneManager.LoadScene("Rote");
                }
                break;
        }

        if (Cstate != CameraState.Vertical)
        {
            ICsta = 0;
        }
        else
        {
            ICsta = 1;
        }
    }

    /// <summary>
    /// カメラの回転
    /// </summary>
    void RotCamera()
    {
        #region 使わない
        //if (Cstate == CameraState.Horizontal && Input.GetMouseButton(1))
        //{
        //    //MainCamera.transform.Rotate(new Vector3(0, 0, -1f));
        //    //var r = Mathf.Repeat(MainCamera.transform.localEulerAngles.z, 360);
        //    angle += new Vector3(0, 0, -1f);
        //    MainCamera.transform.localEulerAngles = angle;
        //    if (angle.z < -90f)
        //    {
        //        //ector3 angle = MainCamera.transform.eulerAngles;
        //        Debug.Log("限界");
        //        angle.z = -90;
        //        MainCamera.transform.eulerAngles = angle;
        //        Cstate = CameraState.Vertical;
        //    }
        //}
        //else if(Cstate == CameraState.Vertical && Input.GetMouseButton(1))
        //{
        //    angle += new Vector3(0, 0, +1f);
        //    MainCamera.transform.localEulerAngles = angle;
        //    if (angle.z > 0)
        //    {
        //        //ector3 angle = MainCamera.transform.eulerAngles;
        //        Debug.Log("aaaaaaaaaaa限界");
        //        angle.z = 0;
        //        MainCamera.transform.eulerAngles = angle;
        //        Cstate = CameraState.Horizontal;
        //    }
        //}

        //if (Cstate == CameraState.Horizontal && Input.GetMouseButtonDown(1))
        //{
        //    float angle = Mathf.LerpAngle(mian, maan, Time.time);
        //    maan *= -1;
        //    MainCamera.transform.eulerAngles = new Vector3(0, -90, angle);
        //}
        //if (Cstate == CameraState.Vertical && Input.GetMouseButtonDown(1))
        //{
        //    float angle = Mathf.LerpAngle(mian, maan, Time.time);
        //    maan *= -1;
        //    MainCamera.transform.eulerAngles = new Vector3(0, -90, angle);
        //}
        #endregion

        if (SceneManager.GetActiveScene().name == "SideView")
        {
            state = 0;
        }
        else if(SceneManager.GetActiveScene().name=="rote")
        {
            state = 1;
        }
        else if(SceneManager.GetActiveScene().name=="TopView")
        {
            state = 2;
        }

        switch (state)
        {
            case 0:
                Cstate = CameraState.Horizontal;
                break;
            case 1:
                if (Cstate == CameraState.Horizontal)
                {
                    angle += new Vector3(0, 0, -1f);
                    MainCamera.transform.localEulerAngles = angle;
                    if (angle.z < -90f)
                    {
                        angle.z = -90;
                        MainCamera.transform.eulerAngles = angle;
                        SceneManager.LoadScene("TopView");
                    }
                }
                if (Cstate == CameraState.Vertical)
                {
                    angle += new Vector3(0, 0, 1f);
                    MainCamera.transform.localEulerAngles = angle;
                    if (angle.z > 0)
                    {
                        angle.z = 0;
                        MainCamera.transform.eulerAngles = angle;
                        SceneManager.LoadScene("SideView");
                    }
                }
                break;
            case 2:
                Cstate = CameraState.Vertical;
                break;
            default:
                break;
        }
    }
}