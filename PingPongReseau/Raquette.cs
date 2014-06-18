using System;
using System.Drawing;
using System.Drawing.Drawing2D;

//Classe de gestion des Raquettes

[Serializable]
public class Raquette
{
    private const int LargueurBarre = 10;
    private const int HauteurBarre = 80;

    //Coordonnées du goal
    private int _XGoalPoint1,_YGoalPoint1,_XGoalPoint2,_YGoalPoint2;
    //Distance de la raquette par rapport a _XGoalPoint1
    private int _DistBarre;

    //Nombre de balle perdu par le joeur
    public int BallePerdu;

    public Raquette(int x1, int y1, int x2, int y2)
    {
       _XGoalPoint1 = x1;
       _YGoalPoint1 = y1;
       _XGoalPoint2 = x2;
       _YGoalPoint2 = y2;
       BallePerdu = 0;
    }

    public void Move(int XMouse, int YMouse)
    {
        _DistBarre = YMouse - HauteurBarre/2;

        //Limite de deplacement
        if (_DistBarre < _YGoalPoint1)
            _DistBarre = _YGoalPoint1;
        else if (_DistBarre > (_YGoalPoint2 - HauteurBarre))
            _DistBarre = _YGoalPoint2 - HauteurBarre;
    }

    public void Draw(Graphics Buffer)// dessin des goal et des raquettes
    {
        Pen p = new Pen(Color.White); // couleur du goal
        SolidBrush b = new SolidBrush(Color.White);//couleur de la raquette
        Font f = new Font("FontFamily", 16);
        int Xreel = _XGoalPoint1 - LargueurBarre / 2;

        Buffer.DrawString(BallePerdu.ToString(), f, b, _XGoalPoint1 - 30 ,5);
        Buffer.DrawString(BallePerdu.ToString(), f, b, _XGoalPoint2 + 30, 5);
        
        Buffer.DrawLine(p, _XGoalPoint1, _YGoalPoint1, _XGoalPoint2, _YGoalPoint2);//ligne du goal
        Buffer.DrawRectangle(p, Xreel, _DistBarre, LargueurBarre, HauteurBarre);
        Buffer.FillRectangle(b, Xreel, _DistBarre, LargueurBarre, HauteurBarre);
    }

    public bool Collision(Balle B)
    {
        int Xreel = _XGoalPoint1 - LargueurBarre / 2;

        //La balle est sur la raquette :
        if (bounding_box(Xreel, _DistBarre, LargueurBarre, HauteurBarre, B.GetX(), B.GetY(), B.GetR(), B.GetR()))
            B.Rebond(90);
        //La balle est dans les buts
        else if (bounding_box(_XGoalPoint1, _YGoalPoint1, 0, _YGoalPoint2, B.GetX(), B.GetY(), B.GetR(), B.GetR()))
        {
            B.reset();
            BallePerdu++;
        }

       return false;
    }

    public void NetWorkSet(int DistBarre)
    {
        _DistBarre = DistBarre;
    }

    public int GetDistBarre()
    {
        return _DistBarre;
    }

    public int GetBallePerdu()
    {
        return BallePerdu;
    }

    public bool bounding_box(int b1_x, int b1_y, int b1_w, int b1_h, int b2_x, int b2_y, int b2_w, int b2_h)
    {
        if ((b1_x > b2_x + b2_w - 1) ||  //estceque b1 est sur le coté droit de b2?
        (b1_y > b2_y + b2_h - 1) ||  // estceque b1 est en dessous de b2?
        (b2_x > b1_x + b1_w - 1) ||  // estceque b2 est sur le coté droit de b1?
        (b2_y > b1_y + b1_h - 1))    // estceque b2 est en dessous de b1?
        {
            // no collision
            return false;
        }

        // collision
        return true;
    }

}