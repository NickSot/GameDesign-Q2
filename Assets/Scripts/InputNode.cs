using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNode : MonoBehaviour
{
    public OutputPort outputport;

    public void ToggleValue() {
       outputport.currentValue = !outputport.currentValue;
       print("current value is: " + outputport.currentValue);
    }
}
