using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject InformationPanel;
    bool isOpen = false;

    public void _TogglePanel()
    {
        if (isOpen)
        {
            InformationPanel.SetActive(false);
            isOpen = false;
        }
        else
        {
            InformationPanel.SetActive(true);
            isOpen = true;
        }
    }

}
