using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Port : MonoBehaviour
{
    [SerializeField] Color activeColor;
    [SerializeField] Color inactiveColor;
    [SerializeField] public bool currentValue;
    protected SpriteRenderer renderer;
    private void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (currentValue) {
            renderer.color = activeColor;
        } else {
            renderer.color = inactiveColor;
        }
    }
}
