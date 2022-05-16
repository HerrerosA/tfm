using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Smartphone : MonoBehaviour
{
    private GameObject chats;
    private GameObject lista_chats;
    private GameObject chat_anonimo;
    private GameObject mapa;
    private GameObject calendario;
    private GameObject portada;
    public string fechaSeleccionada= "";

    System.DateTime myTime =  System.DateTime.Now;
    public TextMeshProUGUI reloj;
    // Start is called before the first frame update
    void Awake()
    {
        portada = GameObject.Find("Home");
        chats = GameObject.Find("Chats");
        lista_chats = GameObject.Find("Lista");
        chat_anonimo = GameObject.Find("Chat_anonimo");
        mapa = GameObject.Find("Maps");
        calendario = GameObject.Find("Calendario");
        chats.SetActive(false);
        lista_chats.SetActive(false);
        chat_anonimo.SetActive(false);
        mapa.SetActive(false);
        calendario.SetActive(false);
        
    }
    void Update()
    {
        myTime =  System.DateTime.Now;
        reloj.text = myTime.ToString("HH:mm");
    }

    
    public void MostrarListaChats(){
        portada.SetActive(false);
        chats.SetActive(true);
        chat_anonimo.SetActive(false);
        lista_chats.SetActive(true);
    }
    public void AbrirChatAnonimo(){
        chat_anonimo.SetActive(true);
        lista_chats.SetActive(false);
    }
    public void AbrirMapa(){
        mapa.SetActive(true);
    }
    public void AbrirCalendario(){
        calendario.SetActive(true);
    }
    public void CogerFechaHora(){
        InputField fecha = GameObject.Find("FechaIntroducir").GetComponent<InputField>();
        InputField hora = GameObject.Find("HoraIntroducir").GetComponent<InputField>();
        fechaSeleccionada = fecha.text + " " + hora.text;
        MostrarPortada();
    }
    
    public void MostrarPortada(){
        portada.SetActive(true);
        chats.SetActive(false);
        lista_chats.SetActive(false);
        chat_anonimo.SetActive(false);
        mapa.SetActive(false);
        calendario.SetActive(false);

    }
    public void Atras(){
        if(chat_anonimo.activeSelf){
            MostrarListaChats();
        }
        else{
            MostrarPortada();
        }
        

    }
}
