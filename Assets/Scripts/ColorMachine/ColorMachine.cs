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

    [SerializeField] private UnityEvent OnMixPressed;

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
        OnMixPressed?.Invoke();

        if (CanPourFlask)
        {
            // get the colors from cc1 and cc2, then make a flask mixing those colors
            Color nextColor = cc1.GetColor() + cc2.GetColor();

            if (FlaskOriginal == null) Debug.Log("A Flask could not be created out of the ColorMachine because the Flask prefab was not assigned.");
            else
            {
                // If the FlaskSlot is occupied
                if (!flaskSlot.IsFlaskSlotAvailable())
                {
                    // add the colour to the flasks colour
                    flaskSlot.MixFlasks(nextColor);
                }
                else
                {
                    // Clone the Flask prefab, make its parent the flask slot gameobject.
                    GameObject CloneFlask = Instantiate(FlaskOriginal, flaskSlot.transform);

                    // Get the clone's flask component and pass it to the flask slot.
                    Flask NewFlask;
                    CloneFlask.TryGetComponent(out NewFlask);
                    flaskSlot.SetFlask(NewFlask);
                }

                
            }
        }
    }

}
