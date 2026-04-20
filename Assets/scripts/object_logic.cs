using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class object_logic : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string name_;
    public string tag;
    public int column;
    public int row;
    
    public bool move_to_cursor;

    public Image image;
    public Transform parentAfterDrag;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false; //this is so the thing doesnt try dropping the item onto itself

        column = 69;
        row = 69;

        for (int i = 0; i < search_function.current.things_internal.Count; i++)
        {
            if (search_function.current.things_internal[i].object_ == this.gameObject)
            {

                search_function.current.things_internal.Remove(search_function.current.things_internal[i]);
            }
        }
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

    public void dropped()
    {
        search_function.current.create_data(this.gameObject, column, row,name_, tag);
    }
}
