using System;
using System.Collections.Generic;
using System.Linq;

namespace checkoutapp
{
    public class result
    {
       public decimal opresult;
       public string errormessage = string.Empty;
    }

    public interface IcheckOut
    {
        result bill(string fruitlist);

    }

    public class checkout : IcheckOut
    {
        

        public result bill(string fruitlist)
        {
            result methodresult = new result();
            decimal result = 0;
            try
            { string[] fruitarr = fruitlist.Split(",");
                bool validateip = validateinput(fruitarr);
                if (validateip)
                {
                  int countapp = fruitarr.Count(p => p.Contains("Apple"));
                   int countavo = fruitarr.Count(p => p.Contains("Avocado"));
                    if (countapp % 2 == 0)
           {
                        result = (((countapp / 2) * 25) + (countavo * 10) + 25);
                        result = result / 100;
                    }
                    else
                    {
                        result = ((countavo * 10) + (countapp * 25));
                        result = result / 100;
                    }

                    methodresult.opresult = result;
                }
                else
                {
                    methodresult.errormessage = "Please check the input";
                    Console.WriteLine(methodresult.errormessage);
                }


            }
            catch (Exception ex)
            {
                throw ex;

            }

            return methodresult ;
        }


        public bool validateinput(string[] fruits)
        {
            bool op = true;
            foreach(string item in fruits)
            {   
                if (item != "Apple" )
                {
                    if(item!= "Avocado")
                    {
                        op = false;
                    }
                }
             
            }

            return op;

        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your order");
            string inputfruits = Console.ReadLine();
            checkout a = new checkout();
            result amtbill = a.bill(inputfruits);
            Console.WriteLine("Bill Amount is :$"+amtbill.opresult);
        }
    }
}
