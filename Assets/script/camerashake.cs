using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    public void Shake(float duration,float magnitude)
    {
        //コルーチンを実行（コルーチン名、引数）
        StartCoroutine(DoShake(duration,magnitude));
    }

    //コルーチンの中身
    //コルーチンとは、処理を自由に中断、再開したりできるもの
    //引数（揺れる時間、揺れる大きさ）
    private IEnumerator DoShake(float duration,float magnitude)
    {
        //ポジション代入
        var pos = transform.localPosition;
        //変数の初期化
        var elapsed = 0f;

        //指定時間よりも小さい場合
        while (elapsed < duration)
        {
            //画面を揺らす
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * magnitude;
            //値を代入
            transform.localPosition = new Vector3(x, y, pos.z);
            //現在時間を入れてます
            elapsed += Time.deltaTime;

            //いったん処理を中断し、次フレームからまた開始
            yield return null;
        }
        transform.localPosition = pos;
    }
}
