using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChooser : MonoBehaviour
{
    // listen to the selectable event
    // on selected, cycle through the color

    // need to be connected to some gameobject that swaps color

    [SerializeField] private int ColorIndex = 0;
    [SerializeField] private List<Color> colors;

    [SerializeField] private UnityEvent <Color> OnColorChange;

    public void CycleColor()
    {
        if (colors.Count == 0)
        {
            Debug.Log("A ColorChooser tried to cycle between available colors and display the next one, but it had no colors in its list.");
            return;
        }
        ColorIndex = (ColorIndex + 1 >= colors.Count) ? 0: ColorIndex + 1;
        OnColorChange?.Invoke(colors[ColorIndex]);
    }

    public Color GetColor()
    {
        return colors[ColorIndex];
    }
}