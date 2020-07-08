﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dream_holiday.Models
{
    public class CheckoutModel
    {


        public CheckoutModel() { }

        public String FirstName = "";
        public String LastName = "";
        public String UserName = "";
        public String Email = "";



        public String Address = "";
        public String Address2 = "";


        public String Country = "";
        public String City = "";
        public String EirCode = "";


        public String NameOnCard = "";

        public String CardNumber = "";
        public DateTime Expiration;
        public String CVC = "";

        public String FirstItem = "";
        public String SecondItem = "";
        public String ThirdItem = "";

        public String GetUserName()
        {
            return FirstName + LastName;

        }

    }
}
