using System;
using System.Collections.Generic;
using System.Text;
using InitialCore.Service.Interfaces;

namespace InitialCore.Service.Implementation
{
    public class KASService : IKASService
    {        
        public List<string> GetKAS() {
            List<string> lstKAS = new List<string>();
            lstKAS[0] = "abc";
            lstKAS[1] = "def";
            return lstKAS;
        } 
    }
}
