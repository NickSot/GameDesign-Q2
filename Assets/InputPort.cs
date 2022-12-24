using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPort : Port
{
    [HideInInspector] public OutputPort connectedOutputPort;

    [SerializeField] private Material activeLine;
    [SerializeField] private Material inactiveLine;

    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (connectedOutputPort != null)
        {
            currentValue = connectedOutputPort.currentValue;
            if (currentValue) {
                lr.material = activeLine;
            } else {
                lr.material = inactiveLine;
            }
            Vector3 connectedPortPos = connectedOutputPort.gameObject.transform.position;
            lr.SetVertexCount(2);
            lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -0.9f));
            lr.SetPosition(1, new Vector3(connectedPortPos.x, connectedPortPos.y, -0.9f));
        }
        else
        {
            lr.SetVertexCount(0);
            currentValue = false;
        }
    }
}
