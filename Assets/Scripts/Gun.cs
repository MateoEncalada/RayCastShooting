
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Gun : MonoBehaviour
{

public float damage = 10f;
public float range = 100f;
public Camera fpsCam;
public Transform laserOrigin;
public float laserDuration = 0.05f;
public int contDisparos =0;
LineRenderer laserline;
ContCubos conteo;
ConteoEsferas conteoEsferas;

void Awake()
{
    laserline = GetComponent<LineRenderer>();
    conteo = FindObjectOfType<ContCubos>();
    conteoEsferas = FindObjectOfType<ConteoEsferas>();
}
    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }
    //Queremos que valga .

    void Shoot ()
    {
        laserline.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))   //fpsCam.transform.position,
        {
            Debug.Log(hit.transform.name);
            laserline.SetPosition(1, hit.point);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage); 
                if (hit.transform.CompareTag("Cube"))
            {
                contDisparos++;

                   if (contDisparos>= 2)
                    { 
                            conteo.CubosElim();
                            contDisparos=0;
                    }
            } 
            else if (hit.transform.CompareTag("Sphere")) 
            {
                contDisparos++;
                if (contDisparos>= 3)
                    { 
                            conteoEsferas.EsferaEliminada();
                            contDisparos=0;
                    }
            }             
            } 
            
                     
        }
        else{
                laserline.SetPosition(1, rayOrigin + (fpsCam.transform.forward * range));
            }
            StartCoroutine(ShootLaser());

    }
    IEnumerator ShootLaser()
    {
        laserline.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserline.enabled = false;
    }
}
