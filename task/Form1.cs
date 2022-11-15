using System.Diagnostics;
using task.Properties;

namespace task;

public partial class Form1 : Form
{
    /// <summary>
    ///     �������� ���� ���������-������, �������� ��������� ����������:
    ///     * ������� ���� �������� 3�3 ������ �������� �� ������;
    ///     * ��� ������� �� ������, �� ��� ������ ������������ �������� (������� ���
    ///     �����);
    ///     * ���������� ������������� ������� ��������� ������� ��� ����� �� �������
    ///     ������;
    ///     * ������������ ������������ ����� ������ ������� ����, ��������� ������;
    ///     * ������������� ����������� ������ ������ ���������, ���������
    ///     �������������;
    ///     * ������������� ������ ������� ����� ����.
    /// </summary>

    // ������ �� ����� � ������� �� ����.
    private readonly Tic_tac_toe_game _game;

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

        if (_game.UserMoveCheck())
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
        for (var i = 0; i < 3; i++)
        for (var j = 0; j < 3; j++)
            if (_game[i, j] == _game.PcLetter)
                // ���������� ��� ������ �� �����.
                foreach (Control c in Controls)
                    // ���� ����� ������, �� ��������� � ����������.
                    if (c is Button)
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
                                {
                                    return;
                                }
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
                                {
                                    return;
                                }
                            }
                        }
    }

    // ���������� ������� �� ������ "������� ���� � ���������-������."
    private void RulesOfTheGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        // ������ �������� � �������� �������.
        var procInfo = new ProcessStartInfo(@"chrome.exe");
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
        if ((FirstMoveComputer.Checked == false && FirstMovePlayer.Checked == false) ||
            (FirstMoveComputer.Checked && FirstMovePlayer.Checked))
        {
            MessageBox.Show("�������� ��� ����� ������ ������ !", "������ !", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        if (FirstMoveComputer.Checked)
            _game.WhoMove = 0; // ��������� ����� ������.
        else
            _game.WhoMove = 1; // ����� ����� ������.

        // �������� ��� ������ ������ !.
        if ((PlayCrosses.Checked == false && PlayZeroes.Checked == false) ||
            (PlayCrosses.Checked && PlayZeroes.Checked))
        {
            MessageBox.Show("�������� ��� ������ ������ !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        } // ����������� �������� ���� ��� ������ � ����������.

        if (PlayCrosses.Checked)
        {
            _game.UserLetter = 'X'; // ����� ���������� ��������.
            _game.PcLetter = '0'; // ��������� ���������� ������.
        }
        else
        {
            _game.UserLetter = '0'; // ����� ���������� ������.
            _game.PcLetter = 'X'; // ��������� ���������� ��������.
        }

        // �������� ������� ��������� !.
        if ((LevelOfDifficulty_Easy.Checked == false && LevelOfDifficulty_Normal.Checked == false &&
             LevelOfDifficulty_Hard.Checked == false) ||
            (LevelOfDifficulty_Easy.Checked && LevelOfDifficulty_Normal.Checked) ||
            (LevelOfDifficulty_Easy.Checked && LevelOfDifficulty_Hard.Checked) ||
            (LevelOfDifficulty_Normal.Checked && LevelOfDifficulty_Hard.Checked) ||
            (LevelOfDifficulty_Normal.Checked && LevelOfDifficulty_Easy.Checked))
        {
            MessageBox.Show("�������� ������� ��������� !", "������ !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // ����������� ������ ���������.
        if (LevelOfDifficulty_Easy.Checked)
            _game.GameDifficulty = 1;
        else if (LevelOfDifficulty_Normal.Checked)
            _game.GameDifficulty = 2;
        else if (LevelOfDifficulty_Hard.Checked)
            _game.GameDifficulty = 3;

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

        // ���������� ������� ����������.
        StartNewGame_button10.Enabled = false;
        FirstMoveComputer.Enabled = false;
        FirstMovePlayer.Enabled = false;
        PlayCrosses.Enabled = false;
        PlayZeroes.Enabled = false;
        LevelOfDifficulty_Easy.Enabled = false;
        LevelOfDifficulty_Normal.Enabled = false;
        LevelOfDifficulty_Hard.Enabled = false;

        // ���� �������, ��� ��������� ����� ������, �� �������� ����� ���� ����������.
        if (FirstMoveComputer.Checked)
        {
            _game.PcMove();
            ShowComputerMove();
        }
    }
}

// ����� ����������� ������ ���� � �����������.
public class Tic_tac_toe_game
{
    // �������� �� �����������.
    private int _winCheck;

    // ������ �������� ����.
    private readonly char[,] arr;

    // �����������.
    public Tic_tac_toe_game()
    {
        arr = new[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        GameDifficulty = 0;
        UserLetter = '3';
        PcLetter = '3';
        WhoMove = -1;
        TotalMovesInGame = 9;
        _winCheck = -1;
        PlayerPointToMove = new Point(-1, -1);
    }

    public char this[int i, int j]
    {
        get => arr[i, j];
        set => arr[i, j] = value;
    }

    // ������� ��������� ��������� ������� �� �����.
    public int GameDifficulty { get; set; }

    // ������ ��� ���� ������.
    public char UserLetter { get; set; }

    // ������ ��� ���� ����������.
    public char PcLetter { get; set; }

    // ��� ����� ������ ?
    public int WhoMove { get; set; }

    // ����� ���������� ����� � ����.
    public int TotalMovesInGame { get; set; }

    public int WinCheck
    {
        get
        {
            _winCheck = WinCheckMethod();
            return _winCheck;
        }
        set => _winCheck = value;
    }

    // ���������� ���� ������������ �� �������.
    public Point PlayerPointToMove { get; set; }

    // ����� �������������� ��������� ������� � ��� �������. ��� ����������� �������� ����� ����������.
    public string ConvertArrCoordinatesToButtonName(int x, int y)
    {
        if (x == 0 && y == 0)
            return "button1";
        if (x == 0 && y == 1)
            return "button2";
        if (x == 0 && y == 2)
            return "button3";
        if (x == 1 && y == 0)
            return "button4";
        if (x == 1 && y == 1)
            return "button5";
        if (x == 1 && y == 2)
            return "button6";
        if (x == 2 && y == 0)
            return "button7";
        if (x == 2 && y == 1)
            return "button8";
        return "button9";
    }

    // ����� �������������� ������� ������ � ���������� �������.
    public Point ConvertButtonToCoordinates(Button button)
    {
        var coordinates = new Point();

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
        return false; // ������ ������, ������ ���� ������.
    }

    // ����� ��������� ���� ������.
    private void UserMove()
    {
        arr[PlayerPointToMove.X, PlayerPointToMove.Y] = UserLetter;
    }

    // ����� �������� ������.
    private int WinCheckMethod()
    {
        if ((arr[0, 0] == UserLetter && arr[0, 1] == UserLetter && arr[0, 2] == UserLetter) || // 1 ��������������
            (arr[1, 0] == UserLetter && arr[1, 1] == UserLetter && arr[1, 2] == UserLetter) || // 2 ��������������
            (arr[2, 0] == UserLetter && arr[2, 1] == UserLetter && arr[2, 2] == UserLetter) || // 3 ��������������
            (arr[0, 0] == UserLetter && arr[1, 0] == UserLetter && arr[2, 0] == UserLetter) || // 1 ������������
            (arr[0, 1] == UserLetter && arr[1, 1] == UserLetter && arr[2, 1] == UserLetter) || // 2 ������������ 
            (arr[0, 2] == UserLetter && arr[1, 2] == UserLetter && arr[2, 2] == UserLetter) || // 3 ������������ 
            (arr[0, 0] == UserLetter && arr[1, 1] == UserLetter && arr[2, 2] == UserLetter) || // ������� ���������
            (arr[2, 0] == UserLetter && arr[1, 1] == UserLetter && arr[0, 2] == UserLetter)) // �������������� ���������
            return 1; // ���������� ��� ������ ������.
        if ((arr[0, 0] == PcLetter && arr[0, 1] == PcLetter && arr[0, 2] == PcLetter) || // 1 ��������������
            (arr[1, 0] == PcLetter && arr[1, 1] == PcLetter && arr[1, 2] == PcLetter) || // 2 ��������������
            (arr[2, 0] == PcLetter && arr[2, 1] == PcLetter && arr[2, 2] == PcLetter) || // 3 ��������������
            (arr[0, 0] == PcLetter && arr[1, 0] == PcLetter && arr[2, 0] == PcLetter) || // 1 ������������
            (arr[0, 1] == PcLetter && arr[1, 1] == PcLetter && arr[2, 1] == PcLetter) || // 2 ������������ 
            (arr[0, 2] == PcLetter && arr[1, 2] == PcLetter && arr[2, 2] == PcLetter) || // 3 ������������ 
            (arr[0, 0] == PcLetter && arr[1, 1] == PcLetter && arr[2, 2] == PcLetter) || // ������� ���������
            (arr[2, 0] == PcLetter && arr[1, 1] == PcLetter && arr[0, 2] == PcLetter)) // �������������� ���������
            return 0; // ���������� ��� ������ ����������.
        if (TotalMovesInGame == 0)
            return 2; // ���������� ��� ������.
        return 3;
    }

    // ����� ������ ��������� ���������� ��� ���� ���������� � ��������� ������. 
    private void PcRandMove()
    {
        var random = new Random();
        var point = new Point();

        do
        {
            point.X = random.Next(0, 3); // ��� ������ �� 0 �� 2.
            point.Y = random.Next(0, 3); // ��� ������ �� 0 �� 2.
        } while (arr[point.X, point.Y] != ' ');

        arr[point.X, point.Y] = PcLetter;
    }

    // ������ ����� ����������.
    private void LogicPcMove()
    {
        var random = new Random();
        var r = random.Next(0, 101);

        if (arr[0, 0] == ' ' && arr[0, 1] == UserLetter && arr[0, 2] == UserLetter) // 1 �������������� [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
        }
        else if ((arr[0, 0] == UserLetter && arr[0, 1] == ' ' && arr[0, 2] == UserLetter) ||
                 (arr[0, 0] == PcLetter && arr[0, 1] == ' ' && arr[0, 2] == PcLetter)) // 1 �������������� [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[0, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[0, 1] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[0, 1] == UserLetter && arr[0, 2] == ' ') // 1 �������������� [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
        }
        else if (arr[1, 0] == ' ' && arr[1, 1] == UserLetter && arr[1, 2] == UserLetter) // 2 �������������� [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[1, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[1, 0] = PcLetter;
            }
        }
        else if (arr[1, 0] == UserLetter && arr[1, 1] == ' ' && arr[1, 2] == UserLetter) // 2 �������������� [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
        }
        else if (arr[1, 0] == UserLetter && arr[1, 1] == UserLetter && arr[1, 2] == ' ') // 2 �������������� [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[1, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[1, 2] = PcLetter;
            }
        }
        else if (arr[2, 0] == ' ' && arr[2, 1] == UserLetter && arr[2, 2] == UserLetter) // 3 �������������� [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
        }
        else if (arr[2, 0] == UserLetter && arr[2, 1] == ' ' && arr[2, 2] == UserLetter) // 3 �������������� [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[2, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[2, 1] = PcLetter;
            }
        }
        else if (arr[2, 0] == UserLetter && arr[2, 1] == UserLetter && arr[2, 2] == ' ') // 3 �������������� [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
        }
        else if (arr[0, 0] == ' ' && arr[1, 0] == UserLetter && arr[2, 0] == UserLetter) // 1 ������������ [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[1, 0] == ' ' && arr[2, 0] == UserLetter) // 1 ������������ [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[1, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[1, 0] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[1, 0] == UserLetter && arr[2, 0] == ' ') // 1 ������������ [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
        }
        else if (arr[0, 1] == ' ' && arr[1, 1] == UserLetter && arr[2, 1] == UserLetter) // 2 ������������[_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[0, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[0, 1] = PcLetter;
            }
        }
        else if (arr[0, 1] == UserLetter && arr[1, 1] == ' ' && arr[2, 1] == UserLetter) // 2 ������������[*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
        }
        else if (arr[0, 1] == UserLetter && arr[1, 1] == UserLetter && arr[2, 1] == ' ') // 2 ������������[**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[2, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[2, 1] = PcLetter;
            }
        }
        else if (arr[0, 2] == ' ' && arr[1, 2] == UserLetter && arr[2, 2] == UserLetter) // 3 ������������ [_**] 
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
        }
        else if (arr[0, 2] == UserLetter && arr[1, 2] == ' ' && arr[2, 2] == UserLetter) // 3 ������������ [*_*] 
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[1, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[1, 2] = PcLetter;
            }
        }
        else if (arr[0, 2] == UserLetter && arr[1, 2] == UserLetter && arr[2, 2] == ' ') // 3 ������������ [**_] 
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
        }
        else if (arr[0, 0] == ' ' && arr[1, 1] == UserLetter && arr[2, 2] == UserLetter) // ������� ��������� [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[0, 0] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[1, 1] == ' ' && arr[2, 2] == UserLetter) // ������� ��������� [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
        }
        else if (arr[0, 0] == UserLetter && arr[1, 1] == UserLetter && arr[2, 2] == ' ') // ������� ��������� [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[2, 2] = PcLetter;
            }
        }
        else if (arr[2, 0] == ' ' && arr[1, 1] == UserLetter && arr[0, 2] == UserLetter) // ������ ��������� [_**]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[2, 0] = PcLetter;
            }
        }
        else if (arr[2, 0] == UserLetter && arr[1, 1] == ' ' && arr[0, 2] == UserLetter) // ������ ��������� [*_*]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[1, 1] = PcLetter;
            }
        }
        else if (arr[2, 0] == UserLetter && arr[1, 1] == UserLetter && arr[0, 2] == ' ') // ������ ��������� [**_]
        {
            if (GameDifficulty == 1)
            {
                PcRandMove(); // ������ � ����� �����.
            }
            else if (GameDifficulty == 2)
            {
                if (r < 50) // � ������ 50% ����� � �����.
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
            else if (GameDifficulty == 3)
            {
                if (r < 20) // � ������ 20% ����� � �����
                    PcRandMove();
                else
                    arr[0, 2] = PcLetter;
            }
        }
        else
        {
            PcRandMove();
        }
    }

    // ��� ����������.
    public void PcMove()
    {
        LogicPcMove();
        TotalMovesInGame--;
        WhoMove = 1; // �������� ���� ������.
    }

    // ��������� �� ������.
    public void Draw()
    {
        MessageBox.Show("�����.", "���� ���������-������.", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // ���� ���, ����� ������� ������������ �� ������ �� ������� ����.
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
                    MessageBox.Show("����� �������.", "���� ���������-������.", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    AskPlayMore();
                }
                else if (WinCheck == 2) // �����.
                {
                    Draw();
                    AskPlayMore();
                }
                else if (WinCheck == 3) // ���������� ������.
                {
                    PcMove();
                }
            }
            else
            {
                MessageBox.Show("�������� ������ ������.", "���� ���������-������.", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        if (WhoMove == 0) // ���������.
            PcMove();
    }

    // ������� ��� ?.
    public void AskPlayMore()
    {
        var result = MessageBox.Show("������� ��� ?", "���� ���������-������.", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (result == DialogResult.No)
            Application.Exit();
        else if (result == DialogResult.Yes)
            Application.Restart();
    }
}