using System.Diagnostics;
using task.Properties;

namespace task;

public partial class Form1 : Form
{
    /// <summary>
    ///     Написать игру «Крестики-нолики», учитывая следующие требования:
    ///     * игровое поле размером 3х3 должно состоять из кнопок;
    ///     * при нажатии на кнопку, на ней должна отобразиться картинка (крестик или
    ///     нолик);
    ///     * необходимо предотвращать попытку поставить крестик или нолик на занятую
    ///     клетку;
    ///     * предоставить пользователю право выбора первого хода, используя флажок;
    ///     * предусмотреть возможность выбора уровня сложности, используя
    ///     переключатели;
    ///     * предусмотреть кнопку «Начать новую игру».
    /// </summary>

    // Ссылка на метод с логикой по игре.
    private readonly Tic_tac_toe_game _game;

    public Form1()
    {
        InitializeComponent();

        // Перед игрой отключаем поле с кнопками.
        // Будет включено только после нажатия кнопки "Начать игру".
        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = false;
        button4.Enabled = false;
        button5.Enabled = false;
        button6.Enabled = false;
        button7.Enabled = false;
        button8.Enabled = false;
        button9.Enabled = false;
        _game = new Tic_tac_toe_game();
    }

    // Обработчик нажатий кнопок на игровом поле.
    private void gameFieldsButtons_Click(object sender, EventArgs e)
    {
        // когда выставлять метку игрока в ячейку ?
        // Отправляем кнопку на конвертацию в координаты массива.
        _game.PlayerPointToMove = _game.ConvertButtonToCoordinates((Button)sender);

        if (_game.UserMoveCheck())
        {
            // Если пользователь ходит крестиками, установить на кнопку картинку крестика.
            if (_game.UserLetter == 'X')
                // Установить на кнопку из ресурсов крестик.
                ((Button)sender).Image = Resources.cross;
            else
                // Установить на кнопку из ресурсов нолик.
                ((Button)sender).Image = Resources._null;
        }

        _game.OneStep();
        ShowComputerMove();
    }

