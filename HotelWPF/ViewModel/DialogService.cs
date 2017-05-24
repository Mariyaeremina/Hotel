using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel
{
    public class DialogService 
    {
        public static void ShowMessage(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
