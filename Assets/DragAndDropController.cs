using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float lineWidth;

    Component componentBeingHeld;
    InputPort inputPortBeingHeld;
    OutputPort outputPortBeingHeld;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = SenseObject();
            if (obj != null)
            {
                if (obj.GetComponent<Component>() != null)
                {
                    componentBeingHeld = obj.GetComponent<Component>();
                }
                else if (obj.GetComponent<InputPort>() != null)
                {
                    inputPortBeingHeld = obj.GetComponent<InputPort>();
                    if (inputPortBeingHeld.connectedOutputPort != null)
                    {
                        outputPortBeingHeld = inputPortBeingHeld.connectedOutputPort;
                        inputPortBeingHeld.connectedOutputPort.connectedInputPort = null;
                        inputPortBeingHeld.connectedOutputPort = null;
                        inputPortBeingHeld = null;
                    }
                }
                else if (obj.GetComponent<OutputPort>() != null)
                {
                    outputPortBeingHeld = obj.GetComponent<OutputPort>();
                } else if (obj.GetComponent<CustomButton>() != null) {
                    obj.GetComponent<CustomButton>().OnClick();
                }
            }
        }

        if (componentBeingHeld != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -0.9f));
            componentBeingHeld.transform.position = new Vector3(mousePos.x, mousePos.y, -0.9f);
        }
        else if (inputPortBeingHeld != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetVertexCount(2);
            lr.SetPosition(0, new Vector3(inputPortBeingHeld.transform.position.x, inputPortBeingHeld.transform.position.y, -0.9f));
            lr.SetPosition(1, new Vector3(mousePos.x, mousePos.y, -0.9f));
        }
        else if (outputPortBeingHeld != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetVertexCount(2);
            lr.SetPosition(0, new Vector3(outputPortBeingHeld.transform.position.x, outputPortBeingHeld.transform.position.y, -0.9f));
            lr.SetPosition(1, new Vector3(mousePos.x, mousePos.y, -0.9f));
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject obj = SenseObject();
            if (SenseObject() == null) {
                lr.SetVertexCount(0);
            }
            if (componentBeingHeld != null)
            {
                componentBeingHeld.transform.position = new Vector3(componentBeingHeld.transform.position.x, componentBeingHeld.transform.position.y, 0f);
                componentBeingHeld = null;
            }
            else if (inputPortBeingHeld != null)
            {
                lr.SetVertexCount(0);
                if (obj != null && obj.GetComponent<OutputPort>() != null)
                {
                    inputPortBeingHeld.GetComponent<InputPort>().connectedOutputPort = obj.GetComponent<OutputPort>();
                    obj.GetComponent<OutputPort>().connectedInputPort = inputPortBeingHeld;
                }
                inputPortBeingHeld = null;
            }
            else if (outputPortBeingHeld != null)
            {
                lr.SetVertexCount(0);
                if (obj != null)
                {
                    if (obj.GetComponent<InputPort>() != null)
                    {
                        obj.GetComponent<InputPort>().connectedOutputPort = outputPortBeingHeld;
                        outputPortBeingHeld.connectedInputPort = obj.GetComponent<InputPort>();
                    }
                }
                outputPortBeingHeld = null;
            }
        }

    }

    public GameObject SenseObject()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        return null;
    }

}
