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

            // ����� ����� ��������� ���� � ��������.
            // ����� �������� ������ ����� ������� ������ "������ ����".
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

        // ���������� ������� ������ �� ������� ����.
        private void gameFieldsButtons_Click(object sender, EventArgs e)
        {
            // �������� ��� ������ �� ������� ������.
            string buttonName = ((Button)sender).Name;

            // ������������ ��� ������ � ��������� ��������.
            if (buttonName == "button1")
            {
                // ���� ����� �����.
                game.arr[0, 0] = ;
            }


            // ���� ������ ������, ������ ���� ��� ��������.
            if (game.arr[,]
               )
                return;
            // �������� �� ��, ��� ������������ ������.
            if (game._crossOrZero == "cross")
            {
                // ���� ������ ����������, �� ������ �������.
                ((Button)sender).Image = Properties.Resources.cross;
            }
            else
            {
                // ���� ������ ��������, �� ������ �����.
                ((Button)sender).Image = Properties.Resources._null;
            }
        }

        // ���������� ������� �� ������ "������� ���� � ���������-������."
        private void RulesOfTheGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ������ �������� � �������� �������.
            ProcessStartInfo procInfo = new ProcessStartInfo(@"chrome.exe");
            procInfo.UseShellExecute = true;
            procInfo.Arguments = "https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B5%D1%81%D1%82%D0%B8%D0%BA%D0%B8-%D0%BD%D0%BE%D0%BB%D0%B8%D0%BA%D0%B8#%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0_%D0%B8%D0%B3%D1%80%D1%8B";
            Process.Start(procInfo);
        }

        // ���������� ������� �� ������ "������ ����� ����".
        private void StartNewGame_button10_Click(object sender, EventArgs e)
        {
            // ��������� ��������� �� ��� ���� ��� ����.
            // �������� "��� ����� ������ ������ ?".
            if (FirstMoveComputer.Checked == false && FirstMovePlayer.Checked == false)
            {
                MessageBox.Show("�������� ��� ����� ������ ������ !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // �������� "������ ���������� ��� �������� ?".
            if (PlayCrosses.Checked == false && PlayZeroes.Checked == false)
            {
                MessageBox.Show("�������� ��� ������ ������ !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // �������� "�������� ������� ���������.".
            if (LevelOfDifficultyEasy.Checked == false && LevelOfDifficultyMedium.Checked == false && LevelOfDifficultyHard.Checked == false)
            {
                MessageBox.Show("�������� ������� ��������� !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ���� ��� ���� ���������, �� �������� ���� � ��������.
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
            //        "������ ������� ��� ?",
            //        "���� \"������ �����.\"",
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
        public string _crossOrZero = ""; // "x" - ����������, "0" - ��������.

        // ��� ����� ?
        public string _move = ""; // "computer" ��� "player".

        // ��������� ������� ���������.
        public string _difficultyLevel = "";
    }
}