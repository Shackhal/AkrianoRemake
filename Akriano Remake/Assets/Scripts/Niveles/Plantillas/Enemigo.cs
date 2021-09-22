using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemigo
{
    public string Nombre_Enemigo;
    public Vector2 Posicion_Enemigo;
    public Sprite Imagen_Enemigo;
    //Tipo_Enemigo es para tener distintos comportamientos
    public int Tipo_Enemigo;
    public int vida_enemigo;
}
