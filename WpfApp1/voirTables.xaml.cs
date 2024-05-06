using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour voirTables.xaml
    /// </summary>
    public partial class voirTables : Window
    {
        public voirTables()
        {
            InitializeComponent();
            // Code à compléter
            for (int i = 1; i <= 10; i++)
            {
                this.lstTables.Items.Add(i);
            }

        }

        private void lstTables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.txtTable.Text = "";

            int table = (int)this.lstTables.SelectedItem;

            for(int i = 1; i <= 10; i++)
            {
                this.txtTable.Text += $"{table} × {i} = {table * i}\r\n";
            }



        }

    }
}
