using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{
    Slider slider;
    public Image sliderImage;
    public int Stock;

    GameObject InObj;
    BeamShoot Inscr;

    bool IsShot;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        InObj = GameObject.Find("Particle Beam");
        Inscr = InObj.GetComponent<BeamShoot>();

        //コルーチンの実行
        StartCoroutine("CountChage");
        //コルーチンの停止
        //StopCoroutine("CountChage");

    }
    void Update()
    {
        //数秒ごとにゲージの値を増やす
        //ゲージが一定の値になったら適当な変数の値を1増やす
        //ビームを撃ったら適当な変数の値を減らして、この値も一定数分減らす
        //コルーチンの実行
        StockUp();
        ShotBeam();
        IsShot = Inscr.IsShot; 
    }

    private IEnumerator CountChage()
    {
        while (true)
        {
            //一秒おきに永遠に呼ばれる
            yield return new WaitForSeconds(0.1f);
            Accumulate();
        }
    }

    void Accumulate()
    {
        slider.value += 0.1f;
    }

    void StockUp()
    {
        //v<30
        if (slider.value < 30)
        {
            Stock = 0;
            //赤
            sliderImage.color = new Color32(255, 0, 0, 255);
        }
        //30<=v<60
        else if (slider.value >= 30 && slider.value < 60)
        {
            Stock = 1;
            //黄色
            sliderImage.color = new Color32(255, 255, 0, 255);
        }
        //v>=60
        else if (slider.value >= 60)
        {
            Stock = 2;
            //黄緑色(51,255,0)
            sliderImage.color = new Color32(51, 255, 0, 255);
        }
    }

    void ShotBeam()
    {
        if (IsShot)
        {
            slider.value -= 30;
        }
        else return;

        Debug.Log(IsShot);
    }
}
