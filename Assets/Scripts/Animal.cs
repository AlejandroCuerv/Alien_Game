using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] bool movRight;
    [SerializeField] int Vidas;
    float minX, maxX;
    float slomo;
    int Hab;
    int Normal;
    [SerializeField] bool Vida;
    

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
        Hab = 1;
        //Normal = Vidas;
    }

    // Update is called once per frame
    void Update()
    {
        if (movRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
       

        if(transform.position.x >= maxX)
        {
            movRight = false;
        }
        else if(transform.position.x <= minX)
        {
            movRight = true;
        }

        //if (Vida)
        //{
            //Vidas = 1;
        //}
        //else
            //Vidas = Normal;

        if (Input.GetKeyDown(KeyCode.X) && Hab <= 3)
        {
            Hab++;
            slomo = Time.time + 2.5f;
            Time.timeScale = 0.5f;
            //Vida = true;
        }

        if (Time.time > slomo)
        {
            Time.timeScale = 1;
            //Vida = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Disparo"))
        {
            Vidas--;
            if (Vidas == 0)
            {
                
                (GameObject.Find("GameManager").GetComponent<GameManager>()).CaptureAnimal();
                Destroy(this.gameObject);
            }
        }
      
    }

}
