using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRaton : MonoBehaviour
{
    [SerializeField] GameObject Redondel;
    Vector2 mouse;
    // Start is called before the first frame update
    void Start()
    {
        Redondel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        Mouse();
        
    }
   void Mouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Redondel.SetActive(true);
            Redondel.transform.position = new Vector3(mouse.x, mouse.y, -2.85f);
        }
        if(Input.GetMouseButtonUp(0)){
            Redondel.SetActive(false);

        }
    }
}
