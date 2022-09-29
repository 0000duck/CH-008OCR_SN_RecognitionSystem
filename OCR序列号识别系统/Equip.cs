using System;
using System.Collections.Generic;
using System.Linq;
using OPC;
using OPCDA;
using OPCDA.NET;


namespace Test_Automation
{
    /// <summary>
    /// 通过RSLinx OPC进行PLC读写的设备对象，请把应用程序发布的目标平台设置为x86，否则无法正常连接
    /// </summary>
    public class Equip : BaseEquip
    {
        #region 字段定义

        private bool _isOpen = false;
        private OpcServer myOPCServer;
        private DataChangeEventHandler dch;         //数据刷新委托对象
        private RefreshGroup asyncRefrGroup;        //数据刷新组，把要感知数据刷新的标签加入此组，这样标签值变化时才会触发DataChange事件
        private SyncIOGroup readWriteGroup;         //数据读写组，把要进行写入操作的标签放入词组，调用Write方法才会生效
        private Dictionary<string, object> readResult = null;       //设备标签数据缓存
        private int stepLen = 100;                  //标签变量的步长设置
        private string groupNamePrefix = "N";      //数据块号前缀

        #endregion

        #region 属性定义

        /// <summary>
        /// OPCServer IP地址
        /// 例：192.168.1.105
        /// </summary>
        public string OpcServerIP
        {
            get
            {
                //return (this.Main.ConnType as Mesnac.Equips.Connection.RSLinxOPC.ConnType).OpcServerIP;
                return "192.168.1.124";
            }
        }

        /// <summary>
        /// OPC服务名称
        /// 例：Kepware.KEPServerEX.V5
        /// </summary>
        public string OpcServerName
        {
            get
            {
                //return (this.Main.ConnType as Mesnac.Equips.Connection.RSLinxOPC.ConnType).OpcServerName;
                return "RSLinx OPC Server";
            }
        }

        /// <summary>
        /// 通道名称Topic
        /// 例：chnlSiemens
        /// </summary>
        public string ChannelName
        {
            get
            {
                //return (this.Main.ConnType as Mesnac.Equips.Connection.RSLinxOPC.ConnType).ChannelName;
                return "demo1";
            }
        }

        #endregion

        public override bool Open()
        {
            lock (this)
            {
                if (this._isOpen == true && this.myOPCServer != null)
                {
                    return true;
                }
                this.State = false;
                this.myOPCServer = new OpcServer();
                int res = this.myOPCServer.Connect(this.OpcServerIP, this.OpcServerName);      //连接OPCServer
                if (HRESULTS.Failed(res))
                {
                    this.myOPCServer = null;
                    Console.WriteLine("OPC连接失败：" + res);
                    this.State = false;
                    return false;
                }
                else
                {
                    this.State = true;
                    this._isOpen = true;
                    Console.WriteLine("OPC连接成功！");
                    this.readWriteGroup = new SyncIOGroup(this.myOPCServer);

                    dch = new DataChangeEventHandler(DataChangeHandler);
                    int rate = this.Main.ReadHz / 2 > 0 ? this.Main.ReadHz / 2 : 1;
                    this.asyncRefrGroup = new RefreshGroup(myOPCServer, dch, rate);

                    #region 初始化读取结果

                    this.readResult = new Dictionary<string, object>();

                    foreach (Equips.BaseInfo.Group group in this.Group.Values)
                    {
                        int tagCount = group.Len % this.stepLen == 0 ? group.Len / this.stepLen : group.Len / this.stepLen + 1;

                        int currLen = 0;

                        for (int i = 0; i < tagCount; i++)
                        {
                            string tagName = String.Empty;
                            if (tagCount == 1)
                            {
                                //tagName = String.Format("{0}-{1}", group.Start, group.Start + group.Len - 1);
                                tagName = String.Format("[{0}],L{1},C1", group.Start, group.Len);
                                currLen = group.Len;
                            }
                            else if (i == tagCount - 1)
                            {
                                //tagName = String.Format("{0}-{1}", group.Start + (i * this.stepLen), group.Start + (i * this.stepLen) + (group.Len % this.stepLen == 0 ? this.stepLen : group.Len % this.stepLen) - 1);
                                tagName = String.Format("[{0}],L{1},C1", group.Start + (i * this.stepLen), group.Len % this.stepLen == 0 ? this.stepLen : group.Len % this.stepLen);
                                currLen = group.Len % this.stepLen;
                            }
                            else
                            {
                                //tagName = String.Format("{0}-{1}", group.Start + (i * this.stepLen), group.Start + (i * this.stepLen) + this.stepLen - 1);
                                tagName = String.Format("[{0}],L{1},C1", group.Start + (i * this.stepLen), this.stepLen);
                                currLen = this.stepLen;
                            }

                            //N100[0],L10,C1
                            string tagFullName = String.Format("{0}{1}{2}", groupNamePrefix, group.Block, tagName);

                            //[demo1]N100[0],L10,C1
                            if (!this.readResult.ContainsKey(tagFullName))
                            {
                                Console.WriteLine(tagFullName);
                                short[] groupData = new short[currLen];
                                this.readResult[tagFullName] = groupData;

                                this.Add2RefrGroup(String.Format("[{0}]{1}", this.ChannelName, tagFullName));
                            }
                        }
                    }

                    #endregion
                }
                return this.State;
            }
        }


