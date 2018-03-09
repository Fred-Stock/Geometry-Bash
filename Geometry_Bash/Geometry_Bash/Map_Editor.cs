using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Geometry_Bash
{
    class Map_Editor
    {
        StreamReader reader;

        public Map_Editor()
        {
            reader = null;

            try
            {
                reader = new StreamReader("");
                string line;

                while ((line = reader.ReadLine()) != null)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

            }
        }
    }
}
