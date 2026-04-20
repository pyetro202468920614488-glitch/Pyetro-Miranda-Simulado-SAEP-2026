using UnityEngine;

public class Playermng : MonoBehaviour
{
    public static Playermng Instance;
    public static MovimentacaoPlayer Movimentacao;
    public static DanoPlayer Dano;
    public static AnimacaoPlayer Animacao;

    private void Awake()
    {
        if(Instance == null)
        {
            Movimentacao = GetComponent<MovimentacaoPlayer>();
            Dano = GetComponent<DanoPlayer>();
            Animacao = GetComponent<AnimacaoPlayer>();
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private AudioSource audioPlayer;


    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void AudioPlayer()
    {
        audioPlayer.Play();
    }

    public void StopAudioPlayer()
    {
        audioPlayer.Stop();
    }
}
