using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    Slider slider;
    public Image HPSliderImage;

    GameObject PHobj;
    PlayerHealth PHscr;
    int PHP;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        PHobj = GameObject.Find("PlayerHit");
        PHscr = PHobj.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        PHP = PHscr.PlayerHp;
        slider.value = PHP;

        Debug.Log(slider.value);
        if (slider.value < 2)
        {
            HPSliderImage.color = Color.red;
        }
    }
}
