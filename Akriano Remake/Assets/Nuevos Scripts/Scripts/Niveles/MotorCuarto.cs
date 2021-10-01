using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCuarto : MonoBehaviour
{

    // Start is called before the first frame update

    public List<Cuarto> Cuartos = new List<Cuarto>();



    public List<GameObject> CuartosCreados = new List<GameObject>();
    public int Index_Cuarto_Actual;
    public GameObject Mapa_Colision;

    void Start()
    {
        ConstruyrCuartos();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void ConstruyrCuartos()
    {
        for (int i = 0; i < Cuartos.Count; i++)
        {
            Cuarto CuartoActual = Cuartos[i];

            GameObject cuarto_fisico = new GameObject();
            cuarto_fisico.AddComponent<SpriteRenderer>();
            cuarto_fisico.GetComponent<SpriteRenderer>().sprite = CuartoActual.Fondo;
            cuarto_fisico.transform.position = CuartoActual.Posicion_Cuarto;
            GameObject collision_copia = Instantiate(Mapa_Colision);
            collision_copia.transform.position = CuartoActual.Posicion_Cuarto;
            cuarto_fisico.AddComponent<LogicaCuarto>();

            CuartosCreados.Add(cuarto_fisico);

            for (int j = 0; j < CuartoActual.Puertas_Cuarto.Count; j++)
            {
                //obtener los datos de la puerta actual
                Puerta datos_puerta = CuartoActual.Puertas_Cuarto[j];

                //voy a construir la puerta con la info
                GameObject puerta_fisica = new GameObject();
                puerta_fisica.AddComponent<SpriteRenderer>();
                puerta_fisica.GetComponent<SpriteRenderer>().sprite = datos_puerta.Imagen_Puerta;

                puerta_fisica.GetComponent<SpriteRenderer>().sortingOrder = 1;

                puerta_fisica.transform.position = datos_puerta.Posicion_Puerta;
                puerta_fisica.transform.eulerAngles = datos_puerta.Rotacion_Puerta;


                switch (datos_puerta.Tipo_Puerta)
                {

                    case 0:
                        //Asignar la accion para pasar a otro cuarto
                        puerta_fisica.AddComponent<PuertaMover>().direccion = datos_puerta.Direccion_Puerta;
                        puerta_fisica.GetComponent<PuertaMover>().Cuarto_Objetivo = datos_puerta.Numero_Cuarto;
                        break;

                    case 1:
                        //Asignar la accion para finalizar el juego
                        puerta_fisica.AddComponent<PuertaFinalizar>();
                        break;

                    case 2:
                        //Asignar la accion para finalizar el juego
                        puerta_fisica.AddComponent<PuertaFinalizar2>();
                        break;

                    case 3:
                        //Asignar la accion para finalizar el juego
                        puerta_fisica.AddComponent<PuertaFinalizar3>();
                        break;

                    case 4:
                        //Asignar la accion para finalizar el juego
                        puerta_fisica.AddComponent<PuertaFinalizar4>();
                        break;

                    case 5:
                        //Asignar la accion para finalizar el juego
                        puerta_fisica.AddComponent<PuertaFinal>();
                        break;
                }
            }

            for (int k = 0; k < CuartoActual.Enemigos.Count; k++)
            {
                CrearEnemigo(CuartoActual.Enemigos[k], cuarto_fisico);
            }


        }

        CuartosCreados[Index_Cuarto_Actual].GetComponent<LogicaCuarto>().PrenderEnemigos();

    }

    public void PrenderEnemigosActuales()
    {
        CuartosCreados[Index_Cuarto_Actual].GetComponent<LogicaCuarto>().PrenderEnemigos();
    }
    public void ApagarEnemigosActuales()
    {
        CuartosCreados[Index_Cuarto_Actual].GetComponent<LogicaCuarto>().ApagarEnemigos();
    }

    public void CrearEnemigo(Enemigo Enemigo_Actual, GameObject Cuarto_Fisico_Actual)
    {
        GameObject enemigo_clon = new GameObject();
        enemigo_clon.gameObject.tag = "Enemigo";
        enemigo_clon.name = Enemigo_Actual.Nombre_Enemigo;
        enemigo_clon.transform.position = Enemigo_Actual.Posicion_Enemigo;
        enemigo_clon.AddComponent<SpriteRenderer>();
        enemigo_clon.GetComponent<SpriteRenderer>().sprite = Enemigo_Actual.Imagen_Enemigo;
        enemigo_clon.GetComponent<SpriteRenderer>().sortingOrder = 1;
        enemigo_clon.AddComponent<BoxCollider2D>().isTrigger = true;
        enemigo_clon.AddComponent<LogicaEnemigo>().Vida_Enemigo = Enemigo_Actual.vida_enemigo;

        Cuarto_Fisico_Actual.GetComponent<LogicaCuarto>().AgregarEnemigo(enemigo_clon);
        //asignar una habilidad
        //swtich
        switch (Enemigo_Actual.Tipo_Enemigo)
        {

            case 0:
                Debug.Log("ASIGNAR LA ACCION SEGUIR");
                enemigo_clon.AddComponent<Seguir_Enemigo>();


                break;

            case 1:
                Debug.Log("ASIGNAR LA ACCION DISPARAR");
                enemigo_clon.AddComponent<Disparar_Enemigo>();
                break;
            case 2:
                Debug.Log("ASIGNAR LA ACCION SEGUIR Y DISPARAR");

                enemigo_clon.AddComponent<Seguir_Enemigo>();
                enemigo_clon.AddComponent<Disparar_Enemigo>();

                break;
        }


    }
   
}
