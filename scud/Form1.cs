using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace scud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            

            String[] fi = { "Аюпов Фирзар Ришатович", "Сидоров Михаил", "Патрушев Лукьян", "Борхес Филипп", "Шкиряк Семён", "Ясинова Оксана", "Ёжин Анатолий", "Ельцов Самсон", "Кочубей Виссарион", "Пережогина Изольда", "Эмин Бронислав", "Суслякова Тамара", "Ягодич Венедикт", "Копорикова Римма", "Комяхов Мирослав", "Балдагуева Роза", "Кондратов Клавдий", "Набойщикова Варвара", "Соколов Денис", "Сметанин Модест", "Фаммуса Диана", "Типалова Изольда", "Ковшутин Аскольд", "Коденко Лилия", "Захарова Марианна", "Ваенга Елисей", "Агеев Валентин", "Каменева Ева", "Спирьянова Марина", "Тихоход Эмиль", "Ярмольник Прокофий", "Мартюшев Савелий", "Антипин Константин", "Мусорин Сергей", "Балунов Платон", "Кобелева Розалия", "Ильясова Вера", "Ясюлевич Ираклий", "Витюгов Мир", "Шапиро Каролина", "Янцев Архип", "Окладников Валерьян", "Васютин Ростислав", "Юханцев Нестор", "Кодица Жанна", "Карданова ﻿Агата", "Тамаркина Ариадна", "Иноземцева Ираида", "Кувшинов Федор", "Гольдин Всеслав", "Ромазанова Евдокия", "Чаадаева Антонина", "Шульц Адриан", "Капылюшный Анна", "Рыков Изяслав", "Кравков Владимир", "Лопатин Евгений", "Хлопонина Лилия", "Фетисов Сергей", "Павленко Эмиль", "Федоренко Пимен", "Поветникова Влада", "Блинова Пелагея", "Папенина Алла", "Мартьянова Анисья", "Сайтахметова Ксения", "Другакова Наталия", "Янчурова Рада", "Янькова Елизавета", "Слобожанина Валентина", "Камбарова Евгения", "Алистратова Анисья", "Ялчевский Роман", "Летавина Христина", "Панарина Антонина", "Луговой Жанна", "Эскина Оксана", "Самошина Вероника", "Оськин Осип", "Лель Модест", "Любимова Эльвира", "Коптильников Михей", "Бебчука Маргарита", "Ямбаева Агния", "Яшнова Маргарита", "Куклов Прохор", "Закиров Юрий", "Владимиров Арсений", "Гачегова Агафья", "Яковченко Таисия", "Кондюрина Анна", "Карибжанов Мир", "Кабицина Ефросиния", "Петрищева Анисья", "Набойченко Вениамин", "Левченко Андрон", "Бысов Никита", "Автухова Марина", "Яфраков Агафон", "Митяшов Никифор", "Матвеев Тарас" };

            writeTable(dataGridView1, fi);
            addEnterDate(dataGridView1, getJsonFromFile().GetEvent("Вход"));
            addExitDate(dataGridView1, getJsonFromFile().GetEvent("Выход"));
        }


        private static Root getJsonFromFile()
        {
            string json = "";
            string path = @"C:\Users\User\source\repos\scud\GetEventListByDatetime.json";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    json = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Root eventlist;

            return JsonConvert.DeserializeObject<Root>(json);
        }
        private static Root getJsonFromServer()

        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.1.123/OpenLavina/");

            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";//Можно GET
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //ответ от сервера
                var result = streamReader.ReadToEnd();

                //Сериализация
                return JsonConvert.DeserializeObject<Root>(result);
            }
        }

        private static void writeTable(DataGridView dgv, String[] fi)
        {
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { Name = "name", HeaderText = "Имя", Width = 200 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { Name = "enterDate", HeaderText = "Вход", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn() { Name = "exiteDate", HeaderText = "Выход", Width = 100 });

            foreach (string f in fi)
            {
                int rowNumber = dgv.Rows.Add();
                dgv.Rows[rowNumber].Cells[0].Value = f;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private static void addEnterDate(DataGridView dgv, List<GetEventListByDatetimeResult> ev)
        {
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                foreach (GetEventListByDatetimeResult e in ev)
                {
                    if (dgv[0, i].Value.ToString() == e.Person)
                    {
                        dgv[1, i].Value = e.EventTime;
                    }
                }
            }
        }

        private static void addExitDate(DataGridView dgv, List<GetEventListByDatetimeResult> ev)
        {
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                foreach (GetEventListByDatetimeResult e in ev)
                {
                    if (dgv[0, i].Value.ToString() == e.Person)
                    {
                        dgv[2, i].Value = e.EventTime;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
