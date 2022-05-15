using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoHanoi : MonoBehaviour
{
    public Vector3 posicionDestino;
    private Vector3 posicionCorrecta;
    public int numero;
    public bool correcto;

    void Awake()
    {
        posicionDestino = transform.position;
        posicionCorrecta = new Vector3((transform.position.x)*(-1), transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, posicionDestino, 0.05f);
        
        if(Vector2.Distance(posicionDestino, posicionCorrecta)<0.1){
            correcto = true;
        }
        else{
            correcto = false;
        }
    }
}
