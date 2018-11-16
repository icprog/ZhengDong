using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
namespace FishClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            //CreateImage();
            InitializeComponent();
        }
        private void CreateImage()
        {
            int height = 500, width = 700;
            Bitmap image = new Bitmap(width, height);
            //创建Graphics类对象
            Graphics g = Graphics.FromImage(image);

            try
            {
                //清空图片背景色
                g.Clear(Color.White);

                Font font = new Font("Arial", 10, FontStyle.Regular);
                Font font1 = new Font("宋体", 20, FontStyle.Bold);

                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                Color.Blue, Color.BlueViolet, 1.2f, true);
                g.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
                // Brush brush1 = new SolidBrush(Color.Blue);

                //g.DrawString(this.ddlTaget.SelectedItem.Text + " " + this.ddlYear.SelectedItem.Text + " 成绩统计柱状图", font1, brush, new PointF(70, 30));
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 1, image.Height - 1);


                Pen mypen = new Pen(brush, 1);
                //绘制线条
                //绘制横向线条
                int x = 100;
                for (int i = 0; i < 14; i++)
                {
                    g.DrawLine(mypen, x, 80, x, 340);
                    x = x + 40;
                }
                Pen mypen1 = new Pen(Color.Blue, 2);
                x = 60;
                g.DrawLine(mypen1, x, 80, x, 340);

                //绘制纵向线条
                int y = 106;
                for (int i = 0; i < 9; i++)
                {
                    g.DrawLine(mypen, 60, y, 620, y);
                    y = y + 26;
                }
                g.DrawLine(mypen1, 60, y, 620, y);

                //x轴
                String[] n = { "第一期", "第二期", "第三期", "第四期", "上半年", "下半年", "全年统计" };
                x = 78;
                for (int i = 0; i < 7; i++)
                {
                    g.DrawString(n[i].ToString(), font, Brushes.Blue, x, 348); //设置文字内容及输出位置
                    x = x + 78;
                }

                //y轴
                String[] m = {"250","225", "200", "175", "150", "125", "100", " 75",
" 50", " 25", " 0"};
                y = 72;
                for (int i = 0; i < 10; i++)
                {
                    g.DrawString(m[i].ToString(), font, Brushes.Blue, 25, y); //设置文字内容及输出位置
                    y = y + 26;
                }

                int[] Count1 = new int[7];
                int[] Count2 = new int[7];

                SqlConnection Con = new SqlConnection("Server=(Local);Database=committeeTraining;Uid=sa;Pwd=**");
                Con.Open();
                string cmdtxt2 = "SELECT * FROM ##Count where Company='"/* + this.ddlTaget.SelectedItem.Text.Trim() + "'"*/;
                SqlDataAdapter da = new SqlDataAdapter(cmdtxt2, Con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                Count1[0] = Convert.ToInt32(ds.Tables[0].Rows[0]["count1"].ToString());
                Count1[1] = Convert.ToInt32(ds.Tables[0].Rows[0]["count3"].ToString());
                Count1[2] = Convert.ToInt32(ds.Tables[0].Rows[0]["count5"].ToString());
                Count1[3] = Convert.ToInt32(ds.Tables[0].Rows[0]["count7"].ToString());

                Count1[4] = Count1[0] + Count1[1];
                Count1[5] = Count1[2] + Count1[3];

                Count1[6] = Convert.ToInt32(ds.Tables[0].Rows[0]["count9"].ToString());


                Count2[0] = Convert.ToInt32(ds.Tables[0].Rows[0]["count2"].ToString());
                Count2[1] = Convert.ToInt32(ds.Tables[0].Rows[0]["count4"].ToString());
                Count2[2] = Convert.ToInt32(ds.Tables[0].Rows[0]["count6"].ToString());
                Count2[3] = Convert.ToInt32(ds.Tables[0].Rows[0]["count8"].ToString());

                Count2[4] = Count2[0] + Count2[1];
                Count2[5] = Count2[2] + Count2[3];

                Count2[6] = Convert.ToInt32(ds.Tables[0].Rows[0]["count10"].ToString());

                //绘制柱状图.
                x = 80;
                Font font2 = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                SolidBrush mybrush = new SolidBrush(Color.Red);
                SolidBrush mybrush2 = new SolidBrush(Color.Green);

                //第一期
                g.FillRectangle(mybrush, x, 340 - Count1[0], 20, Count1[0]);
                g.DrawString(Count1[0].ToString(), font2, Brushes.Red, x, 340 - Count1[0] - 15);

                x = x + 20;
                g.FillRectangle(mybrush2, x, 340 - Count2[0], 20, Count2[0]);
                g.DrawString(Count2[0].ToString(), font2, Brushes.Green, x, 340 - Count2[0] - 15);


                //第二期
                x = x + 60;
                g.FillRectangle(mybrush, x, 340 - Count1[1], 20, Count1[1]);
                g.DrawString(Count1[1].ToString(), font2, Brushes.Red, x, 340 - Count1[1] - 15);


                x = x + 20;
                g.FillRectangle(mybrush2, x, 340 - Count2[1], 20, Count2[1]);
                g.DrawString(Count2[1].ToString(), font2, Brushes.Green, x, 340 - Count2[1] - 15);


                //第三期
                x = x + 60;
                g.FillRectangle(mybrush, x, 340 - Count1[2], 20, Count1[2]);
                g.DrawString(Count1[2].ToString(), font2, Brushes.Red, x, 340 - Count1[2] - 15);

                x = x + 20;
                g.FillRectangle(mybrush2, x, 340 - Count2[2], 20, Count2[2]);
                g.DrawString(Count2[2].ToString(), font2, Brushes.Green, x, 340 - Count2[2] - 15);

                //第四期
                x = x + 60;
                g.FillRectangle(mybrush, x, 340 - Count1[3], 20, Count1[3]);
                g.DrawString(Count1[3].ToString(), font2, Brushes.Red, x, 340 - Count1[3] - 15);

                x = x + 20;
                g.FillRectangle(mybrush2, x, 340 - Count2[3], 20, Count2[3]);
                g.DrawString(Count2[3].ToString(), font2, Brushes.Green, x, 340 - Count2[3] - 15);

                //上半年
                x = x + 60;
                g.FillRectangle(mybrush, x, 340 - Count1[4], 20, Count1[4]);
                g.DrawString(Count1[4].ToString(), font2, Brushes.Red, x, 340 - Count1[4] - 15);

                x = x + 20;
                g.FillRectangle(mybrush2, x, 340 - Count2[4], 20, Count2[4]);
                g.DrawString(Count2[4].ToString(), font2, Brushes.Green, x, 340 - Count2[4] - 15);

                //下半年
                x = x + 60;
                g.FillRectangle(mybrush, x, 340 - Count1[5], 20, Count1[5]);
                g.DrawString(Count1[5].ToString(), font2, Brushes.Red, x, 340 - Count1[5] - 15);

                x = x + 20;
                g.FillRectangle(mybrush2, x, 340 - Count2[5], 20, Count2[5]);
                g.DrawString(Count2[5].ToString(), font2, Brushes.Green, x, 340 - Count2[5] - 15);

                //全年
                x = x + 60;
                g.FillRectangle(mybrush, x, 340 - Count1[6], 20, Count1[6]);
                g.DrawString(Count1[6].ToString(), font2, Brushes.Red, x, 340 - Count1[6] - 15);


                x = x + 20;
                g.FillRectangle(mybrush2, x, 340 - Count2[6], 20, Count2[6]);
                g.DrawString(Count2[6].ToString(), font2, Brushes.Green, x, 340 - Count2[6] - 15);


                //绘制标识
                Font font3 = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                g.DrawRectangle(new Pen(Brushes.Blue), 170, 400, 250, 50); //绘制范围框
                g.FillRectangle(Brushes.Red, 270, 410, 20, 10); //绘制小矩形
                g.DrawString("报名人数", font3, Brushes.Red, 292, 408);

                g.FillRectangle(Brushes.Green, 270, 430, 20, 10);
                g.DrawString("通过人数", font3, Brushes.Green, 292, 428);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //Response.ClearContent();
                //Response.ContentType = "image/Jpeg";
                //Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        DataTable tableView;
        FishBll.Bll.PriWarehouseBll _bll = null;
        private void panel1_Click(object sender, EventArgs e)
        {
            _bll = new FishBll.Bll.PriWarehouseBll();
            tableView = _bll.mx();
            dataGridView1.DataSource = tableView;
            return;
        }
    }
}
