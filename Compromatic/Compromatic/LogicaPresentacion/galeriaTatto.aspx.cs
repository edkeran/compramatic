﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_galeriaTatto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //NO HAY QUE VALIDAR ES UNA URL PUBLICA
        wsTattoSt.WebServiceSoapClient servicio = new wsTattoSt.WebServiceSoapClient();
        DataSet artistas = null;
        try
        {
            artistas = servicio.Galeria();
            try
            {
                GV_Tatto.DataSource = artistas;
                GV_Tatto.DataBind();

                //Seteando Idiomas
                L_Idioma idiot = new L_Idioma();
                Object sesidioma = Session["idiomases"];
                Int32 formulario = 40;
                Int32 idiom = Convert.ToInt32(sesidioma);
                Hashtable compIdioma = new Hashtable();
                idiot.mostraridioma(formulario, idiom, compIdioma);
                try
                {
                    this.title.InnerHtml = compIdioma["title"].ToString();
                }
                catch (Exception ex)
                { }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }catch(Exception ex)
        {
            throw ex;
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GV_Tatto.Rows)
        {
            ImageButton btn =(ImageButton) row.FindControl("ImageButton1");
            ClientScript.RegisterForEventValidation(btn.UniqueID.ToString());
        }
        base.Render(writer);
    }

    protected void GV_Tatto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GV_Tatto.PageIndex = e.NewPageIndex;
        this.GV_Tatto.DataBind();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>window.open('http://tattoostudio.gotdns.ch/Vista/Usuario/Galeria.aspx','_blank')</script>");
    }
}