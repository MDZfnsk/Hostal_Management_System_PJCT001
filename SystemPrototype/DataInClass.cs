using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SystemPrototype
{
    class DataInClass
    {
        public int InsFunction(int UserID, string UserNM, int UserNo_1)
        {
            int EmpID = UserID;
            string EmpNM = UserNM;
            int PhnNum = UserNo_1;

            CommonVali IDvalidate = new CommonVali();
            bool flag = IDvalidate.ID_Validation(EmpID);

            if (flag)
            {
                return 2;
            }
            else
            {
                string querry = "INSERT INTO Employee(Emp_ID,Emp_NM,Contact_NO_1)VALUES (" + EmpID + ",'" + EmpNM + "'," + PhnNum + ")";
                EmpConnection conect = new EmpConnection();
                int result = conect.ExecuteQRY(querry);

                if (result == 1)
                {
                    return 1;

                }
                else
                {
                    return 0;
                }

            }
        }

        public int InsFunction(int UserID, string UserNM, int UserNo_1, int UserNo_2)
        {
            int EmpID = UserID;
            string EmpNM = UserNM;
            int PhnNum_1 = UserNo_1;
            int PhnNum_2 = UserNo_2;


            CommonVali IDvalidate = new CommonVali();
            bool flag = IDvalidate.ID_Validation(EmpID);

            if (flag)
            {
                return 2;
            }
            else
            {
                string querry = "INSERT INTO Employee VALUES (" + EmpID + ",'" + EmpNM + "'," + PhnNum_1 + "," + PhnNum_2 + ")";
                EmpConnection conect = new EmpConnection();
                int result = conect.ExecuteQRY(querry);

                if (result == 1)
                {
                    return 1;

                }
                else
                {
                    return 0;
                }

            }

        }

    }
}
