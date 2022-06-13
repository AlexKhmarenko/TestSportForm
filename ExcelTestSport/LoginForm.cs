using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Application = System.Windows.Forms.Application;

namespace ExcelTestSport
{
    public partial class LoginForm : Form
    {

       // test test;
        public LoginForm()
        {
            InitializeComponent();
        }

        public void EnterVariant_Click(object sender, EventArgs e)
        {
            string adress = $"{Environment.CurrentDirectory}\\Questions\\Questions.xlsx"; //Путь к вопросам

            Excel.Application xlApp = new Excel.Application();
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(adress);
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.ActiveSheet;


            string codeOfTest = "";
            bool code = true;

            while (code)
            {
                codeOfTest = codeVariant.Text;
                for (int i = 1; i <= xlWorkbook.Sheets.Count; i++)
                {
                    xlWorksheet = xlWorkbook.Sheets[i];
                    if (xlWorksheet.Name == codeOfTest)
                    {
                        code = false;
                        DataBase.GlobalCodeOfTest = codeOfTest;
                        break;
                    }
                }
                if (code != false)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(xlWorksheet);
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    MessageBox.Show("Код введен неверно. Повторите попытку: ");
                    codeVariant.Text = "";
                    codeVariant.Focus();
                    return;
                }
                
            }

            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count; //Строки
            rowCount = xlRange.Rows.Count;           //Вычисление количества вопросов
            string[,] questions = new string[rowCount - 1, 9];//0 - Вид спорта
                                                              //1 - Категория
                                                              //2 - Вопрос
                                                              //3 - Вариант ответа
                                                              //4 - Балл
                                                              //5 - максимальный балл
                                                              //6 - Верный ответ
                                                              //7 - Ответ пользователя
                                                              //8 - Время на ответ


            

            for (int i = 2; i <= rowCount; i++)                 //Заполнение массива с вопросами
            {
                if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        questions[i - 2, j] = Convert.ToString(xlRange.Cells[i, j + 1].Value2);

                    }
                }
                else
                {
                    i++;
                }
            }
            string temp;

            for (int i = 0; i < questions.GetUpperBound(0) + 1; i++)
            {
                temp = questions[i, 0].ToUpper();
                questions[i, 0] = temp;
                temp = questions[i, 1].ToUpper();
                questions[i, 1] = temp;
                temp = questions[i, 2].ToUpper();
                questions[i, 2] = temp;
            }
            

            FillRightAnswers(questions, rowCount); // Дополнение массива верными ответами


            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            DataBase.GlobalQuestions = questions; //отправка массива с вопросами в общедоступное хранилище
            this.Hide();

            testForm TestForm = new testForm();
            TestForm.Show();

        }
        static void FillRightAnswers(string[,] questions, int number)
        {
            string question = "";
            int topScore = 0;

            for (int i = 0; i < number; i++)
            {
                string rightAnswer = "";
                int d = i;
                int qq = 0;
                while (d < number - 1)
                {

                    question = questions[d, 2];
                    topScore = Convert.ToInt32(questions[i, 4]);
                    rightAnswer = questions[i, 3];
                    while (questions[d, 2] == question)  /// Определение максимального балла
                    {
                        if (Convert.ToInt32(questions[d, 4]) > topScore)
                        {
                            topScore = Convert.ToInt32(questions[d, 4]);
                            rightAnswer = questions[d, 3];
                        }
                        d++;
                        qq++;

                        if (d >= number - 1)
                        {
                            break;
                        }
                    }
                    d = i;
                    for (int j = 0; j < qq; j++)        //Внесение максимального балла в массив
                    {
                        questions[d, 5] = Convert.ToString(topScore);
                        questions[d, 6] = rightAnswer;
                        d++;

                        if (d >= number - 1)
                        {
                            break;
                        }
                    }
                    i += qq;
                    qq = 0;
                }
            }
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            codeVariant.Focus();
        }

        private void exitBottom_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Хотите прервать тест?", "Окончание теста", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private void exitBottom_MouseEnter(object sender, EventArgs e)
        {
            exitBottom.ForeColor = Color.Red;
        }

        private void exitBottom_MouseLeave(object sender, EventArgs e)
        {
            exitBottom.ForeColor = Color.Black;
        }
    }

}
