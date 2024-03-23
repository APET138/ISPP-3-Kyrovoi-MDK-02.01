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
    public partial class Сведения : Form
    {
        public Сведения()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchGames(textBox2.Text);
        }
        private void SearchGames(string gameName)
        {
            try
            {
                // Подключаемся к базе данных
                string connectionString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создаем SQL-запрос для поиска игр по названию
                    string query = "SELECT * FROM продажи WHERE [game_id] LIKE @gameName";

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

        string q = "Select sale_id, название_игры as [название игры], дата_продажи as [дата продажи] from Продажи join Игры  on Игры.game_id=Игры.game_id";

        private void Сведения_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "коновалов_СВ_УП_02DataSet.Продажи". При необходимости она может быть перемещена или удалена.
            this.продажиTableAdapter.Fill(this.коновалов_СВ_УП_02DataSet.Продажи);

            SqlDataAdapter adapter1 = new SqlDataAdapter();
            System.Data.DataTable table1 = new System.Data.DataTable();
            string q = " Select sale_id, название_игры as [название игры], дата_продажи as [дата продажи] from Продажи join Игры on Игры.game_id = Игры.game_id";
            SqlCommand command1 = new SqlCommand(q, con);
            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }
        SqlConnection con = new SqlConnection(@"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=true");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = "select * from Продажи";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Админестратор frm2 = new Админестратор();
            frm2.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            польз frm2 = new польз();
            frm2.Show();
        }
    }
}
