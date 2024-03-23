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
    public partial class Админестратор : Form
    {
        private int gameId;
        public Админестратор()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=true");

        private void Админестратор_Load(object sender, EventArgs e)
        {
            this.игрыTableAdapter.Fill(this.коновалов_СВ_УП_02DataSet.Игры);
            raundclass.ApplyRoundedCorners(textBox2, 10);
            raundclass.ApplyRoundedCorners(button1, 10);
            raundclass.ApplyRoundedCorners(button2, 10);
            raundclass.ApplyRoundedCorners(button3, 10);

            SqlDataAdapter adapter1 = new SqlDataAdapter();
            System.Data.DataTable table1 = new System.Data.DataTable();
            string q = "Select game_id, название_игры as [название игры],цена, название_фирмы as [название фирмы] ,название_жанра as[название жанра],Видеокарта as Характеристики, Описание from Игры join Производители on Игры.producer_id=Производители.producer_id join Жанры on Жанры.genre_id = Игры.genre_id join Системные_требования on Системные_требования.req_id = Игры.req_id";
            SqlCommand command1 = new SqlCommand(q, con);
            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Добавить_игру addGameForm = new Добавить_игру(); // Передаем ссылку на текущий экземпляр "Администратора"
            addGameForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            редактировать_игру frm2 = new редактировать_игру(gameId); // Передача gameId в качестве параметра конструктора
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            удалить frm2 = new удалить();
            frm2.Show();
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
                    string q = "Select game_id, название_игры as [название игры],цена, название_фирмы as [название фирмы] ,название_жанра as[название жанра],Видеокарта as Характеристики, Описание from Игры join Производители on Игры.producer_id=Производители.producer_id join Жанры on Жанры.genre_id = Игры.genre_id join Системные_требования on Системные_требования.req_id = Игры.req_id where название_игры like @gameName";

                    // Создаем команду с параметрами
                    using (SqlCommand command = new SqlCommand(q, connection))
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "Select game_id, название_игры as [название игры],цена, название_фирмы as [название фирмы] ,название_жанра as[название жанра],Видеокарта as Характеристики, Описание from Игры join Производители on Игры.producer_id=Производители.producer_id join Жанры on Жанры.genre_id = Игры.genre_id join Системные_требования on Системные_требования.req_id = Игры.req_id";
                SqlDataAdapter itm = new SqlDataAdapter(q, con);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            польз f = new польз();
            f.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
      
    }
}
