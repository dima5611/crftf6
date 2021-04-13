using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crftf6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ConnectionString = "Data Source=DESKTOP-BIODV4A;Initial Catalog=Hnkoloqwe;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn(ConnectionString, PCK, dataGridView5);
            conn(ConnectionString, Prepod, dataGridView2);
            conn(ConnectionString, VidMetod, dataGridView3);
            conn(ConnectionString, Metod, dataGridView4);

        }
        public string ConnectionString = "";
        string PCK = " SELECT  Kod_PCK AS [Код пцк], NamePCK AS [Название пцк], PeredsedPCK AS [ФИО председателя ПЦК] FROM PCK ";
        string Prepod = " SELECT Prepod.Kod_Prepod AS [Код преподавателя], Prepod.FloPrepod AS [ФИО преподавателя], Prepod.Dolgnost AS Должность, Prepod.dataPriem AS [Дата приема], Prepod.DataUvol AS [Дата увольнения], Prepod.Kod_PCK AS [Код пцк], Prepod.DataObuch AS [Дата последнего обучения] FROM Prepod INNER JOIN PCK ON Prepod.Kod_PCK = PCK.Kod_PCK ";
        string VidMetod = " SELECT Kod_lDvdMetod AS [Код вид метод разработок], NameVidMetod AS [Название вида] FROM VidMetod ";
        string Metod = " SELECT Metod.Kod_MeroprPepo AS [Код мероприятия], Metod.NameMerpor AS Название, Metod.Kod_lDvdMetod AS [Вид мероприятия], Metod.Uroven AS Уровень, Metod.Result AS Результат, Metod.Dokum AS Документ,  Metod.Mesto AS [Место проведения], Metod.DataProv AS [Дата проведения], Metod.Kod_Prepod AS [Код преподавтельях] FROM Metod INNER JOIN VidMetod ON Metod.Kod_lDvdMetod = VidMetod.Kod_lDvdMetod INNER JOIN Prepod ON Metod.Kod_Prepod = Prepod.Kod_Prepod ";


        private void button16_Click(object sender, EventArgs e)
        {
           
        }
        public void conn(string CS, string cmdT, DataGridView dgv)
        {
            //создание экземпляра адаптера

            SqlDataAdapter Adapter = new SqlDataAdapter(cmdT, CS);
            // сздание обьекта  DataSet (набор данных)
            DataSet ds = new DataSet();
            // Заполнение таблицы набора данных DataSet
            Adapter.Fill(ds, "Table");
            // Связыаем источник данных компонета dataGridView на форме, с таблицей
            dgv.DataSource = ds.Tables["Table"].DefaultView;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
