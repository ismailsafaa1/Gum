using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GymUnversity
{
    class clsTrainees
    {
        private string connectionString = "data source=DESKTOP-GE3H3SI; database=GumManagment; User Id=sa; Password=sa123456; integrated security = True";

        // دالة لإضافة المتدرب
        public void AddStudent(Trainees trainees)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Trainees (Name, Age, Phone, Mony,Country) VALUES (@Name, @Age,@Phone,@Mony,@Country)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", trainees.Name);
                cmd.Parameters.AddWithValue("@Age", trainees.Age);
                cmd.Parameters.AddWithValue("@Phone", trainees.Phone);
                cmd.Parameters.AddWithValue("@Mony", trainees.Mony);
                cmd.Parameters.AddWithValue("@Country", trainees.Country);


                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // دالة لتحديث بيانات المتدرب
        public void UpdateTrainees(Trainees trainees)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Trainees SET Name = @Name, Age = @Age, Phone = @Phone, Mony = @Mony,Country=@Country WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", trainees.ID);
                cmd.Parameters.AddWithValue("@Name", trainees.Name);
                cmd.Parameters.AddWithValue("@Age", trainees.Age);
                cmd.Parameters.AddWithValue("@Phone", trainees.Phone);
                cmd.Parameters.AddWithValue("@Mony", trainees.Mony);
                cmd.Parameters.AddWithValue("@Country", trainees.Country);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // دالة لحذف المتدرب بناءً على ID
        public void DeleteTraineest(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Trainees WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // دالة لجلب جميع المتدرب كـ DataTable لعرضهم في DataGridView
        public DataTable GetAllTrainees()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Trainees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // دالة للبحث عن المتدرب باستخدام الاسم 
        public DataTable SearchTraineest(string searchValue)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Trainees WHERE Name LIKE '"+searchValue+"%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }
    }
}
