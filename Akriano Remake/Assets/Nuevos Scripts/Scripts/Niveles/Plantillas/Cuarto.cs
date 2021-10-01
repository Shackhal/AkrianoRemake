using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cuarto
{
    public Sprite Fondo;
    public Vector2 Posicion_Cuarto;
    public List<Puerta> Puertas_Cuarto;
    public List<Enemigo> Enemigos;
}
