using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Drawing;
using task;
using task.Properties;


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

        private Tic_tac_toe_game _game = null;

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
            _game = new Tic_tac_toe_game();
        }

        // ���������� ������� ������ �� ������� ����.
        private void gameFieldsButtons_Click(object sender, EventArgs e)
        {

            // ����� ���������� ����� ������ � ������ ?
            // ���������� ������ �� ����������� � ���������� �������.
            _game.PlayerPointToMove = _game.ConvertButtonToCoordinates((Button)sender);

            if (_game.UserMoveCheck() == true)
            {
                // ���� ������������ ����� ����������, ���������� �� ������ �������� ��������.
                if (_game.UserLetter == 'X')
                    // ���������� �� ������ �� �������� �������.
                    ((Button)sender).Image = Resources.cross;
                else
                    // ���������� �� ������ �� �������� �����.
                    ((Button)sender).Image = Resources._null;
            }

            _game.OneStep();

            ShowComputerMove();
        }

        // ���������� ��� ����������.
        private void ShowComputerMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_game[i, j] == _game.PcLetter)
                    {
                        // ���������� ��� ������ �� �����.
                        foreach (Control c in Controls)
                        {
                            // ���� ����� ������, �� ��������� � ����������.
                            if (c is Button)
                            {
                                // ���� ���������� ������ ��������� � ������������ �������, �� ������������� �� �� ��������.
                                if (_game.ConvertArrCoordinatesToButtonName(i, j) == ((Button)c).Name &&
                                    ((Button)c).Image == null)
                                {
                                    if (_game.PcLetter == 'X')
                                    {
                                        // ���������� �� ������ �� �������� �������.
                                        ((Button)c).Image = Resources.cross;
                                        if (_game.WinCheck == 0) // ������ ����������.
                                        {
                                            MessageBox.Show("��������� �������.", "���� ���������-������.",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            _game.AskPlayMore();
                                        }
                                        else if (_game.WinCheck == 2) // �����.
                                        {
                                            _game.Draw();
                                            _game.AskPlayMore();
                                        }
                                        else if (_game.WinCheck == 3) // ���������� ������.
                                            return;
                                    }
                                    else
                                    {
                                        // ���������� �� ������ �� �������� �����.
                                        ((Button)c).Image = Resources._null;
                                        if (_game.WinCheck == 0) // ������ ����������.
                                        {
                                            MessageBox.Show("��������� �������.", "���� ���������-������.",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            _game.AskPlayMore();
                                        }
                                        else if (_game.WinCheck == 2) // �����.
                                        {
                                            _game.Draw();
                                            _game.AskPlayMore();
                                        }
                                        else if (_game.WinCheck == 3) // ���������� ������.
                                            return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
            // "��� ����� ������ ������ ?".
            if (FirstMoveComputer.Checked == false && FirstMovePlayer.Checked == false)
            {
                MessageBox.Show("�������� ��� ����� ������ ������ !", "������ !", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else // 
            {
                if (FirstMoveComputer.Checked == true)
                    _game.WhoMove = 0; // ��������� ����� ������.
                else
                    _game.WhoMove = 1; // ����� ����� ������.
            }

            // �������� ��� ������ ������ !.
            if (PlayCrosses.Checked == false && PlayZeroes.Checked == false)
            {
                MessageBox.Show("�������� ��� ������ ������ !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // ����������� �������� ���� ��� ������ � ����������.
            else
            {
                if (PlayCrosses.Checked == true)
                {
                    _game.UserLetter = 'X'; // ����� ���������� ��������.
                    _game.PcLetter = '0'; // ��������� ���������� ������.
                }
                else
                {
                    _game.UserLetter = '0'; // ����� ���������� ������.
                    _game.PcLetter = 'X'; // ��������� ���������� ��������.
                }
            }

            // �������� ������� ��������� !.
            if (LevelOfDifficulty_Easy.Checked == false && LevelOfDifficulty_Normal.Checked == false &&
                LevelOfDifficulty_Hard.Checked == false)
            {
                MessageBox.Show("�������� ������� ��������� !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else // ����������� ������ ���������.
            {
                if (LevelOfDifficulty_Easy.Checked == true)
                    _game.GameDifficulty = 1;
                else if (LevelOfDifficulty_Normal.Checked == true)
                    _game.GameDifficulty = 2;
                else if (LevelOfDifficulty_Hard.Checked == true)
                    _game.GameDifficulty = 3;
            }

            // ���� ��� ���� ��� ������ ���� ���������, �� �������� ������� ���� �� ������.
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            // ����� ���� ��� ���� ��������, ��������� ������ "������ ����� ����" � ������ ������ ��������.
            // �� ���� ����� ������ ��������� �������������.


            StartNewGame_button10.Enabled = false;
            FirstMoveComputer.Enabled = false;
            FirstMovePlayer.Enabled = false;
            PlayCrosses.Enabled = false;
            PlayZeroes.Enabled = false;
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

            // todo:������� 2 ������ ���������
            // �������� ������������ �� ��������
            // ������������� ������
            // ��������� ������.

            // ���� �������, ��� ��������� ����� ������, �� �������� ����� ���� ����������.
            if (FirstMoveComputer.Checked == true)
            {
                _game.PcMove();
                ShowComputerMove();
            }
        }

        private void LevelOfDifficulty_2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    // ����� ����������� ������ ���� � �����������.
    public class Tic_tac_toe_game
    {
        // ������ �������� ����.
        private char[,] arr;

        public char this[int i, int j]
        {
            get { return arr[i, j]; }
            set { arr[i, j] = value; }
        }

        // ������� ��������� ��������� ������� �� �����.
        int _gameDifficulty;
        public int GameDifficulty
        {
            get { return _gameDifficulty; }
            set { _gameDifficulty = value; }
        }

        // ������ ��� ���� ������.
        char _userLetter;
        public char UserLetter { get { return _userLetter; } set { _userLetter = value; } }

        // ������ ��� ���� ����������.
        char _pcLetter;
        public char PcLetter { get { return _pcLetter; } set { _pcLetter = value; } }

        // ��� ����� ������ ?
        int _whoMove; // 0 - ���������, 1 - �����.
        public int WhoMove { get { return _whoMove; } set { _whoMove = value; } }

        // ����� ���������� ����� � ����.
        int _totalMovesInGame;
        public int TotalMovesInGame { get { return _totalMovesInGame; } set { _totalMovesInGame = value; } }

        // �������� �� �����������.
        int _winCheck;
        public int WinCheck
        {
            get
            {
                _winCheck = WinCheckMethod();
                return _winCheck;
            }
            set { _winCheck = value; }
        }

        // ����� �� ������������ ������ ?.
        //bool _userMoveCheckResult;
        //public bool UserMoveCheckResult { get { return _userMoveCheckResult; } set { _userMoveCheckResult = value; } }

        // ���������� ���� ������������ �� �������.
        private Point _playerPointToMove;
        public Point PlayerPointToMove { get { return _playerPointToMove; } set { _playerPointToMove = value; } }

        // �����������.
        public Tic_tac_toe_game()
        {
            arr = new[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            _gameDifficulty = 0;
            _userLetter = '3';
            _pcLetter = '3';
            _whoMove = -1;
            _totalMovesInGame = 9;
            _winCheck = -1;
            //_userMoveCheckResult = false;
            _playerPointToMove = new Point(-1, -1);
        }

        /// <summary>
        /// ���������� ������� � �++.
        /// </summary>

        // ����� �������������� ��������� ������� � ��� �������. ��� ����������� �������� ����� ����������.
        public string ConvertArrCoordinatesToButtonName(int x, int y)
        {
            if (x == 0 && y == 0)
                return "button1";
            else if (x == 0 && y == 1)
                return "button2";
            else if (x == 0 && y == 2)
                return "button3";
            else if (x == 1 && y == 0)
                return "button4";
            else if (x == 1 && y == 1)
                return "button5";
            else if (x == 1 && y == 2)
                return "button6";
            else if (x == 2 && y == 0)
                return "button7";
            else if (x == 2 && y == 1)
                return "button8";
            else
                return "button9";
        }

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
        public bool UserMoveCheck()
        {
            if (arr[PlayerPointToMove.X, PlayerPointToMove.Y] == ' ')
                return true; // ��� ��������.
            else
                return false; // ������ ������, ������ ���� ������.
        }

        // ����� ��������� ���� ������.
        void UserMove()
        {
            arr[PlayerPointToMove.X, PlayerPointToMove.Y] = UserLetter;
        }

        // ����� �������� ������.
        int WinCheckMethod()
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
            else if (TotalMovesInGame == 0)
                return 2; // ���������� ��� ������.
            else
                return 3;
        }

        // ����� ������ ��������� ���������� ��� ���� ���������� � ��������� ������. 
        void PcRandMove()
        {
            Random random = new Random();
            Point point = new Point();

            do
            {
                point.X = random.Next(0, 3); // ��� ������ �� 0 �� 2.
                point.Y = random.Next(0, 3); // ��� ������ �� 0 �� 2.
            } while (arr[point.X, point.Y] != ' ');
            arr[point.X, point.Y] = PcLetter;
        }

        // ����� ������������ ��������� ����. 
        int GameDiff()
        {
            Random random = new Random();

            if (GameDifficulty == 1) // ������ �� 1 �� 5. // Easily
                random.Next(1, 6);
            if (GameDifficulty == 2) // ������ �� 4 �� 8. // Medium
                random.Next(4, 9);
            if (GameDifficulty == 3) // ������ �� 7 �� 10. // Hard
                return random.Next(7, 11);
            else
                return 0;
        }

        // ������ ������� ������ �������� ������� �����������. Easy (������� ������ ������� Medium ���������).
        private void LowLevelComputer(int gameDiff_result)
        {
            PcRandMove(); // ��� ���������� �� ��������� ���� � ����. 
        }

        // ������� ������� ������ �������� ������� �����������. Medium (������� ������� ������� Easy ��������� � ������ ������� Hard ���������).
        private void MediumLevelComputer(int gameDiff_result)
        {

        }

        // ������ ���� ����������.
        int LogicPcMove()
        {
            int rollResult = GameDiff();
            if ((arr[0, 0] == ' ') && (arr[0, 1] == UserLetter) && (arr[0, 2] == UserLetter) ||
                (arr[0, 0] == ' ') &&(arr[0, 1] == PcLetter) && (arr[0, 2] == PcLetter)) // 1 �������������� [_**]
            {
                if (rollResult >= 1 && rollResult <= 4)
                {
                    if (rollResult >= 1 && rollResult <= 3)
                        LowLevelComputer(rollResult);
                    if (rollResult >= 4)
                        MediumLevelComputer(rollResult);


                }
                else if (rollResult >= 4 && rollResult <= 8)
                {
                    if (4)
                }





                if (GameDiff() == 10)

                    arr[0, 0] = PcLetter; // ��������� 90% ����������� ���������� ��� ������ ��� ����������� ���� ����� � ����������.
                else if (GameDiff() == 5) // ��������� 50% ����������� ���������� ��� ������.
                {
                    Random random = new Random();
                    int r = random.Next(1, 3);
                    if (r==1) // ��������� ����������� ��� ������.
                        arr[0, 0] = PcLetter;

                }
                arr[0, 0] = PcLetter;





                if (GameDiff() + GameDifficulty > 10) // 8-10 + 
                else
                            PcRandMove(); // ��� ���������� �� ��������� ���� � ����.
                return 0;
            }
            else if ((arr[0, 0] == UserLetter) && (arr[0, 1] == ' ') && (arr[0, 2] == UserLetter)) // 1 �������������� [*_*]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[0, 1] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == UserLetter) && (arr[0, 1] == UserLetter) && (arr[0, 2] == ' ')) // 1 �������������� [**_]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[0, 2] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == ' ') && (arr[1, 1] == UserLetter) && (arr[1, 2] == UserLetter)) // 2 �������������� [_**]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[1, 0] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == UserLetter) && (arr[1, 1] == ' ') && (arr[1, 2] == UserLetter)) // 2 �������������� [*_*]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[1, 1] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[1, 0] == UserLetter) && (arr[1, 1] == UserLetter) && (arr[1, 2] == ' ')) // 2 �������������� [**_]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[1, 2] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == ' ') && (arr[2, 1] == UserLetter) && (arr[2, 2] == UserLetter)) // 3 �������������� [_**]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[2, 0] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == UserLetter) && (arr[2, 1] == ' ') && (arr[2, 2] == UserLetter)) // 3 �������������� [*_*]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[2, 1] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == UserLetter) && (arr[2, 1] == UserLetter) && (arr[2, 2] == ' ')) // 3 �������������� [**_]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[2, 2] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == ' ') && (arr[1, 0] == UserLetter) && (arr[2, 0] == UserLetter)) // 1 ������������ [_**]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[0, 0] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == UserLetter) && (arr[1, 0] == ' ') && (arr[2, 0] == UserLetter)) // 1 ������������ [*_*]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[1, 0] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == UserLetter) && (arr[1, 0] == UserLetter) && (arr[2, 0] == ' ')) // 1 ������������ [**_]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[2, 0] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == ' ') && (arr[1, 1] == UserLetter) && (arr[2, 1] == UserLetter)) // 2 ������������[_**]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[0, 1] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == UserLetter) && (arr[1, 1] == ' ') && (arr[2, 1] == UserLetter)) // 2 ������������[*_*]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[1, 1] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 1] == UserLetter) && (arr[1, 1] == UserLetter) && (arr[2, 1] == ' ')) // 2 ������������[**_]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[2, 1] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == ' ') && (arr[1, 2] == UserLetter) && (arr[2, 2] == UserLetter)) // 3 ������������ [_**] 
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[0, 2] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == UserLetter) && (arr[1, 2] == ' ') && (arr[2, 2] == UserLetter)) // 3 ������������ [*_*] 
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[1, 2] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 2] == UserLetter) && (arr[1, 2] == UserLetter) && (arr[2, 2] == ' ')) // 3 ������������ [**_] 
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[2, 2] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == ' ') && (arr[1, 1] == UserLetter) && (arr[2, 2] == UserLetter)) // ������� ��������� [_**]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[0, 0] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == UserLetter) && (arr[1, 1] == ' ') && (arr[2, 2] == UserLetter)) // ������� ��������� [*_*]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[1, 1] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[0, 0] == UserLetter) && (arr[1, 1] == UserLetter) && (arr[2, 2] == ' ')) // ������� ��������� [**_]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[2, 2] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == ' ') && (arr[1, 1] == UserLetter) && (arr[0, 2] == UserLetter)) // ������ ��������� [_**]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[2, 0] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == UserLetter) && (arr[1, 1] == ' ') && (arr[0, 2] == UserLetter)) // ������ ��������� [*_*]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[1, 1] = PcLetter;
                else
                    PcRandMove();
                return 0;
            }
            else if ((arr[2, 0] == UserLetter) && (arr[1, 1] == UserLetter) && (arr[0, 2] == ' ')) // ������ ��������� [**_]
            {
                if (GameDiff() + GameDifficulty > 50)
                    arr[0, 2] = PcLetter;
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

        // ��� ����������.
        public void PcMove()
        {
            LogicPcMove();
            TotalMovesInGame--;
            WhoMove = 1; // �������� ���� ������.
            //if (WinCheck == 0) // ������ ����������.
            //{
            //    MessageBox.Show("��������� �������.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    AskPlayMore();
            //}
            //else if (WinCheck == 2) // �����.
            //{
            //    Draw();
            //    AskPlayMore();
            //}
            //else if (WinCheck == 3) // ���������� ������.
            //    return;
        }

        // ��������� �� ������.
        public void Draw()
        {
            MessageBox.Show("�����.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OneStep()
        {
            if (WhoMove == 1) // ������������.
            {
                if (UserMoveCheck())
                {
                    UserMove();
                    TotalMovesInGame--;
                    if (WinCheck == 1) // ������ ������.
                    {
                        MessageBox.Show("����� �������.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AskPlayMore();
                    }
                    else if (WinCheck == 2) // �����.
                    {
                        Draw();
                        AskPlayMore();
                    }
                    else if (WinCheck == 3) // ���������� ������.
                        PcMove();
                }
                else
                    MessageBox.Show("�������� ������ ������.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (WhoMove == 0) // ���������.
                PcMove();
        }

        // ����� ���������� ��� ��������� �� ����� ����.
        private void ReselAllForNewGame() // ����� �������� ����� ��������.
        {
            //Form.ShowDialog();
            //Application.Run(new Form1());
            //for (int i = 0, j = 0; i < 3; i++)
            //    for (int k = 0; k < 3; k++)
            //        arr[i, k] = ' ';
            //GameDifficulty = 0;
            //UserLetter = '3';
            //PcLetter = '3';
            //WhoMove = -1;
            //TotalMovesInGame = 9;
            //WinCheck = -1;
            //PlayerPointToMove = new Point(-1, -1);
        }

        // ������� ��� ?.
        public void AskPlayMore()
        {
            DialogResult result = MessageBox.Show("������� ��� ?", "���� ���������-������.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                Application.Exit();
            else if (result == DialogResult.Yes)
                Application.Restart();
            //ReselAllForNewGame();
        }
    }
}