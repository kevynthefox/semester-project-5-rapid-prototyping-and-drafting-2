using System;
using TMPro;
using UnityEngine;

public class the_thingy : MonoBehaviour
{
    public TextMeshProUGUI name_text;
    public TextMeshProUGUI description_text;

    public string name_;
    public string tag_;
    public int column;
    public int row;
    public GameObject self_references_to;


    private void Start()
    {
        name_text.text = name_;
        description_text.text = "tag: " + tag_ + " c:" + column + " r:" + row;
    }
}
