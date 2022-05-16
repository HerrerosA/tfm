using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public List<string> capas;
    public List<GameObject> minijuegos;
    private BotonesCanvas botonesCanvas;
    private int capaActual;
    private List<int> capasId = new List<int>();
    public Camera cam;
    void Start(){
        botonesCanvas = GameObject.Find("Canvas").GetComponent<BotonesCanvas>();
        foreach (string capa in capas){
            if (capa !=  null){
                capasId.Add(LayerMask.NameToLayer(capa));
            }
        }
        foreach (GameObject minijuego in minijuegos){
            if(minijuego != null){
                minijuego.SetActive(false);

            }
        }
        
    }
    
    
    void Update(){
        capaActual = LayerMask.NameToLayer(botonesCanvas.fondoActual.GetComponent<SpriteRenderer>().sprite.name.ToString());
        if (Input.GetMouseButtonUp(0)){
            Vector2 posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D choque = Physics2D.Raycast(posicion, Vector2.zero, 100);
            if(choque && choque.transform.tag == "Navegacion" && choque.transform.gameObject.layer == capaActual){
                var destino = choque.transform.gameObject.name.ToString();
                botonesCanvas.fondoActual.FondoActual = destino.Substring(2, destino.Length - 2);
            }
            if(choque && choque.transform.tag == "Interactivo" && choque.transform.gameObject.layer == capaActual){
                choque.transform.GetComponent<IUsable>().Interactuar(botonesCanvas.fondoActual);
            }
            if(choque && choque.transform.tag == "Minijuego" && choque.transform.gameObject.layer == capaActual){
                var nombreminijuego = choque.transform.gameObject.name.ToString();
                foreach (GameObject minijuego in minijuegos){
                    if(minijuego.name == nombreminijuego.Substring(2, nombreminijuego.Length - 2)){
                        botonesCanvas.AbrirMinijuego(minijuego);
                    }
                }
            }
            if(!botonesCanvas.minijuegoEnUso && GameObject.Find("Escenarios")){
                var tipoCapa = GameObject.Find(botonesCanvas.fondoActual.FondoActual).transform.tag;
                if (tipoCapa == "Acercamiento" && !botonesCanvas.mochilaEnUso){
                    botonesCanvas.direccion.SetActive(false);
                }
                else if (tipoCapa != "Acercamiento" && !botonesCanvas.direccion.activeSelf && !botonesCanvas.movilEnUso){
                    botonesCanvas.direccion.SetActive(true);
                }
            }
        }
        MostrarOcultar();
    }
    void MostrarOcultar(){        
        foreach (int id in capasId)
        {
            if (id != capaActual){     
                cam.cullingMask &=  ~(1 << id);
            }
            else{
                cam.cullingMask |= 1 << id;
            }
       }
    }
}
