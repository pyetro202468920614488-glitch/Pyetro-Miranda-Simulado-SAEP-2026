using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnJogar : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Game");
    }
}