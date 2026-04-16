using UnityEngine;

public class Controle2 : MonoBehaviour
{
    public float velocidade = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxisRaw("Vertical2")>0)&&(transform.position.y<=4.9f))
        {
            transform.Translate(0, velocidade, 0);
        }else if ((Input.GetAxisRaw("Vertical2") < 0)&&(transform.position.y>=-2.92f))
        {
            transform.Translate(0, -velocidade, 0);
        }
    }
}
