#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskSlot : MonoBehaviour
{
    private Flask? flask;

    public bool IsFlaskSlotAvailable()
    {
        return (flask == null) ? true : false;
    }

    public bool SetFlask(Flask aFlask)
    {
        if (flask == null)
        {
            flask = aFlask;
            return true;
        }
        else
        {
            Debug.Log("A FlaskSlot was given a Flask but there was already a flask in the slot. Remove it first, or perform a color addition if that is the intended operation.");
            return false;
        }
    }

    // Gotta test this out.
    public Flask? TryGrabFlask()
    {
        if (flask is Flask valueOfFlask)
        {
            Flask? temp = valueOfFlask;
            flask = null;
            return temp;
        }
        else
        {
            return null;
        }   
    }

    public bool MixFlasks(Flask? aFlask)
    {
        // If the input flask is null.
        if (aFlask == null) return false;

        // There is a flask in the FlaskSlot
        if (flask is Flask currFlask)
        {
            // Make the flask in this flask slot change color, adding aFlask.
            flask.ColorAddition(aFlask.GetColor());

            // I will consider whether the flask should be destroyed here, or in another script.
            Destroy(aFlask.gameObject);

            return true;
        }
        else
        {
            // There is no flask in the FlaskSlot
            return false;
        }
    }

    public bool MixFlasks(Color colorToMix)
    {
        if (flask is Flask currFlask)
        {
            // Mix the incoming color into the flask
            flask.ColorAddition(colorToMix);

            return true;
        }
        else
        {
            // There is no flask in the FlaskSlot
            return false;
        }
    }
}