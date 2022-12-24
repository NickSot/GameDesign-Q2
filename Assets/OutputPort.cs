using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputPort : Port
{
    [HideInInspector] public InputPort connectedInputPort;
}
