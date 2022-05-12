using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventario : MonoBehaviour
{
    public GameObject huecoActualSeleccionado{get; set;}
    public GameObject huecoPrevioSeleccionado{get; set;}
    private GameObject huecos;
    
    void Start(){
        InicializarInventario();
    }
    
    
    void InicializarInventario(){
        huecos = GameObject.Find("Huecos");
        foreach (Transform hueco in huecos.transform)
        {
            hueco.transform.GetComponent<Image>().sprite = null;
            var image = hueco.transform.GetComponent<Image>();
            var transparencia = image.color;
            transparencia.a = 0f;
            image.color = transparencia;
            hueco.GetComponent<Hueco>().propiedadesObjeto = Hueco.property.vacio;
        }
        huecoActualSeleccionado = null;
        huecoPrevioSeleccionado = huecoActualSeleccionado;
    }
    
    
}
