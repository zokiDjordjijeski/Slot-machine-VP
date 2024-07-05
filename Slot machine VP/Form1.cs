using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Slot_machine_VP
{
    [Serializable]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // ДЕКЛАРАЦИЈА НА ВКУПНО, ОБЛОГ И КРЕДИТИ
        public static long credits = 100;
        public static long total = 0;
        public int bet;

        // ДЕКЛАРАЦИЈА НА СЕКОЈ СИМБОЛ
        public static int p1;
        public static int p2;
        public static int p3;
        public static int p4;
        public static int p5;
        public static int p6;
        public static int p7;
        public static int p8;
        public static int p9;

        // Вчитување на сликите за слот машината
        private Image[] images;

        // Променлива за зачувување на позициите на симболите за поврзување со линија
        private List<Point> linePoints;

        // Променлива за следење дали линијата треба да се прикажува
        private bool drawLine = false;

        private int CalculateWin(params int[] positions)
        {
            int total = 0;
            int[] symbolCounts = new int[images.Length]; // Низа за броење на симболите

            // Пресметај колку пати се појавува секој симбол
            foreach (int position in positions)
            {
                symbolCounts[position]++;
            }

            // Пресметај добивки според бројот на појавувања на симболите
            for (int i = 0; i < symbolCounts.Length; i++)
            {
                int count = symbolCounts[i];
                switch (i)
                {
                    case 0: // Цреша
                        if (count >= 4)
                        {
                            total += 5;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 2;
                        }
                        else if (count == 2) total += 1;
                        if (count >= 5)
                        {
                            total += 7;
                            AddLinePoints(i);
                        }
                        break;
                    case 1: // Лубеница
                        if (count >= 4)
                        {
                            total += 6;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 1;
                        }
                        if (count >= 5)
                        {
                            total += 7;
                            AddLinePoints(i);
                        }

                        break;
                    case 2: // Лимон
                        if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 5;
                        }
                        else if (count >= 4)
                        {
                            total += 7;
                            AddLinePoints(i);
                        }

                        break;
                    case 3: // Ѕвонче
                        if (count >= 4)
                        {
                            total += 15;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 4;
                        }

                        if (count >= 5)
                        {
                            total += 7;
                        }

                        break;
                    case 4: // Бар
                        if (count >= 4)
                        {
                            total += 5;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 2;
                        }
                        if (count >= 6)
                        {
                            total += 7;
                        }

                        break;
                    case 5: // Слива
                        if (count >= 4)
                        {
                            total += 15;
                            AddLinePoints(i);

                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 5;
                        }
                        else if (count == 2) total += 2;
                        if (count >= 4)
                        {
                            total += 7;
                        }

                        break;
                    case 6: // Срце
                        if (count >= 4)
                        {
                            total += 15;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            total += 7;
                            AddLinePoints(i);
                        }
                        else if (count == 2) total += 2;
                        if (count >= 5)
                        {
                            total += 7;
                        }
                        break;
                    case 7: // Детелина
                        if (count >= 4)
                        {
                            total += 20;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            total += 13;
                            AddLinePoints(i);
                        }
                        else if (count == 2) total += 4;
                        if (count >= 5)
                        {
                            total += 7;
                        }

                        break;
                    case 8: // Портокал
                        if (count >= 4)
                        {
                            total += 18;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 9;
                        }
                        else if (count == 2) total += 3;
                        if (count >= 5)
                        {
                            total += 10;
                        }
                        break;
                    case 9: // Потковица
                        if (count >= 4)
                        {
                            total += 12;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            total += 8;
                            AddLinePoints(i);
                        }
                        else if (count == 2) total += 3;
                        if (count > 3) AddLinePoints(i);
                        if (count >= 5)
                        {
                            total += 30;
                        }

                        break;
                    case 10: // Грозје
                        if (count >= 4)
                        {
                            total += 14;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 7;
                        }
                        else if (count == 2) total += 3;
                        if (count >= 5)
                        {
                            total += 7;
                        }

                        break;
                    case 11: // Јаболко
                        if (count >= 4)
                        {
                            total += 10;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 3;
                        }
                        if (count >= 6)
                        {
                            total += 7;
                        }
                        break;
                    case 12: // Дијамант
                        if (count >= 4)
                        {
                            total += 36;
                            AddLinePoints(i);
                        }
                        else if (count == 3)
                        {
                            total += 15;
                            AddLinePoints(i);
                        }
                        else if (count == 2) total += 7;
                        if (count >= 5)
                        {
                            total += 48;
                        }


                        break;
                    case 13: // Монета
                        if (count >= 3)
                        {
                            AddLinePoints(i);
                            total += 14;
                        }
                        else if (count == 3)
                        {
                            AddLinePoints(i);
                            total += 5;
                        }
                        else if (count == 2) total += 5;
                        if (count >= 5)
                        {
                            total += 38;
                            AddLinePoints(i);

                        }
                        break;
                }

            }

            // Ако има голема добивка, овозможи цртање на линијата
            if (total > 0)
            {
                drawLine = true;
            }

            return total;
        }

        private void AddLinePoints(int key)
        {
            // Зачувување на точките за линиите
            linePoints = new List<Point>();

            foreach (var pictureBox in new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9 })
            {
                // Проверка дали сликата во PictureBox е истата со клучот
                if (pictureBox.Image == images[key])
                {
                    var location = pictureBox.Location;
                    var center = new Point(location.X + pictureBox.Width / 2, location.Y + pictureBox.Height / 2);
                    linePoints.Add(center);
                }
            }
        }


        // Метод за чистење на сите нацртани линии
        private void ClearLines()
        {
            linePoints = null;
            drawLine = false;
            Invalidate();
        }

        private void nudBET_ValueChanged_1(object sender, EventArgs e)
        {
            bet = (int)nudBET.Value;
        }

        private void nudBET_Paint(object sender, PaintEventArgs e)
        {
            // Цртање на црвена линија за големи добивки
            if (drawLine && linePoints != null && linePoints.Count > 1)
            {
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    e.Graphics.DrawLines(pen, linePoints.ToArray());
                }
            }
        }

        private void btnROLL_Click(object sender, EventArgs e)
        {
            // Ресетирај линиите пред новото вртење
            ClearLines();

            // Ажурирај облог според вредноста од нумеричката контрола
            bet = (int)nudBET.Value;

            if (credits >= bet)
            {
                credits -= bet;
                lblCREDIT.Text = "Кредити: " + credits.ToString();

                // Врти ги ролните
                p1 = IntUtil.Random(0, images.Length);
                p2 = IntUtil.Random(0, images.Length);
                p3 = IntUtil.Random(0, images.Length);
                p4 = IntUtil.Random(0, images.Length);
                p5 = IntUtil.Random(0, images.Length);
                p6 = IntUtil.Random(0, images.Length);
                p7 = IntUtil.Random(0, images.Length);
                p8 = IntUtil.Random(0, images.Length);
                p9 = IntUtil.Random(0, images.Length);

                // Постави ги сликите
                pictureBox1.Image = images[p1];
                pictureBox2.Image = images[p2];
                pictureBox3.Image = images[p3];
                pictureBox4.Image = images[p4];
                pictureBox5.Image = images[p5];
                pictureBox6.Image = images[p6];
                pictureBox7.Image = images[p7];
                pictureBox8.Image = images[p8];
                pictureBox9.Image = images[p9];

                Invalidate();
                // Пресметај ја добивката и ажурирај ги кредитите
                total = CalculateWin(p1, p2, p3, p4, p5, p6, p7, p8, p9) * bet / 3;
                total -= total / 4;
                credits += total;
                lbWIN.Text = "Win: " + total.ToString();
                lblCREDIT.Text = "Credit: " + credits.ToString();

                // Освежи ја формата за да се нацрта или избрише линијата
                Invalidate();
            }
        }

        private void btnADDCREDIT_Click_1(object sender, EventArgs e)
        {
            Add_Credit addCredit = new Add_Credit();
            if (addCredit.ShowDialog() == DialogResult.OK)
            {
                credits += addCredit.amount;
                lblCREDIT.Text = "Credit: " + credits.ToString();
            }
        }

        private void btnCASHOUT_Click_1(object sender, EventArgs e)
        {
            credits = 0;
            lblCREDIT.Text = "Credit: " + credits.ToString();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            // Цртање на црвена линија за големи добивки
            if (drawLine && linePoints != null && linePoints.Count > 1)
            {
                using (Pen pen = new Pen(Color.Red, 7))
                {
                    e.Graphics.DrawLines(pen, linePoints.ToArray());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Поставување на слика за позадина
            this.BackgroundImage = Image.FromFile("background.jpeg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Вчитување на слики во низата
            images = new Image[]
            {
                    Image.FromFile("1.png"),  // Цреша
                    Image.FromFile("2.png"),  // Лубеница
                    Image.FromFile("3.png"),  // Лимон
                    Image.FromFile("4.png"),  // Бар
                    Image.FromFile("5.png"),  // Слива
                    Image.FromFile("6.png"),  // Срце
                    Image.FromFile("7.png"),  // Детелина
                    Image.FromFile("8.png"),  // Портокал
                    Image.FromFile("9.png"),  // Ѕвонче
                    Image.FromFile("10.png"), // Монета
                    Image.FromFile("11.png"), // Потковица
                    Image.FromFile("12.png"), // Грозје
                    Image.FromFile("13.png"), // Јаболко
                    Image.FromFile("14.png")  // Дијамант
            };

            // Иницијализација на PictureBox-ите со стандардни слики
            pictureBox1.Image = images[IntUtil.Random(0, images.Length)];
            pictureBox2.Image = images[IntUtil.Random(0, images.Length)];
            pictureBox3.Image = images[IntUtil.Random(0, images.Length)];
            pictureBox4.Image = images[IntUtil.Random(0, images.Length)];
            pictureBox5.Image = images[IntUtil.Random(0, images.Length)];
            pictureBox6.Image = images[IntUtil.Random(0, images.Length)];
            pictureBox7.Image = images[IntUtil.Random(0, images.Length)];
            pictureBox8.Image = images[IntUtil.Random(0, images.Length)];
            pictureBox9.Image = images[IntUtil.Random(0, images.Length)];

            // Поставување на стандардна вредност за облог
            bet = (int)nudBET.Value;
        }
    }
}
