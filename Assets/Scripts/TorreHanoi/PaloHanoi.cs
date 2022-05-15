using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaloHanoi : MonoBehaviour
{
    public List<DiscoHanoi> discos;
    public void QuitarDisco(){
        discos.RemoveAt(discos.Count - 1);
    }
    public bool AgregarDisco(DiscoHanoi disco){
        if(discos.Count > 0){
            if(discos[discos.Count-1].numero < disco.numero){
                disco.posicionDestino = new Vector3 (gameObject.transform.position.x,discos[discos.Count-1].transform.position.y+0.25f, gameObject.transform.position.z); 
                discos.Add(disco);
                return true;
            }
            else{
                return false;
            }
        }
        else{
            disco.posicionDestino = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y-0.45f, gameObject.transform.position.z); 
            discos.Add(disco);
            return true;
        }
        
        
    }
    void Awake()
    {

        
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}
