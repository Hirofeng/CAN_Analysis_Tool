using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Fengyuan.CatForm
{
    public class ProjectStorage
    {
        static private double CurrentVersion=1.0;

        static public void WriteProjectFile(CatProjectManager project,string path)
        {
            StreamWriter sw = null;
            try
            {
                string line;
                sw = new StreamWriter(path,false);
                sw.WriteLine(CurrentVersion.ToString());
                line = "Project path=" + project.Name;
                sw.WriteLine(line);
                line = "Dbc path=" + project.DbcPath;
                sw.WriteLine(line);
                line = "svw platform=" + project.GlobalTimeout.Platform;
                sw.WriteLine(line);
                line = "CAN channel=" + project.GlobalTimeout.Channel;
                sw.WriteLine(line);

                project.HasChanged = false;
            }
            catch(UnauthorizedAccessException uax)
            {
                throw new Exception("无法访问" + path, uax);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
            


        }

        static public CatProjectManager ReadProjectFile(string path)
        {
            return null;
        }


    }
}
