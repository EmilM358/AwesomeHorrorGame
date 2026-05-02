using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Flask : MonoBehaviour
{
    private Color color;

    public event Action OnPoured;
    public event Action OnMixed;
    public event Action OnDumped;

    void Start()
    {
        color = Color.white;
        OnPoured?.Invoke();
    }
    public void ColorAddition(float r, float g, float b, float a)
    {
        ColorAddition(new Color(r,g,b,a));
    }
    public void ColorAddition(Color colorToAdd)
    {
        color += colorToAdd;
        OnMixed?.Invoke();
    }
    public Color GetColor()
    {
        return new Color(color.r, color.g, color.b, color.a);
    }
    public void DumpFlask()
    {
        OnDumped?.Invoke();
        Destroy(gameObject);
    }
}