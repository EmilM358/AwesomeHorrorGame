using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskBase : MonoBehaviour
{
    // listen to selected and do stuff with the flasks
    // change how flaskslot works, give it an offset. no that's it actually

    [SerializeField] private FlaskSlot flaskSlot;
    public event Action<FlaskSlot> OnSelected;
    private static List<FlaskBase> flaskBases = new List<FlaskBase>();

    private void OnEnable()
    {
        flaskBases.Add(this);
    }
    private void OnDisable()
    {
        flaskBases.Remove(this);
    }

    public void Selected()
    {
        OnSelected?.Invoke(flaskSlot);
    }

    public static IEnumerable GetFlaskBases()
    {
        foreach (FlaskBase item in flaskBases)
        {
            yield return item;
        }
    }
}
