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
                game.arr[0, 0] = ;
            }



            // Если кнопка занята, тоесть туда уже походили.
            //if (game.arr[,]
            //   )
            //    return;
            // Проверка на то, чем пользователь играет.
            if (game._crossOrZero == "cross")
            {
                // Если играет крестиками, то ставим крестик.
                ((Button)sender).Image = Properties.Resources.cross;
            }
            else
            {
                // Если играет ноликами, то ставим нолик.
                ((Button)sender).Image = Properties.Resources._null;
            }
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

            if (PlayCrosses.Checked == false && PlayZeroes.Checked == false)
            {
                MessageBox.Show("Выберите чем будете играть !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // Проверка "Выберите уровень сложности.".

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

            // Выставляем значение поля "Кто ходит ?" в зависимости от выбора пользователя.
            if (FirstMoveComputer.Checked == true)
                game._whoMove = "computer";
            else
                game._whoMove = "player";


            //DialogResult playMore;
            //do
            //{


            //    playMore = MessageBox.Show(
            //        "Хотите сыграть еще ?",
            //        "Игра \"Угадай число.\"",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //} while (playMore == DialogResult.Yes);
        }

        // 

        Tic_tac_toe_game game = new Tic_tac_toe_game();
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
        //public string _firstMove = ""; // 

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

        // Кто будет ходить первым ?
        int firstMove = 0; // 0 - компьютер, 1 - игрок.

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

        // Игровоц процесс.
        public void GameProcess()
        {
            // Общее количество ходов в игре.
            int totalMovesInGame = 9;

            // Проверка на победимтеля.
            int winCheck = -1;

            bool moveCheckResult = false;

            do
            {
                if (firstMove == 1) // Пользователь.
                {
                    Point userMove = new Point();
                    do
                    {
                        moveCheckResult = UserMoveCheck(userMove);
                        if (moveCheckResult == false)
                            MessageBox.Show("Выберите другую ячейку.", "Ячейка занята.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } while (moveCheckResult == false);
                    UserMove(userMove, _userLetter);





                }









            } while (totalMovesInGame > 0 || winCheck != 2);


        }
    }
}