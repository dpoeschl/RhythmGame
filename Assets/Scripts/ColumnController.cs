using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColumnController : MonoBehaviour
{
    private Color defaultColor;

    private void Awake()
    {
        defaultColor = GetComponent<Image>().color;
    }

    public void Default()
    {
        GetComponent<Image>().color = defaultColor;
    }

    public void Miss()
    {
        GetComponent<Image>().color = new Color(0,0,1);
    }

    public void HitGreat()
    {
        GetComponent<Image>().color = new Color(1,1,0);
    }

    public void HitGood()
    {
        GetComponent<Image>().color = new Color(1,0,0);
    }
}
