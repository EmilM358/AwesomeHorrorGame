using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskManager : MonoBehaviour
{
    [SerializeField] private FlaskSlot GrabbedFlaskSlot;

    // All flasks (and their slots?) should implement this... maybe just the slots
    public event Action OnAllFlasksDumped;

    private void Start()
    {
        Flask.OnFlaskCreated += FlaskCreated;
        Flask.OnFlaskDumped += FlaskDumped;
    }

    private void OnDisable()
    {
        Flask.OnFlaskCreated -= FlaskCreated;
        Flask.OnFlaskDumped -= FlaskDumped;
    }

    private void FlaskCreated(Flask newFlask)
    {
        newFlask.OnSelected += FlaskSelected;
    }
    private void FlaskDumped(Flask dumpedFlask)
    {

    }

    private void FlaskSelected(FlaskSlot flaskSlotSelected)
    {
        // is the grab flask slot empty? if so, put this flask in there
        // else if the grab flask slot is occupied:
        //  if this flask is in the grab flask slot then ... do nothing
        //  if this flask is not then pour the flask in the grab slot into this one and remove it from the grab slot and delete it entirely

        if (GrabbedFlaskSlot.IsFlaskSlotAvailable())
        {
            Flask justGrabbedFlask = flaskSlotSelected.TryGrabFlask();

            if (justGrabbedFlask == null)
            {
                Debug.Log("There was a problem selecting a Flask. The FlaskSlot it should have been in gave a null value instead of returning the Flask that was clicked on.");
                return;
            }

            GrabbedFlaskSlot.SetFlask(justGrabbedFlask);
        }
        else if (!GrabbedFlaskSlot.FlaskCompare(flaskSlotSelected.TryPeekFlask())) // This shouldn't be null because this all happens when we press on a flask. Another problem could lead to a problem here.
        {
            // in this case, there is a flask in the grabbed flask slot that isn't this one
            // i.e. we have a flask in our hand and we click on another
            // so, we want to add the grabbed flask to the clicked flask

            // This Flask will be garbage collected. The point is that it will be mixed into another Flask and removed.
            Flask GrabbedFlask = GrabbedFlaskSlot.TryGrabFlask();

            // The if statements indicate that this Flask should exist. We check if it doesn't anyway.
            if (GrabbedFlask == null)
            {
                Debug.Log("There was a problem getting the previously grabbed Flask in the FlaskManager. At this point in the code, there should have been a Flask in the GrabbedFlaskSlot but it returned null instead.");
                return;
            }

            flaskSlotSelected.MixFlasks(GrabbedFlask);
            //flaskSlotSelected.TryPeekFlask().ColorAddition(GrabbedFlask.GetColor());

        }
        else
        {
            // Debug.Log("The grabbed flask was selected. FlaskManager");
        }
    }

    private void FlaskBaseSelected(FlaskSlot flaskSlotSelected)
    {
        // functionality for when they press the flask base is here
        // if the grabbed flask is empty
        //      if the flask base is empty: do nothing
        //      if the flask base is not empty: put the flask on this base into the grabbed flask slot
        // if the grabbed flask is occupied
        //      if the flask base is empty: put the grabbed flask into the flask base
        //      if the flask base is occupied: mix the grabbed flask into the flask at this flask base
    }
}
