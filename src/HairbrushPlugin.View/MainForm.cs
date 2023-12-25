namespace HairbrushPlugin
{
    using Model;
    using Wrapper;

    /// <summary>
    /// Главное окно.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Словарь для отображения ошибок.
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
        /// Цвет для неверного ввода.
        /// </summary>
        private readonly Color _incorrectBackColor = Color.LightPink;

        /// <summary>
        /// Цвет для верного ввода.
        /// </summary>
        private readonly Color _correctBackColor = Color.White;

        /// <summary>
        /// Всплывающая подсказка, используемая на форме.
        /// </summary>
        private readonly ToolTip commonToolTip = new ToolTip();

        /// <summary>
        /// Параметры для расчёта характеристик расчёски.
        /// </summary>
        private readonly HairbrushParameters _parameters = new();

        /// <summary>
        /// Объект для построения расчёски.
        /// </summary>
        private readonly HairbrushBuilder _hairbrushBuilder = new();

        /// <summary>
        /// Конструктор класса MainForm.
        /// Инициализирует компоненты формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            TextBoxesFilling();
        }

        /// <summary>
        /// Заполнение текстбоксов параметрами по умолчанию.
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
        /// Обработка изменений текста.
        /// </summary>
        private void ProcessingTextChanges(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var parameterTypeStr = textBox.Name[..^"TextBox".Length];

                if (Enum.TryParse(typeof(ParameterType), parameterTypeStr, out object result))
                {
                    var parameterType = (ParameterType)result;
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
                        _errors[parameterType] = "Некорректный формат данных.";
                    }
                }
            }
        }

        /// <summary>
        /// Обработка события наведения мыши.
        /// </summary>
        private void ProcessingMouseEnters(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var parameterTypeStr = textBox.Name[..^"TextBox".Length];

                if (Enum.TryParse(typeof(ParameterType), parameterTypeStr, out object result))
                {
                    var parameterType = (ParameterType)result;
                    if (_errors[parameterType] != "")
                    {
                        commonToolTip.SetToolTip(textBox, _errors[parameterType]);
                    }
                }
            }
        }

        /// <summary>
        /// Проверка формы на наличие ошибок.
        /// </summary>
        /// <returns>True, если ошибок нет. Иначе - false.</returns>
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
        /// Обработчик нажатия кнопки "Build".
        /// Проверяет форму на наличие ошибок и, в случае их отсутствия, строит расчёску.
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (CheckFormOnErrors())
            {
                _hairbrushBuilder.BuildHairbrush(_parameters);
            }
        }
    }
}