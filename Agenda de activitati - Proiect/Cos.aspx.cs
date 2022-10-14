using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda_de_activitati___Proiect
{
    public partial class Cos : System.Web.UI.Page
    {
        Cart myCart;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["myCart"]== null)
            {
                Session["myCart"] = new Cart();
            }
            myCart = (Cart)Session["myCart"];

            if (!IsPostBack)
            {
                
                FillData();
            }
        }

        private void FillData()
        {
            gvShoppingCart.DataSource = myCart.Items;
            gvShoppingCart.DataBind();

            if( myCart.Items.Count == 0)
            {
                lbTotal.Visible = false;

            }
            else
            {
                lbTotal.Text = string.Format("Total = {0,19:C}", myCart.Total);
                lbTotal.Visible = true;
            }
        }

        protected void gvShoppingCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShoppingCart.EditIndex = -1;
            FillData();
        }

        protected void gvShoppingCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            myCart.Delete(e.RowIndex);
            FillData();
        }

        protected void gvShoppingCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtCant = (TextBox)gvShoppingCart.Rows[e.RowIndex].Cells[3].Controls[0];
            int cant = Int32.Parse(txtCant.Text);
            myCart.Update(e.RowIndex, cant);

            gvShoppingCart.EditIndex = -1;
            FillData();
        }

        protected void gvShoppingCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShoppingCart.EditIndex = e.NewEditIndex;
            FillData();


        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PaginaPrincipala.aspx?id=" + Request.QueryString["id"]);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            int ok = 0;

           Response.Write("<script LANGUAGE='JavaScript' >alert('Multumim ca ati cumparat de la noi! Comanda dumneavoasta a fost trimisa catre furnizor si va ajunge la dumeavoasta in cateva zile.')</script>");

        }
    }
}