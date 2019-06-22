using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShoot : MonoBehaviour
{
    //パーティクル
    public ParticleSystem beamParticle;
    //画面揺れ
    public camerashake shake;

    private void Awake()
    {
        beamParticle = GetComponent<ParticleSystem>();
        beamParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shot();
        }
        else
        {
            DisableEffect();
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
