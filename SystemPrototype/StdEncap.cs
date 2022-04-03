using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemPrototype
{
    class StdEncap
    {
       
        private int stdId;
        private string stdname;
        private string addressstd;
        private int stdmobileno;
        private string stdemail;

        public void setValues(int userid, string uname, string useraddress, int usermo, string useremail)
        {
            stdId = userid;
            stdname = uname;
            addressstd = useraddress;
            stdmobileno = usermo;
            stdemail = useremail;
        }

        public int getstudentID()
        {
            return stdId;
        }

        public string getStudentName()
        {
            return stdname;
        }

        public string getstdaddress()
        {
            return addressstd;
        }

        public int getStdmobile()
        {
            return stdmobileno;
        }

        public string getstdemail()
        {
            return stdemail;
        }
    }

}
