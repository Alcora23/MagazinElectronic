using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Agenda_de_activitati___Proiect
{
    public partial class CreareProduse : System.Web.UI.Page
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
            string strMax = "SELECT MAX(Id_produs) FROM Produse";

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


            //aflare id al tipului produsului selectat
            string id_tip_p = "";
            string strInterogare = "SELECT id_tip_produse FROM Tip_produse WHERE tip_produs = @tip";

            SqlParameter p1_tip = new SqlParameter("@tip", System.Data.SqlDbType.VarChar);
            p1_tip.Value = DropDownList1.SelectedValue;

            myCom = new SqlCommand(strInterogare, conexiune);

            myCom.Parameters.Add(p1_tip);

            try
            {

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

            }

            //obtinerea pozei
            string fname = "";
            if (tbPoza.HasFile)
            {
                try
                {
                    fname = Path.GetFileName(tbPoza.FileName);

                    //folderul unde vreau sa salvez pozele
                    tbPoza.SaveAs(Server.MapPath("Poze/") + fname);


                    // construim prima data parametrii care vor avea valorile din textbox-uri
                    SqlParameter p1 = new SqlParameter("@Id_produs", System.Data.SqlDbType.Int);
                    p1.Value = contor;


                    SqlParameter p2 = new SqlParameter("@Nume_produs", System.Data.SqlDbType.NVarChar);
                    p2.Value = tbNumeProdus.Text;

                    SqlParameter p3 = new SqlParameter("@Imagine", System.Data.SqlDbType.NVarChar);
                    p3.Value = tbPoza.FileName;


                    SqlParameter p4 = new SqlParameter("@Pret", System.Data.SqlDbType.NVarChar);
                    p4.Value = tbPret.Text;

                    SqlParameter p5 = new SqlParameter("@Descriere", System.Data.SqlDbType.NVarChar);
                    p5.Value = tbDescriere.Text;


                    SqlParameter p6 = new SqlParameter("@Id_tip_produs", System.Data.SqlDbType.Int);
                    p6.Value = id_tip_p;


                    //facem inserarea
                    string strInsert = "INSERT INTO [Produse] ([Id_produs], [Denumire_produs], [Imagine], [Pret], [Descriere], [Id_tip_produs]) VALUES (@Id_produs, @Nume_produs, @Imagine, @Pret, @Descriere, @Id_tip_produs)";

                    myCom = new SqlCommand(strInsert, conexiune);

                    myCom.Parameters.Add(p1);
                    myCom.Parameters.Add(p2);
                    myCom.Parameters.Add(p3);
                    myCom.Parameters.Add(p4);
                    myCom.Parameters.Add(p5);
                    myCom.Parameters.Add(p6);




                    int t = myCom.ExecuteNonQuery();

                    if (t > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Crearea produsului a fost efectuata cu succes" + "')", true);


                        Response.Redirect("PaginaPrincipala.aspx?id=" + Request.QueryString["id"]);

                        //golire campuri
                        tbNumeProdus.Text = "";
                        tbPret.Text = "";
                        tbDescriere.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Crearea produsului a esuat" + ex + "')", true);
                }
                finally
                {
                    conexiune.Close();
                }
            }

        }

     

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipala.aspx?id=" + Request.QueryString["id"]);
        }

      
    }
}