using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjetoInteractivo : MonoBehaviour, IUsable
{
    public enum PropiedadInteractiva {simple, desbloqueo}
    public PropiedadInteractiva Propiedad;
    public string ObjetoDesbloqueo;
    public GameObject ObjetoAcceso;
    private GameObject inventario;

    void Start(){
        inventario = GameObject.Find("MochilaAbierta");
        if(Propiedad == PropiedadInteractiva.simple){
            return;
        }
        ObjetoAcceso.SetActive(false);
    }
    public void Interactuar(ImagenFondo fondoActual){
        if(inventario.GetComponent<Inventario>().huecoActualSeleccionado.gameObject.transform.GetComponent<Image>().sprite.name == ObjetoDesbloqueo || ObjetoDesbloqueo == ""){
            this.gameObject.SetActive(false);
            var nombre = this.gameObject.name;
            try{
                GameObject.Find(nombre.ToString()).SetActive(false);
            }
            catch{
                
            }
            if(Propiedad == PropiedadInteractiva.simple){
                return;
            }
            inventario.GetComponent<Inventario>().huecoActualSeleccionado.GetComponent<Hueco>().VaciarHueco();
            ObjetoAcceso.SetActive(true);
        }
    }
}
