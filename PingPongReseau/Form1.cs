using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PingPongReseau
{
    public partial class Form1 : Form
    {
        //Creation of variables
        Timer t = new Timer();
        bool  ingame = false;

        //Elements du jeu
        List<Balle> Balles;
        Raquette JoueurLocal;
        Raquette JoueurDistant;
        Raquette JoueurCPU;
        int Yraq = 0;

        int TypeDeJeux;
        bool ConnectionActive;
        const int NombreDeBalle = 3;
        const int LimiteScore = 8;
        string MsgAccueil;

        SimpleTcpServeur Serveur;
        SimpleTcpClient Client;
        SimpleTcpServeur.SyncServeur ServeurSend;
        SimpleTcpClient.SyncClient ClientSend;

        public static Random Rand;
        public static int HauteurJeux;
        public static int LargueurJeux;

        public Form1()
        {
            InitializeComponent();
            MsgAccueil = "The \n Ping Pong \n Reseau";
            t = new Timer();
            Rand = new Random();

          
            //Configure le timer du jeux
            t.Interval = 5;
            t.Tick += new EventHandler(TimerJeu);
        }

        private void InitialisePong()
        {
            menuStrip1.Visible = false;
            ingame = true;
            ConnectionActive = false;

            //Sinon bug ...
            HauteurJeux = Form1.ActiveForm.Size.Height - 32;
            LargueurJeux = Form1.ActiveForm.Size.Width - 25;

            //Initialise les balles :
            Balles = new List<Balle>();
            for (int i = 0; i < NombreDeBalle; i++)
            {
                Balle Bt = new Balle();
                Balles.Add(Bt);
            }

            if (TypeDeJeux == 1) //Jeux en local
            {
                JoueurLocal = new Raquette(12, 5, 12, HauteurJeux);
                JoueurCPU = new Raquette(LargueurJeux, 5, LargueurJeux, HauteurJeux);
            }
            else if (TypeDeJeux == 2) //Jeux mode serveur
            {
                //Initialise les raquettes (gauche pour le serveur)
                JoueurLocal = new Raquette(12, 5, 12, HauteurJeux);
                JoueurDistant = new Raquette(LargueurJeux, 5, LargueurJeux, HauteurJeux);
                
            }
            else if (TypeDeJeux == 3) //Jeux mode client
            {
                JoueurDistant = new Raquette(12, 5, 12, HauteurJeux);
                JoueurLocal = new Raquette(LargueurJeux, 5, LargueurJeux, HauteurJeux);
            }

            //Creates a new mouse movement event handler
            this.MouseMove += new MouseEventHandler(LocalMouseMove);

            //Initiates double buffering
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Demarre le timer du jeux
            t.Start();


        }

        void LocalMouseMove(object sender, MouseEventArgs e)
        {
            //Bouge la raquette du joeur local
            JoueurLocal.Move(e.X, e.Y);
        }

        void TimerJeu(object sender, EventArgs e)
        {
            //Boucle de jeux
            
            int maxY = 0;
            int maxX = 0;

            if (TypeDeJeux == 1) //Jeux contre CPU
            {
                //Instructions du jeux :
                foreach (Balle it in Balles)
                {
                    it.UpdatePosition();
                    JoueurLocal.Collision(it);
                    JoueurCPU.Collision(it);
                    //Pseudo intelligence pour la raquette CPU
                    if (maxX < it.GetX())
                    {
                        maxX = it.GetX();
                        maxY = it.GetY();
                    }
                }

                //Lissage du mouvement du joueur CPU
                if (Yraq < maxY - 5)
                    Yraq += 5;
                else if (Yraq > maxY + 5)
                    Yraq -= 5;

                JoueurCPU.Move(0, Yraq);

            }
            else if(TypeDeJeux == 2) //Serveur gere le jeux
            {
                ConnectionActive = ServeurSend(Balles, JoueurLocal, JoueurDistant, !ingame);
                if (ConnectionActive)
                {
                    foreach (Balle it in Balles)
                    {
                        //Bouge les balles
                        it.UpdatePosition();
                        //Gestion des collisions
                        JoueurLocal.Collision(it);
                        JoueurDistant.Collision(it);
                    }
                }
            }
            else if (TypeDeJeux == 3) //Client recoit les données
            {
                ConnectionActive = ClientSend(Balles, JoueurLocal, JoueurDistant);

            }
            FinDePartie();
            //Demande de mise a jour de l'affichage
            Invalidate();
        }

        private void FinDePartie()//Calcul les conditions de fin de partie
        {
            if (TypeDeJeux == 1) //Jeux contre CPU
            {
                if (JoueurCPU.GetBallePerdu() > LimiteScore)
                {
                    MsgAccueil = "Gagné";
                    int score = JoueurCPU.GetBallePerdu() - JoueurLocal.GetBallePerdu();

                    ingame = false;
                    t.Stop();
                }
                else if (JoueurLocal.GetBallePerdu() > LimiteScore)
                {
                    MsgAccueil = "Perdu";
                    ingame = false;
                    t.Stop();
                }
            }
            else //Serveur ou client (pas de sauvegarde de score ici)
            {
                if (JoueurDistant.GetBallePerdu() > LimiteScore)
                {
                    MsgAccueil = "Gagné";
                    ingame = false;
                    t.Stop();
                    ServeurSend(Balles, JoueurLocal, JoueurDistant, true);
                }
                else if (JoueurLocal.GetBallePerdu() > LimiteScore)
                {
                    MsgAccueil = "Perdu";
                    ingame = false;
                    t.Stop();
                    ServeurSend(Balles, JoueurLocal, JoueurDistant, true);
                }
                else if (ConnectionActive == false && TypeDeJeux == 3)
                {
                    MsgAccueil = "Fin";
                    ingame = false;
                    t.Stop();
                }

            }
        }

        protected override void OnPaint(PaintEventArgs e) //dessine le terrain..
        {
            //Gestion de l'affichage
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            if (ingame == true)
            {
                JoueurLocal.Draw(g);
                if (TypeDeJeux == 1) //Contre CPU
                {
                    JoueurCPU.Draw(g);
                    foreach (Balle it in Balles)
                        it.Draw(g);
                }
                else //En reseau
                {
                    foreach (Balle it in Balles)
                        it.Draw(g);

                    JoueurDistant.Draw(g);
                    if (ConnectionActive == false)
                        g.DrawString("Attente joueur ...", new Font(Font.FontFamily, 32), new SolidBrush(Color.White), new Point(60, 110), StringFormat.GenericDefault);
                }
            }
            if (ingame == false)
            {
                menuStrip1.Visible = true;
                g.DrawString(MsgAccueil, new Font(Font.FontFamily, 42), new SolidBrush(Color.White), new Point(145, 110), StringFormat.GenericDefault);
            }
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeDeJeux = 1;
            InitialisePong();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect(0);
            Environment.Exit(0);
        }

        private void ResizeEvent(object sender, EventArgs e)
        {
            HauteurJeux = Form1.ActiveForm.Size.Height - 32;
            LargueurJeux = Form1.ActiveForm.Size.Width - 25;
        }

        private void ServeurtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeDeJeux = 2;
            Serveur = new SimpleTcpServeur();//construit le serveur
            ServeurSend = new SimpleTcpServeur.SyncServeur(Serveur.SynchroniseFunc);//
            InitialisePong();
        }

        private void ClientStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeDeJeux = 3;
            FormIP frmInfo = new FormIP();
            if (frmInfo.ShowDialog() == DialogResult.OK)
            {
                Client = new SimpleTcpClient(frmInfo.IpServeur);
            }
            else
                Client = new SimpleTcpClient("127.0.0.1");

            ClientSend = new SimpleTcpClient.SyncClient(Client.SynchroniseFunc);
            
            InitialisePong();
        }





    }
}