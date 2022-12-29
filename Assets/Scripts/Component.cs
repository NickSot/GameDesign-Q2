using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Component : MonoBehaviour
{
    // [SerializeField] bool isNot = false;

    // [SerializeField] OutputPort output;

    // public abstract bool LogicStatement();

    // public bool ProcessOutput()
    // {
    //     if (isNot)
    //     {
    //         return !LogicStatement();
    //     }
    //     else
    //     {
    //         return LogicStatement();
    //     }
    // }

    // public void Update()
    // {
    //     output.currentValue = ProcessOutput();
    // }

}
