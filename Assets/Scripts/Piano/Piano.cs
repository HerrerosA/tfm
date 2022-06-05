using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    private Camera camara;
    [SerializeField] private TeclasPiano[] teclas;
    [SerializeField] private AudioSource[] sonidoTeclas;
    public Minijuego minijuego;
    private int correctas = 0;
    private List<int> secuencia;
    private float temporizador = 1;
    private bool resuelto = false;
    void Start()
    {
        camara = Camera.main;
        Reiniciar(-1);
    }

    void Update()
    {
        if(resuelto){
            temporizador -= Time.deltaTime;
            if  (temporizador<=0)
                {
                    minijuego.Resolver();
                    resuelto=false;
                }

        }
        if(Input.GetMouseButtonDown(0)){
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit){
                TeclasPiano estaTecla = hit.transform.GetComponent<TeclasPiano>();
                if(estaTecla != null)
                {
                    PlaySoundKey(estaTecla.numero);
                    if(estaTecla.numero == secuencia[correctas]){
                        if(correctas<secuencia.Count){
                            correctas++;
                        }  
                    }
                    else{
                        Reiniciar(estaTecla.numero);
                    }
                }
            }
            if(correctas==secuencia.Count){
                resuelto=true;
                
                
            }
        }
        
    }

    private void PlaySoundKey(int nota)
    {
        sonidoTeclas[nota-1].Play(0);
    }

    private void Reiniciar(int numero){
        correctas=0;
        secuencia = new List<int>{1,1,5,5,6,6,5,4,4,3,3,2,2,1};
        if (numero == secuencia[0])
        {
            correctas++;
        }
    }
}
