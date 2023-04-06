using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Декоратор
{
    public partial class Form1 : Form
    {
        private Decorator.CardComponentBase _card;
        public Form1()
        {
            InitializeComponent();
            _card = new Decorator.CardComponent(400, 350); // create a basic card component
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();

            if (checkBox1.Checked)
            {
                _card = new Decorator.BorderDecorator(_card, Color.Black, 10);
            }

            if (checkBox2.Checked)
            {
                Image image = Image.FromFile(" E:\\прог\\4 курс\\КПЗ\\Декоратор\\Dimiourgos_repeating_japanese_pattern_83a1f057-aded-44ca-a2bb-28a2109718d1.png ");
                _card = new Decorator.ImageDecorator(_card, image);
                _card = new Decorator.BorderDecorator(_card, Color.Red, 10);
            }

            if (checkBox3.Checked)
            {
                Image image = Image.FromFile(" E:\\прог\\4 курс\\КПЗ\\Декоратор\\Dimiourgos_repeating_japanese_pattern_f1c40323-9ae3-452b-b690-8b2f4949d7ab.png ");
                _card = new Decorator.ImageDecorator(_card, image);
                _card = new Decorator.BorderDecorator(_card, Color.Blue, 10);
            }


            _card.Draw(graphics);
        }
    }
}
