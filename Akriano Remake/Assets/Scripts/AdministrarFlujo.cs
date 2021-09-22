using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministrarFlujo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AnimacionFinal;
    public GameObject AnimacionTexto;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarAnimacionFinal()
    {
        AnimacionFinal.SetActive(true);
        AnimacionTexto.SetActive(true);
    }

    public void DesactivarAnimacionFinal()
    {
        AnimacionFinal.SetActive(false);
        AnimacionTexto.SetActive(false);
    }

}
