using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Flask : MonoBehaviour
{
    private Color color;

    public static event Action<Flask> OnFlaskCreated;

    public event Action OnPoured;
    public event Action OnMixed;
    public event Action OnDumped;

    public event Action OnSelected;
    public event Action OnHover;

    void Start()
    {
        color = Color.white;
        OnPoured?.Invoke();

        OnFlaskCreated?.Invoke(this);
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

/*
 * Hover and select ui:
 * 
 * this will have unity events on grabbed and on hover
 * canvas will have elements related to these two things
 * on hover: text appears asking Grab?
 * on selected: the flask moves to the "grabbed" flask slot which is above the others
 *              text says select a spot to place the flask or mix with another
 * selecting a flask spot will do checks regarding the placement and mixing of flasks
 */