using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace monopoly
{
    public partial class MainWindow : Window
    {
        int zasoby = 0;
        int kartyUcieczki = 0;
        bool biletGalaktyczny = false;
        int planety = 0;
        bool zajetaPlaneta = false;
        bool wykupiona = false;
        bool zastawiona = false;

        public MainWindow()
        {
            InitializeComponent();
            new_game();
        }

        private void update_player_values()
        {
            zasobyLabel.Content = $"{zasoby} $";
            kartyUcieczkiLabel.Content = kartyUcieczki;
            planetyLabel.Content = $"{planety}/5";
            if(!wykupiona)
            {
                zajetaLabel.Content = zajetaPlaneta ? "Zajeta przez innego gracza" : "Niezajeta";
            }
        }

        private void update_planet_buttons()
        {
            bilet.IsEnabled = biletGalaktyczny ? true : false;
            ucieczka.IsEnabled = kartyUcieczki > 0 ? true : false;

            if(zajetaPlaneta)
            {
                port.IsEnabled = false;
                posterunek.IsEnabled = false;
                kopalnia.IsEnabled = false;
                farma.IsEnabled = false;
                zastaw.IsEnabled = false;
            } else
            {
                if(wykupiona && !zastawiona)
                {
                    port.IsEnabled = false;

                    if((string)(posterunek.Content) == "Posterunek: 4$")
                    {
                        posterunek.IsEnabled = zasoby < 4 ? false : true;
                    }
                    if ((string)(posterunek.Content) == "Habitaty mieszkalne: 5$")
                    {
                        posterunek.IsEnabled = zasoby < 5 ? false : true;
                    }
                    if ((string)(posterunek.Content) == "Kolonia: 6$")
                    {
                        posterunek.IsEnabled = zasoby < 6 ? false : true;
                    }
                    if ((string)(posterunek.Content) == "Hotel galaktyczny: 7$")
                    {
                        posterunek.IsEnabled = zasoby < 7 ? false : true;
                    }
                    if ((string)(posterunek.Content) == "Siec hoteli planetarnych: 8$")
                    {
                        if(planety == 5)
                        {
                            posterunek.IsEnabled = zasoby < 8 ? false : true;
                        } else
                        {
                            posterunek.IsEnabled = false;
                        }
                    }

                    if ((string)(kopalnia.Content) == "Kopalnia I stopnia: 5$")
                    {
                        kopalnia.IsEnabled = zasoby < 5 ? false : true;
                    }
                    if ((string)(kopalnia.Content) == "Kopalnia II stopnia: 6$")
                    {
                        kopalnia.IsEnabled = zasoby < 6 ? false : true;
                    }
                    if ((string)(kopalnia.Content) == "Kopalnia III stopnia: 7$")
                    {
                        kopalnia.IsEnabled = zasoby < 7 ? false : true;
                    }

                    if ((string)(farma.Content) == "Farma zywnosci I: 3$")
                    {
                        farma.IsEnabled = zasoby < 3 ? false : true;
                    }
                    if ((string)(farma.Content) == "Farma zywnosci II: 4$")
                    {
                        farma.IsEnabled = zasoby < 4 ? false : true;
                    }
                    if ((string)(farma.Content) == "Farma zywnosci III: 5$")
                    {
                        farma.IsEnabled = zasoby < 5 ? false : true;
                    }
                    if ((string)(farma.Content) == "Farma zywnosci IV: 6$")
                    {
                        farma.IsEnabled = zasoby < 6 ? false : true;
                    }
                    if ((string)(farma.Content) == "Farma zywnosci V: 7$")
                    {
                        farma.IsEnabled = zasoby < 7 ? false : true;
                    }
                    if ((string)(farma.Content) == "Farma zywnosci VI: 8$")
                    {
                        farma.IsEnabled = zasoby < 8 ? false : true;
                    }

                    zastaw.IsEnabled = true;

                } 
                else if(wykupiona && zastawiona)
                {
                    port.IsEnabled = false;
                    posterunek.IsEnabled = false;
                    kopalnia.IsEnabled = false;
                    farma.IsEnabled = false;

                    zastaw.IsEnabled = zasoby >= 3 ? true : false;
                } 
                else
                {
                    posterunek.IsEnabled = false;
                    kopalnia.IsEnabled = false;
                    farma.IsEnabled = false;
                    zastaw.IsEnabled = false;

                    if (zasoby < 6)
                    {
                        port.IsEnabled = false;
                    } else
                    {
                        port.IsEnabled = true;
                    }
                }

            }

        }

        private void new_game()
        {
            Random rnd = new Random();
            zasoby = rnd.Next(20, 30);
            kartyUcieczki = rnd.Next(0, 5);
            zajetaPlaneta = Convert.ToBoolean(rnd.Next(0, 2));
            planety = rnd.Next(0, 5);
            wykupiona = false;

            posterunek.Content = "Posterunek: 4$";
            kopalnia.Content = "Kopalnia I stopnia: 5$";
            farma.Content = "Farma zywnosci I: 3$";

            update_player_values();
            update_planet_buttons();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new_game();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if((string)(posterunek.Content) == "Posterunek: 4$")
            {
                zasoby -= 4;
                posterunek.Content = "Habitaty mieszkalne: 5$";

            } else if((string)(posterunek.Content) == "Habitaty mieszkalne: 5$")
            {
                zasoby -= 5;
                posterunek.Content = "Kolonia: 6$";
            } else if ((string)(posterunek.Content) == "Kolonia: 6$")
            {
                zasoby -= 6;
                posterunek.Content = "Hotel galaktyczny: 7$";
            } else if ((string)(posterunek.Content) == "Hotel galaktyczny: 7$")
            {
                zasoby -= 7;
                posterunek.Content = "Siec hoteli planetarnych: 8$";
            } else if ((string)(posterunek.Content) == "Siec hoteli planetarnych: 8$")
            {
                zasoby -= 8;
                posterunek.Content = "Wykupiono siec hoteli";
                posterunek.IsEnabled = false;
            }

            update_player_values();
            update_planet_buttons();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            zasoby -= 6;
            wykupiona = true;
            zajetaLabel.Content = "Zajeta przez ciebie";
            planety += 1;

            update_player_values();
            update_planet_buttons();
        }

        private void kopalnia_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(kopalnia.Content) == "Kopalnia I stopnia: 5$")
            {
                zasoby -= 5;
                kopalnia.Content = "Kopalnia II stopnia: 6$";

            }
            else if ((string)(kopalnia.Content) == "Kopalnia II stopnia: 6$")
            {
                zasoby -= 6;
                kopalnia.Content = "Kopalnia III stopnia: 7$";
            }
            else if ((string)(kopalnia.Content) == "Kopalnia III stopnia: 7$")
            {
                zasoby -= 7;
                kopalnia.Content = "Wykupiono kopalnie III stopnia";
                kopalnia.IsEnabled = false;
            }

            update_player_values();
            update_planet_buttons();
        }

        private void farma_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(farma.Content) == "Farma zywnosci I: 3$")
            {
                zasoby -= 3;
                farma.Content = "Farma zywnosci II: 4$";

            }
            else if ((string)(farma.Content) == "Farma zywnosci II: 4$")
            {
                zasoby -= 4;
                farma.Content = "Farma zywnosci III: 5$";
            }
            else if ((string)(farma.Content) == "Farma zywnosci III: 5$")
            {
                zasoby -= 5;
                farma.Content = "Farma zywnosci IV: 6$";
            }
            else if ((string)(farma.Content) == "Farma zywnosci IV: 6$")
            {
                zasoby -= 6;
                farma.Content = "Farma zywnosci V: 7$";
            }
            else if ((string)(farma.Content) == "Farma zywnosci V: 7$")
            {
                zasoby -= 7;
                farma.Content = "Farma zywnosci VI: 8$";
            }
            else if ((string)(farma.Content) == "Farma zywnosci VI: 8$")
            {
                zasoby -= 8;
                farma.Content = "Wykupiono farme VI stopnia";
                farma.IsEnabled = false;
            }

            update_player_values();
            update_planet_buttons();
        }

        private void zastaw_Click(object sender, RoutedEventArgs e)
        {
            if((string)(zastaw.Content) == "Zastaw: +3$")
            {
                zastawiona = true;
                zasoby += 3;
                zastaw.Content = "Wykup zastaw: 3$";
            } else
            {
                zastawiona = false;
                zasoby -= 3;
                zastaw.Content = "Zastaw: +3$";
            }

            update_player_values();
            update_planet_buttons();
        }

        private void loteriaButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            switch (rnd.Next(0,6))
            {
                case 0:
                    wydarzenieLabel.Content = "Atak piratow";
                    break;
                case 1:
                    wydarzenieLabel.Content = "+1 karta ucieczki";
                    kartyUcieczki += 1;
                    break;
                case 2:
                    wydarzenieLabel.Content = "Bilet galaktyczny";
                    biletGalaktyczny = true;
                    break;
                case 3:
                    wydarzenieLabel.Content = "Podatek od nieruchomosci";
                    zasoby -= 5;
                    if(zasoby < 0)
                    {
                        MessageBox.Show("Przegrana - zadluzyles sie!");
                    }
                    break;
                case 4:
                    wydarzenieLabel.Content = "Wygrana w loterii";
                    zasoby += 5;
                    break;
                case 5:
                    wydarzenieLabel.Content = "Awaria silnika - utrata 2 tur";
                    zasoby -= 5;
                    if (zasoby < 0)
                    {
                        MessageBox.Show("Przegrana - zadluzyles sie!");
                    }
                    break;
                default:
                    break;
            }

            update_player_values();
            update_planet_buttons();
        }

        private void ucieczka_Click(object sender, RoutedEventArgs e)
        {
            kartyUcieczki -= 1;

            update_player_values();
            update_planet_buttons();
        }

        private void bilet_Click(object sender, RoutedEventArgs e)
        {
            biletGalaktyczny = false;
            var comboBoxItem = przystanki.Items[przystanki.SelectedIndex] as ComboBoxItem;
            if (comboBoxItem != null)
            {
                string selected = comboBoxItem.Content.ToString();
                przystanekInfo.Content = "Udalo ci sie przeniesc na " + selected;
            }

            update_player_values();
            update_planet_buttons();
        }
    }
}