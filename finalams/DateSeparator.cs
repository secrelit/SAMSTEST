using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace finalams
{
  
    public class DateSeparator
    {
        public string str;
        public DateSeparator()
        {

            //string date=StringDate(path);
 
        }
        //H:\\Nilesh sir\\MyExel.xlsx
        public string StringDate(string path)
        {
            string dateString;
            if (path.EndsWith(".xls") == true || path.EndsWith(".xlsx"))
            {

                char[] saparator = new char[1];
                if (path.Contains("\\"))
                {
                    saparator[0] = '\\';
                    String[] subPath = path.Split(saparator);
                    int subPathLength = (subPath.Length) - 1;
                    //Console.WriteLine(subPath[subPathLength]);
                    dateString = subPath[subPathLength];
                    if (dateString.Contains("."))
                    {
                        saparator[0] = '.';

                        subPath = dateString.Split(saparator);

                        dateString = subPath[0];
                        str = dateString;

                        //dateString.Remove(dateString.Length - 4); 

                    }


                    Console.WriteLine(str);
                }
            }
            else
            {
                throw new Exception("The Inapropriate EXCEL FILE ");
            }
            return str;
        }
    }
}
