using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void insert(string name,int age, int w, string gender, int bp)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP - INLJ005; Initial Catalog = meryam; Integrated Security = True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into blood_pressure_tracker(name,age,weight,gender,blood pressure) values(@a,@b,@c,@d,@e)", con);
            SqlParameter p1 = new SqlParameter("@a", name);
            SqlParameter p2 = new SqlParameter("@b", age);
            SqlParameter p3 = new SqlParameter("@c", w);
            SqlParameter p4 = new SqlParameter("@d", gender);
            SqlParameter p5= new SqlParameter("@e", bp);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        [WebMethod]
        public void UpdateUserInfo(int PersonID, string PersonName, int PersonAge, int PerosnWeight, string PerosnGender, int PersonBloodPressure)
        {
            SqlConnection PeopleData = new SqlConnection("Data Source = DESKTOP - INLJ005; Initial Catalog = meryam; Integrated Security = True");
            PeopleData.Open();
            SqlCommand cmd = new SqlCommand("UPDATE blood_pressure_tracker SET name=@namePara, age=@AgePara, weight=@WeightPara, gender=@GenderPara, blood pressure=@bloodPara WHERE id=@IdPara", PeopleData);

            SqlParameter namePara = new SqlParameter("namePara", PersonName);
            SqlParameter AgePara = new SqlParameter("AgePara", PersonAge);
            SqlParameter WeightPara = new SqlParameter("WeightPara", PerosnWeight);
            SqlParameter GenderPara = new SqlParameter("GenderPara", PerosnGender);
            SqlParameter bloodPara = new SqlParameter("bloodPara", PersonBloodPressure);
            SqlParameter IdPara = new SqlParameter("IdPara", PersonID);

            cmd.Parameters.Add(namePara);
            cmd.Parameters.Add(AgePara);
            cmd.Parameters.Add(WeightPara);
            cmd.Parameters.Add(GenderPara);
            cmd.Parameters.Add(bloodPara);
            cmd.Parameters.Add(IdPara);


            cmd.ExecuteNonQuery();
            PeopleData.Close();
        }

        [WebMethod]
        public string ViewUserInfo(int PersonId)
        {
            SqlConnection PeopleData = new SqlConnection("Data Source = DESKTOP - INLJ005; Initial Catalog = meryam; Integrated Security = True");
            PeopleData.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM blood_pressure_tracker WHERE id=@IdPara", PeopleData);

            SqlParameter IdPara = new SqlParameter("@IdPara", PersonId);

            cmd.Parameters.Add(IdPara);

            string PersonData = Convert.ToString(cmd.ExecuteNonQuery());


            return PersonData;
        }

        [WebMethod]
        public bool check(int id)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP - INLJ005; Initial Catalog = meryam; Integrated Security = True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select id from blood pressure tracker where id = @x", con);
            SqlParameter p1 = new SqlParameter("@x", id);
            cmd.Parameters.Add(p1);
            cmd.ExecuteNonQuery();
            con.Close();

            if ((int)cmd.ExecuteScalar() == id)
                return true;
            else
                return false;
                
            
        }
    }
}
