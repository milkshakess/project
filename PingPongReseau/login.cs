using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Xml;
using System.IO;

namespace PingPongReseau
{
    public partial class login : Form
    {
        public string User;
        public string Password;

        public login()
        {
            InitializeComponent();
            VerifyXML();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            //si le login est ok alors dialogresult.ok

            if (VerifyLoginAccount(this.tbUserID.Text,this.tBPasswd.Text))
               this.DialogResult = DialogResult.OK;
           else
               this.lbError.Visible = true;
            
        }

        private string HashGen(string Passwd)
        {
            byte [] PassBytes = UTF8Encoding.Default.GetBytes(Passwd);
            SHA1CryptoServiceProvider HashSha = new SHA1CryptoServiceProvider();
            HashSha.ComputeHash(PassBytes);

            byte[] HashKey = HashSha.Hash;

            //return(UTF8Encoding.Default.GetString(HashKey));
            return ByteArrayToString(HashKey);
        }

        public string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void VerifyXML()
        {
            if (File.Exists("Accounts.xml")) return;
            XmlDocument MyDoc = new XmlDocument();
            XmlDocumentType doctype;
            doctype = MyDoc.CreateDocumentType("accounts", null, null, "<!ELEMENT user EMPTY> <!ATTLIST user ident ID #REQUIRED >");
            MyDoc.AppendChild(doctype);
            XmlElement root = MyDoc.CreateElement("accounts");
            MyDoc.AppendChild(root);

            XmlElement user = MyDoc.CreateElement("user");
            user.SetAttribute("ident", "Admin");
            user.SetAttribute("passwd", HashGen("Admin"));

            root.AppendChild(user);

            MyDoc.Save("Accounts.xml");
        }

        private bool VerifyLoginAccount(string user, string passwd)
        {
            if (!File.Exists("Accounts.xml")) return false;
            XmlDocument MyDoc = new XmlDocument();
            MyDoc.Load("Accounts.xml");
            XmlElement Myuser = MyDoc.GetElementById(user);
            if (Myuser == null) return false;
            string Mypasswd = Myuser.GetAttribute("passwd");
            if (Mypasswd == null) return false;
            return (Mypasswd == HashGen(passwd));
        }
    }
}
