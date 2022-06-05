using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class Smartphone : MonoBehaviour
{
    public bool NoLeido{
        get { return noLeido; }
        set{
            noLeido = value;
        }
    }
    private GameObject chats;
    private GameObject lista_chats;
    private GameObject chat_anonimo;
    private GameObject chat_mama;
    private GameObject mapa;
    private GameObject telefono;
    private GameObject calendario;
    private GameObject portada;
    private bool noLeido;
    public string fechaSeleccionada= "";
    [SerializeField] public GameObject[] notificaciones;

    System.DateTime myTime =  System.DateTime.Now;
    public TextMeshProUGUI reloj;
    public TextMeshProUGUI fecha;
    public TextMeshProUGUI hora;
    // Start is called before the first frame update
    void Awake()
    {
        portada = GameObject.Find("Home");
        chats = GameObject.Find("Chats");
        lista_chats = GameObject.Find("Lista");
        chat_anonimo = GameObject.Find("Chat_anonimo");
        chat_mama = GameObject.Find("Chat_mama");
        mapa = GameObject.Find("Maps");
        telefono = GameObject.Find("Telefono");
        calendario = GameObject.Find("Calendario");
        chats.SetActive(false);
        lista_chats.SetActive(false);
        chat_anonimo.SetActive(false);
        chat_mama.SetActive(false);
        mapa.SetActive(false);
        telefono.SetActive(false);
        calendario.SetActive(false);
        
    }
    void Update()
    {
        if (fechaSeleccionada==""){
            myTime =  System.DateTime.Now;
            hora.text = myTime.ToString("HH:mm");
            fecha.text = myTime.ToString("D", CultureInfo.CreateSpecificCulture("es-ES"));
        }
        else{
            DateTime fechaHora;
            DateTime.TryParse(fechaSeleccionada, out fechaHora);
            hora.text = fechaHora.ToString("HH:mm");
            fecha.text = fechaHora.ToString("D", CultureInfo.CreateSpecificCulture("es-ES"));
        }
        
        foreach (GameObject notificacion in notificaciones){
            notificacion.SetActive(noLeido);
        }
            
        
    }

    
    public void MostrarListaChats(){
        
        portada.SetActive(false);
        chats.SetActive(true);
        chat_anonimo.SetActive(false);
        chat_mama.SetActive(false);
        lista_chats.SetActive(true);
    }
    public void AbrirChatAnonimo(){
        noLeido = false;
        chat_anonimo.SetActive(true);
        chat_mama.SetActive(false);
        lista_chats.SetActive(false);
    }
    public void AbrirChatMama(){
        chat_anonimo.SetActive(false);
        chat_mama.SetActive(true);
        lista_chats.SetActive(false);
    }
    public void AbrirMapa(){
        mapa.SetActive(true);
    }
    public void AbrirTelefono(){
        telefono.SetActive(true);
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
        chat_mama.SetActive(false);
        mapa.SetActive(false);
        telefono.SetActive(false);
        calendario.SetActive(false);

    }
    public void Atras(){
        if(chat_anonimo.activeSelf || chat_mama.activeSelf){
            MostrarListaChats();
        }
        else{
            MostrarPortada();
        }
        

    }
}
