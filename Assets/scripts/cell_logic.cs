using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class cell_logic : MonoBehaviour, IDropHandler
{

    public int column;
    public int row;
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        object_logic object_Logic = dropped.GetComponent<object_logic>();
        object_Logic.parentAfterDrag = transform;
        
        if (dropped.TryGetComponent<object_logic>(out object_logic obj))
        {
            obj.column = column;
            obj.row = row;
            obj.dropped();
        }
    }
}
