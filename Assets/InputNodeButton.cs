using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNodeButton : CustomButton
{
    [SerializeField] InputNode inputNode;
    public override void OnClick() {
        inputNode.ToggleValue();
    }
}
