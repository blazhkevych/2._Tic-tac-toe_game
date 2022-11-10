using System.Diagnostics;

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
            DialogResult playMore;
            do
            {


                playMore = MessageBox.Show(
                    "Хотите сыграть еще ?",
                    "Игра \"Угадай число.\"",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            } while (playMore == DialogResult.Yes);
        }

        private void RulesOfTheGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Запуск браузера с заданным адресом.
            ProcessStartInfo procInfo = new ProcessStartInfo(@"chrome.exe");
            procInfo.UseShellExecute = true;
            procInfo.Arguments = "https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B5%D1%81%D1%82%D0%B8%D0%BA%D0%B8-%D0%BD%D0%BE%D0%BB%D0%B8%D0%BA%D0%B8#%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0_%D0%B8%D0%B3%D1%80%D1%8B";
            Process.Start(procInfo);
        }
    }
}