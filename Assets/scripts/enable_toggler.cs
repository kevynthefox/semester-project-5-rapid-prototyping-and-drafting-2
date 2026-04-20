using UnityEngine;

public class enable_toggler : MonoBehaviour
{
    public GameObject target;
    public bool state;
    
    public void do_()
    {
        state = !state;
        target.SetActive(state);
    }
}
