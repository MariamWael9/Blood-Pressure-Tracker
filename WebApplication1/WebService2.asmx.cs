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
    public class WebService2 : System.Web.Services.WebService
    {

        [WebMethod]
        public string blood_pressure(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-INLJ005;Initial Catalog=meryam;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select blood pressure from blood pressure tracking where id = @y;", con);
            SqlParameter p1 = new SqlParameter("@y", id);
            cmd.Parameters.Add(p1);
            int bp = (int)cmd.ExecuteScalar();
            con.Close();

            if (bp > 120 && bp < 140)
            {
                return "you have Prehypertension you should take care of yourself by follwing diet plan:\n" +
                    "1- Watch the salt\n" +
                    "2- Move more\n" +
                    "3- Get to a healthy weight\n" +
                    "4- Limit alcohol/n" +
                    "5- Curb stress\n" +
                    "6- Keep up with your blood pressure";
            }

            else if (bp > 140)
            {
                return "you have high blood pressure you should follow dash diet the diet is simple:\n " +
                    "1- Eat more fruits, vegetables, and low-fat dairy foods \n " +
                    "2- Cut back on foods that are high in saturated fat, cholesterol, and trans fats\n" +
                    "3- Eat more whole-grain foods, fish, poultry, and nuts \n" +
                    "4- Limit sodium, sweets, sugary drinks, and red meats";


            }
            else if (bp < 90)
            {
                return "you have low blood pressure the plan is simple:\n" +
                    "1- Use more salt\n" +
                    "2- Wear compression stockings/n" +
                    "3- Drink more water, less alcohol\n" +
                    "4- Pay attention to your body positions\n" +
                    "5- Eat small, low-carb meals.\n" +
                    "6- Exercise regularly";
            }
            else
                return "your blood pressure is ideal";






        }
    }
}
