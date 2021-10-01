using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorPuerta : MonoBehaviour
{
    // Start is called before the first frame update

    /*public Puerta MiPrimeraPuerta;
    public Puerta MiSegundaPuerta;*/

    public List<Puerta> Puertas;

    void Start()
    {

        ConstruirPuertas();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConstruirPuertas()
    {


        for (int i = 0; i < Puertas.Count; i++)
        {
            //obtener los datos de la puerta actual
            Puerta datos_puerta = Puertas[i];

            //voy a construir la puerta con la info
            GameObject puerta_fisica = new GameObject();
            puerta_fisica.AddComponent<SpriteRenderer>();
            puerta_fisica.GetComponent<SpriteRenderer>().sprite = datos_puerta.Imagen_Puerta;
            puerta_fisica.transform.position = datos_puerta.Posicion_Puerta;
            puerta_fisica.transform.eulerAngles = datos_puerta.Rotacion_Puerta;
        }
    }
}
