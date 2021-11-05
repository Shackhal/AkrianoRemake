using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider vidaBarra;
    public Player player;

    private float saludMáxima;
    private float saludActual;

    // Start is called before the first frame update
    void Start()
    {
        vidaBarra.maxValue = player.maxHealth;
        vidaBarra.value = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        vidaBarra.value = player.health;

        if (vidaBarra.value <= 0)
        {
            vidaBarra.value = 0;
        }
    }
}
