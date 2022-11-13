using System.Diagnostics;
using System.Drawing;
using task;
using task.Properties;


namespace task
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Написать игру «Крестики-нолики», учитывая следующие требования: 
        /// * игровое поле размером 3х3 должно состоять из кнопок; 
        /// * при нажатии на кнопку, на ней должна отобразиться картинка (крестик или
        /// нолик); 
        /// * необходимо предотвращать попытку поставить крестик или нолик на занятую
        /// клетку; 
        /// * предоставить пользователю право выбора первого хода, используя флажок; 
        /// * предусмотреть возможность выбора уровня сложности, используя
        /// переключатели; 
        /// * предусмотреть кнопку «Начать новую игру».
        /// </summary>

        private Tic_tac_toe_game _game = null;

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
            Point userMoveInto = _game.ConvertButtonToCoordinates((Button)sender);

            if (_game.UserMoveCheck(userMoveInto))
            {
                // Если пользователь ходит крестиками, установить на кнопку картинку крестика.
                if (_game.UserLetter == 'X')
                    // Установить на кнопку из ресурсов крестик.
                    ((Button)sender).Image = Resources.cross;
                else
                    // Установить на кнопку из ресурсов нолик.
                    ((Button)sender).Image = Resources._null;
            }



            // todo: GameProcess переписать, вынести из него поля в класс тикТакТое и реализовать так чтобы он тут при нажатии походил пользователь и после него сразу компьютер.

            // Начало игрового процесса.
            _game.GameProcess(userMoveInto);
        }

        // Обработчик нажатия на ссылку "Правила игры в «Крестики-нолики»."
        private void RulesOfTheGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Запуск браузера с заданным адресом.
            ProcessStartInfo procInfo = new ProcessStartInfo(@"chrome.exe");
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
            if (FirstMoveComputer.Checked == false && FirstMovePlayer.Checked == false)
            {
                MessageBox.Show("Выберите кто будет ходить первым !", "Ошибка !", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else // 
            {
                if (FirstMoveComputer.Checked == true)
                    _game.WhoMove = 0; // Компьютер ходит первым.
                else
                    _game.WhoMove = 1; // Игрок ходит первым.
            }

            // Выберите чем будете играть !.
            if (PlayCrosses.Checked == false && PlayZeroes.Checked == false)
            {
                MessageBox.Show("Выберите чем будете играть !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // Выставление символов игры для игрока и компьютера.
            else
            {
                if (PlayCrosses.Checked == true)
                {
                    _game.UserLetter = 'X'; // Игрок использует крестики.
                    _game.PcLetter = '0'; // Компьютер использует нолики.
                }
                else
                {
                    _game.UserLetter = '0'; // Игрок использует нолики.
                    _game.PcLetter = 'X'; // Компьютер использует крестики.
                }
            }

            // Выберите уровень сложности !.
            if (LevelOfDifficulty_1.Checked == false && LevelOfDifficulty_2.Checked == false &&
                LevelOfDifficulty_3.Checked == false && LevelOfDifficulty_4.Checked == false &&
                LevelOfDifficulty_5.Checked == false && LevelOfDifficulty_6.Checked == false &&
                LevelOfDifficulty_7.Checked == false && LevelOfDifficulty_8.Checked == false &&
                LevelOfDifficulty_9.Checked == false && LevelOfDifficulty_10.Checked == false)
            {
                MessageBox.Show("Выберите уровень сложности !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else // Выставление уровня сложности.
            {
                if (LevelOfDifficulty_1.Checked == true)
                    _game.GameDifficulty = 1;
                else if (LevelOfDifficulty_2.Checked == true)
                    _game.GameDifficulty = 2;
                else if (LevelOfDifficulty_3.Checked == true)
                    _game.GameDifficulty = 3;
                else if (LevelOfDifficulty_4.Checked == true)
                    _game.GameDifficulty = 4;
                else if (LevelOfDifficulty_5.Checked == true)
                    _game.GameDifficulty = 5;
                else if (LevelOfDifficulty_6.Checked == true)
                    _game.GameDifficulty = 6;
                else if (LevelOfDifficulty_7.Checked == true)
                    _game.GameDifficulty = 7;
                else if (LevelOfDifficulty_8.Checked == true)
                    _game.GameDifficulty = 8;
                else if (LevelOfDifficulty_9.Checked == true)
                    _game.GameDifficulty = 9;
                else if (LevelOfDifficulty_10.Checked == true)
                    _game.GameDifficulty = 10;
            }

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

            // После того как игра началась, блокируем кнопку "Начать новую игру" и прочие лишние елементы.
            // По идее можно просто групбоксы заблокировать.
            //StartNewGame_button10.Enabled = false;
            //FirstMoveComputer.Enabled = false;
            //FirstMovePlayer.Enabled = false;
            //PlayCrosses.Enabled = false;
            //PlayZeroes.Enabled = false;
            //LevelOfDifficulty_1.Enabled = false;
            //LevelOfDifficulty_2.Enabled = false;
            //LevelOfDifficulty_3.Enabled = false;
            //LevelOfDifficulty_4.Enabled = false;
            //LevelOfDifficulty_5.Enabled = false;
            //LevelOfDifficulty_6.Enabled = false;
            //LevelOfDifficulty_7.Enabled = false;
            //LevelOfDifficulty_8.Enabled = false;
            //LevelOfDifficulty_9.Enabled = false;
            //LevelOfDifficulty_10.Enabled = false;


        }
    }

    // Класс реализующий логику игры с компьютером.
    public class Tic_tac_toe_game
    {
        // Массив игрового поля.
        private char[,] arr;

        public char this[int i, int j]
        {
            get { return arr[i, j]; }
            set { arr[i, j] = value; }
        }

        // Уровень сложности.
        int _gameDifficulty;
        public int GameDifficulty
        {
            get { return _gameDifficulty; }
            set { _gameDifficulty = value; }
        }

        // Символ для игры игрока.
        char _userLetter;
        public char UserLetter { get { return _userLetter; } set { _userLetter = value; } }

        // Символ для игры компьютера.
        char _pcLetter;
        public char PcLetter { get { return _pcLetter; } set { _pcLetter = value; } }

        // Кто будет ходить ?
        int _whoMove; // 0 - компьютер, 1 - игрок.
        public int WhoMove { get { return _whoMove; } set { _whoMove = value; } }

        // Общее количество ходов в игре.
        int _totalMovesInGame;
        public int TotalMovesInGame { get { return _totalMovesInGame; } set { _totalMovesInGame = value; } }

        // Проверка на победимтеля.
        int _winCheck;
        public int WinCheck
        {
            get { return _winCheck; }
            set { _winCheck = value; }
        }

        // Может ли пользователь ходить.
        bool _userMoveCheckResult;
        public bool UserMoveCheckResult
        {
            get { return _userMoveCheckResult; }
            set { _userMoveCheckResult = value; }
        }

        // Координаты хода пользователя на массиве.
        private Point playerPointToMove;

        // Конструктор.
        public Tic_tac_toe_game()
        {
            arr = new[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            _gameDifficulty = 0;
            _userLetter = '3';
            _pcLetter = '3';
            _whoMove = -1;
            _totalMovesInGame = 9;
            _winCheck = -1;
            _userMoveCheckResult = false;
        }

        /// <summary>
        /// Интеграция проекта с с++.
        /// </summary>

        // Метод преобразования нажатых кнопок в координаты массива.
        public Point ConvertButtonToCoordinates(Button button)
        {
            Point coordinates = new Point();

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
        public bool UserMoveCheck(Point point)
        {
            if (arr[point.X, point.Y] == ' ')
                return true; // Ход возможен.
            else
                return false; // Ячейка занята, ходить сюда нельзя.
        }

        // Метод обрабатки хода игрока.
        void UserMove(Point point, char userLetter)
        {
            arr[point.X, point.Y] = userLetter;
        }

        // Метод проверки победы.
        int WinCheckMethod()
        {
            if (((arr[0, 0] == _userLetter) && (arr[0, 1] == _userLetter) && (arr[0, 2] == _userLetter)) || // 1 горизонтальная
                ((arr[1, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[1, 2] == _userLetter)) || // 2 горизонтальная
                ((arr[2, 0] == _userLetter) && (arr[2, 1] == _userLetter) && (arr[2, 2] == _userLetter)) || // 3 горизонтальная
                ((arr[0, 0] == _userLetter) && (arr[1, 0] == _userLetter) && (arr[2, 0] == _userLetter)) || // 1 вертикальная
                ((arr[0, 1] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[2, 1] == _userLetter)) || // 2 вертикальная 
                ((arr[0, 2] == _userLetter) && (arr[1, 2] == _userLetter) && (arr[2, 2] == _userLetter)) || // 3 вертикальная 
                ((arr[0, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[2, 2] == _userLetter)) || // главная диагональ
                ((arr[2, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[0, 2] == _userLetter))) // второстепенная диагональ
            {
                return 1; // Возвращает при победе игрока.
            }
            else if (((arr[0, 0] == _pcLetter) && (arr[0, 1] == _pcLetter) && (arr[0, 2] == _pcLetter)) || // 1 горизонтальная
                ((arr[1, 0] == _pcLetter) && (arr[1, 1] == _pcLetter) && (arr[1, 2] == _pcLetter)) || // 2 горизонтальная
                ((arr[2, 0] == _pcLetter) && (arr[2, 1] == _pcLetter) && (arr[2, 2] == _pcLetter)) || // 3 горизонтальная
                ((arr[0, 0] == _pcLetter) && (arr[1, 0] == _pcLetter) && (arr[2, 0] == _pcLetter)) || // 1 вертикальная
                ((arr[0, 1] == _pcLetter) && (arr[1, 1] == _pcLetter) && (arr[2, 1] == _pcLetter)) || // 2 вертикальная 
                ((arr[0, 2] == _pcLetter) && (arr[1, 2] == _pcLetter) && (arr[2, 2] == _pcLetter)) || // 3 вертикальная 
                ((arr[0, 0] == _pcLetter) && (arr[1, 1] == _pcLetter) && (arr[2, 2] == _pcLetter)) || // главная диагональ
                ((arr[2, 0] == _pcLetter) && (arr[1, 1] == _pcLetter) && (arr[0, 2] == _pcLetter))) // второстепенная диагональ
            {
                return 0; // Возвращает при победе компьютера.
            }
            else
            {
                return 2; // Возвращает при ничьей.
            }
        }

        // Функция делает рандомный ход компьютера в свободную ячейку. Игра "Крестики-нолики".
        void PcRandMove()
        {
            Random random = new Random();
            Point point = new Point();

            do
            {
                point.X = random.Next(0, 2);// для броска от 0 до 2
                point.Y = random.Next(0, 2);// для броска от 0 до 2
            } while (arr[point.X, point.Y] != ' ');
            arr[point.X, point.Y] = _pcLetter;
        }

        // Функция определяющая сложность игры. Игра "Крестики-нолики".
        int GameDiff()
        {
            Random random = new Random();
            Point point = new Point();
            return random.Next(41, 100);
        }

        // Функция обрабатывающая ход компьютера.
        int PcMove()
        {
            if ((arr[0, 0] == ' ') && (arr[0, 1] == _userLetter) && (arr[0, 2] == _userLetter)) // 1 горизонтальная [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[0, 1] == ' ') && (arr[0, 2] == _userLetter)) // 1 горизонтальная [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[0, 1] == _userLetter) && (arr[0, 2] == ' ')) // 1 горизонтальная [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == ' ') && (arr[1, 1] == _userLetter) && (arr[1, 2] == _userLetter)) // 2 горизонтальная [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == _userLetter) && (arr[1, 1] == ' ') && (arr[1, 2] == _userLetter)) // 2 горизонтальная [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[1, 2] == ' ')) // 2 горизонтальная [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == ' ') && (arr[2, 1] == _userLetter) && (arr[2, 2] == _userLetter)) // 3 горизонтальная [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == _userLetter) && (arr[2, 1] == ' ') && (arr[2, 2] == _userLetter)) // 3 горизонтальная [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == _userLetter) && (arr[2, 1] == _userLetter) && (arr[2, 2] == ' ')) // 3 горизонтальная [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == ' ') && (arr[1, 0] == _userLetter) && (arr[2, 0] == _userLetter)) // 1 вертикальная [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[1, 0] == ' ') && (arr[2, 0] == _userLetter)) // 1 вертикальная [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[1, 0] == _userLetter) && (arr[2, 0] == ' ')) // 1 вертикальная [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == ' ') && (arr[1, 1] == _userLetter) && (arr[2, 1] == _userLetter)) // 2 вертикальная[_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == _userLetter) && (arr[1, 1] == ' ') && (arr[2, 1] == _userLetter)) // 2 вертикальная[*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[2, 1] == ' ')) // 2 вертикальная[**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == ' ') && (arr[1, 2] == _userLetter) && (arr[2, 2] == _userLetter)) // 3 вертикальная [_**] 
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == _userLetter) && (arr[1, 2] == ' ') && (arr[2, 2] == _userLetter)) // 3 вертикальная [*_*] 
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == _userLetter) && (arr[1, 2] == _userLetter) && (arr[2, 2] == ' ')) // 3 вертикальная [**_] 
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == ' ') && (arr[1, 1] == _userLetter) && (arr[2, 2] == _userLetter)) // главная диагональ [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[1, 1] == ' ') && (arr[2, 2] == _userLetter)) // главная диагональ [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[2, 2] == ' ')) // главная диагональ [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == ' ') && (arr[1, 1] == _userLetter) && (arr[0, 2] == _userLetter)) // вторая диагональ [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == _userLetter) && (arr[1, 1] == ' ') && (arr[0, 2] == _userLetter)) // вторая диагональ [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[0, 2] == ' ')) // вторая диагональ [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else
            {
                PcRandMove();
                return 0;
            }
        }

        public void Step()
        {

        }

        // Игровоц процесс.
        public void GameProcess(Point point)
        {




            // Сыграем еще ?.
            string playMore = "-1";
            do
            {
                do
                {
                    if (WhoMove == 1) // Пользователь.
                    {
                        Point playerPointToMove = point;
                        do
                        {
                            UserMoveCheckResult = UserMoveCheck(playerPointToMove);
                            if (UserMoveCheckResult == false)
                                MessageBox.Show("Выберите другую ячейку.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } while (UserMoveCheckResult == false);
                        UserMove(playerPointToMove, UserLetter);
                        WhoMove -= 1;
                        TotalMovesInGame--;
                        WinCheck = WinCheckMethod(); //todo: после обычного хода в начале игры на пустое поле выдает ничью о_О
                        if (WinCheck == 1)
                        {
                            MessageBox.Show("Игрок победил.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                    else if (WhoMove == 0) // Компьютер.
                    {
                        PcMove();
                        WhoMove += 1;
                        TotalMovesInGame--;
                        WinCheck = WinCheckMethod();
                        if (WinCheck == 0)
                        {
                            MessageBox.Show("Компьютер победил.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                } while (TotalMovesInGame > 0 || WinCheck != 2);

                if (WinCheck == 2)
                    MessageBox.Show("Ничья.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);


                MessageBox.Show("Сыграем еще ?", "Игра «Крестики-нолики».", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            } while (playMore == "y");
        }
    }
}