﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace IK073G_Projektuppgift
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VisaAllt(XmlTillLista());
        }
        public void VisaAllt(List<QA> QALista)
        {

            foreach (QA qa in QALista)
            {

                HtmlGenericControl divFråga = new HtmlGenericControl("div class=fråga");
                frågeform.Controls.Add(divFråga);

                HtmlGenericControl kategoriFråga = new HtmlGenericControl("p class=frågaKategori");
                kategoriFråga.InnerText = qa.kategori;
                divFråga.Controls.Add(kategoriFråga);

                HtmlGenericControl rubrikFråga = new HtmlGenericControl("p class=frågaRubrik");
                rubrikFråga.InnerText = qa.fråga;
                divFråga.Controls.Add(rubrikFråga);

                HtmlGenericControl svarsalternativDivFråga = new HtmlGenericControl("div class=svarsalternativ");
                divFråga.Controls.Add(svarsalternativDivFråga);

                HtmlGenericControl svar1Fråga = new HtmlGenericControl("li class=svar1");
                svarsalternativDivFråga.Controls.Add(svar1Fråga);
                HtmlGenericControl checkBox1Fråga = new HtmlGenericControl("input type = checkbox name = svar1");
                svar1Fråga.Controls.Add(checkBox1Fråga);
                HtmlGenericControl svar1TextFråga = new HtmlGenericControl("p");
                svar1TextFråga.InnerText = qa.svar1;
                svar1Fråga.Controls.Add(svar1TextFråga);



            }
        }
        public List<QA> XmlTillLista()
        {
            List<QA> QALista = new List<QA>();
            string path = Server.MapPath("Q&A.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList allaFrågorOchSvar = doc.SelectNodes("/bank/Frågor/FrågorLicensiering/Frågenummer");

            foreach (XmlNode node in allaFrågorOchSvar)
            {
                QA qa = new QA();
                qa.kategori = node["Kategori"].InnerXml;
                qa.typ = node["Typ"].InnerXml;
                qa.fråga = node["Fråga"].InnerXml;
                qa.svar1 = node["Svar"].InnerXml;
                qa.svar2 = node["Svar"].InnerXml;
                qa.svar3 = node["Svar"].InnerXml;
                qa.svar4 = node["Svar"].InnerXml;

                QALista.Add(qa);
            }

            return QALista;
        }
    }
}