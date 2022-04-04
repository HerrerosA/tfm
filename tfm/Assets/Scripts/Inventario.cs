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
    void Update(){
        SeleccionarHueco();
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
        huecoActualSeleccionado = GameObject.Find("Hueco (1)");
        huecoPrevioSeleccionado = huecoActualSeleccionado;
    }
    void SeleccionarHueco(){
        foreach (Transform hueco in huecos.transform)
        {
            if(hueco.gameObject == huecoActualSeleccionado && hueco.GetComponent<Hueco>().propiedadesObjeto == Hueco.property.usable)
            {
                /*TODO: hacer que se vea seleccionado el objeto */
                //hueco.GetComponent<Image>().color = new Color(.5f, 0f, 0.1f, 1);
            }
           
        }
    }
}
