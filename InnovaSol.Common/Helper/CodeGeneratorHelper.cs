﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaSolTest.Common.Helper
{
    public static class CodeGeneratorHelper
    {
        public static string GetActivationCode()
        {
            string CodeLength = "4";
            string Code = string.Empty;

            string Chars = string.Empty;
            Chars = "1,2,3,4,5,6,7,8,9,0";

            char[] seplitChar = { ',' };
            string[] arr = Chars.Split(seplitChar);
            string NewOTP = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(CodeLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                NewOTP += temp;
                Code = NewOTP;
            }
            return Code;
        }
    }
}