        public override bool Read(string block, int start, int len, out object[] buff)
        {
            lock (this)
            {
                buff = null;
                try
                {
                    if (!Open())
                    {
                        return false;
                    }
                    string startTag = String.Empty;
                    string groupName = String.Format("{0}{1}", this.groupNamePrefix, block);        //要读取的OPCServer块,例如：N100或者DB100
                    List<short> groupData = new List<short>();
                    //N100[0],L10,C1
                    string[] keys = this.readResult.Keys.Where(o => o.StartsWith(groupName) && o.Replace(String.Format("{0}", groupName), String.Empty).StartsWith("[")).OrderBy(c => c).ToArray<string>(); ;
                    foreach (string key in keys)
                    {
                        if (String.IsNullOrEmpty(startTag))
                        {
                            startTag = key.Replace(String.Format("{0}", groupName), String.Empty);
                        }
                        short[] values;
                        if (this.readResult[key] is short[])
                        {
                            values = this.readResult[key] as short[];
                        }
                        else
                        {
                            values = new short[] { (short)this.readResult[key] };
                        }
                        groupData.AddRange(values);
                    }
                    buff = new object[len];
                    int startIndex = 0;
                    string strStartIndex = startTag.Substring(1, startTag.IndexOf("]"));
                    int.TryParse(strStartIndex, out startIndex);
                    startIndex = start - startIndex;
                    Array.Copy(groupData.ToArray(), startIndex, buff, 0, buff.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(this.Name + "读取失败:" + ex.Message);
                    this.State = false;
                    return false;
                }
            }
        }

        public override bool Write(int block, int start, object[] buff)
        {
            lock (this)
            {
                try
                {
                    if (!Open())
                    {
                        return false;
                    }

                    bool isWrite = false;

                    #region 按标签变量写入

                    string itemId = "";
                    foreach (Equips.BaseInfo.Group group in this.Group.Values)
                    {
                        if (group.Block == block.ToString())
                        {
                            foreach (Equips.BaseInfo.Data data in group.Data.Values)
                            {
                                if (data.Start == start && data.Len == buff.Length)
                                {
                                    //[demo1]N100[0],L10,C1
                                    itemId = String.Format("[{0}]{1}", this.ChannelName, data.Name);
                                    break;
                                }
                            }
                        }
                    }
                    if (!String.IsNullOrEmpty(itemId))
                    {
                        if (this.AddItem(itemId) == 0)
                        {
                            ItemDef itemData = this.readWriteGroup.Item(itemId);
                            if (itemData != null)
                            {
                                int res = 0;
                                if (buff.Length == 1)
                                {
                                    res = this.readWriteGroup.Write(itemData, buff[0]);
                                }
                                else
                                {
                                    res = this.readWriteGroup.Write(itemData, buff);
                                }
                                string error = readWriteGroup.GetErrorString(res);
                                if (res != 0)
                                {
                                    Console.WriteLine(String.Format("标签变量[{0}]写入失败：{1}", itemId, error));
                                    return false;
                                }
                                else
                                {
                                    isWrite = true;
                                }
                            }
                        }
                    }

                    if (isWrite)
                    {
                        return true;
                    }

                    #endregion

                    Console.WriteLine("-----------------------1");

                    #region 按块写入

                    #region 先读取相应标签数数据

                    string startTag = String.Empty;
                    string groupName = String.Format("{0}{1}", this.groupNamePrefix, block);        //要读取的OPCServer块
                    List<short> groupData = new List<short>();
                    //N100[0],L10,C1
                    string[] keys = readResult.Keys.Where(o => o.StartsWith(groupName) && o.Replace(String.Format("{0}", groupName), String.Empty).StartsWith("[")).OrderBy(c => c).ToArray<string>();

                    foreach (string key in keys)
                    {
                        if (this.readResult[key] is Array)
                        {
                            groupData.AddRange(this.readResult[key] as short[]);
                        }
                        //Console.WriteLine(key);
                        if (String.IsNullOrEmpty(startTag))
                        {
                            startTag = key.Replace(String.Format("{0}", groupName), String.Empty);
                        }

                        string[] beginEnd = new string[2];

                        string tagName = key.Replace(String.Format("{0}", groupName), String.Empty);
                        beginEnd[0] = tagName.Substring(1, tagName.IndexOf("]") - 1);
                        beginEnd[1] = tagName.Replace(",C1", String.Empty).Substring(tagName.IndexOf("L") + 1);

                        int begin = 0;
                        int end = 0;

                        int.TryParse(beginEnd[0], out begin);
                        int.TryParse(beginEnd[1], out end);

                        end += begin - 1;

                        #region 写入之前，先读取一下PLC的值

                        if ((start >= begin && start <= end) || ((start + buff.Length - 1) >= begin && (start + buff.Length - 1) <= end) || (begin > start && (start + buff.Length - 1) < end))
                        {
                            ItemDef itemData = this.readWriteGroup.Item(String.Format("[{0}]{1}", this.ChannelName, key));
                            if (itemData == null)
                            {
                                Console.WriteLine(String.Format("标签变量[{0}]未添加到数据读写组中!", String.Format("[{0}]{1}", this.ChannelName, key)));
                                return false;
                            }
                            OPCItemState itemState = null;
                            int res = this.readWriteGroup.Read(OPCDATASOURCE.OPC_DS_DEVICE, itemData, out itemState);
                            if (HRESULTS.Failed(res))
                            {
                                string error = this.readWriteGroup.GetErrorString(res);
                                Console.WriteLine(String.Format("读取标签变量[{0}]的值失败：{1}", String.Format("[{0}]{1}", this.ChannelName, key), error));
                                return false;
                            }

                            if (itemState.DataValue is Array)
                            {
                                //groupData.AddRange(itemState.DataValue as short[]);
                                short[] source = itemState.DataValue as short[];
                                for (int i = begin; i <= end; i++)
                                {
                                    groupData[i] = source[i - begin];
                                }
                            }
                            else
                            {
                                Console.WriteLine(String.Format("标签变量[{0}]的长度未指定!", String.Format("[{0}]{1}", this.ChannelName, key)));
                            }
                        }
                        #endregion
                    }

                    #endregion

                    #region 更新标签中对应的数据后，再写回OPCServer

                    int startIndex = 0;
                    string strStartIndex = startTag.Substring(1, startTag.IndexOf("]") - 1);

                    int.TryParse(strStartIndex, out startIndex);
                    startIndex = start - startIndex;

                    short[] newDataBuffer = groupData.ToArray();
                    for (int i = 0; i < buff.Length; i++)
                    {
                        short svalue = 0;
                        short.TryParse(buff[i].ToString(), out svalue);
                        newDataBuffer[startIndex + i] = svalue;
                    }

                    string[] keys2 = readResult.Keys.Where(o => o.StartsWith(groupName) && o.Replace(String.Format("{0}", groupName), String.Empty).StartsWith("[")).OrderBy(c => c).ToArray<string>();
                    foreach (string key2 in keys2)
                    {

                        int begin = 0;
                        int end = 0;

                        string[] beginEnd = new string[2];

                        string tagName = key2.Replace(String.Format("{0}", groupName), String.Empty);
                        beginEnd[0] = tagName.Substring(1, tagName.IndexOf("]") - 1);
                        beginEnd[1] = tagName.Replace(",C1", String.Empty).Substring(tagName.IndexOf("L") + 1);

                        int.TryParse(beginEnd[0], out begin);
                        int.TryParse(beginEnd[1], out end);

                        end += begin - 1;

                        if ((start >= begin && start <= end) || ((start + buff.Length - 1) >= begin && (start + buff.Length - 1) <= end) || (begin > start && (start + buff.Length - 1) < end))
                        {
                            ItemDef itemData = this.readWriteGroup.Item(String.Format("[{0}]{1}", this.ChannelName, key2));
                            if (itemData == null)
                            {
                                Console.WriteLine(String.Format("写入失败：标签变量[{0}]未添加到数据读写组中!", String.Format("[{0}]{1}", this.ChannelName, key2)));
                                return false;
                            }
                            if (!(this.readResult[key2] is Array))
                            {
                                Console.WriteLine(String.Format("标签变量[{0}]的长度未指定!", String.Format("[{0}]{1}", this.ChannelName, key2)));
                                return false;
                            }
                            int len = (this.readResult[key2] as short[]).Length;
                            short[] tagDataBuff = new short[len];
                            Array.Copy(newDataBuffer, begin, tagDataBuff, 0, tagDataBuff.Length);
                            int res = this.readWriteGroup.Write(itemData, tagDataBuff);
                            if (HRESULTS.Failed(res))
                            {
                                string error = this.readWriteGroup.GetErrorString(res);
                                Console.WriteLine(String.Format("向标签变量[{0}]中写入值失败:{1}", String.Format("[{0}]{1}", this.ChannelName, key2), error));
                                return false;
                            }
                            else
                            {
                                Console.WriteLine("写入...");
                                return true;
                            }
                        }
                    }
                    #endregion

                    #endregion

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(this.Name + "写入失败:" + ex.Message);
                    return false;
                }
            }
        }

        public override void Close()
        {
            lock (this)
            {
                if (this.myOPCServer != null)
                {
                    if (this.asyncRefrGroup != null)
                    {
                        this.asyncRefrGroup.Dispose();
                    }
                    if (this.readWriteGroup != null)
                    {
                        this.readWriteGroup.Dispose();
                    }
                    this.myOPCServer.Disconnect();
                    System.Threading.Thread.Sleep(2000);
                    this.myOPCServer = null;
                }
            }
        }

        #region 辅助方法

        /// <summary>
        /// OPCServer数据更新事件处理方法
        /// </summary>
        /// <param name="sender">事件源，一般为标签组</param>
        /// <param name="e">事件参数</param>
        private void DataChangeHandler(object sender, OPCDA.NET.DataChangeEventArgs e)
        {
            OPCDA.NET.OPCItemState[] itemStates = e.sts;
            foreach (OPCDA.NET.OPCItemState itemState in itemStates)
            {
                OPCDA.NET.ItemDef itemDef = this.asyncRefrGroup.FindClientHandle(itemState.HandleClient);
                if (itemDef != null)
                {
                    this.readResult[itemDef.OpcIDef.ItemID.Replace(String.Format("[{0}]", this.ChannelName), String.Empty)] = itemState.DataValue;          //把最新数据放入读取结果中
                }
            }
        }

        /// <summary>
        /// 向数据读写组和数据刷新组中添加标签变量
        /// </summary>
        /// <param name="itemId">变量ID</param>
        /// <returns>成功返回0，失败返回-1</returns>
        private int Add2RefrGroup(string itemId)
        {
            if (AddItem(itemId) == 0)                                           //数据读写组
            {
                ItemDef itemData = this.readWriteGroup.Item(itemId);
                int res = this.asyncRefrGroup.Add(itemData.OpcIDef.ItemID);          //数据刷新组
                if (HRESULTS.Failed(res))
                {
                    Console.WriteLine(String.Format("向数据更新组中添加标签变量[{0}]失败，请检查OPCServer中有没有配置此标签!", itemId));
                    return -1;
                }
                return 0;
            }
            return -1;
        }
        /// <summary>
        /// 向数据读写组添加标签变量
        /// </summary>
        /// <param name="itemId">变量ID</param>
        /// <returns>成功返回0， 失败返回-1</returns>
        private int AddItem(string itemId)
        {
            ItemDef itemData = this.readWriteGroup.Item(itemId);
            if (itemData == null)
            {
                this.readWriteGroup.Add(itemId);
                itemData = this.readWriteGroup.Item(itemId);
                if (itemData == null)
                {
                    Console.WriteLine(String.Format("向数据读写组中添加标签变量[{0}]失败，请检查OPCServer中有没有配置此标签!", itemId));
                    return -1;
                }
            }
            return 0;
        }

        #endregion
    }
}