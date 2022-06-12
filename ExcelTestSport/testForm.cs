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

namespace ExcelTestSport
{
    public partial class testForm : Form
    {

        public testForm()
        {
            InitializeComponent();

            string[,] questions = DataBase.GlobalQuestions;

            int numberOfQuestions = 0; //Количество вопросов

            string question;
            question = questions[0, 2];
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

            string[,] test = new string[numberOfQuestions, 9];  //0 - Вид спорта
                                                                //1 - Категория
                                                                //2 - Вопрос
                                                                //3 - Вариант ответа 1
                                                                //4 - Вариант ответа 2
                                                                //5 - Вариант ответа 3
                                                                //6 - Вариант ответа 4
                                                                //7 - Ответ юзера
                                                                //8 - Время на ответ
            int count = 0;        //Подготовка массива для теста
            numberOfQuestions = 0;
            string answer = "";

            question = questions[0, 2];
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

            /////////////////////////
            ///

            int numVariants = 0; //Количество вариантов ответов
            //for (int i = 0; i < numberOfQuestions + 1; i++) //Формулировка вопроса
            //{

                QuestionNumber.Text = $"Вопрос {1} из {numberOfQuestions + 1}";
                SportType.Text = $"Вид спорта: {test[0, 0]}";
                Category.Text =  $"Категория:  {test[0, 1]}";
                QuestionBox.Text=   $"Вопрос: {test[0, 2]}";

                for (int j = 0; j < 4; j++)
                {
                    if (test[0, j + 3] != null)
                    {
                        numVariants++;
                    }
                }

                if (numVariants == 2)
                {
                    AnswerVar1.Text = test[0, 3];
                    AnswerVar2.Text = test[0, 4];
                    AnswerVar3.Visible = false;
                    AnswerVar4.Visible = false;
                }
                else
                {
                    AnswerVar3.Visible = true;
                    AnswerVar4.Visible = true;

                    AnswerVar1.Text = Convert.ToString(test[0, 3]);
                    AnswerVar2.Text = Convert.ToString(test[0, 4]);
                    AnswerVar3.Text = Convert.ToString(test[0, 5]);
                    AnswerVar4.Text = Convert.ToString(test[0, 6]);

                }

         //       for (int j = 0; j < numVariants; j++)
          //      {
         //           Console.WriteLine("Вариант {0}: " + test[i, j + 3], j + 1);
         //       }

                //Console.WriteLine();
                //Console.Write("Ваш вариант ответа: ");

                DateTime t1, t2;
                t1 = DateTime.Now;
                


                ////////////////////
            //}


        }

        public void checkBox1_Click(object sender, EventArgs e)
        {
            AnswerVar2.Checked = false;
            AnswerVar3.Checked = false;
        }

        public void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            AnswerVar1.Checked = false;
            AnswerVar3.Checked = false;
        }

        public void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            AnswerVar1.Checked = false;
            AnswerVar2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Category_Click(object sender, EventArgs e)
        {

        }

        private void AnswerVar1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
