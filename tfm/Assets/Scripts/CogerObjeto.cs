using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogerObjeto : MonoBehaviour, IUsable
{
    public string MostrarSprite;
    public enum property {usable, visible};
    public string CombinacionObjeto;
    public property propiedadesObjeto;
    private GameObject HuecosInventario;
    public void Interactuar(ImagenFondo mostrarActual){
        ObjetoCogido();
    }
    void Start(){

    }
    public void ObjetoCogido(){
        HuecosInventario = GameObject.Find("Huecos");
        foreach (Transform hueco in HuecosInventario.transform){
            if(hueco.transform.GetComponent<Image>().sprite == null){
                hueco.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventario/" + MostrarSprite);
                var image = hueco.transform.GetComponent<Image>();
                var transparencia = image.color;
                transparencia.a = 1f;
                image.color = transparencia;
                hueco.GetComponent<Hueco>().AsignarPropiedad((int)propiedadesObjeto, CombinacionObjeto);
                Destroy(gameObject);
                break;
            }    
        }
        
    }
}
