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
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            //2,07,20.
            if (button1.Image != null && button2.Image != null && button3.Image != null &&
                button4.Image != null && button5.Image != null && button6.Image != null &&
                button7.Image != null && button8.Image != null && button9.Image != null)
            {
                return;
            }
            else
            {
                ((Button)sender).Image = Properties.Resources.cross;
            }
        }

        // Обработчик события нажатия на ссылку "Правила игры в «Крестики-нолики»."
        private void RulesOfTheGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Запуск браузера с заданным адресом.
            ProcessStartInfo procInfo = new ProcessStartInfo(@"chrome.exe");
            procInfo.UseShellExecute = true;
            procInfo.Arguments = "https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B5%D1%81%D1%82%D0%B8%D0%BA%D0%B8-%D0%BD%D0%BE%D0%BB%D0%B8%D0%BA%D0%B8#%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0_%D0%B8%D0%B3%D1%80%D1%8B";
            Process.Start(procInfo);
        }

        // Обработчик события нажатия на кнопку "Начать новую игру".
        private void StartNewGame_button10_Click(object sender, EventArgs e)
        {
            DialogResult playMore;
            do
            {


                playMore = MessageBox.Show(
                    "Хотите сыграть еще ?",
                    "Игра \"Угадай число.\"",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            } while (playMore == DialogResult.Yes);
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
        public string _crossOrZero = "";

        // Кто ходит ?
        public string _move = "";



    }
}