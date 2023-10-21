using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour
{
    private Camera _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Fire();
        }
    }

    private void Fire(){
        //declaracion Objeto Raycast
        RaycastHit myHit;
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(myRay, out myHit)){
            Transform objectHit = myHit.transform; 
            print("object!"+ myHit.transform.name);
            Debug.Log("otra manera de imprimir");
             Vector3 lineOrigin = _mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            Debug.DrawRay(lineOrigin, _mainCamera.transform.forward, Color.green);
        }
            

    }

}