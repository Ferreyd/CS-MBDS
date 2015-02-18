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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QCM.BuisinessLayer.Correcteurs;
using QCM.BuisinessLayer;

namespace QCM.RichClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QCM.BuisinessLayer.QCM Qcm = new BuisinessLayer.QCM("QCM Vide");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Date(object sender, RoutedEventArgs e)
        {
            DateTime localTime = DateTime.Now;
            DateTime noelTime = DateTime.Parse("2015-12-25");
            TimeSpan res = noelTime - localTime;

            String str = String.Format("Il reste " + res.Days + " jours " + res.Hours + " heures" + res.Minutes + " minutes " + res.Seconds + " secondes avant noël 2015");
            MessageBox.Show(str);

        }

        private void Button_Click_QCM(object sender, RoutedEventArgs e)
        {
            Proposition p1 = new Proposition { EstJuste = true, Id = 1, Phrase = "Oui"};
            Question q1 = new Question { Id = 1, Phrase = "Oui ou Non ?"};           
            Reponse r = new Reponse { EstJuste = true, Id = 1};
            Proposition p2 = new Proposition { EstJuste = false, Id = 2, Phrase = "Non" }; 
            q1.Propositions.Add(p2);
            q1.Propositions.Add(p1);
            Qcm.Questions.Add(q1);
            MessageBox.Show(Qcm.ToString());
        }

        private void Button_Click_Correcteur(object sender, RoutedEventArgs e)
        {
            CorrecteurCalculMoyenne correcteur = new CorrecteurCalculMoyenne();
            decimal res = correcteur.Noter(Qcm);
            MessageBox.Show(res.ToString());

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
