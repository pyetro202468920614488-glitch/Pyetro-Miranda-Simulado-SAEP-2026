using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour
{

    private Animator animacao;

    void Start()
    {
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanvasGameMng.Instance.estaPausado == true)
        {
            animacao.speed = 0;
        }
        else
        {
            animacao.speed = 1;
        }
    }


    public void PlayDano()
    {
        animacao.SetTrigger("Dano");
    }
}
