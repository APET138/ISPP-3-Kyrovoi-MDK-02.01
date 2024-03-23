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
    public partial class польз : Form
    {
        public польз()
        {
            InitializeComponent();
        }

        private void польз_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "коновалов_СВ_УП_02DataSet.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.коновалов_СВ_УП_02DataSet.Пользователи);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            Сведения frm2 = new Сведения();
            frm2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Админестратор frm2 = new Админестратор();
            frm2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = "select * from Пользователи";
                SqlDataAdapter itm = new SqlDataAdapter(commandText, con);
                DataTable dt2 = new DataTable();
                itm.Fill(dt2);
                dataGridView1.DataSource = dt2;
                con.Close();
            }
            catch
            {
                MessageBox.Show("Нечего обновлять");
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=true");
        private void SearchGames(string gameName)
        {
            try
            {
                // Подключаемся к базе данных
                string connectionString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создаем SQL-запрос для поиска игр по названию
                    string query = "SELECT * FROM Пользователи WHERE [Роль] LIKE @gameName";

                    // Создаем команду с параметрами
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметр для названия игры
                        command.Parameters.AddWithValue("@gameName", "%" + gameName + "%");

                        // Открываем соединение и выполняем команду
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Загружаем результаты поиска в DataGridView или другой контрол для отображения таблицы игр
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске игр: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchGames(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            удалить1 f = new удалить1();
            f.Show(); 
        }
    }
}
