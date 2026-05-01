using UnityEngine;
using UnityEngine.Events;

public class Selectable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnSelected;
    public void Selected()
    {
        OnSelected?.Invoke();
    }
}
