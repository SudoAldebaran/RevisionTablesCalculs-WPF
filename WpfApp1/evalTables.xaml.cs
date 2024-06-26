﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Logique d'interaction pour evalTables.xaml
    /// </summary>
    public partial class evalTables : Window
    {
        private Random rd;
        private int NumQuestion = 0;
        private int NumEssai = 0;
        private int NbPoints = 0;
        private int Resultat = 0;
        private int Erreur = 0;
        private int table;
        public evalTables()
        {
            InitializeComponent();
            rd = new Random();
            string txt;
            txt = "  Après avoir choisi la table, vous aurez 5 questions; pour chaque question vous aurez deux essais.\n Si vous répondez bien au premier essai vous aurez 2 points mais ";
            txt += "1 point si vous répondez seulement \n au deuxième essai et 0 point sinon. Vous serez ainsi noté sur 10. ";
            this.tBbkPresentation.Text = txt;
            this.txtReponse.IsEnabled = false;
            // code à compléter pour charger la listBox
            for (int i = 1; i <= 10; i++)
            {
                this.lstTable.Items.Add(i);
            }
        }

        private void InitQuestion()
        {
            this.NumQuestion++;
            if (this.NumQuestion <= 5)
            {
                Random rand = new Random();
                int nbAlea = rand.Next(1, 9);
                this.NumEssai = 1;
                this.txtReponse.IsEnabled = true;
                this.txtReponse.Focus();
                //code pour faire apparaitre la question et calculer le bon résultat
                this.tBkContent.Text = $"{nbAlea} x {this.table}";
                this.tBkQuestion.Text = $"Question {this.NumQuestion}";

                Resultat = nbAlea * this.table;
                
            }
            else
            {
                MessageBox.Show("C'est terminé !!");
                
                this.lstTable.IsEnabled = true;
                this.btnCommencer.IsEnabled = true;
                this.NumQuestion = 0;
                this.tBkContent.Text = "";
                this.txtReponse.IsEnabled = false;
                this.Erreur = 0;
            }
        }
        private void btnCommencer_Click(object sender, RoutedEventArgs e)
        {
            this.btnCommencer.IsEnabled = false;
            this.table = Convert.ToInt32(lstTable.SelectedValue);
            this.lstTable.IsEnabled = false;
            InitQuestion();
        }

        private void txtReponse_KeyDown(object sender, KeyEventArgs e)
        {
           try
            {
               if (e.Key == Key.Enter)
                {
                    // code pour tester la saisie et gérer les points selon la réponse et l'essai
                    int resTest = Convert.ToInt32(txtReponse.Text);

                    if (resTest == Resultat)
                    {
                        MessageBox.Show("Bravo !");
                        InitQuestion();
                        this.txtReponse.Text = "";
                    }
                    else
                    {
                        if (this.Erreur == 1) 
                        {
                            MessageBox.Show("PERDU !!");
                            
                            this.lstTable.IsEnabled = true;
                            this.btnCommencer.IsEnabled = true;
                            this.NumQuestion = 0;
                            this.tBkContent.Text = "";
                            this.txtReponse.IsEnabled = false;
                            this.txtReponse.Text = "";
                            this.Erreur = 0;

                        }
                        else
                        {
                            MessageBox.Show("Faux, encore un essai");
                            this.Erreur++;
                        }
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saisir un nombre svp");
                this.txtReponse.Text = "";
            }
        }


    }
}
