using UnityEngine;

public class Controle1 : MonoBehaviour
{
    public float velocidade = 10;
    public bool inversao = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inversao)
        {
            if ((Input.GetAxisRaw("Vertical") > 0) && (transform.position.y >= -2.92f))
            {
                transform.Translate(0, -velocidade, 0);
            }
            else if ((Input.GetAxisRaw("Vertical") < 0) && (transform.position.y <= 4.9f))
            {
                transform.Translate(0, velocidade, 0);
            }
        }else
        {
            if ((Input.GetAxisRaw("Vertical") > 0) && (transform.position.y <= 4.9f))
            {
                transform.Translate(0, velocidade, 0);
            }
            else if ((Input.GetAxisRaw("Vertical") < 0) && (transform.position.y >= -2.92f))
            {
                transform.Translate(0, -velocidade, 0);
            }
        }
        
    }
}
