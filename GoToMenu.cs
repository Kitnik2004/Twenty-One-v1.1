using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public void GoBack()//Вернуться в меню из игры или правил
    {
        SceneManager.LoadScene("Menu");
    }
}
