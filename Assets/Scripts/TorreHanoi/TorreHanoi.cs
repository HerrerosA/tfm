using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreHanoi : MonoBehaviour
{
    private Camera camara;
    public List<DiscoHanoi> discos;
    [SerializeField] private PaloHanoi[] palos;
    public Minijuego minijuego; 
    private Vector3 posicionEspera;
    private DiscoHanoi discoEspera;

    void Start()
    {
        camara = Camera.main;
        posicionEspera = new Vector3(0,1,0);
        discoEspera = null;
        Rellenar();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit){
                PaloHanoi estePalo = hit.transform.GetComponent<PaloHanoi>();
                if(discoEspera){
                    var movido = estePalo.AgregarDisco(discoEspera);
                    if (movido){
                        discoEspera = null;
                    }
                }
                else{
                    discoEspera = estePalo.discos[estePalo.discos.Count - 1];
                    discoEspera.posicionDestino = posicionEspera;
                    estePalo.QuitarDisco();

                }
            }
        }
        int correctas = 0;
        foreach(var a in discos)
        {
            if (a != null){
                if(a.correcto){
                    correctas++;
                }
            }
        }
        if (correctas == discos.Count){
            minijuego.Resolver();
            
        }
        
    }
    public void Rellenar(){
        for(int i = 0; i<palos.Length; i++){
            float posicion = palos[i].transform.position.x;
            for(int j = 0; j<discos.Count; j++){
                if(posicion == discos[j].posicionDestino.x){
                    palos[i].discos.Add(discos[j]);
                }
            }

        }
    }
}
