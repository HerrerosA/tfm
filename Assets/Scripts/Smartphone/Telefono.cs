using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Telefono : MonoBehaviour
{

    [Header("UI Teléfono")] 
    [SerializeField] private TextMeshProUGUI numeroTelefonoText;
    [SerializeField] private Button[] numerosTelefono;
    [SerializeField] private Button llamarTelefono;
    [SerializeField] private Button borrarSecuenciaActual;
    [Header("Número de teléfono correcto")]
    [SerializeField] private string numeroTelefonoCorrecto;
    [Header("Sonidos")] 
    [SerializeField] private AudioSource sonidoCorrecto;
    [SerializeField] private AudioSource sonidoErroneo;
    
    private string secuenciaActual;
    private int cantidadNumerosPulsados;
    private bool llamadaEnCurso = false;
    private float temporizadorLlamada = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i< numerosTelefono.Length; i++)
        {
            var i1 = i;
            numerosTelefono[i].onClick.AddListener(() => NumeroPulsado(i1));
        }
        
        llamarTelefono.onClick.AddListener(LlamarPulsado);
        borrarSecuenciaActual.onClick.AddListener(BorrarSecuenciaPulsado);
    }

    private void Update()
    {
        if (!llamadaEnCurso) return;
        temporizadorLlamada += Time.deltaTime;
        numeroTelefonoText.text = "00:"+((int)temporizadorLlamada).ToString("00");
    }
    private void BorrarSecuenciaPulsado()
    {
        if (llamadaEnCurso) return;
        ResetearSecuencia();
    }

    private void LlamarPulsado()
    {
        if (llamadaEnCurso) return;
        
        StartCoroutine (LlamadaCoroutine());
    }

    private void NumeroPulsado(int numeroInt)
    {
        if (llamadaEnCurso) return;
        if (cantidadNumerosPulsados >= 9) return;
        
        cantidadNumerosPulsados++;
        secuenciaActual += numeroInt;
  
        numeroTelefonoText.text = secuenciaActual;
    }

    IEnumerator LlamadaCoroutine()
    {
        llamadaEnCurso = true;

        if (String.Equals(numeroTelefonoCorrecto, secuenciaActual))
        {
            sonidoCorrecto.Play(0);
            yield return new WaitWhile (()=> sonidoCorrecto.isPlaying);
        }
        else
        {
            sonidoErroneo.Play(0);
            yield return new WaitWhile (()=> sonidoErroneo.isPlaying);
        }
        
        llamadaEnCurso = false;
        
        ResetearSecuencia();
    }

    private void ResetearSecuencia()
    {
        cantidadNumerosPulsados = 0;
        temporizadorLlamada = 0;
        secuenciaActual = "";
        numeroTelefonoText.text = secuenciaActual;
    }
}
