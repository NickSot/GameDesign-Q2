using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrComponent : Component
{
    [SerializeField] InputPort inpA;
    [SerializeField] InputPort inpB;

    public override bool LogicStatement()
    {
        return inpA.currentValue || inpB.currentValue;
    }
}