    // Отрисовать ход компьютера.
    private void ShowComputerMove()
    {
        for (var i = 0; i < 3; i++)
        for (var j = 0; j < 3; j++)
            if (_game[i, j] == _game.PcLetter)
                // Перебираем все кнопки на форме.
                foreach (Control c in Controls)
                    // Если нашли кнопку, то проверяем её координаты.
                    if (c is Button)
                        // Если координаты кнопки совпадают с координатами массива, то устанавливаем на неё картинку.
                        if (_game.ConvertArrCoordinatesToButtonName(i, j) == ((Button)c).Name &&
                            ((Button)c).Image == null)
                        {
                            if (_game.PcLetter == 'X')
                            {
                                // Установить на кнопку из ресурсов крестик.
                                ((Button)c).Image = Resources.cross;
                                if (_game.WinCheck == 0) // Победа компьютера.
                                {
                                    MessageBox.Show("Компьютер победил.", "Игра «Крестики-нолики».",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _game.AskPlayMore();
                                }
                                else if (_game.WinCheck == 2) // Ничья.
                                {
                                    _game.Draw();
                                    _game.AskPlayMore();
                                }
                                else if (_game.WinCheck == 3) // Продолжаем играть.
                                {
                                    return;
                                }
                            }
                            else
                            {
                                // Установить на кнопку из ресурсов нолик.
                                ((Button)c).Image = Resources._null;
                                if (_game.WinCheck == 0) // Победа компьютера.
                                {
                                    MessageBox.Show("Компьютер победил.", "Игра «Крестики-нолики».",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _game.AskPlayMore();
                                }
                                else if (_game.WinCheck == 2) // Ничья.
                                {
                                    _game.Draw();
                                    _game.AskPlayMore();
                                }
                                else if (_game.WinCheck == 3) // Продолжаем играть.
                                {
                                    return;
                                }
                            }
                        }
    }

    // Обработчик нажатия на ссылку "Правила игры в «Крестики-нолики»."
    private void RulesOfTheGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        // Запуск браузера с заданным адресом.
        var procInfo = new ProcessStartInfo(@"chrome.exe");
        procInfo.UseShellExecute = true;
        procInfo.Arguments =
            "https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B5%D1%81%D1%82%D0%B8%D0%BA%D0%B8-%D0%BD%D0%BE%D0%BB%D0%B8%D0%BA%D0%B8#%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0_%D0%B8%D0%B3%D1%80%D1%8B";
        Process.Start(procInfo);
    }

    // Обработчик нажатия на кнопку "Начать новую игру".
    private void StartNewGame_button10_Click(object sender, EventArgs e)
    {
        // Проверяем заполнены ли все поля для игры.
        // "Кто будет ходить первым ?".
        if ((FirstMoveComputer.Checked == false && FirstMovePlayer.Checked == false) ||
            (FirstMoveComputer.Checked && FirstMovePlayer.Checked))
        {
            MessageBox.Show("Выберите кто будет ходить первым !", "Ошибка !", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        if (FirstMoveComputer.Checked)
            _game.WhoMove = 0; // Компьютер ходит первым.
        else
            _game.WhoMove = 1; // Игрок ходит первым.

        // Выберите чем будете играть !.
        if ((PlayCrosses.Checked == false && PlayZeroes.Checked == false) ||
            (PlayCrosses.Checked && PlayZeroes.Checked))
        {
            MessageBox.Show("Выберите чем будете играть !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        } // Выставление символов игры для игрока и компьютера.

        if (PlayCrosses.Checked)
        {
            _game.UserLetter = 'X'; // Игрок использует крестики.
            _game.PcLetter = '0'; // Компьютер использует нолики.
        }
        else
        {
            _game.UserLetter = '0'; // Игрок использует нолики.
            _game.PcLetter = 'X'; // Компьютер использует крестики.
        }

        // Выберите уровень сложности !.
        if ((LevelOfDifficulty_Easy.Checked == false && LevelOfDifficulty_Normal.Checked == false &&
             LevelOfDifficulty_Hard.Checked == false) ||
            (LevelOfDifficulty_Easy.Checked && LevelOfDifficulty_Normal.Checked) ||
            (LevelOfDifficulty_Easy.Checked && LevelOfDifficulty_Hard.Checked) ||
            (LevelOfDifficulty_Normal.Checked && LevelOfDifficulty_Hard.Checked) ||
            (LevelOfDifficulty_Normal.Checked && LevelOfDifficulty_Easy.Checked))
        {
            MessageBox.Show("Выберите уровень сложности !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Выставление уровня сложности.
        if (LevelOfDifficulty_Easy.Checked)
            _game.GameDifficulty = 1;
        else if (LevelOfDifficulty_Normal.Checked)
            _game.GameDifficulty = 2;
        else if (LevelOfDifficulty_Hard.Checked)
            _game.GameDifficulty = 3;

        // Если все поля для начала игры заполнены, то включаем игровое поле из кнопок.
        button1.Enabled = true;
        button2.Enabled = true;
        button3.Enabled = true;
        button4.Enabled = true;
        button5.Enabled = true;
        button6.Enabled = true;
        button7.Enabled = true;
        button8.Enabled = true;
        button9.Enabled = true;

        // Блокировка лишнего интерфейса.
        StartNewGame_button10.Enabled = false;
        FirstMoveComputer.Enabled = false;
        FirstMovePlayer.Enabled = false;
        PlayCrosses.Enabled = false;
        PlayZeroes.Enabled = false;
        LevelOfDifficulty_Easy.Enabled = false;
        LevelOfDifficulty_Normal.Enabled = false;
        LevelOfDifficulty_Hard.Enabled = false;

        // Если выбрано, что компьютер ходит первым, то вызываем метод хода компьютера.
        if (FirstMoveComputer.Checked)
        {
            _game.PcMove();
            ShowComputerMove();
        }
    }
}

// Класс реализующий логику игры с компьютером.
public class Tic_tac_toe_game
{
    // Проверка на победимтеля.
    private int _winCheck;

    // Массив игрового поля.
    private readonly char[,] arr;

    // Конструктор.
    public Tic_tac_toe_game()
    {
        arr = new[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        GameDifficulty = 0;
        UserLetter = '3';
        PcLetter = '3';
        WhoMove = -1;
        TotalMovesInGame = 9;
        _winCheck = -1;
        PlayerPointToMove = new Point(-1, -1);
    }

    public char this[int i, int j]
    {
        get => arr[i, j];
        set => arr[i, j] = value;
    }

    // Уровень сложности выбранный игроком на форме.
    public int GameDifficulty { get; set; }

    // Символ для игры игрока.
    public char UserLetter { get; set; }

    // Символ для игры компьютера.
    public char PcLetter { get; set; }

    // Кто будет ходить ?
    public int WhoMove { get; set; }

    // Общее количество ходов в игре.
    public int TotalMovesInGame { get; set; }

    public int WinCheck
    {
        get
        {
            _winCheck = WinCheckMethod();
            return _winCheck;
        }
        set => _winCheck = value;
    }

    // Координаты хода пользователя на массиве.
    public Point PlayerPointToMove { get; set; }

    // Метод преобразования координат массива в имя кнопоки. Для выставления игрового знака компьютера.
    public string ConvertArrCoordinatesToButtonName(int x, int y)
    {
        if (x == 0 && y == 0)
            return "button1";
        if (x == 0 && y == 1)
            return "button2";
        if (x == 0 && y == 2)
            return "button3";
        if (x == 1 && y == 0)
            return "button4";
        if (x == 1 && y == 1)
            return "button5";
        if (x == 1 && y == 2)
            return "button6";
        if (x == 2 && y == 0)
            return "button7";
        if (x == 2 && y == 1)
            return "button8";
        return "button9";
    }

    // Метод преобразования нажатых кнопок в координаты массива.
    public Point ConvertButtonToCoordinates(Button button)
    {
        var coordinates = new Point();

        if (button.Name == "button1")
        {
            coordinates.X = 0;
            coordinates.Y = 0;
        }
        else if (button.Name == "button2")
        {
            coordinates.X = 0;
            coordinates.Y = 1;
        }
        else if (button.Name == "button3")
        {
            coordinates.X = 0;
            coordinates.Y = 2;
        }
        else if (button.Name == "button4")
        {
            coordinates.X = 1;
            coordinates.Y = 0;
        }
        else if (button.Name == "button5")
        {
            coordinates.X = 1;
            coordinates.Y = 1;
        }
        else if (button.Name == "button6")
        {
            coordinates.X = 1;
            coordinates.Y = 2;
        }
        else if (button.Name == "button7")
        {
            coordinates.X = 2;
            coordinates.Y = 0;
        }
        else if (button.Name == "button8")
        {
            coordinates.X = 2;
            coordinates.Y = 1;
        }
        else if (button.Name == "button9")
        {
            coordinates.X = 2;
            coordinates.Y = 2;
        }

        return coordinates;
    }

    // Метод проверки свободной ячейки в матрице под ход игрока.
    public bool UserMoveCheck()
    {
        if (arr[PlayerPointToMove.X, PlayerPointToMove.Y] == ' ')
            return true; // Ход возможен.
        return false; // Ячейка занята, ходить сюда нельзя.
    }

    // Метод обрабатки хода игрока.
    private void UserMove()
    {
        arr[PlayerPointToMove.X, PlayerPointToMove.Y] = UserLetter;
    }

    // Метод проверки победы.
    private int WinCheckMethod()
    {
        if ((arr[0, 0] == UserLetter && arr[0, 1] == UserLetter && arr[0, 2] == UserLetter) || // 1 горизонтальная
            (arr[1, 0] == UserLetter && arr[1, 1] == UserLetter && arr[1, 2] == UserLetter) || // 2 горизонтальная
            (arr[2, 0] == UserLetter && arr[2, 1] == UserLetter && arr[2, 2] == UserLetter) || // 3 горизонтальная
            (arr[0, 0] == UserLetter && arr[1, 0] == UserLetter && arr[2, 0] == UserLetter) || // 1 вертикальная
            (arr[0, 1] == UserLetter && arr[1, 1] == UserLetter && arr[2, 1] == UserLetter) || // 2 вертикальная 
            (arr[0, 2] == UserLetter && arr[1, 2] == UserLetter && arr[2, 2] == UserLetter) || // 3 вертикальная 
            (arr[0, 0] == UserLetter && arr[1, 1] == UserLetter && arr[2, 2] == UserLetter) || // главная диагональ
            (arr[2, 0] == UserLetter && arr[1, 1] == UserLetter && arr[0, 2] == UserLetter)) // второстепенная диагональ
            return 1; // Возвращает при победе игрока.
        if ((arr[0, 0] == PcLetter && arr[0, 1] == PcLetter && arr[0, 2] == PcLetter) || // 1 горизонтальная
            (arr[1, 0] == PcLetter && arr[1, 1] == PcLetter && arr[1, 2] == PcLetter) || // 2 горизонтальная
            (arr[2, 0] == PcLetter && arr[2, 1] == PcLetter && arr[2, 2] == PcLetter) || // 3 горизонтальная
            (arr[0, 0] == PcLetter && arr[1, 0] == PcLetter && arr[2, 0] == PcLetter) || // 1 вертикальная
            (arr[0, 1] == PcLetter && arr[1, 1] == PcLetter && arr[2, 1] == PcLetter) || // 2 вертикальная 
            (arr[0, 2] == PcLetter && arr[1, 2] == PcLetter && arr[2, 2] == PcLetter) || // 3 вертикальная 
            (arr[0, 0] == PcLetter && arr[1, 1] == PcLetter && arr[2, 2] == PcLetter) || // главная диагональ
            (arr[2, 0] == PcLetter && arr[1, 1] == PcLetter && arr[0, 2] == PcLetter)) // второстепенная диагональ
            return 0; // Возвращает при победе компьютера.
        if (TotalMovesInGame == 0)
            return 2; // Возвращает при ничьей.
        return 3;
    }

    // Метод выдает случайные координаты для хода компьютера в свободную ячейку. 
    private void PcRandMove()
    {
        var random = new Random();
        var point = new Point();

        do
        {
            point.X = random.Next(0, 3); // Для броска от 0 до 2.
            point.Y = random.Next(0, 3); // Для броска от 0 до 2.
        } while (arr[point.X, point.Y] != ' ');

        arr[point.X, point.Y] = PcLetter;
    }

    // Логика ходов компьютера.
    private void LogicPcMove()
    {
        var random = new Random();
        var r = random.Next(0, 101);

        if (arr[0, 0] == ' ' && arr[0, 1] == UserLetter && arr[0, 2] == UserLetter) // 1 горизонтальная [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
        }
        else if ((arr[0, 0] == UserLetter && arr[0, 1] == ' ' && arr[0, 2] == UserLetter) ||
                 (arr[0, 0] == PcLetter && arr[0, 1] == ' ' && arr[0, 2] == PcLetter)) // 1 горизонтальная [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[0, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[0, 1] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[0, 1] == UserLetter && arr[0, 2] == ' ') // 1 горизонтальная [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
        }
        else if (arr[1, 0] == ' ' && arr[1, 1] == UserLetter && arr[1, 2] == UserLetter) // 2 горизонтальная [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[1, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[1, 0] = PcLetter;
            }
        }
        else if (arr[1, 0] == UserLetter && arr[1, 1] == ' ' && arr[1, 2] == UserLetter) // 2 горизонтальная [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
        }
        else if (arr[1, 0] == UserLetter && arr[1, 1] == UserLetter && arr[1, 2] == ' ') // 2 горизонтальная [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[1, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[1, 2] = PcLetter;
            }
        }
        else if (arr[2, 0] == ' ' && arr[2, 1] == UserLetter && arr[2, 2] == UserLetter) // 3 горизонтальная [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
        }
        else if (arr[2, 0] == UserLetter && arr[2, 1] == ' ' && arr[2, 2] == UserLetter) // 3 горизонтальная [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[2, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[2, 1] = PcLetter;
            }
        }
        else if (arr[2, 0] == UserLetter && arr[2, 1] == UserLetter && arr[2, 2] == ' ') // 3 горизонтальная [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
        }
        else if (arr[0, 0] == ' ' && arr[1, 0] == UserLetter && arr[2, 0] == UserLetter) // 1 вертикальная [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[1, 0] == ' ' && arr[2, 0] == UserLetter) // 1 вертикальная [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[1, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[1, 0] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[1, 0] == UserLetter && arr[2, 0] == ' ') // 1 вертикальная [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
        }
        else if (arr[0, 1] == ' ' && arr[1, 1] == UserLetter && arr[2, 1] == UserLetter) // 2 вертикальная[_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[0, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[0, 1] = PcLetter;
            }
        }
        else if (arr[0, 1] == UserLetter && arr[1, 1] == ' ' && arr[2, 1] == UserLetter) // 2 вертикальная[*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
        }
        else if (arr[0, 1] == UserLetter && arr[1, 1] == UserLetter && arr[2, 1] == ' ') // 2 вертикальная[**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[2, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[2, 1] = PcLetter;
            }
        }
        else if (arr[0, 2] == ' ' && arr[1, 2] == UserLetter && arr[2, 2] == UserLetter) // 3 вертикальная [_**] 
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
        }
        else if (arr[0, 2] == UserLetter && arr[1, 2] == ' ' && arr[2, 2] == UserLetter) // 3 вертикальная [*_*] 
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[1, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[1, 2] = PcLetter;
            }
        }
        else if (arr[0, 2] == UserLetter && arr[1, 2] == UserLetter && arr[2, 2] == ' ') // 3 вертикальная [**_] 
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
        }
        else if (arr[0, 0] == ' ' && arr[1, 1] == UserLetter && arr[2, 2] == UserLetter) // главная диагональ [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[1, 1] == ' ' && arr[2, 2] == UserLetter) // главная диагональ [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[1, 1] == UserLetter && arr[2, 2] == ' ') // главная диагональ [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
        }
        else if (arr[2, 0] == ' ' && arr[1, 1] == UserLetter && arr[0, 2] == UserLetter) // вторая диагональ [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
        }
        else if (arr[2, 0] == UserLetter && arr[1, 1] == ' ' && arr[0, 2] == UserLetter) // вторая диагональ [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
        }
        else if (arr[2, 0] == UserLetter && arr[1, 1] == UserLetter && arr[0, 2] == ' ') // вторая диагональ [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // Всегда в любую ходит.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // В меньше 50% ходит в любую.
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // В меньше 20% ходит в любую
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
        }
        else
        {
            PcRandMove();
        }
    }

    // Ход компьютера.
    public void PcMove()
    {
        LogicPcMove();
        TotalMovesInGame--;
        WhoMove = 1; // Передача хода игроку.
    }

    // Сообщение об ничьей.
    public void Draw()
    {
        MessageBox.Show("Ничья.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // Один шаг, после нажатия пользователя на кнопку на игровом поле.
    public void OneStep()
    {
        if (WhoMove == 1) // Пользователь.
        {
            if (UserMoveCheck())
            {
                UserMove();
                TotalMovesInGame--;
                if (WinCheck == 1) // Победа игрока.
                {
                    MessageBox.Show("Игрок победил.", "Игра «Крестики-нолики».", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    AskPlayMore();
                }
                else if (WinCheck == 2) // Ничья.
                {
                    Draw();
                    AskPlayMore();
                }
                else if (WinCheck == 3) // Продолжаем играть.
                {
                    PcMove();
                }
            }
            else
            {
                MessageBox.Show("Выберите другую ячейку.", "Игра «Крестики-нолики».", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        if (WhoMove == 0) // Компьютер.
            PcMove();
    }

    // Сыграем еще ?.
    public void AskPlayMore()
    {
        var result = MessageBox.Show("Сыграем еще ?", "Игра «Крестики-нолики».", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (result == DialogResult.No)
            Application.Exit();
        else if (result == DialogResult.Yes)
            Application.Restart();
    }
}