using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void __Start()//Запуск игры из главного меню
    {
        SceneManager.LoadScene("Game");
    }
}
