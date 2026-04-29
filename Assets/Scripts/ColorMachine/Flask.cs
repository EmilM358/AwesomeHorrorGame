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

/*
 * So, I want to make a system for the flask machine
 * I'm calling t color machine in my code but that can change later.
 * 
 * Color machine connects to (1) its own UI, (2) the two ColorChoosers, and (3) the main FlaskSlot
 * 
 * This flask will contain a texture
 * Info on its color: could be the literal color but prob shouldn't be so it's easier to combine them idk: Color can prob easily combine
 * Going to think about how to get a main texture and apply the color stored in the flask
 * - SetColor()
 * - GetColor()
 * 
 * 
 */