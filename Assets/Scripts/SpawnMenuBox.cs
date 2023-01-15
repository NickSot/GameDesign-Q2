using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnMenuBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public DragAndDropController dNDController;

    bool isOnObject;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOnObject = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOnObject = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && isOnObject)
        {
            Destroy(dNDController.componentBeingHeld.gameObject);
            dNDController.componentBeingHeld = null;
        }
    }
}
