using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda_de_activitati___Proiect
{
    public partial class CreareCategorie : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnulare_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipala.aspx?id=" + Request.QueryString["id"]);
        }

        protected void btnAdauga_Click(object sender, EventArgs e)
        {
            int contor = 0;

            // realizam conexiunea
            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            SqlCommand myCom;

            //selectez cel mai mare id
            string strMax = "SELECT MAX(Id_tip_produse) FROM Tip_Produse";

            myCom = new SqlCommand(strMax, conexiune);

            SqlDataReader dr = null;

            try
            {
                conexiune.Open();
                dr = myCom.ExecuteReader();

                while (dr.Read())
                {
                    contor = int.Parse(dr[0].ToString());

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
           
            contor++;

            // construim prima data parametrii care vor avea valorile din textbox-uri
            SqlParameter p1 = new SqlParameter("@Id_tip_produs", System.Data.SqlDbType.Int);
            p1.Value = contor;


            SqlParameter p2 = new SqlParameter("@Tip_produs", System.Data.SqlDbType.NVarChar);
            p2.Value = tbNumeCateg.Text;

            //facem inserarea
            string strInsert = "INSERT INTO [Tip_produse] ([Id_tip_produse], [tip_produs]) VALUES (@Id_tip_produs, @Tip_produs)";

            myCom = new SqlCommand(strInsert, conexiune);

            myCom.Parameters.Add(p1);
            myCom.Parameters.Add(p2);
          

            try
            {
                myCom.ExecuteNonQuery();
                TextBox1.Text += "\r\nInserare OK";

                //golire campuri
                tbNumeCateg.Text = "";
               

            }
            catch (Exception ex)
            {
                TextBox1.Text += "\r\nInserare esuata " +ex.Message;
            }
            finally
            {
                conexiune.Close();
            }
            

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            // realizam conexiunea
            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            SqlCommand myCom;

            //selectez cel mai mare id ca sa stiu cu ce id actualizez -> cu ultimul creat
            int contor = 0;

            string strMax = "SELECT MAX(Id_tip_produse) FROM Tip_Produse";

            myCom = new SqlCommand(strMax, conexiune);

            SqlDataReader dr = null;

            try
            {
                conexiune.Open();
                dr = myCom.ExecuteReader();

                while (dr.Read())
                {
                    contor = int.Parse(dr[0].ToString());

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

            //update la cheia externa tabela produse

            string strUpdate = "UPDATE Produse set Id_tip_produs= @id Where id_produs=@idProdus";

            myCom = new SqlCommand(strUpdate, conexiune);

        
            SqlParameter p1 = new SqlParameter("@id", System.Data.SqlDbType.Int);
            p1.Value = contor;
         
            SqlParameter p2 = new SqlParameter("@idProdus", System.Data.SqlDbType.Int);
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;

            // And you respective cell's value
            p2.Value = row.Cells[0].Text; 

        
            myCom = new SqlCommand(strUpdate, conexiune);


            myCom.Parameters.Add(p1);
            myCom.Parameters.Add(p2);
   

            try
            {
                myCom.ExecuteNonQuery();
                myCom.Dispose();
                TextBox1.Text += "\r\n" + GridView1.SelectedRow.Cells[0].Text+"   "+ GridView1.SelectedRow.Cells[1].Text+ " actualizat cu succes.";

         

                //golire campuri
                tbNumeCateg.Text = "";


            }
            catch (Exception ex)
            {
               TextBox1.Text += "\r\n Inserare membrii esuata:  " + ex.Message;
            }
            finally
            {
                conexiune.Close();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipala.aspx?id=" + Request.QueryString["id"]);
        }
    }
}