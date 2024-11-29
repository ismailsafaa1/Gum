using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GymUnversity
{
    public partial class Traines : Form
    {
        public Traines()
        {
            InitializeComponent();
        }
        string query;
        DataSet ds;
        private void ClearFields()
        {
            texName.Text = "";
            texPhone.Text = "";
            texAge.Text = "";
            texPrice.Text = "";
            texCountry.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (texName.Text == "" || texAge.Text == "" || texPrice.Text == "" || texPhone.Text == "" ||texCountry.Text == "" || texPhone.Text == "")
    {
        MessageBox.Show("الرجاء ملء جميع الحقول.");
        return;
    }

    try
    {
        // إنشاء كائن جديد من نوع Trainees وتعبئة بياناته
        Trainees newTrainees = new Trainees
        {
            Name = texName.Text,
            Country = texCountry.Text,
            Age = texAge.Text,
            Mony = texPrice.Text,
            Phone = texPhone.Text
        };

        // استدعاء كلاس clsTrainess لإضافة المتدرب
        clsTrainees repo = new clsTrainees();
        repo.AddStudent(newTrainees);

        // رسالة تأكيد
        MessageBox.Show("تم إضافة المتدرب بنجاح.");

        // مسح الحقول
        ClearFields();

        // تحديث البيانات في DataGridView
       dataGridView1.DataSource = repo.GetAllTrainees();
    }
    catch (Exception ex)
    {
        MessageBox.Show("حدث خطأ أثناء الإضافة: " + ex.Message);
    }
        }
        public void connectionString(string connectionString4)
        {
        connectionString4 = "data source=DESKTOP-GE3H3SI; database=GumManagment; User Id=sa; Password=sa123456; integrated security = True";
        }
        DB dB = new DB();
       
        private void Form1_Load(object sender, EventArgs e)
        {
            clsTrainees d = new clsTrainees();
            dataGridView1.DataSource =  d.GetAllTrainees();

            query = "select * from Trainees where Name ";
             
        }
       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(texID.Text, out int studentId))
            {
                Trainees UpdateTrainees = new Trainees
                {
                    ID = studentId,
                    Name = texName.Text,
                    Country = texCountry.Text,
                    Age = texAge.Text,
                    Mony = texPrice.Text,
                    Phone = texPhone.Text
                };

                clsTrainees repo = new clsTrainees();
                repo.UpdateTrainees(UpdateTrainees);

                MessageBox.Show("تم تعديل بيانات المتدرب بنجاح.");
                ClearFields();

                dataGridView1.DataSource = repo.GetAllTrainees();
            }
            else
            {
                MessageBox.Show("القيمة المدخلة للمعرف غير صحيحة. يجب أن يكون المعرف رقميًا.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (int.TryParse(texID.Text, out int studentId))
            {
                clsTrainees repo = new clsTrainees();
                repo.DeleteTraineest(studentId);

                MessageBox.Show("تم حذف المتدرب بنجاح.");
                ClearFields();

                dataGridView1.DataSource = repo.GetAllTrainees();
            }
            else
            {
                MessageBox.Show("القيمة المدخلة غير صحيحة. يجب أن يكون المعرف رقميًا.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

            try
            {
                string studentId = texID.Text;

                // استدعاء دالة البحث في clsTrainees
                clsTrainees repo = new clsTrainees();
                DataTable result = repo.SearchTraineest(textBox1.Text);
                
                    dataGridView1.DataSource = result; // عرض النتيجة في DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message);
            }
        }

    }

}
