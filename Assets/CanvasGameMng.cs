using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameMng : MonoBehaviour
{

    public static CanvasGameMng Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    [SerializeField] GameObject[] paineis;

    public bool estaPausado;
    public bool ComecouJogo;

    [Header("Config Player")]
    [SerializeField] Slider sldVidaPlayer;
    private float vidaPlayerMaxima = 150;
    private float vidaPlayerAtual;

    [Header("Config Inimigo")]
    [SerializeField] Slider sldVidaInimigo;
    [SerializeField] TextMeshProUGUI txtDistancia;
    private float vidaInimigoMaxima = 600;
    private float vidaInimigoAtual;

    private void Start()
    {
        ExibirPainel(0);

        estaPausado = false;
        ComecouJogo = true;

        sldVidaPlayer.maxValue = vidaPlayerMaxima;
        sldVidaPlayer.value = vidaPlayerMaxima;
        vidaPlayerAtual = vidaPlayerMaxima;

        sldVidaInimigo.maxValue = vidaInimigoMaxima;
        sldVidaInimigo.value = vidaInimigoMaxima;
        vidaInimigoAtual = vidaInimigoMaxima;

    }

    private void Update()
    {
        if (ComecouJogo == false) return;
        if (Input.GetKeyDown(KeyCode.P))
        {
            estaPausado = !estaPausado;
            if (estaPausado == true)
            {
                ExibirPainel(1);
            }
            else
            {
                ExibirPainel(0);
            }
        }

        //Gerado por IA----------------------
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }

        //a-----------------------------------
    }

    public void ContinuarJogo()
    {
        estaPausado = false;
        ExibirPainel(0);
    }



    public void ExibirPainel(int index)
    {
        foreach (GameObject painel in paineis)
        {
            painel.SetActive(false);
        }

        paineis[index].SetActive(true);
    }

    private void GameOver()
    {
        ExibirPainel(3);

        estaPausado = true;
        ComecouJogo = false;
    }

    public void FimDeJogo()
    {
        ExibirPainel(2);

        estaPausado = true;
        ComecouJogo = false;
    }

    public void AtualizarVidaPlayer(float valorDano)
    {
        vidaPlayerAtual -= valorDano;
        if (vidaPlayerAtual <= 0)
        {
            vidaPlayerAtual = 0;
            GameOver();
        }
        else
        {
            sldVidaPlayer.value = vidaPlayerAtual;
        }
    }
    public void AtualizarVidaInimigo(float Dano)
    {
        vidaInimigoAtual -= Dano;
        if (vidaInimigoAtual <= 0)
        {
            FimDeJogo();
        }
        else
        {
            sldVidaInimigo.value = vidaInimigoAtual;
        }
    }

    //Gerado por IA--------------------------


    private bool isPaused = false;


    void Pause()
    {
        Time.timeScale = 0f; // Congela o jogo
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Volta ao normal
        isPaused = false;
    }
    //---------------------------------------
}
