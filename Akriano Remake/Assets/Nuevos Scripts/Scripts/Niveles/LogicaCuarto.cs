using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCuarto : MonoBehaviour
{
    public List<GameObject> Enemigos_Actuales_Cuarto = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PrenderEnemigos()
    {
        for (int i = 0; i < Enemigos_Actuales_Cuarto.Count; i++)
        {
            Enemigos_Actuales_Cuarto[i].SetActive(true);
        }
    }

    public void ApagarEnemigos()
    {
        for (int i = 0; i < Enemigos_Actuales_Cuarto.Count; i++)
        {
            Enemigos_Actuales_Cuarto[i].SetActive(false);
        }
    }

    public void AgregarEnemigo(GameObject Enemigo_Actual)
    {
        Enemigo_Actual.SetActive(false);

        Enemigos_Actuales_Cuarto.Add(Enemigo_Actual);
    }
}
