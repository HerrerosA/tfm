using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public List<string> capas;
    private ImagenFondo fondoActual;
    private int capaActual;
    private List<int> capasId = new List<int>();
    public Camera cam;
    void Start(){
        fondoActual = GameObject.Find("Fondo").GetComponent<ImagenFondo>();
        foreach (string capa in capas){
            if (capa !=  null){
                capasId.Add(LayerMask.NameToLayer(capa));

            }
        }
    }
    void Update(){
        capaActual = LayerMask.NameToLayer(fondoActual.GetComponent<SpriteRenderer>().sprite.name.ToString());
        if (Input.GetMouseButtonDown(0)){
            Vector2 posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D choque = Physics2D.Raycast(posicion, Vector2.zero, 100);
            if(choque && choque.transform.tag == "Navegacion" && choque.transform.gameObject.layer == capaActual){
                var destino = choque.transform.gameObject.name.ToString();
                fondoActual.FondoActual = destino.Substring(2, destino.Length - 2);
            } 
            if(choque && choque.transform.tag == "Interactivo" && choque.transform.gameObject.layer == capaActual){
                choque.transform.GetComponent<IUsable>().Interactuar(fondoActual);
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
