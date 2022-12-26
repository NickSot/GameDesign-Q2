using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPort : MonoBehaviour
{
    [HideInInspector] public OutputPort connectedOutputPort;
    public bool connected;
    public string outputTag;
    [SerializeField] float lineWidth;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
    }

    public void Update()
    {
        if (connectedOutputPort != null) // if there is a connection
        {
            Vector3 connectedPortPos = connectedOutputPort.gameObject.transform.position;
            lr.SetVertexCount(2);
            lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -0.9f));
            lr.SetPosition(1, new Vector3(connectedPortPos.x, connectedPortPos.y, -0.9f));
            outputTag = connectedOutputPort.tag;
            connected = true;
      
        }
        else
        {
            lr.SetVertexCount(0);

            connected = false;
        }
        
    }

    public int GetPortValue()
    {
        if (outputTag == "Switch")
        {
            return connectedOutputPort.GetComponentInParent<Switch>().value;
        }
        else if (outputTag == "ANDGate")
        {
            return connectedOutputPort.GetComponentInParent<ANDGate>().output;
        } else if (outputTag == "ORGate")
        {
            return connectedOutputPort.GetComponentInParent<ORGate>().output;
        } else if (outputTag == "NOTGate")
        {
            return connectedOutputPort.GetComponentInParent<NOT>().output;
        } else
        {
            return 0;
        }
        
    }
   
}

