using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda_de_activitati___Proiect
{
    public partial class PaginaUtilizatori : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (tbNume.Text.Equals(null))
            {
                
            }
            int contor=0; 

            //selectez cel mai mare  id
            string strMax = "SELECT MAX(Id_utilizator) FROM Utilizatori";

            // realizam conexiunea
            SqlConnection conexiune = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MagazinVirtualDB;Integrated Security=True;Pooling=False");

            SqlCommand myCom = new SqlCommand(strMax, conexiune);

            SqlDataReader dr = null; // pt a afisa ce retureaza select-ul

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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" +ex.Message + "')", true);
               
            }
            finally
            {
                dr.Close();
            }

            contor++;

            // construim prima data parametrii care vor avea valorile din textbox-uri
            SqlParameter p1 = new SqlParameter("@Id_utilizator", System.Data.SqlDbType.Int);
            p1.Value = contor;


            SqlParameter p2 = new SqlParameter("@Nume", System.Data.SqlDbType.NVarChar);
            p2.Value = tbNume.Text;


            SqlParameter p3 = new SqlParameter("@Prenume", System.Data.SqlDbType.NVarChar);
            p3.Value = tbPrenume.Text;


            SqlParameter p4 = new SqlParameter("@Varsta", System.Data.SqlDbType.Int);
            p4.Value = int.Parse(tbVarsta.Text);

            //facem inserarea
            string strInsert = "INSERT INTO [Utilizatori] ([Id_utilizator], [Nume], [Prenume], [Varsta]) VALUES (@Id_utilizator, @Nume, @Prenume, @Varsta)";

            myCom = new SqlCommand(strInsert, conexiune);

            myCom.Parameters.Add(p1);
            myCom.Parameters.Add(p2);
            myCom.Parameters.Add(p3);
            myCom.Parameters.Add(p4);

            try
            {
                myCom.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Inserare OK" + "')", true);

                //golire campuri
                tbNume.Text = "";
                tbPrenume.Text = "";
                tbVarsta.Text = "";

                //vizualizare si in tabel
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Inserarea a esuat:" + ex.Message + "')", true);
            }
            finally
            {
                conexiune.Close();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           int id = GridView1.SelectedIndex + 1;
           Response.Redirect("PaginaPrincipala.aspx?id="+id);
        }
    }
}