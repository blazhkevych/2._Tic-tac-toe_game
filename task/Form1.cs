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


        Tic_tac_toe_game _game = new Tic_tac_toe_game();
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

            // ������������ ��� ������ � ��������� �������� ��� �������� ������� � ��������� ������.
            if (buttonName == "button1")
            {
                // �������� ������� � ��������� ������.
                // game.arr[0, 0] = ;
            }




            //// �������� �� ��, ��� ������������ ������.
            //if (game._crossOrZero == "cross")
            //{
            //    // ���� ������ ����������, �� ������ �������.
            //    ((Button)sender).Image = Properties.Resources.cross;
            //}
            //else
            //{
            //    // ���� ������ ��������, �� ������ �����.
            //    ((Button)sender).Image = Properties.Resources._null;
            //}
        }

        // ���������� ������� �� ������ "������� ���� � ���������-������."
        private void RulesOfTheGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ������ �������� � �������� �������.
            ProcessStartInfo procInfo = new ProcessStartInfo(@"chrome.exe");
            procInfo.UseShellExecute = true;
            procInfo.Arguments =
                "https://ru.wikipedia.org/wiki/%D0%9A%D1%80%D0%B5%D1%81%D1%82%D0%B8%D0%BA%D0%B8-%D0%BD%D0%BE%D0%BB%D0%B8%D0%BA%D0%B8#%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D0%B0_%D0%B8%D0%B3%D1%80%D1%8B";
            Process.Start(procInfo);
        }

        // ���������� ������� �� ������ "������ ����� ����".
        private void StartNewGame_button10_Click(object sender, EventArgs e)
        {
            // ��������� ��������� �� ��� ���� ��� ����.
            // �������� "��� ����� ������ ������ ?".
            if (FirstMoveComputer.Checked == false && FirstMovePlayer.Checked == false)
            {
                MessageBox.Show("�������� ��� ����� ������ ������ !", "������ !", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            } // �������� "������ ���������� ��� �������� ?".
            else
            {
                if (FirstMoveComputer.Checked == true)
                    _game.WhoMove = 0; // ��������� ����� ������.
                _game.WhoMove = 1; // ����� ����� ������.
            }

            if (PlayCrosses.Checked == false && PlayZeroes.Checked == false)
            {
                MessageBox.Show("�������� ��� ������ ������ !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // �������� "�������� ������� ���������.".
            else
            {
                if (PlayCrosses.Checked == true)
                {
                    _game.UserLetter = 'X'; // ����� ���������� ��������.
                    _game.PcLetter = '0'; // ��������� ���������� ������.
                }
                else
                {
                    _game.UserLetter = '0'; // ����� ���������� ��������.
                    _game.PcLetter = 'X'; // ��������� ���������� ������.
                }
            }

            if (LevelOfDifficultyEasy.Checked == false && LevelOfDifficultyMedium.Checked == false &&
                LevelOfDifficultyHard.Checked == false)
            {
                MessageBox.Show("�������� ������� ��������� !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ���� ��� ���� ���������, �� �������� ���� � �������� ��������.
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            // ��� ��� ����� ������ ?.


            // ���������� �������� ���� "��� ����� ?" � ����������� �� ������ ������������.
            if (FirstMoveComputer.Checked == true)
                _game.WhoMove = 0;
            else
                _game.WhoMove = 1;

            _game.GameProcess();


        }
    }

    // ����� ����������� ������ ���� � �����������.
    public class Tic_tac_toe_game
    {
        int size = 3;

        // ������ �������� ����.
        private char[,] arr = new char[,]
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        // ��� ������ ����� ?
        //public string _whoMove = ""; // 

        // ������ ���������� ��� ��������� ?
        // public string _crossOrZero = ""; // "x" - ����������, "0" - ��������.

        // ��� ����� ?
        // public string _whoMove = ""; // "computer" ��� "player".

        // ��������� ������� ���������.
        //public string _difficultyLevel = "";

        // �������� � ����� ���������� ���� ������������.
        //public void GetCoordinatesFromForm(int x, int y)
        //{
        //    arr[x, y] = 'x';
        //}

        /// <summary>
        /// ���������� ������� � �++.
        /// </summary>

        // ������� ���������� ������� ���������. ���� "��������-������".
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

        // ������� ���������.
        int _gameDifficulty = 0;
        public int GameDifficulty { get; set; }

        // ����� ������� ��������� ��� �������.
        int _userChoice = -1;
        public int UserChoice { get; set; }

        // ������ ��� ���� ������.
        char _userLetter = '3';
        public char UserLetter { get; set; }

        // ������ ��� ���� ����������.
        char _pcLetter = '3';
        public char PcLetter { get; set; }

        // ����� ���������� ��� ����� ������ ����� � ���������.
        void CrossOrZero(int crossOrZero) // ��������� ��������� ������ �� radiobutton.
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

        // ��� ����� ������ ?
        int _whoMove = -1; // 0 - ���������, 1 - �����.
        public int WhoMove { get; set; }

        // ����� �������������� ������� ������ � ���������� �������.
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

        // ����� �������� ��������� ������ � ������� ��� ��� ������.
        bool UserMoveCheck(Point point)
        {
            if (arr[point.X, point.Y] == ' ')
                return true;
            else
                return false;
        }

        // ����� ��������� ���� ������.
        void UserMove(Point point, char userLetter)
        {
            arr[point.X, point.Y] = userLetter;
        }

        // ����� �������� ������.
        int WinCheck()
        {
            if (((arr[0, 0] == _userLetter) && (arr[0, 1] == _userLetter) && (arr[0, 2] == _userLetter)) || // 1 ��������������
                ((arr[1, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[1, 2] == _userLetter)) || // 2 ��������������
                ((arr[2, 0] == _userLetter) && (arr[2, 1] == _userLetter) && (arr[2, 2] == _userLetter)) || // 3 ��������������
                ((arr[0, 0] == _userLetter) && (arr[1, 0] == _userLetter) && (arr[2, 0] == _userLetter)) || // 1 ������������
                ((arr[0, 1] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[2, 1] == _userLetter)) || // 2 ������������ 
                ((arr[0, 2] == _userLetter) && (arr[1, 2] == _userLetter) && (arr[2, 2] == _userLetter)) || // 3 ������������ 
                ((arr[0, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[2, 2] == _userLetter)) || // ������� ���������
                ((arr[2, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[0, 2] == _userLetter))) // �������������� ���������
            {
                return 1; // ���������� ��� ������ ������.
            }
            else if (((arr[0, 0] == _pcLetter) && (arr[0, 1] == _pcLetter) && (arr[0, 2] == _pcLetter)) || // 1 ��������������
                ((arr[1, 0] == _pcLetter) && (arr[1, 1] == _pcLetter) && (arr[1, 2] == _pcLetter)) || // 2 ��������������
                ((arr[2, 0] == _pcLetter) && (arr[2, 1] == _pcLetter) && (arr[2, 2] == _pcLetter)) || // 3 ��������������
                ((arr[0, 0] == _pcLetter) && (arr[1, 0] == _pcLetter) && (arr[2, 0] == _pcLetter)) || // 1 ������������
                ((arr[0, 1] == _pcLetter) && (arr[1, 1] == _pcLetter) && (arr[2, 1] == _pcLetter)) || // 2 ������������ 
                ((arr[0, 2] == _pcLetter) && (arr[1, 2] == _pcLetter) && (arr[2, 2] == _pcLetter)) || // 3 ������������ 
                ((arr[0, 0] == _pcLetter) && (arr[1, 1] == _pcLetter) && (arr[2, 2] == _pcLetter)) || // ������� ���������
                ((arr[2, 0] == _pcLetter) && (arr[1, 1] == _pcLetter) && (arr[0, 2] == _pcLetter))) // �������������� ���������
            {
                return 0; // ���������� ��� ������ ����������.
            }
            else
            {
                return 2; // ���������� ��� ������.
            }
        }

        // ������� ������ ��������� ��� ���������� � ��������� ������. ���� "��������-������".
        void PcRandMove()
        {
            Random random = new Random();
            Point point = new Point();

            do
            {
                point.X = random.Next(0, 2);// ��� ������ �� 0 �� 2
                point.Y = random.Next(0, 2);// ��� ������ �� 0 �� 2
            } while (arr[point.X, point.Y] != ' ');
            arr[point.X, point.Y] = _pcLetter;
        }

        // ������� ������������ ��������� ����. ���� "��������-������".
        int GameDiff()
        {
            Random random = new Random();
            Point point = new Point();
            return random.Next(41, 100);
        }

        // ������� �������������� ��� ����������.
        int PcMove()
        {
            if ((arr[0, 0] == ' ') && (arr[0, 1] == _userLetter) && (arr[0, 2] == _userLetter)) // 1 �������������� [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[0, 1] == ' ') && (arr[0, 2] == _userLetter)) // 1 �������������� [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[0, 1] == _userLetter) && (arr[0, 2] == ' ')) // 1 �������������� [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == ' ') && (arr[1, 1] == _userLetter) && (arr[1, 2] == _userLetter)) // 2 �������������� [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == _userLetter) && (arr[1, 1] == ' ') && (arr[1, 2] == _userLetter)) // 2 �������������� [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[1, 2] == ' ')) // 2 �������������� [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == ' ') && (arr[2, 1] == _userLetter) && (arr[2, 2] == _userLetter)) // 3 �������������� [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == _userLetter) && (arr[2, 1] == ' ') && (arr[2, 2] == _userLetter)) // 3 �������������� [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == _userLetter) && (arr[2, 1] == _userLetter) && (arr[2, 2] == ' ')) // 3 �������������� [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == ' ') && (arr[1, 0] == _userLetter) && (arr[2, 0] == _userLetter)) // 1 ������������ [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[1, 0] == ' ') && (arr[2, 0] == _userLetter)) // 1 ������������ [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[1, 0] == _userLetter) && (arr[2, 0] == ' ')) // 1 ������������ [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == ' ') && (arr[1, 1] == _userLetter) && (arr[2, 1] == _userLetter)) // 2 ������������[_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == _userLetter) && (arr[1, 1] == ' ') && (arr[2, 1] == _userLetter)) // 2 ������������[*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[2, 1] == ' ')) // 2 ������������[**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == ' ') && (arr[1, 2] == _userLetter) && (arr[2, 2] == _userLetter)) // 3 ������������ [_**] 
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == _userLetter) && (arr[1, 2] == ' ') && (arr[2, 2] == _userLetter)) // 3 ������������ [*_*] 
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == _userLetter) && (arr[1, 2] == _userLetter) && (arr[2, 2] == ' ')) // 3 ������������ [**_] 
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == ' ') && (arr[1, 1] == _userLetter) && (arr[2, 2] == _userLetter)) // ������� ��������� [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[0, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[1, 1] == ' ') && (arr[2, 2] == _userLetter)) // ������� ��������� [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[2, 2] == ' ')) // ������� ��������� [**_]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 2] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == ' ') && (arr[1, 1] == _userLetter) && (arr[0, 2] == _userLetter)) // ������ ��������� [_**]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[2, 0] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == _userLetter) && (arr[1, 1] == ' ') && (arr[0, 2] == _userLetter)) // ������ ��������� [*_*]
            {
                if (GameDiff() + _gameDifficulty > 50)
                    arr[1, 1] = _pcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == _userLetter) && (arr[1, 1] == _userLetter) && (arr[0, 2] == ' ')) // ������ ��������� [**_]
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

        // ������� �������.
        public void GameProcess()
        {
            // ����� ���������� ����� � ����.
            int totalMovesInGame = 9;

            // �������� �� �����������.
            int winCheck = -1;

            // ����� �� ������������ ������.
            bool moveCheckResult = false;

            // ������� ��� ?.
            string playMore = "-1";
            do
            {
                do
                {
                    if (_whoMove == 1) // ������������.
                    {
                        Point userMove = new Point();
                        do
                        {
                            moveCheckResult = UserMoveCheck(userMove);
                            if (moveCheckResult == false)
                                MessageBox.Show("�������� ������ ������.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } while (moveCheckResult == false);
                        UserMove(userMove, _userLetter);
                        _whoMove -= 1;
                        totalMovesInGame--;
                        winCheck = WinCheck();
                        if (winCheck == 1)
                        {
                            MessageBox.Show("����� �������.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                    else if (_whoMove == 0) // ���������.
                    {
                        PcMove();
                        _whoMove += 1;
                        totalMovesInGame--;
                        winCheck = WinCheck();
                        if (winCheck == 0)
                        {
                            MessageBox.Show("��������� �������.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                } while (totalMovesInGame > 0 || winCheck != 2);

                if (winCheck == 2)
                    MessageBox.Show("�����.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);


                MessageBox.Show("������� ��� ?", "���� ���������-������.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            } while (playMore == "y");
        }
    }
}