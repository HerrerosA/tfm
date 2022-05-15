using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaDeslizante : MonoBehaviour
{
    public Vector3 posicionDestino;
    private Vector3 posicionCorrecta;
    public int numero;
    public bool correcto;
    void Awake()
    {
        posicionDestino = transform.position;
        posicionCorrecta = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, posicionDestino, 0.05f);
        if(posicionDestino == posicionCorrecta){
            correcto = true;
        }
        else{
            correcto = false;
        }
        
    }
}
