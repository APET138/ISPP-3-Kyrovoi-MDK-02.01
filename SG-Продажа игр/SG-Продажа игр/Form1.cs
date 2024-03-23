using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_Продажа_игр
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowPlaceholder();
        }
        private void ShowPlaceholder()
        {
            // Показываем надпись только если TextBox пустой
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Логин";
                textBox1.ForeColor = System.Drawing.Color.Silver; // Цвет текста серый
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "Пароль";
                textBox2.ForeColor = System.Drawing.Color.Silver; // Цвет текста серый
            }
        }

        public static string rol = "";
        public string CmdText = "SELECT login,Name_ak,Pas,buy + sale AS 'Стоимость аккаунта',guard,phon,phon_date FROM [ak]";
        public string ConnString = "Data Source=192.168.1.3;" +
                                   "Initial Catalog=Коновалов_СВ_УП_02;" +
                                   "User id=КоноваловСергей;" +
                                    "Password=1202;";//Глобальная БД

        public static string connectString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=true";
        public static string a, b;
        private SqlConnection myConnection;

        public SqlDataAdapter da = null;
        public DataSet ds = new DataSet();
        public SqlConnection connP = new SqlConnection();

        private void Form1_Load(object sender, EventArgs e)
        {
            raundclass.ApplyRoundedCorners(textBox1, 10);
            raundclass.ApplyRoundedCorners(textBox2, 10);
            raundclass.ApplyRoundedCorners(button1, 10);
            raundclass.ApplyRoundedCorners(button2, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            регистрация frm2 = new регистрация();
            frm2.Show();
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Логин")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            myConnection = new SqlConnection(connectString);
            myConnection.Open();
            string query = "SELECT Логин, пароль, Роль  From Пользователи";
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(query, myConnection);
            da.Fill(dt);
            Boolean flag = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Логин"].ToString() == textBox1.Text && row["пароль"].ToString() == textBox2.Text)
                {
                    flag = true;
                    if (row["Роль"].ToString() == "Админестратор")
                    {
                        this.Hide();
                        Админестратор frm2 = new Админестратор();
                        frm2.Show();
                    }
                    else if (row["Роль"].ToString() == "Пользователь")
                    {
                        this.Hide();
                        Пользователь frm2 = new Пользователь();
                        frm2.Show();
                    }
                    break;
                }
            }
            if (flag == false)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            myConnection.Close();
        }
    }
}
