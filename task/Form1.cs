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

            // Сопоставляем имя кнопки с двумерным массивом.
            if (buttonName == "button1")
            {
                // Если ходит игрок.
                game.arr[0, 0] = ;
            }


            // Если кнопка занята, тоесть туда уже походили.
            if (game.arr[,]
               )
                return;
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
            procInfo.Arguments = "https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B5%D1%81%D1%82%D0%B8%D0%BA%D0%B8-%D0%BD%D0%BE%D0%BB%D0%B8%D0%BA%D0%B8#%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0_%D0%B8%D0%B3%D1%80%D1%8B";
            Process.Start(procInfo);
        }

        // Обработчик нажатия на кнопку "Начать новую игру".
        private void StartNewGame_button10_Click(object sender, EventArgs e)
        {
            // Проверяем заполнены ли все поля для игры.
            // Проверка "Кто будет ходить первым ?".
            if (FirstMoveComputer.Checked == false && FirstMovePlayer.Checked == false)
            {
                MessageBox.Show("Выберите кто будет ходить первым !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // Проверка "Играть крестиками или ноликами ?".
            if (PlayCrosses.Checked == false && PlayZeroes.Checked == false)
            {
                MessageBox.Show("Выберите чем будете играть !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // Проверка "Выберите уровень сложности.".
            if (LevelOfDifficultyEasy.Checked == false && LevelOfDifficultyMedium.Checked == false && LevelOfDifficultyHard.Checked == false)
            {
                MessageBox.Show("Выберите уровень сложности !", "Ошибка !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Если все поля заполнены, то включаем поле с кнопками.
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;


            //DialogResult playMore;
            //do
            //{


            //    playMore = MessageBox.Show(
            //        "Хотите сыграть еще ?",
            //        "Игра \"Угадай число.\"",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //} while (playMore == DialogResult.Yes);
        }

        private void FirstMove_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Name == "FirstMoveComputer")
                game._firstMove = "computer";
            else
                game._firstMove = "player";
        }

        Tic_tac_toe_game game = new Tic_tac_toe_game();
    }

    // Класс реализующий логику игры с компьютером.
    public class Tic_tac_toe_game
    {
        // Массив игрового поля.
        public char[,] arr = new char[,]
        {
            { ' ', ' ', ' '},
            { ' ', ' ', ' '},
            { ' ', ' ', ' '}
        };

        // Кто первый ходит ?
        public string _firstMove = "";

        // Играть крестиками или лноликами ?
        public string _crossOrZero = ""; // "x" - крестиками, "0" - ноликами.

        // Кто ходит ?
        public string _move = ""; // "computer" или "player".

        // Выбранный уровень сложности.
        public string _difficultyLevel = "";
    }
}