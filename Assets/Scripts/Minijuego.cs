using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minijuego : MonoBehaviour
{
    public bool resuelto = false;
    public CogerObjeto objeto;
    public GameObject entradaAlMinijuego;
    
    public void Resolver(){
        resuelto = true;
        objeto.ObjetoCogido();
        BotonesCanvas bc = GameObject.Find("Canvas").GetComponent<BotonesCanvas>();
        bc.CerrarMinijuego();
        Destroy(entradaAlMinijuego);
    }

}
