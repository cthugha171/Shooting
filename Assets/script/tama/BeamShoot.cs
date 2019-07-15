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

    private GameObject Bom;
    public GameObject coldata;//当たり判定用オブジェクト
    // GameObject enemy;
    //ビームのストック数格納用変数
    int Stock;
    private string targetTag;
    [SerializeField] private Status status;
    public Status MyStatus
    {
        get { return status; }
    }


    private void Awake()
    {
        Debug.Log("----------------------------------------------------------");
        //Debug.Log(ene.name);
        beamParticle = GetComponent<ParticleSystem>();
        InObj = GameObject.Find("Slider");
        Inscr = InObj.GetComponent<SliderTest>();
        beamParticle.Stop();
        timer = BeamTimer;
    }

    void Start()
    {
        coldata = transform.GetChild(0).gameObject;
        Bom = transform.GetChild(0).gameObject;

        Bom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShotManage();
        //常に値をチェック
        Stock = Inscr.Stock;

        //distanceTarget = Vector3.Distance(transform.position, targetTra.position);
        // RaycastHit[] hit = Physics.BoxCastAll(transform.position, Vector3.one * 0.5f, transform.forward, Quaternion.identity, 100f, LayerMask.GetMask("Enemy"));

       
    }

    public void Damage(Status other)
    {
        status.Damage(other.atk);
    }
    public void Damage(int atk)
    {
        status.Damage(atk);
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
                    state = 2;
                    IsShot = true;
                    Bom.SetActive(true);
                    RaycastHit[] hitInfo;
                    hitInfo = Physics.BoxCastAll(coldata.transform.position, coldata.GetComponent<BoxCollider>().size * 0.5f, transform.forward, Quaternion.identity, LayerMask.GetMask("Enemy"));
                    for(int i=0;i<hitInfo.Length;i++)
                    {
                        Debug.Log(hitInfo[i]);
                    }
                    foreach (RaycastHit hit in hitInfo)
                    {
                        if (hit.transform.gameObject.CompareTag("Enemy")) 
                        {
                            Debug.Log("当たった");
                            Destroy(hit.transform.gameObject);
                            //Destroy(ene.gameObject);
                        }
                        if(hit.transform.gameObject.CompareTag("Boss"))
                        {
                            Debug.Log("当たった Boss");
                            var enemy = hit.transform.gameObject.GetComponent<EnemyHealth>();
                            enemy.Damage(MyStatus.atk);
                        }
                    }

                }
                break;
            case 2:
                Shot();

                BeamTimer -= Time.deltaTime;
                IsShot = false;
                Bom.SetActive(false);
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

       // Physics.BoxCastAll();
    }

    //パーティクルを止める
    private void DisableEffect()
    {
        beamParticle.Stop();
    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Enemy" /*&& Bom.activeSelf == true*/)
    //    {

    //        Debug.Log("当たった AA");
    //        Destroy(ene);
    //    }

    //}
}
