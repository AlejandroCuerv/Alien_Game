using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject balaRafaga;
    [SerializeField] GameObject disparador;

    [SerializeField] float fireRate;

    float minX, maxX, minY, maxY;
    float nextFire = 0;
    float nextRafaga = 0;
    bool cambiarBala = true;

    // Start is called before the first frame update
    void Start()
    {
        
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 puntoMinY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));

        maxX = esquinaSupDer.x - 0.7f;
        maxY = esquinaSupDer.y - 0.7f;
        minX = puntoMinY.x + 0.7f;
        minY = puntoMinY.y + 0.7f;

    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        Disparar();
        if (cambiarBala)
            Disparar();
        else
            DispararRafaga();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            cambiarBala = cambiarBala ? false : true;
        }
    }

    void DispararRafaga()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextRafaga)
        {
            Instantiate(balaRafaga, disparador.transform.position, transform.rotation);
            nextRafaga = Time.time + (fireRate/3);
        }
    }

    void Disparar()
    {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(bala, disparador.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
    void MoverNave()
    {

        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed);
        //acá se mueve
        transform.Translate(movimiento);

        //acá se verifica la posición
        if(transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if(transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        if(transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if(transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }

    }


}
