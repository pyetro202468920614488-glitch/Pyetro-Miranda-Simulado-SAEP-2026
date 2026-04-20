using UnityEngine;

public class DetectarLimite : MonoBehaviour
{
    [SerializeField] int idLimite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Limite"))
        {
            Playermng.Movimentacao.AcionarLimite(idLimite);
        }
    }
}
