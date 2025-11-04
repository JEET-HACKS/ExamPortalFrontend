using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Helpers;

namespace Examportal.Models
{
    public class ActionDbContext : DbContext
    {
        public ActionDbContext() : base("MyCustomConnection")
        {

        }

        public string SignUpCredentials(string Role,string UserId,string pswd)
        {
            string msg = "";
            try
            {
                 msg = Database.SqlQuery<string>("EXEC SP_FOR_CREDENTIALS @what,@userid,@pswd,@Role",
                            new SqlParameter("@what", "Signup"),
                            new SqlParameter("@userid", UserId),
                            new SqlParameter("@pswd", pswd),
                            new SqlParameter("@Role", Role)).FirstOrDefault();

            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            

            return msg;
            //string msg=Database.SqlQuery<string>("EXEC SP_FOR_CREDENTIALS @what='Signup',@userid='" + UserId + "',@pswd='" + pswd + "',@Role='" + Role + "'").FirstOrDefault();

        }
        public string LoginCredentials(string Role, string UserId, string pswd)
        {
            string msg = "";
            try
            {
                 msg = Database.SqlQuery<string>("EXEC SP_FOR_CREDENTIALS @what,@userid,@pswd,@Role",
                        new SqlParameter("@what", "Login"),
                        new SqlParameter("@userid", UserId),
                        new SqlParameter("@pswd", pswd),
                        new SqlParameter("@Role", Role)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return msg;
        }

        public string UserInfo(FormDetails fd)
        {
            string msg = "";
            try
            {
            msg = Database.SqlQuery<string>("EXEC InsertFormDetails @what=@what, @Full_Name=@Full_Name, @Father_Name=@Father_Name, @Mother_Name=@Mother_Name, @DOB=@DOB, @Gender=@Gender, @Email=@Email, @State=@State, @MobileNo=@MobileNo, @Course=@Course, @Exam_Type=@Exam_Type, @Semester=@Semester, @Photo=@Photo, @Idproof=@Idproof, @Signature=@Signature, @Subjects=@Subjects, @paymentmethod=@paymentmethod, @paymentmethodid=@paymentmethodid, @Amount=@Amount, @caste=@caste, @Examformname=@Examformname",
            new SqlParameter("@what", "InsertForm"),
            new SqlParameter("@Full_Name", fd.Full_Name),
            new SqlParameter("@Father_Name", fd.Father_Name),
            new SqlParameter("@Mother_Name", fd.Mother_Name),
            new SqlParameter("@DOB", fd.DOB),
            new SqlParameter("@Gender", fd.Gender),
            new SqlParameter("@Email", fd.Email),
            new SqlParameter("@State", fd.State),
            new SqlParameter("@MobileNo", fd.MobileNo),
            new SqlParameter("@Course", fd.Course),
            new SqlParameter("@Exam_Type", fd.Exam_Type),
            new SqlParameter("@Semester", fd.Semester),
            new SqlParameter("@Photo", fd.Photo),
            new SqlParameter("@Idproof", fd.Idproof),
            new SqlParameter("@Signature", fd.signature),
            new SqlParameter("@Subjects", fd.subjects),
            new SqlParameter("@paymentmethod", fd.Payment_Method),
            new SqlParameter("@paymentmethodid", fd.Payment_Method_Id),
            new SqlParameter("@Amount", fd.Amount),
            new SqlParameter("@caste", fd.caste),
            new SqlParameter("@Examformname", fd.Exam_Name)
           ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return msg;
        }

        public string AddNewFormDetails(NewFormDetails Anf)
        {
            string msg = "";
            try
            {
                    msg = Database.SqlQuery<string>(
                    "EXEC InsertFormDetails @what=@what, @ReleaseD=@ReleaseD, @Description=@Description, @Eligibility=@Eligibility, @Lastdate=@Lastdate, @formfee=@formfee",
                    new SqlParameter("@what", "Forminsert"),
                    new SqlParameter("@ReleaseD", Anf.ReleaseDate),
                    new SqlParameter("@Description", Anf.Description),
                    new SqlParameter("@Eligibility", Anf.Eligibility),
                    new SqlParameter("@Lastdate", Anf.LastDate),
                    new SqlParameter("@formfee", Anf.FormFee)
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            


            return msg;
        }

        public List<NewFormDetails> GetDetails()
        {
            string mssg = "";
            List<NewFormDetails> msg = new List<NewFormDetails>();
            try
            {
                msg = Database.SqlQuery<NewFormDetails>("EXEC InsertFormDetails @what",
                        new SqlParameter("@what", "AdminView")).ToList();
                //int result = Database.ExecuteSqlCommand("EXEC InsertFormDetails @what",
                //           new SqlParameter("@what", "AdminView"));
            }
            catch (Exception ex)
            {
                mssg = ex.Message;
            }
            
            return msg;
        }

        public string DeleteDetails(string id)
        {
            string msg = "";
            try
            {
                int result = Database.ExecuteSqlCommand("EXEC InsertFormDetails @what=@what,@unqid=@unqid",
                        new SqlParameter("@what", "DeleteForm"),
                        new SqlParameter("@unqid", id));
                //int result = Database.ExecuteSqlCommand("EXEC InsertFormDetails @what",
                //           new SqlParameter("@what", "AdminView"));

                if (result == 1)
                    msg = "ok";
                else
                    msg = "No Rows Affected";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return msg;
        }

        public List<NewFormDetails> RetrieveDetails(string id)
        {
            string mssg = "";
            List<NewFormDetails> msg = new List<NewFormDetails>();
            try
            {
                 msg = Database.SqlQuery<NewFormDetails>("EXEC InsertFormDetails @what=@what,@unqid=@unqid",
                        new SqlParameter("@what", "Retrieve"),
                        new SqlParameter("@unqid", id)).ToList();
            }
            catch (Exception ex)
            {
                mssg = ex.Message;
            }
            
            
            return msg;
        }

        public List<DashboardData> DashboardDetails()
        {
            string mssg = "";
            List<DashboardData> msg = new List<DashboardData>();
            try
            {
                
                msg = Database.SqlQuery<DashboardData>(
                "EXEC InsertFormDetails @what=@what",
                new SqlParameter("@what", "DashBoardDetails")
            ).ToList();
            }
            catch (Exception ex)
            {
                mssg = ex.Message;
            }
            

            return msg;
        }

        public List<FormDetails> DashGetDetails()
        {
            string mssg = "";
            List<FormDetails> msg = new List<FormDetails>();
            try
            {
                 msg = Database.SqlQuery<FormDetails>("EXEC InsertFormDetails @what",
                        new SqlParameter("@what", "AdminDash")).ToList();
                //int result = Database.ExecuteSqlCommand("EXEC InsertFormDetails @what",
                //           new SqlParameter("@what", "AdminView"));
            }
            catch (Exception ex)
            {
                mssg = ex.Message;
            }
            
            return msg;
        }

        public string UpdateDetails(NewFormDetails fd)
        {
            string mssg = "";
            try
            {
            int result = Database.ExecuteSqlCommand(
            "EXEC InsertFormDetails @what=@what, @ReleaseD=@ReleaseD, @Description=@Description, @Eligibility=@Eligibility, @Lastdate=@Lastdate, @formfee=@formfee,@unqid=@unqid",
            new SqlParameter("@what", "Update"),
            new SqlParameter("@ReleaseD", fd.ReleaseDate),
            new SqlParameter("@Description", fd.Description),
            new SqlParameter("@Eligibility", fd.Eligibility),
            new SqlParameter("@Lastdate", fd.LastDate),
            new SqlParameter("@formfee", fd.FormFee),
            new SqlParameter("@unqid", fd.unqid)
            );
            }
            catch (Exception ex)
            {
                mssg = ex.Message;
            }
            
           

            return mssg;

        }



    }
}