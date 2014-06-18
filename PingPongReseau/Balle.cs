using System;
using System.Drawing;
using System.Drawing.Drawing2D;

//Classe de gestion des balles

[Serializable]
public class Balle // creation de la balle
{
    private const int RayonBalle = 10;

    private int _x, _y;
    private double _xReel, _yReel;
    private int _Speed;
    private double _Angle;
    public int _RebondCount;

    public Balle()
    {
        reset();
    }

    public void reset()// remet a zero les balle apres un but
    {
        _yReel = PingPongReseau.Form1.HauteurJeux / 2;//place les balle au centre
        _xReel = PingPongReseau.Form1.LargueurJeux / 2;//
        _x = (int)_xReel;
        _y = (int)_yReel;
        _RebondCount = 0;

        _Speed = PingPongReseau.Form1.Rand.Next(3, 7);

        //Angle aleatoire
        if (PingPongReseau.Form1.Rand.Next(0, 2) == 0)
            _Angle = PingPongReseau.Form1.Rand.Next(-30, 30);
        else
        {
            if (PingPongReseau.Form1.Rand.Next(0, 2) == 0)
                _Angle = PingPongReseau.Form1.Rand.Next(160, 180);
            else
                _Angle = PingPongReseau.Form1.Rand.Next(-180, -160);
        }

    }

    public void Draw(Graphics Buffer)
    {
        Pen p = new Pen(Color.White);
        SolidBrush b = new SolidBrush(Color.White);
        p.Width = 2;
        Buffer.DrawEllipse(p, _x, _y, RayonBalle, RayonBalle);
        Buffer.FillEllipse(b, _x, _y, RayonBalle, RayonBalle);
    }

    public void UpdatePosition() // deplacement de la balle, Rebond sur le bord
    {
        //Anti-blocage
        if (_RebondCount > 0)
            _RebondCount--;

        //Rebond sur le bord
        int MRayon = RayonBalle / 2;
        if (_x + MRayon >= PingPongReseau.Form1.LargueurJeux)
            Rebond(90);
        if (_x - MRayon <= 1)
            Rebond(90);
        if (_y + MRayon >= PingPongReseau.Form1.HauteurJeux)
            Rebond(0);
        if (_y - MRayon <= 1)
            Rebond(0);

        //Evolution de la balle
        _xReel += (Math.Cos(Math.PI * _Angle / 180) * _Speed);
        _yReel -= (Math.Sin(Math.PI * _Angle / 180) * _Speed);

        _x = (int)_xReel;
        _y = (int)_yReel;
    }

    public void Rebond(double AngleMur) //Calcul du rebond en fonction de l'angle

    {
        //Calcul du rebond en fonction de l'angle

        if (AngleMur == 90)
            if (_Angle > 0)
                _Angle = 180 - _Angle;
            else
                _Angle = -(_Angle + 180);
        else if (AngleMur == 0)
            _Angle = -_Angle;


        //Anti-blocage 
        if (_RebondCount > 1)
            reset();
        _RebondCount = 5;


        /*
        if (_Angle > 180)
            while (_Angle > 180)
                _Angle -= 180;
        else if (_Angle < -180)
            while (_Angle < -180)
                _Angle += 180;
       */

    }

    public int GetX()
    {
        return _x;
    } //les accesseurs..

    public int GetY()
    {
        return _y;
    }

    public int GetR()
    {
        return RayonBalle;
    }

    public void SetA(double NAngle)
    {
        _Angle = NAngle;
    }
    public double GetA()
    {
        return _Angle;
    }

    public void SetX(int X)
    {
        _x = X;
    }
}