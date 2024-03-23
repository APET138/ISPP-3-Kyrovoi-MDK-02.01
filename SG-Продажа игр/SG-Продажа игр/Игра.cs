using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_Продажа_игр
{
    public partial class Игра : Form
    {
        private string data1;
        private string data2;
        private string data3;
        private string data4;
        private string data5;
        private string data6;
        private string data7;
        public Игра(string data1, string data2, string data3, string data4, string data5, string data6, string data7)
        {
            InitializeComponent();

            this.data1 = data1;
            this.data2 = data2;
            this.data3 = data3;
            this.data4 = data4;
            this.data5 = data5;
            this.data6 = data6;
            this.data7 = data7;

            textBox4.Text = data1;
            textBox2.Text = data2;
            textBox1.Text = data3;
            textBox3.Text = data4;
            textBox5.Text = data5;
            textBox6.Text = data6;
            textBox7.Text = data7;
        }
        public void LoadImage(string imagePath)
        {

           


        }
        private void Игра_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            try
            {
                string connectionString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=True";
                string gameInsertQuery = "INSERT INTO [Игра] ([game_id], [название_игры]) VALUES (@game_id, @название_игры)";
                string salesInsertQuery = "INSERT INTO [Продажи] ([sale_id], [game_id], [дата_продажи]) VALUES (@sale_id, @game_id, @дата_продажи)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Добавляем игру в таблицу Игра
                    using (SqlCommand command = new SqlCommand(gameInsertQuery, connection))
                    {
                        int game_id = Convert.ToInt32(textBox4.Text);
                        string название_игры = Convert.ToString(textBox2.Text);

                        command.Parameters.AddWithValue("@game_id", game_id);
                        command.Parameters.AddWithValue("@название_игры", название_игры);

                        command.ExecuteNonQuery();
                    }

                    // Добавляем информацию о продаже в таблицу Продажи
                    using (SqlCommand command = new SqlCommand(salesInsertQuery, connection))
                    {
                        int sale_id;
                        int game_id = Convert.ToInt32(textBox4.Text);
                        DateTime дата_продажи = DateTime.Now;

                        // Получаем максимальное значение sale_id из таблицы Продажи и увеличиваем его на 1
                        string maxSaleIdQuery = "SELECT MAX(sale_id) FROM Продажи";
                        using (SqlCommand maxSaleIdCommand = new SqlCommand(maxSaleIdQuery, connection))
                        {
                            object result = maxSaleIdCommand.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                sale_id = Convert.ToInt32(result) + 1;
                            }
                            else
                            {
                                sale_id = 1; // Если таблица пуста, начинаем с 1
                            }
                        }

                        command.Parameters.AddWithValue("@sale_id", sale_id);
                        command.Parameters.AddWithValue("@game_id", game_id);
                        command.Parameters.AddWithValue("@дата_продажи", дата_продажи);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Пользователь f = new Пользователь();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            библеотека f = new библеотека();
            f.Show();
        }
    }
}
