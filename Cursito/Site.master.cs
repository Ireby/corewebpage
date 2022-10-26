using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;


public partial class SiteMaster : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
            if (!IsPostBack)
            {

                //set DisplaySessionTimeout() as the startup script of this page
                Page.ClientScript.RegisterStartupScript(this.GetType(),"onLoad", "DisplaySessionTimeout()", true);

                if (Session["usuario"] != null)
                {

                    if (NavigationMenu.Items.Count == 0)
                    {
                        Interfaz i = new Interfaz();

                        NavigationMenu.Items.AddRange(i.Armar(Session["usuario"].ToString()));

                    }
                    btn_cerrar.Visible = true;

                    pan_tiempo_sesion.Visible = true;
                    //btn_buscador.Visible = true;
                    DataTable dt = Interfaz.EjecutarConsultaBD("LocalSqlServer", "SELECT * FROM USUARIOS with(nolock) WHERE idusuario=" + Session["usuario"].ToString() + " order by nombre");
                    lbl_footer.Text = dt.Rows[0]["Nombre"].ToString();

                    try
                    {
                        string ip = ((Request.ServerVariables["REMOTE_ADDR"] != null) ? Request.ServerVariables["REMOTE_ADDR"].ToString().Replace(",", ".") : "");
                        string Host = ((Request.ServerVariables["REMOTE_HOST"] != null) ? Request.ServerVariables["REMOTE_HOST"].ToString().Replace(",", ".") : "");
                        string pagina = ((Request.FilePath != null) ? Request.FilePath.ToString().Remove(0, 1) : "");

                        if (pagina.Length > 0)
                        {
                            dt = Interfaz.EjecutarConsultaBD("LocalSqlServer", "select ID_DESARROLLO from MENU where URL like '" + pagina + "%'");
                            if (dt.Rows.Count > 0)
                            {
                                Interfaz.Alta_Auditoria(Session["usuario"].ToString(), dt.Rows[0]["ID_DESARROLLO"].ToString(), "IT_DESARROLLOS", "10", ip, Host, "Acceso a " + pagina);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }

                }
                else
                {
                    NavigationMenu.Items.Clear();
                    btn_cerrar.Visible = false;
                   
                    lbl_footer.Text = "";
                  
                    
                }
            }

            CargarUbicacion();


      

        }

        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void CargarUbicacion()
    {
        try
        {
            string sql = "select UBICACION= m1.DESCRIPCION+' / '+m.DESCRIPCION";
            sql += " ,ARCHIVO_INSTRUCTIVO=isnull(d.ARCHIVO_INSTRUCTIVO,'')";
            sql += " ,ARCHIVO_FORMULARIO=isnull(d.ARCHIVO_FORMULARIO,'')";
            sql += " ,USUARIO_CLAVE=SJMLGH_NOMBRE";
            sql += " from MENU m";
            sql += " left join IT_DESARROLLOS d";
            sql += " on m.ID_DESARROLLO=d.ID";
            sql += " left join MENU m1";
            sql += " on m1.MENUID=m.PADREID";
            sql += " left join cbs.dbo.SJMLGH s";
            sql += " on SJMLGH_CODEMP +'-'+replace(SJMLGH_NROLEG,' ','')=d.KEY_USER";
            sql += " where m.URL like '" + Page.AppRelativeVirtualPath.Replace("~/", "") + "%'";

            DataTable dt1 = Interfaz.EjecutarConsultaBD("LocalSqlServer", sql);
            if (dt1.Rows.Count > 0)
            {
                div_pagina.InnerHtml = "<table width='100%' style=' font-size: x-small; padding: 2px;background-color:#F7F7FE; border-bottom: 1px solid #E6E6E6;'><tr><td align='left' style='padding-left:10px;'>" + dt1.Rows[0]["UBICACION"].ToString() + ".</td>";
                div_pagina.InnerHtml += "<td align='right' style='padding-right:10px;' >";
                if (dt1.Rows[0]["ARCHIVO_INSTRUCTIVO"].ToString().Length > 0)
                {
                    div_pagina.InnerHtml += " <a target='_blank' href='" + dt1.Rows[0]["ARCHIVO_INSTRUCTIVO"].ToString() + "'>Instructivo</a> ";
                }
                if (dt1.Rows[0]["ARCHIVO_FORMULARIO"].ToString().Length>0)
                {
                    div_pagina.InnerHtml += " | <a target='_blank' href='" + dt1.Rows[0]["ARCHIVO_FORMULARIO"].ToString() + "'>Especificación</a> ";
                }
                if (dt1.Rows[0]["USUARIO_CLAVE"].ToString().Length > 0)
                {
                    div_pagina.InnerHtml += " | <font color='Red'><img src='imagenes/key_user.jpg' Height='14px' /> " + dt1.Rows[0]["USUARIO_CLAVE"].ToString() + "</font> ";
                }
                div_pagina.InnerHtml += "</td></tr></table>";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

  


    protected void NavigationMenu_MenuItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {

        MainContent.Visible = true;
        if (e.Item.Target.Contains("http:") || e.Item.Target.Contains("file:") || e.Item.Target.Contains("https:"))
        { Response.Write("<script>window.open('" + e.Item.Target + "','_blank');</script>"); }
        else
        { Response.Redirect(e.Item.Target); }
      
        
    }

    protected void btn_buscador_Click(object obj, EventArgs e)
    {
        Response.Redirect("INTRANET_BUSCADOR.aspx");

    }

    protected void btn_cerrar_Click(object obj, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            Session.Clear();
            Session.Abandon();
            lbl_footer.Text = "";
            Response.Redirect("INTRANET_LOGIN.aspx");
        }
        else
        {
            Session["usuario"] = null;
            Response.Redirect("INTRANET_LOGIN.aspx");
        }
    }

}
