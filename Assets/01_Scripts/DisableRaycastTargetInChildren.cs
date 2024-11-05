using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisableRaycastTargetInChildren : MonoBehaviour
{
    void Start()
    {
        DisableRaycastTargetsInChildren();
    }

    void DisableRaycastTargetsInChildren()
    {
        // Obtiene todos los componentes Graphic en los hijos
        Graphic[] graphics = GetComponentsInChildren<Graphic>(true);

        foreach (Graphic graphic in graphics)
        {
            if (graphic.gameObject == gameObject) continue;
            graphic.raycastTarget = false;
        }

        // Adicionalmente, para TextMeshProUGUI
        TextMeshProUGUI[] textMeshProElements = GetComponentsInChildren<TextMeshProUGUI>(true);

        foreach (TextMeshProUGUI textMeshPro in textMeshProElements)
        {
            if (textMeshPro.gameObject == gameObject) continue;
            textMeshPro.raycastTarget = false;
        }
    }
}
