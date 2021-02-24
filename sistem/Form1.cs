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

namespace sistem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection("data source=SEYMUR-PC\\SQLEXPRESS;initial catalog=sistem;integrated security=SSPI");
        SqlCommand com;
        SqlDataAdapter da;
        DataSet ds;
        int setir, sutun,setir1,sutun1,setir2,sutun2,setir3,sutun3;
        int i, j;

        public DataTable Sorgu(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
          DataTable  dt = new DataTable();
            da.Fill(dt);
            con.Close();
          return(dt);
        }

        public void Qowul(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
        }

        public int Nomre(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            int K = ds.Tables[0].Rows.Count;
            if (K > 0)
                return ds.Tables[0].Rows.Count;

            else return (0);
        }

        public void goster1(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        public void goster2(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }

        public void goster3(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            con.Close();
        }


        public void goster4(string w)
        {
            con.Open();
            da = new SqlDataAdapter(w, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            con.Close();
        }


        public Color Reng(int w)
        {
            Color R = Color.White;
           
              if(w>=0 && w<4) R = Color.Silver;
               if(w>=4 && w<8)  R = Color.Beige;
              if(w>=8 && w<12)  R = Color.Gray;
                if(w>=12 && w<16)  R = Color.Gainsboro; 
               if(w>=16 && w<20)  R = Color.LightBlue; 
            
            return(R);
        }




        public Color Reng1(int w)
        {
            Color R1 = Color.White;

            if (w ==0) R1 = Color.Silver;
            if (w ==1) R1 = Color.Beige;
            if (w ==2) R1 = Color.Gray;
            if (w ==3) R1 = Color.Gainsboro;
            if (w ==4) R1 = Color.LightBlue;

            return (R1);
        }


        public Color Reng2(int w)
        {
            Color R2 = Color.White;

            if (w == 0) R2 = Color.Silver;
            if (w == 1) R2 = Color.Beige;
            if (w == 2) R2 = Color.Gray;
            if (w == 3) R2 = Color.Gainsboro;
            if (w == 4) R2 = Color.LightBlue;
            if (w == 5) R2 = Color.Silver;
            if (w == 6) R2 = Color.Gray;



            return (R2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sistemDataSet4.otaq' table. You can move, or remove it, as needed.
            this.otaqTableAdapter.Fill(this.sistemDataSet4.otaq);
      
            // TODO: This line of code loads data into the 'sistemDataSet2.qrup' table. You can move, or remove it, as needed.
            this.qrupTableAdapter.Fill(this.sistemDataSet2.qrup);
            // TODO: This line of code loads data into the 'sistemDataSet1.fennler' table. You can move, or remove it, as needed.
            this.fennlerTableAdapter.Fill(this.sistemDataSet1.fennler);
            // TODO: This line of code loads data into the 'sistemDataSet.muellimler' table. You can move, or remove it, as needed.
            this.muellimlerTableAdapter.Fill(this.sistemDataSet.muellimler);
       
            //*************************************combobox2 Muellim 
            string T = "";
            Qowul("select* from muellimler");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                
                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox2.Items.Add(T); T = "";
            }
                //*************************************combobox3 Fenler 
            Qowul("select* from fennler");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox3.Items.Add(T); T = "";
            }


                //*************************************combobox4 Qr 
            Qowul("select* from qrup");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox4.Items.Add(T); T = "";
            }

                //*************************************combobox5 Otaq 

            Qowul("select* from otaq");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox5.Items.Add(T); T = "";
            }
            //**************************************************************

                dataGridView5.EnableHeadersVisualStyles = false;
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            

            dataGridView5.RowCount = 20;
            dataGridView5.ColumnCount = 4;

            for (i = 0; i < 20; i++)
                dataGridView5.Rows[i].Height = 50;

            //****************************************** sutunlarin adlari
            con.Open();
            da = new SqlDataAdapter("select* from saat",con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

            for (i = 1; i <= 3; i++)
                dataGridView5.Columns[i].HeaderText = ds.Tables[0].Rows[i - 1].ItemArray[0].ToString();
            //********************************************************** setirlerin adlari her bir 4 set bir
            con.Open();
            da = new SqlDataAdapter("select* from hefte", con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

            for (i = 0; i <= 4; i++)
                dataGridView5[0,4*i].Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();

            for (j = 0; j <= 3; j++)
            {
                for (i = 0; i <= 19; i++)
                    dataGridView5.Rows[i].Cells[j].Style.BackColor = Reng(i);
            }
            //************************************************************cedvelin doldurulmasi
            string P = "";
            for (i = 1; i <= 5; i++)
                for (j = 1; j <= 3; j++)
                {
                    DataTable DT = Sorgu("select * from T1 where gun_nomre like " + i.ToString() + " and saat_nomre like " + j.ToString() + "" );
                    for (int l = 0; l < DT.Rows.Count; l++)
                    {
                        P = "";
                        for (int m = 2; m <= 5; m++)
                            P += DT.Rows[l].ItemArray[m].ToString() + " ";
                        dataGridView5[j, i + l-1].Value = P;
                    }
                }
          //  ****************************************dataGridView6****************************************************
            dataGridView6.EnableHeadersVisualStyles = false;
            dataGridView6.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;



            dataGridView6.RowCount = 5;
            dataGridView6.ColumnCount = 8;

            for (i = 0; i < 5; i++)
                dataGridView6.Rows[i].Height = 50;
            //**************************************************** sutunlarin adlari
            con.Open();
            da = new SqlDataAdapter("select* from saat2", con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

            for (i = 1; i <=7; i++)
                dataGridView6.Columns[i].HeaderText = ds.Tables[0].Rows[i - 1].ItemArray[0].ToString();

            //********************************************************** setirlerin adlari 
           con.Open();
            da = new SqlDataAdapter("select* from hefte", con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();


             for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                dataGridView6[0,i].Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();

            for (j = 0; j <= 7; j++)
            {
                for (i = 0; i <= 4; i++)
                    dataGridView6.Rows[i].Cells[j].Style.BackColor = Reng1(i);
            }

            //***************************************************************cedvelin doldurulmasi
            string P1 = "";
            for (i = 1; i <= 5; i++)
                for (j = 1; j <= 7; j++)
                {
                    DataTable DT = Sorgu("select * from T1 where gun_nomre like " + i.ToString() + " and saat_nomre like " + j.ToString() + " and qrup like '"+ comboBox9.Text+"'");
                    for (int l = 0; l < DT.Rows.Count; l++)
                    {
                        P = "";
                        for (int m = 2; m <= 5; m++)
                            P1 += DT.Rows[l].ItemArray[m].ToString() + " ";
                        dataGridView6[j, i + l - 1].Value = P1;
                    }
                }

            //*************************************combobox10  Muellim 
            string T1 = "";
            Qowul("select* from muellimler");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T1 += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox10.Items.Add(T1); T1 = "";
            }
            //*************************************combobox11 Fenler 
            Qowul("select* from fennler");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T1 += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox11.Items.Add(T1); T1 = "";
            }


            //*************************************combobox9 Qr 
            Qowul("select* from qrup");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T1 += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox9.Items.Add(T1); T1 = "";
              
            }

            //*************************************combobox12 Otaq 

            Qowul("select* from otaq");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T1 += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox12.Items.Add(T1); T1 = "";
            }

       //********************************************datagridView7********************************************************
            dataGridView7.EnableHeadersVisualStyles = false;
            dataGridView7.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;



            dataGridView7.RowCount = 7;
            dataGridView7.ColumnCount = 6;

            for (i = 0; i < 7; i++)
                dataGridView7.Rows[i].Height = 50;

            //**************************************************** sutunlarin adlari
            con.Open();
            da = new SqlDataAdapter("select* from hefte", con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

            for (i = 1; i <= 5; i++)
                dataGridView7.Columns[i].HeaderText = ds.Tables[0].Rows[i - 1].ItemArray[0].ToString();

            //********************************************************** setirlerin adlari 
          con.Open();
            da = new SqlDataAdapter("select* from saat2", con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

          for (i = 0; i < ds.Tables[0].Rows.Count; i++)
          dataGridView7[0,i].Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();

          for (j = 0; j <= 5; j++)
          {
              for (i = 0; i <= 6; i++)
                  dataGridView7.Rows[i].Cells[j].Style.BackColor = Reng2(i);
          }

         //*************************************************************cedvelin doldurulmasi
          string P2 = "";
          for (i = 1; i <= 7; i++)
              for (j = 1; j <= 6; j++)
              {
                  DataTable DT = Sorgu("select * from T1 where gun_nomre like " + i.ToString() + " and saat_nomre like " + j.ToString() + " and muellim like '" + comboBox13.Text + "'");
                  for (int l = 0; l < DT.Rows.Count; l++)
                  {
                      P = "";
                      for (int m = 2; m <= 5; m++)
                          P2 += DT.Rows[l].ItemArray[m].ToString() + " ";
                      dataGridView6[j, i + l - 1].Value = P2;
                  }
              }


            //*************************************combobox13  Muellim 
            string T2 = " ";
            Qowul("select* from muellimler");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T2 += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox13.Items.Add(T2); T2 = "";
            }
            //*************************************combobox14 Fenler 
            Qowul("select* from fennler");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T2 += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox14.Items.Add(T2); T2 = "";
            }


            //*************************************combobox15 Qr 
            Qowul("select* from qrup");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T2 += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox15.Items.Add(T2); T2 = "";

            }

            //*************************************combobox16 Otaq 

            Qowul("select* from otaq");
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    T2 += ds.Tables[0].Rows[i].ItemArray[j].ToString() + "  ";
                comboBox16.Items.Add(T2); T2 = "";
            }
           

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }

        private void umumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
        }

        private void muellimlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void fenlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox4.Visible = false;
        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar == 8))
                textBox1.ReadOnly = false;
            else textBox1.ReadOnly = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox1.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar == 8))
                textBox2.ReadOnly = false;
            else textBox2.ReadOnly = true;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox2.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox3.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar == 8))
                textBox4.ReadOnly = false;
            else textBox4.ReadOnly = true;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox4.TextLength == 0)
                    MessageBox.Show("Empty");
                else textBox5.Focus();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == 8))
                textBox6.ReadOnly = false;
            else textBox6.ReadOnly = true;
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox6.TextLength == 0)
                    MessageBox.Show("Empty");
                else comboBox7.Focus();
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == 8))
                textBox8.ReadOnly = false;
            else textBox8.ReadOnly = true;
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox8.TextLength == 0)
                    MessageBox.Show("Empty");
                else comboBox6.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select* from muellimler", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

            con.Open();
            com = new SqlCommand("insert into muellimler(ad,soyad,elmi_derece)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
            com.ExecuteNonQuery();
            con.Close();

            goster1("select* from muellimler");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select* from fennler", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

            con.Open();
            com = new SqlCommand("insert into fennler(ad,tip)values('" + textBox4.Text + "','" + textBox5.Text + "')", con);
            com.ExecuteNonQuery();
            con.Close();

            goster2("select* from fennler");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select* from qrup", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            string M="";
            int N = 0;
            string T = DateTime.Now.Year.ToString();
            T = T.Substring(2, 2);
            N = Nomre("select* from qrup"); N++;
            if (N.ToString().Length == 1)
                M =comboBox8.Text+"00"+N.ToString()+ T;
               else
            M =comboBox8.Text+ N.ToString()+ T.ToString();
              
               textBox6.Text = M;

            con.Open();
            com = new SqlCommand("insert into qrup(nomre,kurs,sektor)values('" + textBox6.Text + "','" + comboBox7.Text + "','" + comboBox1.Text + "')", con);
            com.ExecuteNonQuery();
            con.Close();

            goster3("select* from qrup");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select* from otaq", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

            string F = "";
            int N = 0;
            N = Nomre("select* from otaq"); N++;
            if (N.ToString().Length == 1)
                F = "00" + N.ToString();
            else F = N.ToString();
            textBox8.Text = F;

            con.Open();
            com = new SqlCommand("insert into otaq(nomre,mertebe)values('" + textBox8.Text + "','" + comboBox6.Text + "')", con);
            com.ExecuteNonQuery();
            con.Close();

            goster4("select* from otaq");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setir = e.RowIndex;
            sutun = e.ColumnIndex;
            con.Open();
            com = new SqlCommand("delete from muellimler where ad like '" + dataGridView1[sutun, setir].Value.ToString() + "'", con);
            com.ExecuteNonQuery();
            con.Close();

            DialogResult a = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
            switch (a)
            {
                case DialogResult.Yes: break;
                case DialogResult.No:  break;
            }
            goster1("select* from muellimler");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setir1 = e.RowIndex;
            sutun1 = e.ColumnIndex;
            con.Open();
            com = new SqlCommand("delete from fennler where ad like '" + dataGridView2[sutun1, setir1].Value.ToString() + "'", con);
            com.ExecuteNonQuery();
            con.Close();

            DialogResult a = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
            switch (a)
            {
                case DialogResult.Yes: break;
                case DialogResult.No: break;
            }
            goster2("select* from fennler");
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setir2 = e.RowIndex;
            sutun2 = e.ColumnIndex;
            con.Open();
            com = new SqlCommand("delete from qrup where nomre like '" + dataGridView3[sutun2, setir2].Value.ToString() + "'", con);
            com.ExecuteNonQuery();
            con.Close();

            DialogResult a = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
            switch (a)
            {
                case DialogResult.Yes: break;
                case DialogResult.No: break;
            }
            goster3("select* from qrup");
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setir3 = e.RowIndex;
            sutun3 = e.ColumnIndex;
            con.Open();
            com = new SqlCommand("delete from otaq where nomre like '" + dataGridView4[sutun3, setir3].Value.ToString() + "'", con);
            com.ExecuteNonQuery();
            con.Close();

            DialogResult a = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
            switch (a)
            {
                case DialogResult.Yes: break;
                case DialogResult.No: break;
            }
            goster4("select* from otaq");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {


        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           con.Open();
            da=new SqlDataAdapter("select* from T1 where gun_nomre like "+e.ColumnIndex.ToString()+" and saat_nomre like "+e.RowIndex.ToString()+"",con);
            ds= new DataSet();
            da.Fill(ds);
            con.Close();
            int Res=0;
              for(i=0;i<ds.Tables[0].Rows.Count;i++)
                  if(ds.Tables[0].Rows[i].ItemArray[6].ToString()=="0" )Res++;

              if (Res == 1) MessageBox.Show("ERROR!");
              else
              {
                  dataGridView5[e.ColumnIndex, e.RowIndex].Value = comboBox2.Text + "  " + comboBox3.Text + "   " + comboBox4.Text + "  " + comboBox5.Text;

                  con.Open();
                  string ID = "1";

                  int Gun = 0;
                  if (e.RowIndex >= 0 && e.RowIndex < 4) Gun = 1;
                  if (e.RowIndex >= 4 && e.RowIndex < 8) Gun = 2;
                  if (e.RowIndex >= 8 && e.RowIndex < 12) Gun = 3;
                  if (e.RowIndex >= 12 && e.RowIndex < 16) Gun = 4;
                  if (e.RowIndex >= 16 && e.RowIndex < 20) Gun = 5;

                  //MessageBox.Show("Insert into T1(gun_nomre,saat_nomre,muellim,fennler,qrup,otaq,id)values(" + Gun.ToString() + "," + e.ColumnIndex.ToString() + ",'" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "'," + ID + ")");
                  com = new SqlCommand("Insert into T1(gun_nomre,saat_nomre,muellim,fennler,qrup,otaq,id)values(" + Gun.ToString() + "," + (e.ColumnIndex).ToString() + ",'" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "'," + ID + ")", con);
                  com.ExecuteNonQuery();
                  con.Close();
              }
        }

        private void groupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
          
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            con.Open();
            da = new SqlDataAdapter("select* from T1 where gun_nomre like " + e.ColumnIndex.ToString() + " and saat_nomre like " + e.RowIndex.ToString() + "", con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            int Res = 0;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                if (ds.Tables[0].Rows[i].ItemArray[6].ToString() == "0") Res++;

            if (Res == 1) MessageBox.Show("ERROR!");
            else
            {
                dataGridView6[e.ColumnIndex, e.RowIndex].Value = comboBox9.Text + "  " + comboBox10.Text + "   " + comboBox11.Text + "  " + comboBox12.Text;

                con.Open();
                string ID = "1";

                int Gun = 0;
               if (e.RowIndex==0) Gun = 1;
                if (e.RowIndex==1) Gun = 2;
                if (e.RowIndex==2) Gun = 3;
                if (e.RowIndex==3) Gun = 4;
                if (e.RowIndex==4) Gun = 5;
          

                //MessageBox.Show("Insert into T1(gun_nomre,saat_nomre,muellim,fennler,qrup,otaq,id)values(" + Gun.ToString() + "," + e.ColumnIndex.ToString() + ",'" + comboBox10.Text + "','" + comboBox11.Text + "','" + comboBox9.Text + "','" + comboBox12.Text + "'," + ID + ")");
                com = new SqlCommand("Insert into T1(gun_nomre,saat_nomre,muellim,fennler,qrup,otaq,id)values(" + Gun.ToString() + "," + (e.ColumnIndex).ToString() + ",'" + comboBox10.Text + "','" + comboBox11.Text + "','" + comboBox9.Text + "','" + comboBox12.Text + "'," + ID + ")", con);
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
          
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select* from T1 where gun_nomre like " + e.ColumnIndex.ToString() + " and saat_nomre like " + e.RowIndex.ToString() + "", con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            int Res = 0;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                if (ds.Tables[0].Rows[i].ItemArray[6].ToString() == "0") Res++;

            if (Res == 1) MessageBox.Show("ERROR!");
            else
            {
                dataGridView7[e.ColumnIndex, e.RowIndex].Value = comboBox13.Text + "  " + comboBox14.Text + "   " + comboBox15.Text + "  " + comboBox16.Text;

                con.Open();
                string ID = "1";

                int Gun = 0;
                if (e.RowIndex == 0) Gun = 1;
                if (e.RowIndex == 1) Gun = 2;
                if (e.RowIndex == 2) Gun = 3;
                if (e.RowIndex == 3) Gun = 4;
                if (e.RowIndex == 4) Gun = 5;


                //MessageBox.Show("Insert into T1(gun_nomre,saat_nomre,muellim,fennler,qrup,otaq,id)values(" + Gun.ToString() + "," + e.ColumnIndex.ToString() + ",'" + comboBox10.Text + "','" + comboBox11.Text + "','" + comboBox9.Text + "','" + comboBox12.Text + "'," + ID + ")");
                com = new SqlCommand("Insert into T1(gun_nomre,saat_nomre,muellim,fennler,qrup,otaq,id)values(" + Gun.ToString() + "," + (e.ColumnIndex).ToString() + ",'" + comboBox13.Text + "','" + comboBox14.Text + "','" + comboBox15.Text + "','" + comboBox16.Text + "'," + ID + ")", con);
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1_Load(sender,e);
        }
    }
}
