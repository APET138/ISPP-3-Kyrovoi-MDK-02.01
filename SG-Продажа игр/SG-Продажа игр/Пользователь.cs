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

namespace SG_Продажа_игр
{
    public partial class Пользователь : Form
    {
        public Пользователь()
        {
            InitializeComponent();
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Пользователь_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "коновалов_СВ_УП_02DataSet.Игры". При необходимости она может быть перемещена или удалена.
            this.игрыTableAdapter.Fill(this.коновалов_СВ_УП_02DataSet.Игры);
            raundclass.ApplyRoundedCorners(textBox1, 10);
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            System.Data.DataTable table1 = new System.Data.DataTable();
            string q = "Select game_id, название_игры as [название игры],цена, название_фирмы as [название фирмы] ,название_жанра as[название жанра],Видеокарта as Характеристики, Описание from Игры join Производители on Игры.producer_id=Производители.producer_id join Жанры on Жанры.genre_id = Игры.genre_id join Системные_требования on Системные_требования.req_id = Игры.req_id";
            SqlCommand command1 = new SqlCommand(q, con);
            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;

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
                    string query = "SELECT * FROM Игры WHERE [название_игры] LIKE @gameName";

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
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = "select * from Игры";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchGames(textBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            int rowIndex = e.RowIndex;

            // Проверяем, что индекс строки действителен
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                // Получаем данные из выбранной строки
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                string data1 = selectedRow.Cells[0].Value.ToString();
                string data2 = selectedRow.Cells[1].Value.ToString();
                string data3 = selectedRow.Cells[2].Value.ToString();
                string data4 = selectedRow.Cells[3].Value.ToString();
                string data5 = selectedRow.Cells[4].Value.ToString();
                string data6 = selectedRow.Cells[5].Value.ToString();
                string data7 = selectedRow.Cells[6].Value.ToString();

                // Открываем форму игры, передавая данные
                OpenGameForm(data1, data2, data3, data4, data5, data6, data7);
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void OpenGameForm(string data1, string data2, string data3, string data4, string data5, string data6, string data7)
        {
            Игра gameForm = new Игра(data1, data2, data3, data4,data5, data6, data7);
            gameForm.ShowDialog(); 
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            библеотека а = new библеотека();
            а.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            Пользователь а = new Пользователь();
            а.Show();
        }
    }
}
