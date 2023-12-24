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
        private readonly HairbrushParameters _parameters = new HairbrushParameters();

        /// <summary>
        /// Объект для построения расчёски.
        /// </summary>
        private readonly HairbrushBuilder _hairbrushBuilder = new HairbrushBuilder();

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
        /// <param name="parameterType">Тип параметра.</param>
        /// <param name="textBox">Текстовое поле.</param>
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
                _errors[parameterType] = "Некорректный формат данных.";
            }
        }

        /// <summary>
        /// Обработка события наведения мыши.
        /// </summary>
        /// <param name="parameterType">Тип параметра.</param>
        /// <param name="textBox">Текстовое поле.</param>
        private void ProcessingMouseEnters(ParameterType parameterType, TextBox textBox)
        {
            if (_errors[parameterType] != "")
            {
                commonToolTip.SetToolTip(textBox, _errors[parameterType]);
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

        /// <summary>
        /// Обработчик изменения текста в поле для ввода длины ручки.
        /// Вызывает метод обработки изменений текста.
        /// </summary>
        private void HandleLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.HandleLength, HandleLengthTextBox);
        }

        /// <summary>
        /// Обработчик изменения текста в поле для ввода количества зубьев.
        /// Вызывает метод обработки изменений текста.
        /// </summary>
        private void NumberOfTeethTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.NumberOfTeeth, NumberOfTeethTextBox);
        }

        /// <summary>
        /// Обработчик изменения текста в поле для ввода длины зубьев.
        /// Вызывает метод обработки изменений текста.
        /// </summary>
        private void LengthOfTeethTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.LengthOfTeeth, LengthOfTeethTextBox);
        }

        /// <summary>
        /// Обработчик изменения текста в поле для ввода расстояния между зубьями.
        /// Вызывает метод обработки изменений текста.
        /// </summary>
        private void DistanceBetweenTeethTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.DistanceBetweenTeeth, DistanceBetweenTeethTextBox);
        }

        /// <summary>
        /// Обработчик изменения текста в поле для ввода ширины зубьев.
        /// Вызывает метод обработки изменений текста.
        /// </summary>
        private void WidthOfTeethTextBox_TextChanged(object sender, EventArgs e)
        {
            ProcessingTextChanges(ParameterType.WidthOfTeeth, WidthOfTeethTextBox);
        }

        /// <summary>
        /// Обработчик события наведения мыши в текстовое поле с количеством зубцов.
        /// Вызывает метод обработки события "мышь входит".
        /// </summary>
        private void NumberOfTeethTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.NumberOfTeeth, NumberOfTeethTextBox);
        }

        /// <summary>
        /// Обработчик события наведения мыши в текстовое поле с длиной ручки.
        /// Вызывает метод обработки события "мышь входит".
        /// </summary>
        private void HandleLengthTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.HandleLength, HandleLengthTextBox);
        }

        /// <summary>
        /// Обработчик события наведения мыши в текстовое поле с длиной зубьев.
        /// Вызывает метод обработки события "мышь входит".
        /// </summary>
        private void LengthOfTeethTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.LengthOfTeeth, LengthOfTeethTextBox);
        }

        /// <summary>
        /// Обработчик события наведения мыши в текстовое поле с расстоянием между зубьями.
        /// Вызывает метод обработки события "мышь входит".
        /// </summary>
        private void DistanceBetweenTeethTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.DistanceBetweenTeeth, DistanceBetweenTeethTextBox);
        }

        /// <summary>
        /// Обработчик события наведения мыши в текстовое поле с шириной зубьев.
        /// Вызывает метод обработки события "мышь входит".
        /// </summary>
        private void WidthOfTeethTextBox_MouseEnter(object sender, EventArgs e)
        {
            ProcessingMouseEnters(ParameterType.WidthOfTeeth, WidthOfTeethTextBox);
        }
    }
}