using System;
using UnityEngine;
using UnityEngine.Events;

public class Selectable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnSelected;
    public event Action IsHovering;

    public void Selected()
    {
        OnSelected?.Invoke();
    }
    public void Hovering()
    {
        IsHovering?.Invoke();
    }
}
