using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UtilCoding.Helpers;
using Newtonsoft.Json;
using System.Drawing;
using System.Text;

namespace UtilCoding
{
    public partial class ucJson : UserControl
    {
        public ucJson()
        {
            InitializeComponent();
        }


        public class Question
        {
            public string question { get; set; }
            public string cod { get; set; }
            public int level { get; set; }
            public List<Answer> answers { get; set; }
        }

        public class Answer
        {
            public string text { get; set; }
            public bool valid { get; set; }
        }

        public class QuestionsData
        {
            public List<Question> questions { get; set; }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            string sPath;
            List<JsonHelper.JsonEntity> ljson = new List<JsonHelper.JsonEntity>();
            string sJson = string.Empty;
            string sInsert = string.Empty;
            try
            {
                sPath = txtPath.Text;
                //sJson = File.ReadAllText(sPath);

                //ljson =  JsonHelper.Instance.JsonToEntity(sJson);
                //JsonHelper.Instance.JsonEntityToDataset(ljson);

                sInsert = ConvertJsonToSqlInsert(sPath);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public string ConvertJsonToSqlInsert(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                // Leer el archivo JSON
                var jsonData = File.ReadAllText(filePath);
                var questionsData = JsonConvert.DeserializeObject<QuestionsData>(jsonData);

                foreach (var question in questionsData.questions)
                {
                    // Generar sentencia SQL para la pregunta
                    string insertQuestion = $"INSERT INTO Questions (cod, question, level) VALUES ('{question.cod}', '{question.question.Replace("'", "''")}', {question.level});";
                    sb.AppendLine(insertQuestion);

                    foreach (var answer in question.answers)
                    {
                        // Generar sentencia SQL para cada respuesta
                        string insertAnswer = $"INSERT INTO Answers (question_cod, text, valido) VALUES ('{question.cod}', '{answer.text.Replace("'", "''")}', {answer.valid.ToString().ToLower()});";
                        sb.AppendLine(insertAnswer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return sb.ToString();
        }



    }
}
