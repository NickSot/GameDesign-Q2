using UnityEngine;
using UnityEngine.EventSystems;

public class ComponentSpawner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] GameObject component;
    SpawnMenuBox menuBox;

    bool isOnObject;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOnObject = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOnObject = false;
    }

    private void Start()
    {
        menuBox = transform.parent.gameObject.GetComponent<SpawnMenuBox>();
    }

    private void Update()
    {
        if (isOnObject && Input.GetMouseButtonDown(0))
        {
            print(gameObject.name);
            GameObject spawnedComponent = Instantiate(component, Input.mousePosition, Quaternion.identity);
            menuBox.dNDController.componentBeingHeld = spawnedComponent.GetComponent<Component>();
        }

    }

}