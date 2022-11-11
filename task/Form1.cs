using System.Diagnostics;
using task;


namespace task
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// �������� ���� ���������-������, �������� ��������� ����������: 
        /// * ������� ���� �������� 3�3 ������ �������� �� ������; 
        /// * ��� ������� �� ������, �� ��� ������ ������������ �������� (������� ���
        /// �����); 
        /// * ���������� ������������� ������� ��������� ������� ��� ����� �� �������
        /// ������; 
        /// * ������������ ������������ ����� ������ ������� ����, ��������� ������; 
        /// * ������������� ����������� ������ ������ ���������, ���������
        /// �������������; 
        /// * ������������� ������ ������� ����� ����.
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

        // ���������� ������� ������� �� ������ "������� ���� � ���������-������."
        private void RulesOfTheGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ������ �������� � �������� �������.
            ProcessStartInfo procInfo = new ProcessStartInfo(@"chrome.exe");
            procInfo.UseShellExecute = true;
            procInfo.Arguments = "https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B5%D1%81%D1%82%D0%B8%D0%BA%D0%B8-%D0%BD%D0%BE%D0%BB%D0%B8%D0%BA%D0%B8#%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0_%D0%B8%D0%B3%D1%80%D1%8B";
            Process.Start(procInfo);
        }

        // ���������� ������� ������� �� ������ "������ ����� ����".
        private void StartNewGame_button10_Click(object sender, EventArgs e)
        {
            DialogResult playMore;
            do
            {


                playMore = MessageBox.Show(
                    "������ ������� ��� ?",
                    "���� \"������ �����.\"",
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

    // ����� ����������� ������ ���� � �����������.
    public class Tic_tac_toe_game
    {
        // ������ �������� ����.
        public char[,] arr = new char[,]
        {
            { ' ', ' ', ' '},
            { ' ', ' ', ' '},
            { ' ', ' ', ' '}
        };

        // ��� ������ ����� ?
        public string _firstMove = "";

        // ������ ���������� ��� ��������� ?
        public string _crossOrZero = "";

        // ��� ����� ?
        public string _move = "";



    }
}