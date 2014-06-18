using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;


[Serializable]
public class PongMsgServeur
{
    public List<Balle> Balles;
    public int DRaquette;
    public bool Stop;
}//Message du serveur

[Serializable]
public class PongMsgClient//Message du client
{
    public int IDSource;
    public int DRaquette;
}

[Serializable]
public class PongMsgStatus//Message d'initialisation de la connection
{
    public int TypeMsg;
    public int Data;
}

//-----------------------------------------

public class SimpleTcpServeur
{
    NetworkStream StreamClient;
    const int TCP_PORT = 13050;
    PongMsgServeur MsgServeur;
    PongMsgClient MsgClient;
    bool ConnectionActive;

    public delegate bool SyncServeur(List<Balle> B, Raquette Local, Raquette Client, bool _Stop);

    public SimpleTcpServeur()//construct
    {
        MsgServeur = new PongMsgServeur();
        MsgClient = new PongMsgClient();
        ConnectionActive = false;

        Thread th = new Thread(new ThreadStart(ThreadServeur));
        th.IsBackground = true;
        th.Start();
    }

    //envoi message au client avec donné de balle raquette,..
    public bool SynchroniseFunc(List<Balle> B, Raquette Local, Raquette Client, bool _Stop)
    {
        MsgServeur.Balles = B;
        MsgServeur.DRaquette = Local.GetDistBarre();
        MsgServeur.Stop = _Stop;
        Client.NetWorkSet(MsgClient.DRaquette);
        return ConnectionActive;
    }

    //Attente du client
    //Demande,attribution,acceptation de connection du client
    // Start the game !
    private void ThreadServeur()
    {
        BinaryFormatter bf = new BinaryFormatter();
        PongMsgStatus MsgStatus = new PongMsgStatus();
        TcpListener TcpServer = new TcpListener(IPAddress.Any, TCP_PORT);//ecoute des connection client

        try
        {
            //Attente du client
            TcpServer.Start();
            TcpClient TcpClient = TcpServer.AcceptTcpClient();
            StreamClient = TcpClient.GetStream();

            while (true)
            {
                MsgStatus = (PongMsgStatus)bf.Deserialize(StreamClient);

                //Demande de connection du client
                if (MsgStatus.TypeMsg == 1)
                {
                    MsgStatus.TypeMsg = 2; //Attribution du numero client
                    MsgStatus.Data = 2; //Client numero 2
                    bf.Serialize(StreamClient, MsgStatus);
                }
                //Acceptation du client
                if (MsgStatus.TypeMsg == 3)
                {
                    MsgStatus.TypeMsg = 4; // Start the game !
                    MsgStatus.Data = 0;
                    bf.Serialize(StreamClient, MsgStatus);
                    break;
                }
            }
            MsgServeur.Stop = false;
            ConnectionActive = true;

            //Optimisation de connection :
            while (true)
            {
                MsgClient = (PongMsgClient)bf.Deserialize(StreamClient);
                bf.Serialize(StreamClient, MsgServeur);
                Thread.Sleep(5);
                if (MsgServeur.Stop)
                {
                    bf.Serialize(StreamClient, MsgServeur);
                    break;
                }
            }
        }
        catch (Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.Message);
        }
        ConnectionActive = false;
        MsgServeur.Stop = true;
        //StreamClient.Close();
        TcpServer.Stop();

    }
}

//------------------------------------------
public class SimpleTcpClient
{
    const int TCP_PORT = 13050;
    string _IpServeur; 
    PongMsgServeur MsgServeur;
    PongMsgClient MsgClient;

    public delegate bool SyncClient(List<Balle> B, Raquette Local, Raquette Serveur);

    public SimpleTcpClient(string IpServeur)
    {
        MsgServeur = new PongMsgServeur();
        MsgClient = new PongMsgClient();
        _IpServeur = IpServeur;
        Thread th = new Thread(new ThreadStart(ThreadClient));
        th.IsBackground = true;
        th.Start();
    }//contruct

    public bool SynchroniseFunc(List<Balle> B, Raquette Local, Raquette Serveur)
    {
        if (MsgServeur.Balles != null)
        {
            B.Clear();
            B.AddRange(MsgServeur.Balles);
        }
        Serveur.NetWorkSet(MsgServeur.DRaquette);
        MsgClient.DRaquette = Local.GetDistBarre();

        return !MsgServeur.Stop;
    }

    //Connection au serveur Demande Attribution du numero client
    //Start the game
    public void ThreadClient()
    {
        BinaryFormatter bf = new BinaryFormatter();
        PongMsgStatus MsgStatus = new PongMsgStatus();
        TcpClient TcpClient = new TcpClient();

        try
        {
            //Connection au serveur :
            TcpClient.Connect(IPAddress.Parse(_IpServeur), TCP_PORT);
            NetworkStream stream = TcpClient.GetStream();

       
            //Demande de connection :
            MsgStatus.TypeMsg = 1;
            bf.Serialize(stream, MsgStatus);

            while (true)
            {
                MsgStatus = (PongMsgStatus)bf.Deserialize(stream);

                //Attribution du numero client
                if (MsgStatus.TypeMsg == 2)
                {
                    MsgStatus.TypeMsg = 3; //Acceptation
                    bf.Serialize(stream, MsgStatus);
                }

                if (MsgStatus.TypeMsg == 4) //Start the game
                    break;
            }

            while (true)
            {
                bf.Serialize(stream, MsgClient);
                MsgServeur = (PongMsgServeur)bf.Deserialize(stream);

                Thread.Sleep(5);
                if (MsgServeur.Stop)
                    break;
            }
        }
        catch (Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.Message);
        }

        MsgServeur.Stop = true;
        //stream.Close();
        TcpClient.Close();

    }
}
           

