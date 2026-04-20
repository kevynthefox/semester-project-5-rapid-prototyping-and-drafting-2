using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable_item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Transform parentAfterDrag;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false; //this is so the thing doesnt try dropping the item onto itself
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true; 
    }
}
