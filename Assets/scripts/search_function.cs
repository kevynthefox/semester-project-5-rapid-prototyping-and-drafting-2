using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class search_function : MonoBehaviour
{
    public static search_function current;
    
    public List<data_> things_internal;

    public string input_name;
    public string input_tag;

    public List<data_> things_display;

    public GameObject template;
    public GameObject holder;

    public TextMeshProUGUI  name_input_text;
    public TextMeshProUGUI tag_input_text;

    private void Start()
    {
        current = this;
    }

    #region  searching

    public void OnEnable()
    {
        search_all();
    }


    public void search_all()
    {
        
        destroy_list();
        if (input_tag.Length <= 1 && input_name.Length <= 1)
        {
            Debug.Log("tag and name were empty, displaying all");
            foreach (data_ data in things_internal)
            {
                things_display.Add(data);
            }
            display_list();
            
        }
        if  (input_tag.Length >= 2) search_tag();
        if  (input_name.Length >= 2) search_name();
    }

    public void search_name()
    {
        //Debug.Log(input_name);
        for (int i = 0;i < things_internal.Count; i++)
        {
            //Debug.Log(things_internal[i].name_.Substring(0,input_name.Length));
            if (things_internal[i].name_ == input_name)
            {
                things_display.Add(things_internal[i]);
            }
        }
        display_list();
    }
    
    public void search_tag()
    {
        //Debug.Log(input_tag);
        for (int i = 0;i < things_internal.Count; i++)
        {
            /*string length_adjusted_internal = things_internal[i].tag.Substring(0, input_tag.Length);
            Debug.Log("tag length: " + input_tag.Length + " internal length: " + length_adjusted_internal.Length);
            Debug.Log("tag input: " + input_tag + " tag internal: " + length_adjusted_internal);*/
            if (input_tag == things_internal[i].tag)
            {
                Debug.Log("input == the tag");
                things_display.Add(things_internal[i]);
                display_list();
            }
        }
        
    }
    
    #endregion

    #region listing
    public void display_list()
    {
        Debug.Log("trying to display");
        foreach (data_ data in things_display)
        {
            var displayed_data = Instantiate(template, holder.transform);
            displayed_data.transform.SetParent(holder.transform);
            if (displayed_data.TryGetComponent<the_thingy>(out the_thingy thingy))
            {
                thingy.name_ = data.name_;
                thingy.tag_ = data.tag;
                thingy.column = data.column;
                thingy.row = data.row;
                if (data.object_ != null ) thingy.self_references_to = data.object_;
            }
            
        }
    }

    public void destroy_list()
    {
        things_display.Clear();
        for (int i = 0; i < holder.transform.childCount; i++)
        {
            Destroy(holder.transform.GetChild(i).gameObject);
        }
    }
    #endregion

    #region text_retrieving

    public void name_retrieval()
    {
        input_name = name_input_text.text;
        search_all();
    }
    public void tag_retrieval()
    {
        input_tag = tag_input_text.text;
        search_all();
    }
    
    #endregion

    #region data_creation

    public void create_data(GameObject data, int column, int row, string name_, string tag)
    {
        things_internal.Add(new data_());
        things_internal.Last().object_ = data;
        things_internal.Last().column = column;
        things_internal.Last().row = row;
        things_internal.Last().name_ = name_;
        things_internal.Last().tag = tag;
    }

    #endregion
}

[Serializable]
public class data_
{
    public GameObject object_;
    public int column;
    public int row;
    public string name_;
    public string tag;
}
