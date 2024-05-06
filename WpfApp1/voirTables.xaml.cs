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
            
        }

        private void lstTables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.txtTable.Text = "";
            //string table = (string)this.lstTables.SelectedItem.ToString();

            string table = (lstTables.SelectedItem as ListBoxItem)?.Content?.ToString();

            int tableS = Convert.ToInt32(table);



            for(int i = 1; i <= 10; i++)
            {
                this.txtTable.Text += $"{table} × {i} = {tableS * i}\r\n";
            }



        }

    }
}
