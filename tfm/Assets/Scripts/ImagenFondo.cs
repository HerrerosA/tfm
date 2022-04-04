using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImagenFondo : MonoBehaviour
{
    public string FondoActual{
        get { return fondoActual; }
        set{
            /* Todas las escenas tienen cuatro posiciones, así que cuando llega a la 5 es otra vez la primera */
            if(value.Contains("5")){
                fondoActual = value.Replace("5", "1");
            }
            /* Cuando la escena llega a 0 porque se va restando es lo mismo que la última */
            else if (value.Contains("0")){
                fondoActual = value.Replace("0", "4");
            }
            else{
                fondoActual = value;
            }
        }
    }
    public string escenario;
    private string fondoActual;
    private string fondoPrevio;
    
    /* Se empieza el nivel en la escena definida pero en la posición 1 */
    void Start()
    {
        fondoPrevio = "0";
        fondoActual = escenario;
    }

    /* Se comprueba si el fondo ha cambiado y se busca la imagen en los recursos y se cambia la que había */
    void Update()
    {
        /* Se coge el nombre de la escena y la posición */
        if(fondoActual != fondoPrevio){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Fondos/" + fondoActual.ToString());
        }
        fondoPrevio = fondoActual; 
    }
}
