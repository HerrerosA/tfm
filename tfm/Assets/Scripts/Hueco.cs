using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hueco : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventario;
    public enum property {usable, vacio};
    public property propiedadesObjeto {get; set;}
    public string combinacionObjeto { get; private set; }
    void Start()
    {
        inventario = GameObject.Find("MochilaAbierta");
    
    }

    public void OnPointerClick(PointerEventData eventData){
        inventario.GetComponent<Inventario>().huecoPrevioSeleccionado = inventario.GetComponent<Inventario>().huecoActualSeleccionado;
        inventario.GetComponent<Inventario>().huecoActualSeleccionado = this.gameObject;
        Combinar();
    }
    public void AsignarPropiedad(int numeroOrden, string combinacionObjeto){
        propiedadesObjeto = (property)numeroOrden;
        this.combinacionObjeto = combinacionObjeto;
    }
    void Combinar(){
        if(inventario.GetComponent<Inventario>().huecoPrevioSeleccionado.GetComponent<Hueco>().combinacionObjeto == this.gameObject.GetComponent<Hueco>().combinacionObjeto && this.gameObject.GetComponent<Hueco>().combinacionObjeto != ""){
            GameObject objetoCombinado = Instantiate(Resources.Load<GameObject>("Combinados/" + combinacionObjeto));
            objetoCombinado.GetComponent<CogerObjeto>().ObjetoCogido();
            inventario.GetComponent<Inventario>().huecoPrevioSeleccionado.GetComponent<Hueco>().VaciarHueco();
            VaciarHueco();

        }
    }
    public void VaciarHueco(){
        propiedadesObjeto = Hueco.property.vacio;
        combinacionObjeto = "";
        transform.GetComponent<Image>().sprite = null;
        var image = transform.GetComponent<Image>();
        var transparencia = image.color;
        transparencia.a = 0f;
        image.color = transparencia;
    }
}
