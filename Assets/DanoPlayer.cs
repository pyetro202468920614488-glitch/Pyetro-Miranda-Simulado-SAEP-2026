using System.Collections;
using UnityEngine;

public class DanoPlayer : MonoBehaviour
{

    [SerializeField] GameObject efeitoDano;
    [SerializeField] GameObject efeitoMorte;
    private bool imunidade;


    void Start()
    {
        imunidade = false;
    }
    void Update()
    {

    }


    private IEnumerator TempoImunidadePlayer()
    {
        yield return new WaitForSeconds(3f);
        imunidade = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstaculo"))
        {
            if (!imunidade == true) return;
            imunidade = true;
            CanvasGameMng.Instance.AtualizarVidaPlayer(25);
            Playermng.Animacao.PlayDano();
            Playermng.Movimentacao.ZerarVelocidade();
            efeitoDano.SetActive(true);


            Destroy(collision.gameObject);
            StartCoroutine(TempoImunidadePlayer());
        }

        
    }






}
