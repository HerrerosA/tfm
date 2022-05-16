using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesCanvas : MonoBehaviour
{
    [HideInInspector] public ImagenFondo fondoActual;
    [HideInInspector] public bool mochilaEnUso;
    [HideInInspector] public bool movilEnUso;
    [HideInInspector] public bool minijuegoEnUso;

    [HideInInspector] public GameObject direccion;

    private GameObject mochila;
    private GameObject atras;
    private CanvasGroup mochilaAbierta;
    private GameObject movilEncendido;
    private bool inventario;
    private GameObject minijuegoAbierto = null;
    private GameObject escenarios;
    
    
    /* Se carga el fondo actual */
    void Start(){
        fondoActual = GameObject.Find("Fondo").GetComponent<ImagenFondo>();
        mochila = GameObject.Find("Mochila");
        mochila.SetActive(true);
        mochilaAbierta = GameObject.Find("MochilaAbierta").GetComponent<CanvasGroup>();
        mochilaAbierta.alpha = 0;
        mochilaAbierta.interactable = false;
        mochilaAbierta.blocksRaycasts = false;
        movilEncendido = GameObject.Find("Smartphone");
        movilEncendido.SetActive(false);
        direccion = GameObject.Find("Direccion");
        direccion.SetActive(false);
        atras = GameObject.Find("IrAtras");
        atras.SetActive(false);
        mochilaEnUso = false;
        movilEnUso = false;
        minijuegoEnUso = false;
        escenarios = GameObject.Find("Escenarios");
    }
    /* Si se pulsa la flecha de la derecha se suma uno a la posición y si es la de la izquierda se resta */
    public void PulsarDerecha(){
        if(!inventario){
            int numero;
            int.TryParse(fondoActual.FondoActual.Substring(fondoActual.FondoActual.Length - 1), out numero);
            numero = numero + 1;
            fondoActual.FondoActual = fondoActual.FondoActual.Remove(fondoActual.FondoActual.Length -1, 1) + numero;
        }
    }
    public void PulsarIzquierda(){
        if(!inventario){
            int numero;
            int.TryParse(fondoActual.FondoActual.Substring(fondoActual.FondoActual.Length - 1), out numero);
            numero = numero - 1;
            fondoActual.FondoActual = fondoActual.FondoActual.Remove(fondoActual.FondoActual.Length -1, 1) + numero;
        }
    }
    public void IrLugar(){
        if(movilEncendido.GetComponent<Smartphone>().fechaSeleccionada=="15/04/2022 17:32"){
            fondoActual.FondoActual= "Buzones1";
            IrAtras();
            IrAtras();
        }
    }
    public void IrAtras(){
        if (movilEnUso == true){
            CerrarSmartphone();
        }
        else if (mochilaEnUso == true){
            CerrarMochila();
        }
        else if(minijuegoEnUso == true){
            CerrarMinijuego();
        }
    }
    public void PulsarMochila(){
        atras.SetActive(true);
        inventario = true;
        mochila.SetActive(false);
        direccion.SetActive(true);
        movilEncendido.SetActive(false);
        escenarios.SetActive(false);
        mochilaAbierta.alpha = 1;
        mochilaAbierta.interactable = true;
        mochilaAbierta.blocksRaycasts = true;
        mochilaEnUso = true;
    }
    public void CerrarMochila(){
        atras.SetActive(false);
        inventario = false;
        mochila.SetActive(true);
        direccion.SetActive(true);
        movilEncendido.SetActive(false);
        escenarios.SetActive(true);
        mochilaAbierta.alpha = 0;
        mochilaAbierta.interactable = false;
        mochilaAbierta.blocksRaycasts = false;
        mochilaEnUso = false;
    }
    public void PulsarSmartphone(){
        mochila.SetActive(false);
        direccion.SetActive(false);
        movilEncendido.SetActive(true);
        mochilaAbierta.alpha = 0;
        mochilaAbierta.interactable = false;
        mochilaAbierta.blocksRaycasts = false;
        movilEnUso = true;
    }
    public void CerrarSmartphone(){
        mochila.SetActive(false);
        direccion.SetActive(true);
        movilEncendido.SetActive(false);
        mochilaAbierta.alpha = 1;
        mochilaAbierta.interactable = true;
        mochilaAbierta.blocksRaycasts = true;
        movilEnUso = false;
    }
    public void AbrirMinijuego(GameObject minijuego){
        atras.SetActive(true);
        mochila.SetActive(false);
        direccion.SetActive(false);
        escenarios.SetActive(false);
        minijuego.SetActive(true);
        minijuegoAbierto = minijuego;
        minijuegoEnUso = true;
    }
    public void CerrarMinijuego(){
        if (minijuegoAbierto!= null){
            minijuegoAbierto.SetActive(false);
        }
        atras.SetActive(false);
        mochila.SetActive(true);
        direccion.SetActive(true);
        escenarios.SetActive(true);
        minijuegoAbierto = null;
        minijuegoEnUso = false;
    }
    
}
