using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorMachine : MonoBehaviour
{
    // connect to color choosers (x2)
    // connect to selectable event

    // on selected, pour the flask (i.e. create a flask which mixes the two colors)
    //  check if the flask slot is empty, if it is, create a flask and put it in there

    [SerializeField] private GameObject FlaskOriginal;

    [SerializeField] private ColorChooser cc1;
    [SerializeField] private ColorChooser cc2;
    private bool CanPourFlask = true;

    [SerializeField] private FlaskSlot flaskSlot;

    [SerializeField] private UnityEvent OnButtonPressed;

    private void Start()
    {
        if (cc1 == null || cc2 == null || flaskSlot == null)
        {
            Debug.Log("The ColorMachine cannot pour flasks because one or both ColorChoosers and/or the FlaskSlot is not assigned in the inspector or otherwise missing.");
            CanPourFlask = false;
        }
    }

    public void TryPourFlask()
    {
        OnButtonPressed?.Invoke();

        if (CanPourFlask)
        {
            // get the colors from cc1 and cc2, then make a flask mixing those colors
            Color nextColor = cc1.GetColor() + cc2.GetColor();

            // Ok so I'm not gonna instantiate a flask object, I'm going to link a prefab of a modeled flask that 
            if (FlaskOriginal == null) Debug.Log("A Flask could not be created out of the ColorMachine because the Flask prefab was not assigned.");
            else
            {
                // try get flask component, add this color to it
                // place it into the flask slot
            }
        }
    }

}
