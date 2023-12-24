namespace HairbrushPlugin
{
    using Model;
    using Wrapper;

    /// <summary>
    /// ������� ����.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// ������� ��� ����������� ������.
        /// </summary>
        private readonly Dictionary<ParameterType, string> _errors = new Dictionary<ParameterType, string>()
        {
            { ParameterType.HandleLength, "" },
            { ParameterType.NumberOfTeeth, "" },
            { ParameterType.LengthOfTeeth, "" },
            { ParameterType.DistanceBetweenTeeth, "" },
            { ParameterType.WidthOfTeeth, "" }
        };

        /// <summary>
        /// ���� ��� ��������� �����.
        /// </summary>
        private readonly Color _incorrectBackColor = Color.LightPink;

        /// <summary>
        /// ���� ��� ������� �����.
        /// </summary>
        private readonly Color _correctBackColor = Color.White;

        /// <summary>
        /// ����������� ���������, ������������ �� �����.
        /// </summary>
        private readonly ToolTip commonToolTip = new ToolTip();

        /// <summary>
        /// ��������� ��� ������� ������������� ��������.
        /// </summary>
        private readonly HairbrushParameters _parameters = new HairbrushParameters();

        /// <summary>
        /// ������ ��� ���������� ��������.
        /// </summary>
        private readonly HairbrushBuilder _hairbrushBuilder = new HairbrushBuilder();

        /// <summary>
        /// ����������� ������ MainForm.
        /// �������������� ���������� �����.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            TextBoxesFilling();
        }

        /// <summary>
        /// ���������� ����������� ����������� �� ���������.
        /// </summary>
        private void TextBoxesFilling()
        {
            HandleLengthTextBox.Text = _parameters.Parameters[ParameterType.HandleLength]
                .Value.ToString();
            NumberOfTeethTextBox.Text = _parameters.Parameters[ParameterType.NumberOfTeeth]
                .Value.ToString();
            LengthOfTeethTextBox.Text = _parameters.Parameters[ParameterType.LengthOfTeeth]
                .Value.ToString();
            DistanceBetweenTeethTextBox.Text = _parameters.Parameters[ParameterType.DistanceBetweenTeeth]
                .Value.ToString();
            WidthOfTeethTextBox.Text = _parameters.Parameters[ParameterType.WidthOfTeeth]
                .Value.ToString();
        }

        /// <summary>
        /// ��������� ��������� ������.
        /// </summary>
        /// <param name="parameterType">��� ���������.</param>
        /// <param name="textBox">��������� ����.</param>
        private void ProcessingTextChanges(ParameterType parameterType, TextBox textBox)
        {
            try
            {
                _parameters.Parameters[parameterType].Value = double.Parse(textBox.Text);
                _errors[parameterType] = "";
                textBox.BackColor = _correctBackColor;
            }
            catch (ArgumentException exception)
            {
                textBox.BackColor = _incorrectBackColor;
                _errors[parameterType] = exception.Message;
            }
            catch
            {
                textBox.BackColor = _incorrectBackColor;
                _errors[parameterType] = "������������ ������ ������.";
            }
        }

        /// <summary>
        /// ��������� ������� ��������� ����.
        /// </summary>
        /// <param name="parameterType">��� ���������.</param>
        /// <param name="textBox">��������� ����.</param>
        private void ProcessingMouseEnters(ParameterType parameterType, TextBox textBox)
        {
            if (_errors[parameterType] != "")
            {
                commonToolTip.SetToolTip(textBox, _errors[parameterType]);
            }
        }

        /// <summary>
        /// �������� ����� �� ������� ������.
        /// </summary>
        /// <returns>True, ���� ������ ���. ����� - false.</returns>
        private bool CheckFormOnErrors()
        {
            string errorMessage = "";
            foreach (var error in _errors)
            {
                if (error.Value != "")
                {
                    errorMessage = errorMessage + "- " + error.Value + "\n";
                }
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���������� ������� ������ "Build".
        /// ��������� ����� �� ������� ������ �, � ������ �� ����������, ������ ��������.
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (CheckFormOnErrors())
            {
                _hairbrushBuilder.BuildHairbrush(_parameters);
            }
        }

        /// <summary>
        /// ���������� ��������� ������ � ���� ��� ����� ����� �����.
        /// �������� ����� ��������� ��������� ������.
        /// </summary>
        private void HandleLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.HandleLength, HandleLengthTextBox);
        }

        /// <summary>
        /// ���������� ��������� ������ � ���� ��� ����� ���������� ������.
        /// �������� ����� ��������� ��������� ������.
        /// </summary>
        private void NumberOfTeethTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.NumberOfTeeth, NumberOfTeethTextBox);
        }

        /// <summary>
        /// ���������� ��������� ������ � ���� ��� ����� ����� ������.
        /// �������� ����� ��������� ��������� ������.
        /// </summary>
        private void LengthOfTeethTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.LengthOfTeeth, LengthOfTeethTextBox);
        }

        /// <summary>
        /// ���������� ��������� ������ � ���� ��� ����� ���������� ����� �������.
        /// �������� ����� ��������� ��������� ������.
        /// </summary>
        private void DistanceBetweenTeethTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.DistanceBetweenTeeth, DistanceBetweenTeethTextBox);
        }

        /// <summary>
        /// ���������� ��������� ������ � ���� ��� ����� ������ ������.
        /// �������� ����� ��������� ��������� ������.
        /// </summary>
        private void WidthOfTeethTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.WidthOfTeeth, WidthOfTeethTextBox);
        }

        /// <summary>
        /// ���������� ������� ��������� ���� � ��������� ���� � ����������� ������.
        /// �������� ����� ��������� ������� "���� ������".
        /// </summary>
        private void NumberOfTeethTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.NumberOfTeeth, NumberOfTeethTextBox);
        }

        /// <summary>
        /// ���������� ������� ��������� ���� � ��������� ���� � ������ �����.
        /// �������� ����� ��������� ������� "���� ������".
        /// </summary>
        private void HandleLengthTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.HandleLength, HandleLengthTextBox);
        }

        /// <summary>
        /// ���������� ������� ��������� ���� � ��������� ���� � ������ ������.
        /// �������� ����� ��������� ������� "���� ������".
        /// </summary>
        private void LengthOfTeethTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.LengthOfTeeth, LengthOfTeethTextBox);
        }

        /// <summary>
        /// ���������� ������� ��������� ���� � ��������� ���� � ����������� ����� �������.
        /// �������� ����� ��������� ������� "���� ������".
        /// </summary>
        private void DistanceBetweenTeethTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.DistanceBetweenTeeth, DistanceBetweenTeethTextBox);
        }

        /// <summary>
        /// ���������� ������� ��������� ���� � ��������� ���� � ������� ������.
        /// �������� ����� ��������� ������� "���� ������".
        /// </summary>
        private void WidthOfTeethTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.WidthOfTeeth, WidthOfTeethTextBox);
        }
    }
}