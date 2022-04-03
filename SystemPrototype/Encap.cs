using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemPrototype
{
    class Encap
    {
        private int std_ID;
        private float Amount;

        public void Set_ID(int User_ID)
        {
            std_ID = User_ID;
        }

        public int Get_ID()
        {
            return std_ID;
        }

        public void Set_Amount(float User_amount)
        {
            Amount = User_amount;
        }

        public float Get_Amount()
        {
            return Amount;
        }
    }
}
