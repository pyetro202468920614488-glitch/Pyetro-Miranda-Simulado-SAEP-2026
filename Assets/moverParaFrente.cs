using UnityEngine;

public class moverParaFrente : MonoBehaviour
{

    [SerializeField] float velocidade;

   
    void Update()
    {
        if (CanvasGameMng.Instance.estaPausado == true) return;
        gameObject.transform.position = velocidade * Vector3.up * Time.deltaTime;
    }
}
