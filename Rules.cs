using UnityEngine;
using UnityEngine.SceneManagement;

public class Rules : MonoBehaviour
{
    public void RulesMenu()//Перейти на страницу с правилами
    {
        SceneManager.LoadScene("Rules");
    }
}
