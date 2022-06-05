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
    private bool seleccionado = false;
    private bool nocombina = false;
    [HideInInspector] public GameObject objetoSeleccionado = null;
    void Start()
    {
        inventario = GameObject.Find("MochilaAbierta");
    
    }
    public void Update()
    {
        if (seleccionado)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            objetoSeleccionado.transform.position = new Vector3(cursorPos.x, cursorPos.y, -2.85f);
        }
        
    }

    public void OnPointerClick(PointerEventData eventData){
        if (this.propiedadesObjeto == property.usable){
            inventario.GetComponent<Inventario>().huecoPrevioSeleccionado = inventario.GetComponent<Inventario>().huecoActualSeleccionado;
            inventario.GetComponent<Inventario>().huecoActualSeleccionado = this.gameObject;
            Seleccionar();
        }
    }
    public void AsignarPropiedad(int numeroOrden, string combinacionObjeto){
        propiedadesObjeto = (property)numeroOrden;
        this.combinacionObjeto = combinacionObjeto;
    }
    void Seleccionar(){
        
        if (inventario.GetComponent<Inventario>().huecoPrevioSeleccionado!= null){
            if(inventario.GetComponent<Inventario>().huecoPrevioSeleccionado.GetComponent<Hueco>().combinacionObjeto == this.gameObject.GetComponent<Hueco>().combinacionObjeto && this.gameObject.GetComponent<Hueco>().combinacionObjeto != "" && this.gameObject.GetComponent<Hueco>() != inventario.GetComponent<Inventario>().huecoPrevioSeleccionado.GetComponent<Hueco>()){
                GameObject objetoCombinado = Instantiate(Resources.Load<GameObject>("Combinados/" + combinacionObjeto));
                objetoCombinado.GetComponent<CogerObjeto>().ObjetoCogido();
                inventario.GetComponent<Inventario>().huecoPrevioSeleccionado.GetComponent<Hueco>().VaciarHueco();
                VaciarHueco();
            }
            else{
                if(this.gameObject.GetComponent<Hueco>() != inventario.GetComponent<Inventario>().huecoPrevioSeleccionado.GetComponent<Hueco>()){
                    nocombina = true;
                }
                SeleccionarHueco();
            }
        }
        else{
            SeleccionarHueco();
        }
        
    }
    public void SeleccionarHueco(){
        var colorObjeto = this.GetComponent<Image>().color;
        if (inventario.GetComponent<Inventario>().huecoPrevioSeleccionado == this.gameObject || nocombina){
            if(nocombina){
                inventario.GetComponent<Inventario>().huecoPrevioSeleccionado.GetComponent<Hueco>().SeleccionarHueco();
                nocombina=false;
            }
            Destroy(objetoSeleccionado);
            colorObjeto.a = 1.0f;
            seleccionado = false;
            inventario.GetComponent<Inventario>().huecoPrevioSeleccionado = inventario.GetComponent<Inventario>().huecoActualSeleccionado = null;
                
        }
          
        else{
            if (inventario.GetComponent<Inventario>().huecoPrevioSeleccionado != null)
                
                inventario.GetComponent<Inventario>().huecoPrevioSeleccionado = null;
                colorObjeto.a = 0.5f;
                seleccionado = true;
                objetoSeleccionado = new GameObject(this.GetComponent<Image>().sprite.name, typeof(SpriteRenderer));
                objetoSeleccionado.transform.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Inventario/" + this.GetComponent<Image>().sprite.name);
                objetoSeleccionado.transform.GetComponent<SpriteRenderer>().sortingOrder=3;
                objetoSeleccionado.transform.localScale= new Vector3(0.1f, 0.1f, 0.1f);
        }
        this.GetComponent<Image>().color = colorObjeto;
        
    }

    public void VaciarHueco(){
        propiedadesObjeto = Hueco.property.vacio;
        combinacionObjeto = "";
        transform.GetComponent<Image>().sprite = null;
        var image = transform.GetComponent<Image>();
        var transparencia = image.color;
        transparencia.a = 0f;
        image.color = transparencia;
        seleccionado=false;
        Destroy(objetoSeleccionado);
    }
}
