using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextoInteractuarScript : MonoBehaviour
{
    public GameObject textoInteractuar;
    public TMP_Text textoUI;
    // Start is called before the first frame update
    public void CerrarTextoInteractuar()
    {
        textoInteractuar.SetActive(false);
        textoUI.text = null;
    }
    public void AbrirTextoInteractuar(string text)
    {
        textoInteractuar.SetActive(true);
        textoUI.text = text;
    }

}
