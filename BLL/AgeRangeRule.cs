using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//להוסיף---------------
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Globalization;

namespace MishnatYosef.BLL
{
    public class AgeRangeRule : ValidationRule
    {
        private int _min;
        private int _max;

        //public AgeRangeRule()
        //{
        //}

        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        // validation check
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age = 0;

            try
            {
                if (((string)value).Length > 0)
                    age = Int32.Parse((String)value);
            }
            // check if all digits
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            //  check age range
            if ((age < Min) || (age > Max))
            {
                return new ValidationResult(false,
                  "Please enter an age in the range: " + Min + " - " + Max + ".");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }




    public class EmailRule : ValidationRule
    {

        // validation check
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if ((string)value == "")
                return new ValidationResult(false,
                         "Please enter an Email.");

            try
            {
                MailAddress m = new MailAddress((string)value);

                return ValidationResult.ValidResult;
            }
            catch (FormatException)
            {
                return new ValidationResult(false,
                          "Please enter a legal Email.");
            }
        }
    }


    public class EmailRule2 : ValidationRule
    {

        // validation check
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string email = (string)value;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return ValidationResult.ValidResult;  // correct
            else
                return new ValidationResult(false,
                          "Please enter a legal Email.");  // is incorrect
        }
    }
    public class isHebrewRule2 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string pattern = (string)value;
            Regex reg = new Regex(@"\b[א-ת-\s ]+$");
            Match match = reg.Match(pattern);
            if (match.Success)
                return ValidationResult.ValidResult;  // correct
            else
                return new ValidationResult(false,
                          "Please enter a legal Hebrew.");  // is incorrect
        }
    }

    //פלאפון

    public class IsCellPhone : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string pattern = (string)value;
            Regex reg = new Regex(@"\b05[0 2 4 5 6 7 8 3][2-9]\d{6}$");
            Match match = reg.Match(pattern);
            if (match.Success)
                return ValidationResult.ValidResult;  // correct
            else
                return new ValidationResult(false,
                          "הכנס טלפון תקין");  // is incorrect
        }
    }

    //   מספרים בלבד


    public class IsNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string pattern = (string)value;
            Regex reg = new Regex(@"\b[0-9-\s]+$");
            Match match = reg.Match(pattern);
            if (match.Success)
                return ValidationResult.ValidResult;  // correct
            else
                return new ValidationResult(false,
                          "Please enter a legal number.");  // is incorrect
        }
    }

    //בדיקת תעודת זהות 


    public class IsId : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string s = (string)value;

            int x;
            if (!int.TryParse(s, out x))
                return new ValidationResult(false,
                         "Please enter a legal number.");  // is incorrect
            if (s.Length < 5 || s.Length > 9)
                return new ValidationResult(false,
                         "Please enter a legal number.");  // is incorrect
            for (int i = s.Length; i < 9; i++)
                s = "0" + s;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]) - '0');
                if (k > 9)
                    k -= 9;
                sum += k;

            }
            if (sum % 10 != 0) return new ValidationResult(false, "id is not correct");
            return ValidationResult.ValidResult;  // correct

        }
    }
}



