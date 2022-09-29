using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EthernetIPFunc
{
    public enum CIPEncapCommands : ushort
    {
        NOOP,
        LISTTARGETS,
        LISTSERVICES = 4,
        LISTIDENTITY = 99,
        LISTINTERFACES,
        REGISTERSESSION,
        UNREGISTERSESSION,
        SEND_RRDATA = 111,
        SEND_UNITDATA,
        INDICATESTATUS = 114,
        CANCEL
    }
    public enum CIPEncapStatus : uint
    {
        Success,
        Unsupported_Command,
        Insufficient_Memory,
        Incorrect_Data,
        Invalid_Session_Handle = 100u,
        Invalid_Length,
        Unsupported_Protocol_Revision = 105u
    }
    public class MTagNameInfo
    {
        private string f_tagname;
        private int f_valuenum;
        public string F_TagName
        {
            get
            {
                return this.f_tagname;
            }
            set
            {
                this.f_tagname = value;
            }
        }
        public int F_ValueNum
        {
            get
            {
                return this.f_valuenum;
            }
            set
            {
                this.f_valuenum = value;
            }
        }
    }
}
