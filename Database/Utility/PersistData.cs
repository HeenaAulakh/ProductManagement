using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Database.Utility
{
    public class PersistData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        public static string WriteData (string payload)
        {
            string userMessage = string.Empty;
            try
            {
                //Getting path to store Json in Bin folder under Product Suggestion project
                String path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");
                if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(payload))
                {
                    //Using stream write will ensure that file is created if it does not exist and then it will append data to it
                    using (StreamWriter writer = File.AppendText(path + "Products.json"))
                    {
                        writer.WriteLine(payload);
                        userMessage = "Your product has been saved";
                    }
                }
            }
            catch (Exception ex)
            {
                userMessage = "Your product could not be saved. Exception: [ " + ex.Message + " ]";
            }
            return userMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ReadData()
        {
            //Implement the reading logic here
            return "";
        }
    }
}
