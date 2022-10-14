using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda_de_activitati___Proiect
{
    public partial class ProduseDetalii : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            // realizam conexiunea
            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            SqlCommand myCom;

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {

                myCom = new SqlCommand("select * from produse", conexiune);

                da.SelectCommand = myCom;

                DataSet ds = new DataSet();

                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {

                conexiune.Close();
            }
        }

        protected void btnAnulare_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipala.aspx?id=" + Request.QueryString["id"]);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;

            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            TextBox text1 = (TextBox)row.FindControl("TextBox1");
            TextBox text2 = (TextBox)row.FindControl("TextBox2");
            TextBox text3 = (TextBox)row.FindControl("TextBox3");
            FileUpload fu = (FileUpload)row.FindControl("FileUpload1");
            Label label1 = (Label)row.FindControl("Label5");
           

            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            SqlCommand myCom;

            fu.SaveAs(Server.MapPath("~/Poze/") + Path.GetFileName(fu.FileName));

            string link = Path.GetFileName(fu.FileName);

            string updatedata = "Update produse set Denumire_produs=' " + text1.Text + " ', Imagine='" + link + " ', Descriere='" + text2.Text + " ', Pret='" + text3.Text + "' where Id_produs=" + label1.Text;

            try
            {
                conexiune.Open();

                myCom = new SqlCommand(updatedata, conexiune);

                myCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {
                conexiune.Close();
            }

            GridView1.EditIndex = -1;
            Bind();



            SqlDataReader dr = null;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // realizam conexiunea
            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            SqlCommand myCom;

            string strInterogare = "Delete FROM Produse WHERE Id_produs = @id";

            SqlParameter p1 = new SqlParameter("@id", System.Data.SqlDbType.VarChar);
            p1.Value = e.RowIndex + 1;

            myCom = new SqlCommand(strInterogare, conexiune);

            myCom.Parameters.Add(p1);

            try
            {
                conexiune.Open();
                myCom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
            finally
            {
                conexiune.Close();
            }
            Bind();

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PaginaPrincipala.aspx?id=" + Request.QueryString["id"]);
        }
    }
}