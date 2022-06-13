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
    public partial class testForm : Form
    {
        public int questionNumber = 0; //счетчик вопросов
        public string[,] questions; //массив с вопросами
        public string[,] test; //массив с вариантами ответов
        public int numberOfQuestions = 0; //Количество вопросов
        public int numVariants = 0;
        public DateTime t1, t2; //счетчик времени

        public testForm()
        {
            InitializeComponent();

            string[,] questions = DataBase.GlobalQuestions; //загрузка массива с вопросами

            string question; //переменная для работы с вопросами
            question = questions[0, 2]; //получение количества вопросов
            for (int i = 0; i < questions.GetUpperBound(0) + 1; i++)
            {
                if (questions[i, 2] == question)
                {
                    questions[i, 2] = question;
                }
                else
                {
                    question = questions[i, 2];
                    numberOfQuestions++;
                }
            }
            numberOfQuestions++;
                                                      
            test = new string[numberOfQuestions, 7];  //создание массива с вариантами ответов нужного размера
                                                      //0 - Вид спорта
                                                      //1 - Категория
                                                      //2 - Вопрос
                                                      //3 - Вариант ответа 1
                                                      //4 - Вариант ответа 2
                                                      //5 - Вариант ответа 3
                                                      //6 - Вариант ответа 4
                                                      //7 - Ответ юзера
                                                      //8 - Время на ответ
            numberOfQuestions = 0;
            int count = 0;                  //варианты ответов в массиве с ответами
            question = questions[0, 2];     //заполнение массива с вариантами ответов
            for (int i = 0; i < questions.GetUpperBound(0) + 1; i++)
            {
                if (questions[i, 2] == question)
                {
                    test[numberOfQuestions, 0] = questions[i, 0];
                    test[numberOfQuestions, 1] = questions[i, 1];
                    test[numberOfQuestions, 2] = questions[i, 2];
                    test[numberOfQuestions, 3 + count] = questions[i, 3];
                }
                else
                {
                    question = questions[i, 2];
                    numberOfQuestions++;
                    count = -1;
                    i--;
                }
                count++;
            }

            fillForm();

        }

        public void fillForm()
        {
            int numVariants = 0; //Количество вариантов ответов

            QuestionNumber.Text = $"Вопрос {questionNumber+1} из {numberOfQuestions + 1}";
            SportType.Text = $"Вид спорта: {test[questionNumber, 0]}";
            Category.Text = $"Категория:  {test[questionNumber, 1]}";
            QuestionBox.Text = $"Вопрос: {test[questionNumber, 2]}";

            for (int j = 0; j < 4; j++)
            {
                if (test[questionNumber, j + 3] != null)
                {
                    numVariants++;
                }
                else
                {
                    break;
                }
            }

            if (numVariants == 2)
            {
                AnswerVar1.Text = test[questionNumber, 3];
                AnswerVar2.Text = test[questionNumber, 4];
                AnswerVar3.Visible = false;
                AnswerVar4.Visible = false;
            }
            else
            {
                AnswerVar3.Visible = true;
                AnswerVar4.Visible = true;
                AnswerVar1.Text = Convert.ToString(test[questionNumber, 3]);
                AnswerVar2.Text = Convert.ToString(test[questionNumber, 4]);
                AnswerVar3.Text = Convert.ToString(test[questionNumber, 5]);
                AnswerVar4.Text = Convert.ToString(test[questionNumber, 6]);
            }
            t1 = DateTime.Now;
        }

        public void AnswerVar1_Click(object sender, EventArgs e)
        {
            AnswerVar2.Checked = false;
            AnswerVar3.Checked = false;
            AnswerVar4.Checked = false;
        }

        public void AnswerVar2_Click(object sender, EventArgs e)
        {
            AnswerVar1.Checked = false;
            AnswerVar3.Checked = false;
            AnswerVar4.Checked = false;
        }

        public void AnswerVar3_Click(object sender, EventArgs e)
        {
            AnswerVar1.Checked = false;
            AnswerVar2.Checked = false;
            AnswerVar4.Checked = false;
        }


        public void AnswerVar4_Click(object sender, EventArgs e)
        {
            AnswerVar1.Checked = false;
            AnswerVar2.Checked = false;
            AnswerVar3.Checked = false;
        }

        private void answerBottom_Click(object sender, EventArgs e)
        {
            questions = DataBase.GlobalQuestions;

            if (AnswerVar1.Checked == false && 
                AnswerVar2.Checked == false && 
                AnswerVar3.Checked == false && 
                AnswerVar4.Checked == false)
            {
                MessageBox.Show("Выберите вариант ответа");
            }
            else
            {
                t2 = DateTime.Now;
                TimeSpan ts = t2 - t1;
                string time = Convert.ToString(ts.Hours.ToString() + " минут " + ts.Seconds.ToString() + " секунд");

                if (AnswerVar1.Checked == true)
                {
                    FillFinalResult(AnswerVar1.Text, time);

                }
                else if (AnswerVar2.Checked == true)
                {
                    FillFinalResult(AnswerVar2.Text, time);

                }
                else if (AnswerVar3.Checked == true)
                {
                    FillFinalResult(AnswerVar3.Text, time);
                }
                else if (AnswerVar4.Checked == true)
                {
                    FillFinalResult(AnswerVar4.Text, time);
                }

                if (questionNumber == numberOfQuestions)
                {
                    ReportToExcel();
                    MessageBox.Show("ВСЬО");
                    Application.Exit();

                }
                else
                {
                    questionNumber++;
                    AnswerVar1.Checked = false;
                    AnswerVar2.Checked = false;
                    AnswerVar3.Checked = false;
                    AnswerVar4.Checked = false;
                    fillForm();
                }
            }
        }

        public void FillFinalResult(string answerVar, string t)
        {
            for (int d = 0; questionNumber < questions.GetUpperBound(0) + 1; d++)
            {
                if (test[questionNumber, 2] == questions[d, 2] && answerVar == questions[d, 3])
                {
                    questions[d, 7] = answerVar;
                    questions[d, 8] = t;
                    break;
                }
            }
        }

        public void ReportToExcel()
        {

            string codeOfTest = DataBase.GlobalCodeOfTest;

            Excel.Application excel = new Excel.Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;
            Excel.Workbook workBook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.ActiveSheet;

            workSheet.Name = codeOfTest;

            Excel.Range xlRange = workSheet.UsedRange;

            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 8]].Merge();
            workSheet.Range[workSheet.Cells[2, 1], workSheet.Cells[2, 8]].Merge();
            workSheet.Range[workSheet.Cells[3, 1], workSheet.Cells[3, 8]].Merge();
            workSheet.Cells[1, 1] = $"Результаты тестирования по коду идентификатора {codeOfTest}";
            workSheet.Cells[2, 1] = $"Время тестирования: {DateTime.Now.ToString()}";
            workSheet.Cells[5, 1] = "№";
            workSheet.Cells[5, 2] = "Вид спорта";
            workSheet.Cells[5, 3] = "Категория";
            workSheet.Cells[5, 4] = "Вопрос";
            workSheet.Cells[5, 5] = "Ответ пользователя";
            workSheet.Cells[5, 6] = "Верный ответ";
            workSheet.Cells[5, 7] = "Балл";
            workSheet.Cells[5, 8] = "Время на ответ";

            int questionNum = 1;
            int score = 0;
            int maxScore = 0;

            for (int i = 0; i < questions.GetUpperBound(0) + 1; i++)
            {

                if (questions[i, 7] != null)
                {
                    workSheet.Cells[questionNum + 5, 1] = questionNum;
                    workSheet.Cells[questionNum + 5, 2] = questions[i, 0];
                    workSheet.Cells[questionNum + 5, 3] = questions[i, 1];
                    workSheet.Cells[questionNum + 5, 4] = questions[i, 2];
                    workSheet.Cells[questionNum + 5, 5] = questions[i, 7];
                    workSheet.Cells[questionNum + 5, 6] = questions[i, 6];
                    workSheet.Cells[questionNum + 5, 7] = questions[i, 4];
                    workSheet.Cells[questionNum + 5, 8] = questions[i, 8];

                    questionNum++;
                    score += Convert.ToInt32(questions[i, 4]);
                    maxScore += Convert.ToInt32(questions[i, 5]);
                }

            }
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
            workSheet.Columns[3].AutoFit();
            workSheet.Columns[4].AutoFit();
            workSheet.Columns[5].AutoFit();
            workSheet.Columns[6].AutoFit();
            workSheet.Columns[7].AutoFit();
            workSheet.Columns[8].AutoFit();

            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[2, 8]].Font.Size = 15;

            workSheet.Cells[questionNum + 7, 1] = $"Пользователь набрал {score} из {maxScore} возможных баллов";
            workSheet.Cells[questionNum + 7, 1].Font.Size = 15;

            string currentTime = DateTime.Now.ToString().Replace(':', '_');
            string fileName = ($"{Environment.CurrentDirectory}\\Report\\{codeOfTest }-{currentTime}.xlsx");
            workBook.SaveAs(fileName);
            //workBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, $"{Environment.CurrentDirectory}\\Report\\1-{currentTime}.pdf");

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(workSheet);
            workBook.Close();
            Marshal.ReleaseComObject(workBook);
            excel.Quit();
            Marshal.ReleaseComObject(excel);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
