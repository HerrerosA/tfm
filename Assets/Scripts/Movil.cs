using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Movil : MonoBehaviour
{
    System.DateTime myTime =  System.DateTime.Now;
    public TextMeshProUGUI reloj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTime =  System.DateTime.Now;
        reloj.text = myTime.ToString("HH:mm");
    }
}
