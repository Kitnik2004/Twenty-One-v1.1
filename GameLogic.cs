using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    int PlayerScores = 0;   //очки игрока
    int BotScores = 0;      //очки бота
    int[] Cards = new int[11] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };    //колода
    List<int> BotCards = new List<int>();   //колода у бота (для вскрытия карт)
    int CardOnTheFloorPlayer = 0;   //Кол-во карт игрока на столе
    int CardOnTheFloorBot = 0;      //Кол-во карт бота на столе
    int CardOnTheFloor = 0;         //Кол-во карт на столе
    bool isWinPlayer = false;       //Выигрыш игрока при 21
    bool isWinBot = false;          //Выигрыш бота при 21
    bool EndGame = false;           //Конец игры при 21
    bool isNotEnable = true;        //Доступность карты в колоде
    bool isBotEnded = false;        //Бот закончил
    public GameObject Card1;        //Туз
    public GameObject Card2;        //2
    public GameObject Card3;        //3
    public GameObject Card4;        //4
    public GameObject Card5;        //5
    public GameObject Card6;        //6
    public GameObject Card7;        //7
    public GameObject Card8;        //8
    public GameObject Card9;        //9
    public GameObject Card10;       //10
    public GameObject Card11;       //Валет
    public GameObject Card0;        //Рубашка карты
    private int tempCard;           //Временная карта 
    public Transform CanvasPlayer;  //Игровое поле
    private GameObject __Text;      //Объект текста очков игрока
    private TextMeshProUGUI Scores; //Текст очков игрока
    private GameObject Buttons;     //Кнопки "Взять ещё" и "Хватит"
    private GameObject __TextBot;   //Объект текста очков бота
    private TextMeshProUGUI ScoresBot;  //Текст очков бота
    private GameObject __TextWin;   //Объект текста объявления победителя
    private TextMeshProUGUI Winner; //Текст объявления победителя


    private int PlayerTakeCard()//Выбор карты игрока
    {
        int Card = 0;//Объявление карты
        while (isNotEnable && (CardOnTheFloorPlayer <= 10))//Пока цикл включён и количество карт игрока меньше либо равно 10
        {
            int Position = Random.Range(0, Cards.Length);//Рандомный выбор карты
            if (Cards[Position] != 0)//Если эта карта не равна 0
            {
                Card = Cards[Position];//Запись карты
                Cards[Position] = 0;//Убираем карту с колоды
                isNotEnable = false;//Отключаем цикл
            }

        }
        if (!isNotEnable)//После цикла включаем 
        {
            isNotEnable = true;//Включение
        }
        PlayerScores += Card;//Прибавляем очки игроку
        CardOnTheFloor++;//+1 карта на столе
        CardOnTheFloorPlayer++;//+1 карта игрока на столе
        return Card;//Вывод карты в другую функцию (95 строка)
    }
    private int BotTakeCard()//Выбор карты бота
    {
        int Card = 0;//Объявление карты
        while (isNotEnable)//Пока цикл включён
        {
            int Position = Random.Range(0, Cards.Length);//Рандомный выбор карты
            if (Cards[Position] != 0)//Если эта карта не равна 0
            {
                Card = Cards[Position];//Запись карты
                Cards[Position] = 0;//Убираем карту с колоды
                isNotEnable = false;//Отключаем цикл
            }
        }
        if (!isNotEnable)//После цикла включаем
        {
            isNotEnable = true;//Включение
        }
        BotScores += Card;//Прибавляем очки боту
        CardOnTheFloor++;//+1 карта на столе
        BotCards.Add(Card);//Добавляем карту бота в список для вскрытия в конце
        CardOnTheFloorBot++;//+1 карта бота на столе
        return Card;//Вывод карты в другую функцию(178 строка)
    }
    public void TakeCardOnTheFloorPlayer()//Положить карту игрока на стол (привязана к кнопке)
    {
        if (!EndGame)//Если игрок ещё не закончил набор карт
        {
            tempCard = PlayerTakeCard();//Выбор карты
            switch (tempCard)
            {
                case 1:
                    {
                        Instantiate(Card1, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 2:
                    {
                        Instantiate(Card2, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 3:
                    {
                        Instantiate(Card3, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 4:
                    {
                        Instantiate(Card4, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 5:
                    {
                        Instantiate(Card5, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 6:
                    {
                        Instantiate(Card6, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 7:
                    {
                        Instantiate(Card7, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 8:
                    {
                        Instantiate(Card8, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 9:
                    {
                        Instantiate(Card9, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 10:
                    {
                        Instantiate(Card10, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 11:
                    {
                        Instantiate(Card11, new Vector3(300 + (CardOnTheFloorPlayer * 150), 240, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }//Карта кладётся на стол
            tempCard = 0;//Временная карта 
            Scores.SetText($"{PlayerScores}/21");//Обновление счётчика очков
            if (PlayerScores == 21)//Если набрал 21
            {
                isWinPlayer = true;//Победа игрока
                EndGame = true;//Конец выбора игрока
                StopMoving();//Переход к концу игры
            }
            if (PlayerScores > 21)//Если перебор
            {
                StopMoving();//Переход к концу игры
            }
        }
    }
    public void TakeCardOnTheFloorBot()//Положить карту бота на стол (привязана к кнопке)
    {
        tempCard = BotTakeCard();//Выбор карты
        if (CardOnTheFloorBot == 1)//Первая карта кладётся рубашкой вниз
        {
            switch (tempCard)
            {
                case 1:
                    {
                        Instantiate(Card1, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 2:
                    {
                        Instantiate(Card2, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 3:
                    {
                        Instantiate(Card3, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 4:
                    {
                        Instantiate(Card4, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 5:
                    {
                        Instantiate(Card5, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 6:
                    {
                        Instantiate(Card6, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 7:
                    {
                        Instantiate(Card7, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 8:
                    {
                        Instantiate(Card8, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 9:
                    {
                        Instantiate(Card9, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 10:
                    {
                        Instantiate(Card10, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 11:
                    {
                        Instantiate(Card11, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }//Карта кладётся на стол
        }
        else//Остальные рубашкой вверх
        {
            Instantiate(Card0, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
        }
        tempCard = 0;//Обнуление временной карты
    }
    public void StopMoving()//Игрок закончил ход
    {
        Buttons.SetActive(false);//Выключение кнопок "Взять ещё" и "Хватит"
        BotAIStarting();//Включение бота
    }
    private void BotAIStarting()//Запуск бота
    {
        while (BotScores < 18)//Пока сумма очков меньше 18
        {
            TakeCardOnTheFloorBot();//Берёт карту
        }
        isBotEnded = true;//Бот закончил
        if (BotScores == 21)//Если набрал 21
        {
            isWinBot = true;//Бот выиграл
            EndGame = true;//Конец игры
        }
        ShowBotCards();//Вскрыть карты бота
        ScoresBot.text = $"{BotScores}/21";//Показать счёт бота
        Ending();//Перейти к финалу
    }
    private void ShowBotCards()//Показать карты бота
    {
        CardOnTheFloorBot = 1;
        for (int i = 0; i < BotCards.Count; i++)//Перебор карт бота
        {
            int tempCard = BotCards[i];//Временная карта для её открытия
            switch (tempCard)
            {
                case 1:
                    {
                        Instantiate(Card1, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 2:
                    {
                        Instantiate(Card2, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 3:
                    {
                        Instantiate(Card3, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 4:
                    {
                        Instantiate(Card4, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 5:
                    {
                        Instantiate(Card5, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 6:
                    {
                        Instantiate(Card6, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 7:
                    {
                        Instantiate(Card7, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 8:
                    {
                        Instantiate(Card8, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 9:
                    {
                        Instantiate(Card9, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 10:
                    {
                        Instantiate(Card10, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                case 11:
                    {
                        Instantiate(Card11, new Vector3(300 + (CardOnTheFloorBot * 150), 840, 0), Quaternion.identity, CanvasPlayer);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }//Открытие карты
            CardOnTheFloorBot++;//+1 карта на столе бота
        }
    }
    private void Ending()//Финал
    {
        if (EndGame) //Если кто-то набрал 21
        {
            if (isWinPlayer)//Игрок
            {
                Winner.text = "Вы выиграли!";
            }
            else if (isWinBot)//Бот
            {
                Winner.text = "Вы проиграли";
            }
        }
        else //Если ни у кого нет 21
        {
            if (PlayerScores > 21  && BotScores > 21) //Если у обоих перебор
            {
                Winner.text = "Ничья";
            }
            else if (BotScores > 21 && PlayerScores < 21)//Если у бота перебор а у игрока нет
            {
                Winner.text = "Вы выиграли!";
            } 
            else if (PlayerScores > 21 && BotScores < 21)//Если у игрока перебор а у бота нет
            {
                Winner.text = "Вы проиграли!";
            }
            else //Если ни у кого нет перебора
            {
                if (PlayerScores > BotScores)//Если у обоих нет перебора, но у игрока больше очков
                {
                    Winner.text = "Вы выиграли!";
                }
                else if (PlayerScores < BotScores)//Если у обоих нет перебора, но у бота больше очков
                {
                    Winner.text = "Вы проиграли!";
                }
                else 
                { 
                    Winner.text = "Ничья"; 
                }
            }
        }
    }
    public void Start()//Выполнение кода при запуске сцены
    {
        __Text = GameObject.Find("Scores");//Поиск объекта текста очков игрока
        Scores = __Text.GetComponent<TextMeshProUGUI>();//Получение компонента текста очков игрока
        __TextBot = GameObject.Find("ScoresBot");//Поиск объекта текста очков бота
        ScoresBot = __TextBot.GetComponent<TextMeshProUGUI>();//Получение компонента текста очков бота
        Buttons = GameObject.Find("Buttons");//Поиск объекта кнопок
        __TextWin = GameObject.Find("WhoWin");//Поиск объекта текста победителя
        Winner = __TextWin.GetComponent<TextMeshProUGUI>();//Получение компонента текста победителя
        TakeCardOnTheFloorPlayer();//Первая карта игрока
        TakeCardOnTheFloorPlayer();//Вторая карта игрока
        TakeCardOnTheFloorBot();//Первая карта бота
        TakeCardOnTheFloorBot();//Вторая карта бота
    }
    public void RestartGame()//Перезапуск сцены (привязана к кнопке)
    {
        SceneManager.LoadScene("Game");//Загрузка этой же сцены
    }
}