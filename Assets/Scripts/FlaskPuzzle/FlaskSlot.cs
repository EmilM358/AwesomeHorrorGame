#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskSlot : MonoBehaviour
{
    private Flask? flask;

    private void Update()
    {
        string flaskName;
        if (flask == null) flaskName = "No flask";
        else flaskName = flask.name;

        // Debug to check if FlaskSlots are operating properly
        Debug.Log("FlaskSlot: " + name + " Flask: " + flaskName);
    }

    public bool IsFlaskSlotAvailable()
    {
        return (flask == null) ? true : false;
    }

    // Gotta test this out.
    public Flask? TryGrabFlask()
    {
        Debug.Log("A Flask was grabbed from a FlaskSlot.");

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
    public Flask? TryPeekFlask()
    {
        Debug.Log("A Flask was peeked at from a FlaskSlot.");

        if (flask is Flask valueOfFlask)
        {
            return valueOfFlask;
        }
        else
        {
            return null;
        }
    }

    // I should make a func that sets the flask if empty and mixes the flask otherwise, maybe
    public bool SetFlask(Flask aFlask)
    {
        Debug.Log("A Flask was set into a FlaskSlot.");

        if (flask == null)
        {
            flask = aFlask;
            flask.SetFlaskSlot(this);

            flask.transform.SetParent(transform);
            flask.transform.position = transform.position;
            
            return true;
        }
        else
        {
            Debug.Log("A FlaskSlot was given a Flask but there was already a flask in the slot. Remove it first, or perform a color addition if that is the intended operation.");
            return false;
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

    public bool FlaskCompare(Flask compareTo)
    {
        if (compareTo == null || flask == null) return false;
        return compareTo == flask;
    }
}