using System.Diagnostics;
using task;


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


        Tic_tac_toe_game _game = new Tic_tac_toe_game();
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
        }

        // Обработчик нажатий кнопок на игровом поле.
        private void gameFieldsButtons_Click(object sender, EventArgs e)
        {
            // Получаем имя кнопки на которую нажали.
            string buttonName = ((Button)sender).Name;

            // Сопоставляем имя кнопки с двумерным массивом для передачи позиции в двумерный массив.
            if (buttonName == "button1")
            {
                // Передаем позицию в двумерный массив.
                // game.arr[0, 0] = ;
            }




            //// Проверка на то, чем пользователь играет.
            //if (game._crossOrZero == "cross")
            //{
            //    // Если играет крестиками, то ставим крестик.
            //    ((Button)sender).Image = Properties.Resources.cross;
            //}
            //else
            //{
            //    // Если играет ноликами, то ставим нолик.
            //    ((Button)sender).Image = Properties.Resources._null;
            //}
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
            // Проверка "Кто будет ходить первым ?".
            if (FirstMoveComputer.Checked == false && FirstMovePlayer.Checked == false)
            {
                MessageBox.Show("Выберите кто будет ходить первым !", "Ошибка !", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            } // Проверка "Играть крестиками или ноликами ?".
            else
            {
                if (FirstMoveComputer.Checked == true)
                    _game.WhoMove = 0; // Компьютер ходит первым.
                _game.WhoMove = 1; // Игрок ходит первым.
            }

            if (PlayCrosses.Checked == false && PlayZeroes.Checked == false)
            {
                MessageBox.Show("Выберите чем будете играть !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // Проверка "Выберите уровень сложности.".
            else
            {
                if (PlayCrosses.Checked == true)
                {
                    _game.UserLetter = 'X'; // Игрок использует крестики.
                    _game.PcLetter = '0'; // Компьютер использует нолики.
                }
                else
                {
                    _game.UserLetter = '0'; // Игрок использует крестики.
                    _game.PcLetter = 'X'; // Компьютер использует нолики.
                }
            }

            if (LevelOfDifficultyEasy.Checked == false && LevelOfDifficultyMedium.Checked == false &&
                LevelOfDifficultyHard.Checked == false)
            {
                MessageBox.Show("Выберите уровень сложности !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Если все поля заполнены, то включаем поле с игровыми кнопками.
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            // Кто чем будет играть ?.


            // Выставляем значение поля "Кто ходит ?" в зависимости от выбора пользователя.
            if (FirstMoveComputer.Checked == true)
                _game.WhoMove = 0;
            else
                _game.WhoMove = 1;

            _game.GameProcess();


        }
    }

    // Класс реализующий логику игры с компьютером.
    public class Tic_tac_toe_game
    {
        int size = 3;

        // Массив игрового поля.
        private char[,] arr = new char[,]
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        // Кто первый ходит ?
        //public string _whoMove = ""; // 

        // Играть крестиками или лноликами ?
        // public string _crossOrZero = ""; // "x" - крестиками, "0" - ноликами.

        // Кто ходит ?
        // public string _whoMove = ""; // "computer" или "player".

        // Выбранный уровень сложности.
        //public string _difficultyLevel = "";

        // Получает с формы координаты хода пользователя.
        //public void GetCoordinatesFromForm(int x, int y)
        //{
        //    arr[x, y] = 'x';
        //}

        /// <summary>
        /// Интеграция проекта с с++.
        /// </summary>

        // Функция заполнения матрицы пробелами. Игра "Крестики-нолики".
        void FillArrWithSpaces()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = ' ';
                }
            }
        }

        // Уровень сложности.
        int _gameDifficulty = 0;
        public int GameDifficulty { get; set; }

        // Выбор игроком крестиков или ноликов.
        int _userChoice = -1;
        public int UserChoice { get; set; }

        // Символ для игры игрока.
        char _userLetter = '3';
        public char UserLetter { get; set; }

        // Символ для игры компьютера.
        char _pcLetter = '3';
        public char PcLetter { get; set; }

        // Метод выставляет чем будут играть игрок и компьютер.
        void CrossOrZero(int crossOrZero) // Принимает результат выбора по radiobutton.
        {
            if (_userChoice == 1)
            {
                _userLetter = 'X';
                _pcLetter = 'O';
            }
            else if (_userChoice == 2)
            {
                _userLetter = 'O';
                _pcLetter = 'X';
            }
        }

        // Кто будет ходить ?
        int _whoMove = -1; // 0 - компьютер, 1 - игрок.
        public int WhoMove { get; set; }

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
        bool UserMoveCheck(Point point)
        {
            if (arr[point.X, point.Y] == ' ')
                return true;
            else
                return false;
        }

        // Метод обрабатки хода игрока.
        void UserMove(Point point, char userLetter)
        {
            arr[point.X, point.Y] = userLetter;
        }

        // Метод проверки победы.
        int WinCheck()
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

        // Игровоц процесс.
        public void GameProcess()
        {
            // Общее количество ходов в игре.
            int totalMovesInGame = 9;

            // Проверка на победимтеля.
            int winCheck = -1;

            // Может ли пользователь ходить.
            bool moveCheckResult = false;

            // Сыграем еще ?.
            string playMore = "-1";
            do
            {
                do
                {
                    if (_whoMove == 1) // Пользователь.
                    {
                        Point userMove = new Point();
                        do
                        {
                            moveCheckResult = UserMoveCheck(userMove);
                            if (moveCheckResult == false)
                                MessageBox.Show("Выберите другую ячейку.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } while (moveCheckResult == false);
                        UserMove(userMove, _userLetter);
                        _whoMove -= 1;
                        totalMovesInGame--;
                        winCheck = WinCheck();
                        if (winCheck == 1)
                        {
                            MessageBox.Show("Игрок победил.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                    else if (_whoMove == 0) // Компьютер.
                    {
                        PcMove();
                        _whoMove += 1;
                        totalMovesInGame--;
                        winCheck = WinCheck();
                        if (winCheck == 0)
                        {
                            MessageBox.Show("Компьютер победил.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                } while (totalMovesInGame > 0 || winCheck != 2);

                if (winCheck == 2)
                    MessageBox.Show("Ничья.", "Игра «Крестики-нолики».", MessageBoxButtons.OK, MessageBoxIcon.Information);


                MessageBox.Show("Сыграем еще ?", "Игра «Крестики-нолики».", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            } while (playMore == "y");
        }
    }
}