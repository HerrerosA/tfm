using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChatAnonimo : MonoBehaviour
{
    [SerializeField] public GameObject[] botones; 
    public GameObject opcionElegida;
    public GameObject respuesta;
    // Start is called before the first frame update
    void Start()
    {
        opcionElegida.SetActive(false);
        respuesta.SetActive(false);
    }

    public void PulsarRespuesta(TextMeshProUGUI texto){
        opcionElegida.SetActive(true);
        opcionElegida.transform.Find("Texto").GetComponent<TextMeshProUGUI>().text= texto.text; 
        for(int i =0; i<botones.Length; i++){
            botones[i].SetActive(false);
        }
    }
    public void MostrarRespuestaNueva(){
        StartCoroutine(nuevaRespuesta());
    }
    IEnumerator nuevaRespuesta(){
        yield return new WaitForSeconds(3f);
        respuesta.SetActive(true);

    }
}
