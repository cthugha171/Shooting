using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextorBackPanel : MonoBehaviour
{
    [SerializeField] private Image page1;
    [SerializeField] private Image page2;
    [SerializeField] private Image page3;

    private void Start()
    {
        page1.enabled = true;
        page2.enabled = false;
        page3.enabled = false;
    }

    public void OnClickPage1()
    {
        page1.enabled = true;
        page2.enabled = false;
        page3.enabled = false;
    }

    public void OnClickPage2()
    {
        page2.enabled = true;
        page1.enabled = false;
        page3.enabled = false;
    }

    public void OnClickPage3()
    {
        page3.enabled = true;
        page1.enabled = false;
        page2.enabled = false;
    }
}
