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
    public partial class библеотека : Form
    {
       
        public библеотека()
        {
            InitializeComponent();
            this.Load += библеотека_Load;
        }

        public DataGridView GetLibraryDataGridView()
        {
            return dataGridViewLibrary;
        }

        private void библеотека_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "коновалов_СВ_УП_02DataSet.Игра". При необходимости она может быть перемещена или удалена.
            this.играTableAdapter.Fill(this.коновалов_СВ_УП_02DataSet.Игра);
            dataGridViewLibrary.Tag = dataGridViewLibrary;
        }

        private void dataGridViewLibrary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Пользователь f = new Пользователь();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchGames(textBox1.Text);
        }
        private void SearchGames(string gameName)
        {
            try
            {
                string connectionString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Игра WHERE [название_игры] LIKE @gameName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@gameName", "%" + gameName + "%");

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Загружаем результаты поиска в DataGridView или другой контрол для отображения таблицы игр
                        dataGridViewLibrary.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске игр: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=true");

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = "select * from игра";
                SqlDataAdapter itm = new SqlDataAdapter(commandText, con);
                DataTable dt2 = new DataTable();
                itm.Fill(dt2);
                dataGridViewLibrary.DataSource = dt2;
                con.Close();
            }
            catch
            {
                MessageBox.Show("Нечего обновлять");
            }
        }
    }
}
