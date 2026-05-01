using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChooser : MonoBehaviour
{
    // listen to the selectable event
    // on selected, cycle through the color

    // need to be connected to some gameobject that swaps color

    private void CycleColor()
    {
        // cycle color
        // show cycled color
    }

    public Color GetColor()
    {
        return new Color();
    }
}


/**
 *  this has a ui element for the color
 *  it has a ui element for the text
 *  it has ui element(s) for turning the wheel
 *  
 *  i guess they're not necessarily ui elements... they would be gameobjects to press...
 *  yeah they can't be ui elements, they've gotta be GOs
 *  
 *  so, i need to rethink this
 *  i need GOs that: (1) switch color, (2) display color, (3) pour flask
 *  
 *  
 *  
 *  
 */