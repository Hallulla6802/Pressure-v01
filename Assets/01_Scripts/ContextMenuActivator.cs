using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuActivator : MonoBehaviour
{
    public GameObject ContextMenu;
    public TextSequence textSequence;
    public void ActivateContextMenu()
    {
        ContextMenu.SetActive(true);
        textSequence.StartContextScreen();
    }
}
