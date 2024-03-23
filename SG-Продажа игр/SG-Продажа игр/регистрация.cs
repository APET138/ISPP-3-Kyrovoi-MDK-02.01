using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SG_Продажа_игр
{
    public partial class регистрация : Form
    {
        public регистрация()
        {
            InitializeComponent();
            ShowPlaceholder();
        }

        private void ShowPlaceholder()
        {
            // Показываем надпись только если TextBox пустой
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Имя";
                textBox1.ForeColor = System.Drawing.Color.White; // Цвет текста серый
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "Фамилия";
                textBox2.ForeColor = System.Drawing.Color.White; // Цвет текста серый
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "e-mail";
                textBox3.ForeColor = System.Drawing.Color.White; // Цвет текста серый
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Text = "Пароль";
                textBox4.ForeColor = System.Drawing.Color.White; // Цвет текста серый
            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Text = "Логин";
                textBox5.ForeColor = System.Drawing.Color.White; // Цвет текста серый
            }
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Имя")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {

        }
        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }
        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }
        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }
        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {

        }
        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {

        }
        private void textBox4_DragEnter(object sender, DragEventArgs e)
        {

        }
        private void textBox5_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void textBox3_DragLeave(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Фамилия")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }
        private void textBox4_MouseEnter(object sender, EventArgs e)
        {

        }
        private void textBox5_MouseEnter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Логин")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.White;
            }
        }
        private void textBox3_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseLeave_1(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }

        private void textBox3_MouseEnter_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "e-mail")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.White;
            }
        }

        private void textBox3_MouseLeave_1(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }

        private void textBox4_MouseEnter_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "Пароль")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.White;
            }
        }

        private void textBox4_MouseLeave_1(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }

        private void textBox5_MouseEnter_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "Логин")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.White;
            }
        }

        private void textBox5_MouseLeave_1(object sender, EventArgs e)
        {
            ShowPlaceholder();
        }

        private void регистрация_Load(object sender, EventArgs e)
        {
            raundclass.ApplyRoundedCorners(textBox1, 10);
            raundclass.ApplyRoundedCorners(textBox2, 10);
            raundclass.ApplyRoundedCorners(textBox3, 10);
            raundclass.ApplyRoundedCorners(textBox4, 10);
            raundclass.ApplyRoundedCorners(textBox5, 10);
            raundclass.ApplyRoundedCorners(button2, 10);
        }

        SqlConnection con = new SqlConnection(@"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=true");
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    string connectionString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Вставка данных в таблицу Пользователи
                        string query1 = "INSERT INTO [Пользователи] ([Роль],[пароль],[Логин]) VALUES (@rol, @par, @log)";
                        using (SqlCommand command = new SqlCommand(query1, connection))
                        {
                            string rol = "Пользователь";
                            string login = textBox5.Text;
                            string password = textBox4.Text;

                            command.Parameters.AddWithValue("@rol", rol);
                            command.Parameters.AddWithValue("@par", password);
                            command.Parameters.AddWithValue("@log", login);

                            command.ExecuteNonQuery();
                        }

                        // Получение последнего добавленного ID
                        int lastUserId = 0;
                        string queryGetLastId = "SELECT @@IDENTITY";
                        using (SqlCommand commandGetLastId = new SqlCommand(queryGetLastId, connection))
                        {
                            object result = commandGetLastId.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                lastUserId = Convert.ToInt32(result);
                            }
                        }

                        // Вставка данных в таблицу Пользователь
                        string query2 = "INSERT INTO [Пользователь] ([use_id],[имя],[фамилия],[e_mail]) VALUES (@id, @name, @fam, @e_mail)";
                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {
                            string id = lastUserId.ToString();
                            string name = textBox1.Text;
                            string fam = textBox2.Text;
                            string email = textBox3.Text;

                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@fam", fam);
                            command.Parameters.AddWithValue("@e_mail", email);

                            command.ExecuteNonQuery();
                        }
                    }

                    this.Close();
                    Пользователь frm = new Пользователь();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении операции: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
