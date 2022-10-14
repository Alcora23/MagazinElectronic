using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda_de_activitati___Proiect
{
    public partial class PaginaPrincipala : System.Web.UI.Page
    {

        Cart myCart;
        protected void Page_Load(object sender, EventArgs e)
        {

            // realizam conexiunea
            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            SqlCommand myCom;

            SqlDataReader dr = null; // pt a afisa ce retureaza select-ul

            SqlDataReader dr2 = null; // pt a afisa ce retureaza select-ul

            try
            {
                conexiune.Open();

                myCom = new SqlCommand("select prenume from utilizatori where id_utilizator = @id", conexiune);

                SqlParameter p_user = new SqlParameter("@id", System.Data.SqlDbType.Int);
                p_user.Value = Request.QueryString["id"];

                myCom.Parameters.Add(p_user);

                dr2 = myCom.ExecuteReader();

                while (dr2.Read())
                {
                    Label10.Text = dr2[0].ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {
                dr2.Close();
            }



            try
            {
              
                myCom = new SqlCommand("select * from produse", conexiune);

                dr = myCom.ExecuteReader();

                if (dr.HasRows == true)
                {
                    GridView2.DataSource = dr;
                    GridView2.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {

                dr.Close();
                conexiune.Close();
            }

            if (DropDownList1.Items.Count != 0)
            {
                string id_tip_p = "";


                string strInterogare = "SELECT id_tip_produse FROM Tip_produse WHERE tip_produs = @tip";

                SqlParameter p1 = new SqlParameter("@tip", System.Data.SqlDbType.VarChar);
                p1.Value = DropDownList1.SelectedValue;

                myCom = new SqlCommand(strInterogare, conexiune);

                myCom.Parameters.Add(p1);

                try
                {
                    conexiune.Open();
                    dr = myCom.ExecuteReader();

                    while (dr.Read())
                    {
                        id_tip_p = dr[0].ToString();
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

                }
                finally
                {

                    dr.Close();
                    conexiune.Close();
                }

                id_tip.Text = id_tip_p;


                if (DropDownList1.SelectedValue != "")
                {
                    //selectie dupa un anumit tip de produs
                    string strInterogare2 = "SELECT * FROM Produse WHERE id_tip_produs = @id_tip";

                    SqlParameter p2 = new SqlParameter("@id_tip", System.Data.SqlDbType.Int);
                    p2.Value = id_tip_p;

                    myCom = new SqlCommand(strInterogare2, conexiune);

                    myCom.Parameters.Add(p2);

                    try
                    {
                        conexiune.Open();
                        dr = myCom.ExecuteReader();

                        if (dr.HasRows == true)
                        {
                            GridView2.DataSource = dr;
                            GridView2.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

                    }
                    finally
                    {

                        dr.Close();
                        conexiune.Close();
                    }
                }


            }

        }


        protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            //SqlCommand myCom = new SqlCommand();
            //ApelFunctie(conexiune, myCom);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // realizam conexiunea
            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");
            string id_tip_p = "";

            SqlCommand myCom = new SqlCommand();

            SqlDataReader dr = null; // pt a afisa ce retureaza select-ul

            string strInterogare = "SELECT id_tip_produse FROM Tip_produse WHERE tip_produs = @tip";

            SqlParameter p1 = new SqlParameter("@tip", System.Data.SqlDbType.VarChar);
            p1.Value = DropDownList1.SelectedValue;

            myCom = new SqlCommand(strInterogare, conexiune);

            myCom.Parameters.Add(p1);

            try
            {
                conexiune.Open();
                dr = myCom.ExecuteReader();

                while (dr.Read())
                {
                    id_tip_p = dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {

                dr.Close();
                conexiune.Close();
            }

            id_tip.Text = id_tip_p;

        }


        protected void btnUtiliz_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PaginaUtilizatori.aspx");
        }

        protected void btnCos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Cos.aspx?id=" + Request.QueryString["id"]);
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CreareProduse.aspx?id=" + Request.QueryString["id"]);
        }

        protected void btnEditDel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ProduseDetalii.aspx?id=" + Request.QueryString["id"]);
        }

        protected void btnCateg_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CreareCategorie.aspx?id=" + Request.QueryString["id"]);
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Session["myCart"] == null)
            {
                myCart = new Cart();
                Session["myCart"] = myCart;
            }
            myCart = (Cart)Session["myCart"];

            // realizam conexiunea
            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            SqlCommand myCom = new SqlCommand();
            SqlCommand myCom2 = new SqlCommand();
            SqlCommand myCom3= new SqlCommand();
            SqlCommand myCom4 = new SqlCommand();

            SqlDataReader dr = null; // pt a afisa ce retureaza select-ul
            SqlDataReader dr2 = null;
            SqlDataReader dr3 = null;
            SqlDataReader dr4 = null;

            string denumire = "";
            string img = "";
            string descriere = "";
            string pret = "";

            string strInterogare1 = "SELECT Denumire_produs FROM Produse WHERE Id_produs= @id";
            string strInterogare2 = "SELECT Imagine FROM Produse WHERE Id_produs= @id";
            string strInterogare3 = "SELECT Descriere FROM Produse WHERE Id_produs= @id";
            string strInterogare4 = "SELECT Pret FROM Produse WHERE Id_produs= @id";

            int id = GridView2.SelectedIndex + 1;
            SqlParameter p1 = new SqlParameter("@id", System.Data.SqlDbType.Int);
            p1.Value = id;

            SqlParameter p2 = new SqlParameter("@id", System.Data.SqlDbType.Int);
            p2.Value = id;

            SqlParameter p3 = new SqlParameter("@id", System.Data.SqlDbType.Int);
            p3.Value = id;

            SqlParameter p4 = new SqlParameter("@id", System.Data.SqlDbType.Int);
            p4.Value = id;

            myCom = new SqlCommand(strInterogare1, conexiune);
            myCom2 = new SqlCommand(strInterogare2, conexiune);
            myCom3 = new SqlCommand(strInterogare3, conexiune);
            myCom4 = new SqlCommand(strInterogare4, conexiune);

            myCom.Parameters.Add(p1);
            myCom2.Parameters.Add(p2);
            myCom3.Parameters.Add(p3);
            myCom4.Parameters.Add(p4);

            try
            {
                conexiune.Open();
                dr = myCom.ExecuteReader();
                

                while (dr.Read())
                {
                    denumire = dr[0].ToString();
                   
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {

                dr.Close();
                
            }

            try
            {
                dr2 = myCom2.ExecuteReader();

                while (dr2.Read())
                {
                    img = dr2[0].ToString();
                    
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {
                dr2.Close();
            }

            try
            {
                dr3 = myCom3.ExecuteReader();

                while (dr3.Read())
                {
                    descriere = dr3[0].ToString();

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {
                dr3.Close();
            }


            try
            {
                dr4 = myCom4.ExecuteReader();

                while (dr4.Read())
                {
                    pret = dr4[0].ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {

                dr4.Close();
                conexiune.Close();
            }

            myCart.Insert(new CartItem(GridView2.SelectedIndex + 1, denumire, img, descriere, Double.Parse(pret), 1));
        }

        
    }
}