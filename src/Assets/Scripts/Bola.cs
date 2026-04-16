using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    public int velocidade = 1;
    int ponto_jogador_2 = 0;
    int ponto_jogador_1 = 0;
    public TMP_Text textoPlayer1;
    public TMP_Text textoPlayer2;
    public Camera cameraPrincipal;
    public Controle1 scriptExterno;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scriptExterno = FindAnyObjectByType<Controle1>();
        if((ponto_jogador_1>3)||(ponto_jogador_2>3))
        {
            SceneManager.LoadScene("GameOver");
        }
        textoPlayer1.SetText(ponto_jogador_1.ToString());
        textoPlayer2.SetText(ponto_jogador_2.ToString());
        Debug.Log("Ponto Jogador 2: "+ponto_jogador_2);
        Debug.Log("Ponto Jogador 1: " + ponto_jogador_1);
        transform.position = new Vector3(-0.22f, 0, 3);
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2);
        if(y==0)
        {
            y = -1;
        }else
        {
            y = 1;
        }
        GetComponent<Rigidbody>().linearVelocity = new Vector2(velocidade * x, velocidade * y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision batida)
    {
        if(batida.gameObject.name=="Esquerda")
        {
            //Debug.Log("Passei aqui!");
            ponto_jogador_2++;
            //ponto_jogador_2=ponto_jogador_2+1;
            Start();
        }else if(batida.gameObject.name=="Direita")
        {
            ponto_jogador_1++;
            Start();
        }else if(batida.gameObject.name=="Power1")
        {
            Destroy(batida.gameObject);
            int teste = Random.Range(1, 3);
            int tempo = Random.Range(1, 6);
            if (teste==1)
            {
              cameraPrincipal.transform.Rotate(0, 0, 180);
              StartCoroutine(Retorno(tempo));
            }
            else
            {
                scriptExterno.inversao = true;
                StartCoroutine(Direcao(tempo));
            }
            
        }
    }

    private void OnTriggerEnter(Collider toque)
    {
        if (toque.gameObject.name == "Power2")
        {
            toque.gameObject.SetActive(false);
        }

    }

    IEnumerator Retorno(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        cameraPrincipal.transform.Rotate(0, 0, 180);
    }

    IEnumerator Direcao(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        scriptExterno.inversao = false;

    }
}
