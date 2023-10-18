using System;

class Program
{
  static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //поле
                                                                         
  static char currentPlayer = 'X'; //начинает игрок 'X'

  static void Main()
  {
    bool shouldExit = false;
    do
    {
      Console.Clear();
      Console.WriteLine("Добро пожаловать в игру Крестики-нолики!");
      InitializeBoard(); // Добавляем инициализацию игрового поля
      int menuChoice = DisplayMainMenu();
      switch (menuChoice)
      {
        case 1:
          PlayGame();
          break;
        case 2:
          DisplayRules();
          break;
        case 3:
          shouldExit = true;
          break;
        default:
          Console.WriteLine("Недопустимый выбор. Попробуйте еще раз.");
          break;
      }
    } while (!shouldExit);
  }

  static void InitializeBoard()
  {
    board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
  }

  static int DisplayMainMenu()
  {
    Console.WriteLine("Главное меню:");
    Console.WriteLine("1. Начать игру");
    Console.WriteLine("2. Прочитать правила");
    Console.WriteLine("3. Выйти");
    int choice;
    while (true)
    {
      Console.Write("Выберите вариант (1-3): ");
      // Считываем выбор пользователя и проверяем его на валидность
      if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
      {
        return choice;
      }
      else
      {
        // Если выбор недопустим, выводим сообщение
        Console.WriteLine("Недопустимый выбор. Попробуйте еще раз.");
      }
    }
  }

  static void DisplayRules()
  {
    // Выводим правила игры на экран
    Console.WriteLine("Правила игры:");
    Console.WriteLine("Игроки ходят по очереди.");
    Console.WriteLine("Для совершения хода введите номер ячейки (1-9).");
    Console.WriteLine("Цель - собрать три своих символа в ряд по горизонтали, вертикали или диагонали.");
    Console.WriteLine("Если все ячейки заполняются, и победителя не выявлено, игра объявляется ничьей.");
    Console.WriteLine("Удачи!");
    Console.WriteLine("Нажмите Enter, чтобы вернуться в главное меню.");
    Console.ReadLine();
  }

  static void PlayGame()
  {
    bool gameOver = false;
    int moves = 0;
    do
    {
      Console.Clear();
      DisplayBoard();
      int choice;
      bool validInput;

      do
      {
        Console.Write($"Игрок {currentPlayer}, введите номер ячейки (1-9): ");
        validInput = int.TryParse(Console.ReadLine(), out choice);

        if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
        
        {
          Console.WriteLine("Недопустимый ход. Попробуйте еще раз.");
          validInput = false;
        }
      } while (!validInput);

      // yстанавливаем символ текущего игрока в выбранную ячейку
      board[choice - 1] = currentPlayer;
      moves++;
      if (CheckForWin())
      {
        Console.Clear();
        DisplayBoard();
        Console.WriteLine($"Игрок {currentPlayer} выиграл!");
        gameOver = true;
      }
      else if (moves == 9)
      {
        Console.Clear();
        DisplayBoard();
        Console.WriteLine("Ничья!");
        gameOver = true;
      }
      else
      {
        // Переключаем текущего игрока на следующего
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
      }
    } 
    while (!gameOver);
    Console.Write("Нажмите Enter, чтобы вернуться в главное меню...");
    Console.ReadLine();
  }

  static void DisplayBoard()
  {
    Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
  }

  static bool CheckForWin()
  {
    return (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) ||
           (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) ||
           (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) ||
           (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) ||
           (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
           (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
           (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
           (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer);
  }
}
//крестики нолики две миланы в домике