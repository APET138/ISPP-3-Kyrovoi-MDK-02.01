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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace SG_Продажа_игр
{
    public partial class удалить : Form
    {
        public удалить()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, введено ли название игры для удаления
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Введите название игры для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем название игры для удаления
                string gameName = textBox2.Text;

                // Подключаемся к базе данных
                string connectionString = @"Data Source=sql;Initial Catalog=Коновалов_СВ_УП_02;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создаем SQL-запрос для удаления игры по названию
                    string query = "DELETE FROM Игры WHERE [название_игры] = @gameName";

                    // Создаем команду с параметрами
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметр для названия игры
                        command.Parameters.AddWithValue("@gameName", gameName);

                        // Открываем соединение и выполняем команду
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // Проверяем, была ли удалена хотя бы одна запись
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Игра с названием '{gameName}' успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Закрываем форму после успешного удаления
                        }
                        else
                        {
                            MessageBox.Show($"Игра с названием '{gameName}' не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении игры: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void удалить_Load(object sender, EventArgs e)
        {
            raundclass.ApplyRoundedCorners(button3, 10);

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Админестратор frm2 = new Админестратор();
            frm2.Show();
        }
    }
}
