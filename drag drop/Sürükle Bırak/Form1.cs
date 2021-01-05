using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sürükle_Bırak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int indeks;
        private void listBox1_MouseDown(object sender, MouseEventArgs buton)
        {
            //farenin listbox içerisinde kliklenen yerin koordinatlrını alır.
            Point nokta = new Point(buton.X, buton.Y);
            //IndexFromPoint()=Listbox'ın kliklenen elemanının indexini verir.
            indeks = listBox1.IndexFromPoint(nokta);
            if (indeks==-1)
            {
                return;
            }
            if (buton.Button==MouseButtons.Left)
            {
                //sürüklenecek nesne alınıyor
                listBox1.DoDragDrop(listBox1.Items[indeks], DragDropEffects.Move);
            }

        }

        private void listBox2_DragOver(object sender, DragEventArgs e)
        {
            if (e.KeyState==1)//1=sol tuş, 2=sağ tuş
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            int index = listBox1.SelectedIndices.Count - 1;
            //for (int i = listBox1.SelectedIndices.Count - 1; i >=0; i--)
            //{
            //    listBox2.Items.Add(listBox1.SelectedItems[i]);
            //    listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            //}

            while (index >=0)
            {
                listBox2.Items.Add(listBox1.SelectedItems[index]);
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[index]);
                index--;
            }
        }
    }
}

//Üzerine bırakılacak nesne (listbox2) AllowDrop özelliğ true yapılmak zorundadır. 
