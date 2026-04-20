using UnityEngine;

public class MovimentacaoPlayer : MonoBehaviour
{
    private float velocidade = 1;
    private float forca = 3;
    private bool limiteDireita;
    private bool limiteEsquerda;
    private bool limiteCima;
    private bool limiteBaixo;
    private float velocidadeMaxima = 1;
    private bool ativareducaoVelocidade;

    void Start()
    {

    }

    void Update()
    {
        controleVelocidade();
        Movimentar();
    }

    private void Movimentar()
    {
        if (Input.GetKey(KeyCode.A) && limiteEsquerda == false)
        {
            transform.Translate(Vector3.left * velocidade * forca * Time.deltaTime);
            limiteDireita = false;
        }

        if (Input.GetKey(KeyCode.D) && limiteDireita == false)
        {
            transform.Translate(Vector3.right * velocidade * forca * Time.deltaTime);
            limiteEsquerda = false;
        }

        if (Input.GetKey(KeyCode.W) && limiteCima == false)
        {
            transform.Translate(Vector3.up * velocidade * forca * Time.deltaTime);
            limiteBaixo = false;
        }

        if (Input.GetKey(KeyCode.S) && limiteBaixo == false)
        {
            transform.Translate(Vector3.down * velocidade * forca * Time.deltaTime);
            limiteCima = false;
        }


    }

    public void AcionarLimite(int id)
    {
        switch (id)
        {
            case 0:
                limiteDireita = true; break;
            case 1:
                limiteCima = true; break;
            case 2:
                limiteEsquerda = true; break;
            case 3:
                limiteBaixo = true; break;
        }
    }

    private void controleVelocidade()
    {
        if (ativareducaoVelocidade == true)
        {
            diminuirVelocidadePara30Porcento();
        }

        else
        {
            aumentarVelocidadeGradualmente();
        }
    }

    private void aumentarVelocidadeGradualmente()
    {
        if (velocidade < velocidadeMaxima)
        {
            velocidade += Time.deltaTime * 0.5f;
        }

        else
        {
            velocidade = velocidadeMaxima;
        }
    }

    private void diminuirVelocidadePara30Porcento()
    {
        if (velocidade > velocidadeMaxima * 0.3f)
        {
            velocidade -= Time.deltaTime * 0.5f;
        }

        else
        {
            velocidade = velocidadeMaxima * 0.3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Acostamento"))
        {
            ativareducaoVelocidade = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Acostamento"))
        {
            ativareducaoVelocidade = false;
        }
    }

    public void ZerarVelocidade()
    {
        velocidade = 0;
    }

}
