using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SG_Продажа_игр
{
    public partial class Добавить_игру : Form
    {

        // Измененный конструктор, который принимает аргумент типа Админестратор
        public Добавить_игру()
        {
            InitializeComponent();
        }
        private void Добавить_игру_Load(object sender, EventArgs e)
        {


            raundclass.ApplyRoundedCorners(textBox2, 10);
            raundclass.ApplyRoundedCorners(textBox1, 10);
            raundclass.ApplyRoundedCorners(textBox4, 10);
            raundclass.ApplyRoundedCorners(button1, 10);
            raundclass.ApplyRoundedCorners(comboBox2, 10);
            raundclass.ApplyRoundedCorners(comboBox3, 10);
            raundclass.ApplyRoundedCorners(comboBox1, 10);

            string connectionString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=True";

            // Получаем данные о производителях и загружаем их в comboBox1
            string query1 = "SELECT producer_id, название_фирмы FROM Производители";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBox1.DataSource = dataTable;
                comboBox1.ValueMember = "producer_id";
                comboBox1.DisplayMember = "название_фирмы";
            }

            // Получаем данные о жанрах игр и загружаем их в comboBox2
            string query2 = "SELECT genre_id, название_жанра FROM Жанры";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBox2.DataSource = dataTable;
                comboBox2.ValueMember = "genre_id";
                comboBox2.DisplayMember = "название_жанра";
            }

            // Получаем данные о требованиях к системе и загружаем их в comboBox3
            string query3 = "SELECT req_id, Видеокарта FROM Системные_требования";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query3, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBox3.DataSource = dataTable;
                comboBox3.ValueMember = "req_id";
                comboBox3.DisplayMember = "Видеокарта";
            }

        }
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    string connectionString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=True";
                    string query = "INSERT INTO [Игры] ([game_id],[название_игры],[цена],[producer_id],[genre_id],[req_id],[Описание]) VALUES (@game_id, @название_игры, @цена, @producer_id, @genre_id, @req_id, @Описание)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int game_id = Convert.ToInt32(textBox4.Text);
                        string название_игры = Convert.ToString(textBox2.Text);
                        decimal цена = Convert.ToDecimal(textBox1.Text);
                        int producer_id = Convert.ToInt32(comboBox1.SelectedValue);
                        int genre_id = Convert.ToInt32(comboBox2.SelectedValue);
                        int req_id = Convert.ToInt32(comboBox3.SelectedValue);
                        string Описание = Convert.ToString(textBox3.Text);

                        command.Parameters.AddWithValue("@game_id", game_id);
                        command.Parameters.AddWithValue("@название_игры", название_игры);
                        command.Parameters.AddWithValue("@цена", цена);
                        command.Parameters.AddWithValue("@producer_id", producer_id);
                        command.Parameters.AddWithValue("@genre_id", genre_id);
                        command.Parameters.AddWithValue("@req_id", req_id);
                        command.Parameters.AddWithValue("@Описание", Описание);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    this.Hide();
                    Админестратор frm2 = new Админестратор();
                    frm2.Show();
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка проверте чтобы описание было не больше 255 символов и ID" );
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void SaveImageToDatabase(Image image)
        {

        }

        private void Добавить_игру_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Добавить_игру_DragEnter(object sender, DragEventArgs e)
        {

        }


        // Метод для загрузки данных

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Админестратор frm2 = new Админестратор();
            frm2.Show();
        }
    }
}
