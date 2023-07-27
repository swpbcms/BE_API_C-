using BCMS.DTO;
using BCMS.Interface;
using Newtonsoft.Json;

namespace BCMS.Services
{
    public class AdminService :IAdmin
    {
        public AdminService() { }

        public Admin login(string username, string password)
        {
            Admin ad = new Admin();
            string file = "admin.json";

            using(StreamReader sr = File.OpenText(file))
            {
                var obj = sr.ReadToEnd();
                ad = JsonConvert.DeserializeObject<Admin>(obj);
            }

            if(ad != null)
            {
                if(ad.Username== username && ad.Password == password)
                {
                    return ad;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Admin update(string username, string password, string newpass)
        {
            Admin ad = new Admin();
            string file = "admin.json";

            using (StreamReader sr = File.OpenText(file))
            {
                var obj = sr.ReadToEnd();
                ad = JsonConvert.DeserializeObject<Admin>(obj);
            }

            if (ad != null)
            {
                if (ad.Username == username && ad.Password == password)
                {
                    ad.Password= newpass;
                    using (StreamWriter sw = File.CreateText(file))
                    {
                        var newdata = JsonConvert.SerializeObject(ad);
                        sw.WriteLine(newdata);
                    }
                    return ad;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
