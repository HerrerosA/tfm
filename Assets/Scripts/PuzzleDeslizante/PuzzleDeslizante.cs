using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDeslizante : MonoBehaviour
{
    [SerializeField] private Transform vacio = null;
    private Camera camara;
    [SerializeField] private PiezaDeslizante[] piezas;
    private int indiceVacio = 15;
    public Minijuego minijuego;
    void Start(){
        camara = Camera.main;
        Remover();
    }
    
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit){
                if(Vector2.Distance(vacio.position, hit.transform.position)<1){
                    Vector2 ultimaPosicionEspacioVacio = vacio.position;
                    PiezaDeslizante estaPieza = hit.transform.GetComponent<PiezaDeslizante>();
                    vacio.position = estaPieza.posicionDestino;
                    estaPieza.posicionDestino = ultimaPosicionEspacioVacio;
                    int indicePieza = buscarIndice(estaPieza);
                    piezas[indiceVacio]= piezas[indicePieza];
                    piezas[indicePieza] = null;
                    indiceVacio = indicePieza;
                }
            }
        }
        int correctas = 0;
        foreach (var a in piezas)
        {
            if (a != null){
                if(a.correcto){
                    correctas++;
                }
            }
        }
        if (correctas == piezas.Length-1){
            minijuego.Resolver();
            
        }
           
        
        
    }
    public void Remover(){
        if (indiceVacio != 15){
            var piezaUltimaposicion = piezas[15].posicionDestino;
            piezas[15].posicionDestino = vacio.position;
            vacio.position = piezaUltimaposicion;
            piezas[indiceVacio] = piezas[15];
            piezas[15] = null;
            indiceVacio = 15;
        }
        int invertido;
        do{
            for (int i = 0; i<=14; i++){
                if(piezas[i]!= null){
                    var ultimaposicion = piezas[i].posicionDestino;
                    int aleatorio = Random.Range(0,14);
                    piezas[i].posicionDestino = piezas[aleatorio].posicionDestino;
                    piezas[aleatorio].posicionDestino = ultimaposicion;
                    var pieza = piezas[i];
                    piezas[i] = piezas[aleatorio];
                    piezas[aleatorio] = pieza;
                }
            }
            invertido = Invertidos();
        }
        while(invertido % 2 != 0);
    }
    public int buscarIndice(PiezaDeslizante p){
        for(int i = 0; i < piezas.Length; i ++){
            if(piezas[i] != null)
            {
                if(piezas[i]== p){
                    return i;
                }
            }
        }
        return -1;
    }
    int Invertidos(){
        int suma = 0;
        for(int i = 0; i<piezas.Length; i++){
            int esteInvertido = 0;
            for(int j=i; j<piezas.Length; j++){
                if(piezas[j]!=null){
                    if(piezas[i].numero > piezas[j].numero){
                        esteInvertido ++;
                    }
                }
            }
            suma+=esteInvertido;
        }
        return suma;
    }


}
