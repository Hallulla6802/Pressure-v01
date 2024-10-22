using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoInteractuarScript : MonoBehaviour
{
    public GameObject textoInteractuar;
    // Start is called before the first frame update
    public void CerrarTextoInteractuar()
    {
        textoInteractuar.SetActive(false);
    }
    public void AbrirTextoInteractuar()
    {
        textoInteractuar.SetActive(true);
    }
}
