using System.Collections.Generic;

namespace TotDbs_ArchivierungsTool.Classes
{
    public class Cls_ReadServers
    {
        public List<string> listOfServers = new List<string>();
        public Cls_ReadServers()
        {
            listOfServers.Add("(local)");
            listOfServers.Add("DMSQL01");
            listOfServers.Add("DMSQL02");
        }
    }
}
