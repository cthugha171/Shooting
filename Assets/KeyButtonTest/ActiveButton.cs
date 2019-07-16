using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActiveButton : MonoBehaviour
{
    private void Start()
    {
        //自身を選択状態にする
        Selectable sel = GetComponent<Selectable>();
        sel.Select();
    }
}
