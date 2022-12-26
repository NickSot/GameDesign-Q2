using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPort : MonoBehaviour
{
    [HideInInspector] public OutputPort connectedOutputPort;
    public bool connected;

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
        if (connectedOutputPort != null)
        {
            Vector3 connectedPortPos = connectedOutputPort.gameObject.transform.position;
            lr.SetVertexCount(2);
            lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -0.9f));
            lr.SetPosition(1, new Vector3(connectedPortPos.x, connectedPortPos.y, -0.9f));
            connected = true;
        
        }
        else
        {
            lr.SetVertexCount(0);
            connected = false;
        }
    }
}
