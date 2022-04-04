using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesCanvas : MonoBehaviour
{
    private ImagenFondo fondoActual;
    private GameObject mochila;
    private CanvasGroup mochilaAbierta;
    private GameObject movilEncendido;
    private GameObject direccion;
    private bool inventario;

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
        direccion.SetActive(true);
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
    public void PulsarMochila(){
        inventario = true;
        mochila.SetActive(false);
        direccion.SetActive(true);
        movilEncendido.SetActive(false);
        mochilaAbierta.alpha = 1;
        mochilaAbierta.interactable = true;
        mochilaAbierta.blocksRaycasts = true;
    }
    public void CerrarMochila(){
        inventario = false;
        mochila.SetActive(true);
        direccion.SetActive(true);
        movilEncendido.SetActive(false);
        mochilaAbierta.alpha = 0;
        mochilaAbierta.interactable = false;
        mochilaAbierta.blocksRaycasts = false;
    }
    public void CerrarSmartphone(){
        mochila.SetActive(false);
        direccion.SetActive(true);
        movilEncendido.SetActive(false);
        mochilaAbierta.alpha = 1;
        mochilaAbierta.interactable = true;
        mochilaAbierta.blocksRaycasts = true;
    }
    public void PulsarSmartphone(){
        mochila.SetActive(false);
        direccion.SetActive(false);
        movilEncendido.SetActive(true);
        mochilaAbierta.alpha = 0;
        mochilaAbierta.interactable = false;
        mochilaAbierta.blocksRaycasts = false;
    }
}
