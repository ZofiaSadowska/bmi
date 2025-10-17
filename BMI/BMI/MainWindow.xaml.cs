using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ObliczBMI_Click(object sender, RoutedEventArgs e)
        {
            
                if (string.IsNullOrWhiteSpace(txtWaga.Text) || string.IsNullOrWhiteSpace(txtWzrost.Text))
                {
                    txtOpis.Text = "Prosze wprowadzic dane";
                    return;
                }
                if (!double.TryParse(txtWaga.Text, out double waga) ||
                    !double.TryParse(txtWzrost.Text, out double wzrost))
                {
                    txtOpis.Text = "Prosze wprowadzic poprawne dane";
                    return;
                }
                
                

                string jednostkaWagi = ((ComboBoxItem)cmbWagaJednostka.SelectedItem).Content.ToString();
                string jednostkaWzrostu = ((ComboBoxItem)cmbWzrostJednostka.SelectedItem).Content.ToString();

                double wagaKg = 0;
                double wzrostM = 0;

                if ((jednostkaWzrostu == "stopy" || jednostkaWzrostu == "cale") && jednostkaWagi != "funty")
                {
                    txtOpis.Text = "Prosze podac wage w funtach";
                    return;
                }

                if (jednostkaWzrostu == "cm" && jednostkaWagi != "kg")
                {
                    txtOpis.Text = "Prosze podac wage w kilogramach.";
                    return;
                }

            if (jednostkaWagi == "kg")
            {
                if (waga >= 30 && waga <= 150)
                {
                    txtOpis.Text = "Waga nie miesci sie w zakresie od 30 do 150";
                }
                else wagaKg = waga;

            }
            else
            {
                wagaKg = waga * 0.45359237;

            }

                if (jednostkaWzrostu == "cm")
                {
                    if (wzrost >= 100 && wzrost <= 250)
                    {
                        txtOpis.Text = "Wzrost nie miesci sie w zakresie od 100 do 250";
                    }
                    else wzrostM = wzrost/100;

            }
                else if(jednostkaWzrostu == "cale")
                {
                    wzrostM = wzrost * 0.0254;

            }
                else
                {
                    wzrostM = wzrost * 0.3048;

            }

                

                double bmi = wagaKg / (wzrostM * wzrostM);

                string kategoria;
                if (bmi < 18.5)
                    kategoria = "Niedowaga. Rozważ wizyte u dietetyka,staraj sie jesc wiecej i o stalych porach.";
                else if (bmi > 18.5 && bmi < 24.9)
                    kategoria = "Prawidłowa masa ciała. Tak trzymaj pamietaj o systematycznych ćwiczeniach.";
                else if (bmi > 25 && bmi < 29.9)
                    kategoria = "Nadwaga. Rozważ wizyte u dietetyka, pamietaj o ćwiczeniach.";
                else
                    kategoria = "Otyłość. Nie ma rantunku :(";

                bmi = bmi*100;
                bmi = Math.Round(bmi);
                bmi = bmi / 100;

            txtWynik.Content = bmi;
            txtOpis.Text = kategoria;
            }
            
        
    }
}