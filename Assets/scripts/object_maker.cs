using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class object_maker : MonoBehaviour
{
    public GameObject object_template;
    public List<Sprite> potential_objects;
    public List<GameObject> current_objects;
    
    public TextMeshProUGUI  name_input_text;
    public TextMeshProUGUI tag_input_text;

    public GameObject background;
    public GameObject cell_template;

    public int column = 1;
    public int row = 1;
    public int column_count;
    public int row_count;


    private void Start()
    {
        make_grid();
    }

    public void make_object()
    {
        int random_obj = Random.Range(0, potential_objects.Count);
        
        var new_obj = Instantiate(object_template,Vector3.zero,Quaternion.identity);
        new_obj.GetComponent<Image>().sprite = potential_objects[random_obj];
        new_obj.transform.SetParent(this.transform);
        
        current_objects.Add(new_obj);
    }

    public void name_object()
    {
        current_objects.Last().GetComponent<object_logic>().name_ =  name_input_text.text;
    }
    
    public void tag_object()
    {
        current_objects.Last().GetComponent<object_logic>().tag =  tag_input_text.text;
    }

    public void make_grid()
    {

        for (int i = 0; i < (column_count * row_count); i++)
        {
            var new_cell = Instantiate(cell_template,Vector3.zero,Quaternion.identity);
            new_cell.transform.SetParent(background.transform); 

            if (new_cell.TryGetComponent<cell_logic>(out cell_logic logic))
            {
                logic.column = column;
                column++;
                logic.row = row;
                if (column > column_count)
                {
                    column = 1;
                    row++;
                }
            }
        }
        
    }
}
