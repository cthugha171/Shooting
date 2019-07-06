using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShoot : MonoBehaviour
{
    //パーティクル
    public ParticleSystem beamParticle;
    //画面揺れ
    public camerashake shake;
    //ビームを撃ち続ける時間
    public float BeamTimer = 5;
    //初期化用タイマー
    float timer;
    //ビームを撃っている状態かどうか
    public bool IsShot = false;
    //スイッチ遷移用変数
    int state;
    //スライダー取得
    GameObject InObj;
    SliderTest Inscr;
    //ビームのストック数格納用変数
    int Stock;


    private void Awake()
    {
        beamParticle = GetComponent<ParticleSystem>();
        InObj = GameObject.Find("Slider");
        Inscr = InObj.GetComponent<SliderTest>();
        beamParticle.Stop();
        timer = BeamTimer;
    }

    // Update is called once per frame
    void Update()
    {
        ShotManage();
        //常に値をチェック
        Stock = Inscr.Stock;
    }

    /// <summary>
    /// 弾の発射管理
    /// </summary>
    void ShotManage()
    {
        switch (state)
        {
            case 0:
                if (Stock == 0) return;
                else { state = 1; }
                break;
            case 1:
                if (Input.GetMouseButtonDown(0))
                {
                    IsShot = true;
                    Shot();
                    BeamTimer -= Time.deltaTime;
                    IsShot = false;
                }
                if (BeamTimer < 0)
                {
                    BeamTimer = timer;
                    DisableEffect();
                    state = 0;
                }
                break;
            default:
                break;
        }
    }

    //パーティクルを打つ
    private void Shot()
    {
        beamParticle.Stop();
        beamParticle.Play();
        if (shake != null)
        {
            shake.Shake(0.25f, 0.1f);
        }
    }

    //パーティクルを止める
    private void DisableEffect()
    {
        beamParticle.Stop();
    }
}
