using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMC_Suhi
{
    public static class StringHelper
    {
        public static string getOutput(string data1, string data2, string input)
        {
            List<string> listdata1 = data1.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
            List<string> listdata2 = data2.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
            List<string> listinput = input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

            StringBuilder result = new StringBuilder();

            foreach(string line in listinput)
            {
                int index = listdata1.FindIndex(x => x.Equals(line));
                if (index > 0)
                {
                    result.Append(listdata2[index]);
                } else
                {
                    result.Append("");
                }
                result.Append(Environment.NewLine);
            }

            return result.ToString().Substring(0,result.ToString().Length-1);
        }

        public static void getOutputList(string data1, string data2, string input, DataTable dataTable)
        {
            List<string> listdata1 = data1.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
            List<string> listdata2 = data2.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

            List<string> listinput = input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

            //List<string> output = new List<string>();
            int i = 1;
            foreach (string line in listinput)
            {
                int index = listdata1.FindIndex(x => x.Equals(line));
                if (index > 0)
                {
                    //output.Add(listdata2[index]);
                    dataTable.Rows.Add(i, line, listdata2[index]);
                }
                else
                {
                    //output.Add("");
                    dataTable.Rows.Add(i, line, "");
                }
                i++;
            }

        }

        public static string getSQL(DataTable dataTable)
        {
            string sql = "SELECT @komoku@ \r\n FROM Shinsei__c where BunshoBango__c='XXX'";
            StringBuilder komoku = new StringBuilder();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row[2].ToString().Trim() != "")
                {
                    komoku.Append(" Komoku" + row[2] + "__c, ");
                }
            }

            return sql.Replace("@komoku@", komoku.ToString().Substring(0, komoku.ToString().Length-2));

        }
    }
}
