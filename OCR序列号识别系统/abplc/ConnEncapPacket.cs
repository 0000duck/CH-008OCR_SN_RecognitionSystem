using System;
using System.Linq;
using System.Text;
namespace DataAccess.EthernetIPFunc
{
	public class ConnEncapPacket
	{
		private CIPEncapCommands EncapHeaderCmd;
		private ushort EncapHeaderDataLength;
		private uint EncapHeaderSessionHandle;
		private CIPEncapStatus EncapHeaderStatus = CIPEncapStatus.Invalid_Session_Handle;
		private byte[] EncapHeaderSenderContent = new byte[8];
		private uint EncapHeaderOptions;
		private ushort DataSevReqSN = 0;
		public byte[] GetRegSessionHeadArray()
		{
			byte[] bytesResult = new byte[28];
			this.EncapHeaderCmd = CIPEncapCommands.REGISTERSESSION;
			this.EncapHeaderDataLength = 4;
			this.EncapHeaderSessionHandle = 0u;
			this.EncapHeaderStatus = CIPEncapStatus.Success;
			this.EncapHeaderOptions = 0u;
			BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderCmd)).CopyTo(bytesResult, 0);
			BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderDataLength)).CopyTo(bytesResult, 2);
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderSessionHandle)).CopyTo(bytesResult, 4);
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderStatus)).CopyTo(bytesResult, 8);
			for (int i = 0; i < 8; i++)
			{
				bytesResult[i + 12] = 0;
			}
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderOptions)).CopyTo(bytesResult, 20);
			ushort protocalVersion = 1;
			ushort optionsFlags = 0;
			BitConverter.GetBytes(Convert.ToUInt16(protocalVersion)).CopyTo(bytesResult, 24);
			BitConverter.GetBytes(Convert.ToUInt16(optionsFlags)).CopyTo(bytesResult, 26);
			return bytesResult;
		}
		public uint GetSessionHandle(byte[] srcRecvResult)
		{
			uint iResult = 0u;
			if (srcRecvResult != null)
			{
				if (srcRecvResult.Count<byte>() >= 28)
				{
					iResult = BitConverter.ToUInt32(srcRecvResult, 4);
				}
			}
			return iResult;
		}
		public byte[] GetFwdOpenReqBytes(uint srcSessionHandle)
		{
			byte[] bytesResult = new byte[90];
			this.EncapHeaderCmd = CIPEncapCommands.SEND_RRDATA;
			this.EncapHeaderDataLength = 66;
			this.EncapHeaderSessionHandle = srcSessionHandle;
			this.EncapHeaderStatus = CIPEncapStatus.Success;
			this.EncapHeaderOptions = 0u;
			BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderCmd)).CopyTo(bytesResult, 0);
			BitConverter.GetBytes(this.EncapHeaderDataLength).CopyTo(bytesResult, 2);
			BitConverter.GetBytes(this.EncapHeaderSessionHandle).CopyTo(bytesResult, 4);
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderStatus)).CopyTo(bytesResult, 8);
			for (int i = 0; i < 8; i++)
			{
				bytesResult[i + 12] = 0;
			}
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderOptions)).CopyTo(bytesResult, 20);
			byte[] FwdSpecDatas = this.FwdOpenReqCommandSpecificData();
			if (FwdSpecDatas != null)
			{
				if (FwdSpecDatas.Count<byte>() >= 16)
				{
					FwdSpecDatas.CopyTo(bytesResult, 24);
				}
			}
			byte[] FwdCIPDatas = this.FwdOpenReqCIPBytes();
			if (FwdCIPDatas != null)
			{
				if (FwdCIPDatas.Count<byte>() >= 48)
				{
					FwdCIPDatas.CopyTo(bytesResult, 40);
				}
			}
			return bytesResult;
		}
		private byte[] FwdOpenReqCommandSpecificData()
		{
			byte[] bResult = new byte[16];
			uint InterfaceHandle = 0u;
			ushort Timeout = 5;
			ushort ItemCount = 2;
			ushort AddrItemType = 0;
			ushort AddrItemLength = 0;
			ushort DataItemType = 178;
			ushort DataItemLength = 50;
			BitConverter.GetBytes(InterfaceHandle).CopyTo(bResult, 0);
			BitConverter.GetBytes(Timeout).CopyTo(bResult, 4);
			BitConverter.GetBytes(ItemCount).CopyTo(bResult, 6);
			BitConverter.GetBytes(AddrItemType).CopyTo(bResult, 8);
			BitConverter.GetBytes(AddrItemLength).CopyTo(bResult, 10);
			BitConverter.GetBytes(DataItemType).CopyTo(bResult, 12);
			BitConverter.GetBytes(DataItemLength).CopyTo(bResult, 14);
			return bResult;
		}
		private byte[] FwdOpenReqCIPBytes()
		{
			byte[] bResult = new byte[50];
			byte ServiceID = 84;
			byte ReqPathSize = 2;
			uint ReqPath = 19138080u;
			byte PriorityTime_tick = 7;
			byte Timeout_ticks = 20;
			uint O_T_ConnID = 1u;
			uint T_O_ConnID = 536870913u;
			Random a = new Random();
			ushort Connection_SN = Convert.ToUInt16(a.Next(65535));
			ushort Originator_VID = 21313;
			uint Originator_SN = 134480385u;
			byte Connection_TimeOut_Multiple = 2;
			byte Reserved = 0;
			byte Reserved2 = 0;
			byte Reserved3 = 0;
			uint O_T_RPI = 2000000u;
			ushort O_T_NetConnParam = 17396;
			uint T_O_RPI = 2000000u;
			ushort T_O_NetConnParam = 17396;
			byte TransportType = 163;
			byte ConnectionPathSize = 4;
			byte[] ConnectionPath = new byte[]
			{
				1,
				0,
				32,
				2,
				36,
				1
			};
			ushort SeqEndCmd = 300;
			bResult[0] = ServiceID;
			bResult[1] = ReqPathSize;
			BitConverter.GetBytes(ReqPath).CopyTo(bResult, 2);
			bResult[6] = PriorityTime_tick;
			bResult[7] = Timeout_ticks;
			BitConverter.GetBytes(O_T_ConnID).CopyTo(bResult, 8);
			BitConverter.GetBytes(T_O_ConnID).CopyTo(bResult, 12);
			BitConverter.GetBytes(Connection_SN).CopyTo(bResult, 16);
			BitConverter.GetBytes(Originator_VID).CopyTo(bResult, 18);
			BitConverter.GetBytes(Originator_SN).CopyTo(bResult, 20);
			bResult[24] = Connection_TimeOut_Multiple;
			bResult[25] = Reserved;
			bResult[26] = Reserved2;
			bResult[27] = Reserved3;
			BitConverter.GetBytes(O_T_RPI).CopyTo(bResult, 28);
			BitConverter.GetBytes(O_T_NetConnParam).CopyTo(bResult, 32);
			BitConverter.GetBytes(T_O_RPI).CopyTo(bResult, 34);
			BitConverter.GetBytes(T_O_NetConnParam).CopyTo(bResult, 38);
			bResult[40] = TransportType;
			bResult[41] = ConnectionPathSize;
			ConnectionPath.CopyTo(bResult, 42);
			BitConverter.GetBytes(SeqEndCmd).CopyTo(bResult, 48);
			return bResult;
		}
		public uint GetTONetWorkConnectionID(byte[] srcRecvBytes)
		{
			uint iResult = 0u;
			if (srcRecvBytes != null)
			{
				if (srcRecvBytes.Count<byte>() >= 48)
				{
					iResult = BitConverter.ToUInt32(srcRecvBytes, 44);
				}
			}
			return iResult;
		}
		public byte[] GetFwdCloseReqBytes(uint srcSessionHandle, uint srcToNetWorkConnectionID)
		{
			byte[] bytesResult = new byte[90];
			this.EncapHeaderCmd = CIPEncapCommands.SEND_RRDATA;
			this.EncapHeaderDataLength = 40;
			this.EncapHeaderSessionHandle = srcSessionHandle;
			this.EncapHeaderStatus = CIPEncapStatus.Success;
			this.EncapHeaderOptions = 0u;
			BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderCmd)).CopyTo(bytesResult, 0);
			BitConverter.GetBytes(this.EncapHeaderDataLength).CopyTo(bytesResult, 2);
			BitConverter.GetBytes(this.EncapHeaderSessionHandle).CopyTo(bytesResult, 4);
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderStatus)).CopyTo(bytesResult, 8);
			for (int i = 0; i < 8; i++)
			{
				bytesResult[i + 12] = 0;
			}
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderOptions)).CopyTo(bytesResult, 20);
			byte[] FwdCloseSpecDatas = this.FwdCloseReqCommandSpecificData();
			if (FwdCloseSpecDatas != null)
			{
				if (FwdCloseSpecDatas.Count<byte>() >= 16)
				{
					FwdCloseSpecDatas.CopyTo(bytesResult, 24);
				}
			}
			byte[] FwdCloseCIPDatas = this.FwdCloseReqCIPBytes(srcToNetWorkConnectionID);
			if (FwdCloseCIPDatas != null)
			{
				if (FwdCloseCIPDatas.Count<byte>() >= 24)
				{
					FwdCloseCIPDatas.CopyTo(bytesResult, 40);
				}
			}
			return bytesResult;
		}
		private byte[] FwdCloseReqCommandSpecificData()
		{
			byte[] bResult = new byte[16];
			uint InterfaceHandle = 0u;
			ushort Timeout = 5;
			ushort ItemCount = 2;
			ushort AddrItemType = 0;
			ushort AddrItemLength = 0;
			ushort DataItemType = 178;
			ushort DataItemLength = 24;
			BitConverter.GetBytes(InterfaceHandle).CopyTo(bResult, 0);
			BitConverter.GetBytes(Timeout).CopyTo(bResult, 4);
			BitConverter.GetBytes(ItemCount).CopyTo(bResult, 6);
			BitConverter.GetBytes(AddrItemType).CopyTo(bResult, 8);
			BitConverter.GetBytes(AddrItemLength).CopyTo(bResult, 10);
			BitConverter.GetBytes(DataItemType).CopyTo(bResult, 12);
			BitConverter.GetBytes(DataItemLength).CopyTo(bResult, 14);
			return bResult;
		}
		private byte[] FwdCloseReqCIPBytes(uint srcToNetWorkConnectionID)
		{
			byte[] bResult = new byte[24];
			byte ServiceID = 78;
			byte ReqPathSize = 2;
			uint ReqPath = 19138080u;
			byte PriorityTime_tick = 7;
			byte Timeout_ticks = 20;
			ushort Connection_SN = 0;
			ushort Originator_VID = 21313;
			byte ConnectionPathSize = 3;
			byte Reserved = 0;
			byte[] ConnectionPath = new byte[]
			{
				1,
				0,
				32,
				2,
				36,
				1
			};
			bResult[0] = ServiceID;
			bResult[1] = ReqPathSize;
			BitConverter.GetBytes(ReqPath).CopyTo(bResult, 2);
			bResult[6] = PriorityTime_tick;
			bResult[7] = Timeout_ticks;
			BitConverter.GetBytes(Connection_SN).CopyTo(bResult, 8);
			BitConverter.GetBytes(Originator_VID).CopyTo(bResult, 10);
			BitConverter.GetBytes(srcToNetWorkConnectionID).CopyTo(bResult, 12);
			bResult[16] = ConnectionPathSize;
			bResult[17] = Reserved;
			ConnectionPath.CopyTo(bResult, 18);
			return bResult;
		}
		public byte[] GetUnloadRegSessionHeadArray()
		{
			byte[] bytesResult = new byte[28];
			this.EncapHeaderCmd = CIPEncapCommands.UNREGISTERSESSION;
			this.EncapHeaderDataLength = 4;
			this.EncapHeaderSessionHandle = 0u;
			this.EncapHeaderStatus = CIPEncapStatus.Success;
			this.EncapHeaderOptions = 0u;
			BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderCmd)).CopyTo(bytesResult, 0);
			BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderDataLength)).CopyTo(bytesResult, 2);
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderSessionHandle)).CopyTo(bytesResult, 4);
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderStatus)).CopyTo(bytesResult, 8);
			for (int i = 0; i < 8; i++)
			{
				bytesResult[i + 12] = 0;
			}
			BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderOptions)).CopyTo(bytesResult, 20);
			ushort protocalVersion = 1;
			ushort optionsFlags = 0;
			BitConverter.GetBytes(Convert.ToUInt16(protocalVersion)).CopyTo(bytesResult, 24);
			BitConverter.GetBytes(Convert.ToUInt16(optionsFlags)).CopyTo(bytesResult, 26);
			return bytesResult;
		}
		public byte[] GetReadDataReqBytes(uint srcSessionHandle, uint srcToNetWorkConnectionID, MTagNameInfo[] srcTagNames)
		{
			int cipOffSet = 0;
			byte[] bytesReadReqCmdCIP = this.ReadDataReqCommandCIPBytes(srcToNetWorkConnectionID, srcTagNames);
			byte[] bytesResult = new byte[1024];
			if (bytesReadReqCmdCIP != null)
			{
				cipOffSet = bytesReadReqCmdCIP.Count<byte>();
				if (cipOffSet > 0)
				{
					this.EncapHeaderCmd = CIPEncapCommands.SEND_UNITDATA;
					this.EncapHeaderDataLength = Convert.ToUInt16(cipOffSet);
					this.EncapHeaderSessionHandle = srcSessionHandle;
					this.EncapHeaderStatus = CIPEncapStatus.Success;
					this.EncapHeaderOptions = 0u;
					BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderCmd)).CopyTo(bytesResult, 0);
					BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderDataLength)).CopyTo(bytesResult, 2);
					BitConverter.GetBytes(this.EncapHeaderSessionHandle).CopyTo(bytesResult, 4);
					BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderStatus)).CopyTo(bytesResult, 8);
					for (int i = 0; i < 8; i++)
					{
						bytesResult[i + 12] = 0;
					}
					BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderOptions)).CopyTo(bytesResult, 20);
					Array.Copy(bytesReadReqCmdCIP, 0, bytesResult, 24, cipOffSet);
				}
			}
			byte[] bResult = new byte[24 + cipOffSet];
			Array.Copy(bytesResult, 0, bResult, 0, 24 + cipOffSet);
			return bResult;
		}
		private byte[] ReadDataReqCommandCIPBytes(uint srcToNetWorkConnectionID, MTagNameInfo[] tagNames)
		{
			byte[] bResult = null;
			if (tagNames != null)
			{
				ushort SevTagNum = Convert.ToUInt16(tagNames.Count<MTagNameInfo>());
				ushort[] sevOffSetValues = this.CalcOffSetValue(tagNames);
				if (sevOffSetValues != null)
				{
					if (sevOffSetValues.Count<ushort>() == (int)SevTagNum)
					{
						byte[] bTempResult = new byte[1024];
						int offset = 0;
						uint InterfaceHandle = 0u;
						ushort Timeout = 0;
						ushort ItemCount = 2;
						ushort ConnAddrItemType = 161;
						ushort ConnAddrItemLength = 4;
						ushort DataItemType = 177;
						if (this.DataSevReqSN >= 65530)
						{
							this.DataSevReqSN = 0;
						}
						this.DataSevReqSN += 1;
						BitConverter.GetBytes(InterfaceHandle).CopyTo(bTempResult, 0);
						BitConverter.GetBytes(Timeout).CopyTo(bTempResult, 4);
						BitConverter.GetBytes(ItemCount).CopyTo(bTempResult, 6);
						BitConverter.GetBytes(ConnAddrItemType).CopyTo(bTempResult, 8);
						BitConverter.GetBytes(ConnAddrItemLength).CopyTo(bTempResult, 10);
						BitConverter.GetBytes(srcToNetWorkConnectionID).CopyTo(bTempResult, 12);
						BitConverter.GetBytes(DataItemType).CopyTo(bTempResult, 16);
						BitConverter.GetBytes(this.DataSevReqSN).CopyTo(bTempResult, 20);
						offset += 22;
						byte ServiceID = 10;
						byte ReqPathSize = 2;
						uint ReqPath = 19137056u;
						bTempResult[offset] = ServiceID;
						offset++;
						bTempResult[offset] = ReqPathSize;
						offset++;
						BitConverter.GetBytes(ReqPath).CopyTo(bTempResult, offset);
						offset += 4;
						BitConverter.GetBytes(SevTagNum).CopyTo(bTempResult, offset);
						offset += 2;
						for (int i = 0; i < (int)SevTagNum; i++)
						{
							BitConverter.GetBytes(sevOffSetValues[i]).CopyTo(bTempResult, offset);
							offset += 2;
						}
						for (int i = 0; i < (int)SevTagNum; i++)
						{
							byte SevFlag = 76;
							bTempResult[offset] = SevFlag;
							offset++;
							string tagName = tagNames[i].F_TagName.Trim();
							if (!tagName.Contains('.'))
							{
								byte sevReqPathLength = Convert.ToByte((tagNames[i].F_TagName.Length + 1) / 2 + 1);
								byte ExpSymbol = 145;
								byte[] TagNameBytes = Encoding.Default.GetBytes(tagNames[i].F_TagName);
								byte TagNameLength = Convert.ToByte(TagNameBytes.Count<byte>());
								ushort SevCmdEndValue = 1;
								bTempResult[offset] = sevReqPathLength;
								offset++;
								bTempResult[offset] = ExpSymbol;
								offset++;
								bTempResult[offset] = TagNameLength;
								offset++;
								TagNameBytes.CopyTo(bTempResult, offset);
								offset += TagNameBytes.Count<byte>();
								if (TagNameLength % 2 != 0)
								{
									bTempResult[offset] = 0;
									offset++;
								}
								BitConverter.GetBytes(SevCmdEndValue).CopyTo(bTempResult, offset);
								offset += 2;
							}
							else
							{
								string[] tagSplitNames = tagName.Split(new char[]
								{
									'.'
								});
								if (tagSplitNames.Count<string>() == 2)
								{
									int tagTotalLen = 0;
									int sevReqPathLenBytesAddr = offset;
									offset++;
									for (int j = 0; j < 2; j++)
									{
										string tagSplitName = tagSplitNames[j];
										byte ExpSymbol = 145;
										byte[] TagSplitNameBytes = Encoding.Default.GetBytes(tagSplitName);
										byte TagSplitNameLength = Convert.ToByte(TagSplitNameBytes.Count<byte>());
										bTempResult[offset] = ExpSymbol;
										offset++;
										bTempResult[offset] = TagSplitNameLength;
										offset++;
										TagSplitNameBytes.CopyTo(bTempResult, offset);
										offset += TagSplitNameBytes.Count<byte>();
										if (TagSplitNameLength % 2 != 0)
										{
											bTempResult[offset] = 0;
											offset++;
											tagTotalLen += (int)(TagSplitNameLength + 1);
										}
										else
										{
											tagTotalLen += (int)TagSplitNameLength;
										}
									}
									byte sevReqPathLength = Convert.ToByte((tagTotalLen + 3) / 2 + 1);
									bTempResult[sevReqPathLenBytesAddr] = sevReqPathLength;
									ushort SevCmdEndValue = Convert.ToUInt16(tagNames[i].F_ValueNum);
									BitConverter.GetBytes(SevCmdEndValue).CopyTo(bTempResult, offset);
									offset += 2;
								}
							}
						}
						ushort BackBytesLength = Convert.ToUInt16(offset - 20);
						BitConverter.GetBytes(BackBytesLength).CopyTo(bTempResult, 18);
						bResult = new byte[offset];
						Array.Copy(bTempResult, 0, bResult, 0, offset);
					}
				}
			}
			return bResult;
		}
		private ushort[] CalcOffSetValue(MTagNameInfo[] tagNames)
		{
			ushort[] offSets = null;
			if (tagNames != null)
			{
				if (tagNames.Count<MTagNameInfo>() > 0)
				{
					int tagNum = tagNames.Count<MTagNameInfo>();
					ushort sevOffSet = 0;
					sevOffSet += Convert.ToUInt16(2 + 2 * tagNum);
					offSets = new ushort[tagNum];
					for (int i = 0; i < tagNum; i++)
					{
						offSets[i] = sevOffSet;
						string tagName = tagNames[i].F_TagName;
						if (tagName.Trim() != "")
						{
							if (!tagName.Contains('.'))
							{
								sevOffSet += 4;
								byte[] tagNameBytes = Encoding.Default.GetBytes(tagName);
								ushort tagNameLength = Convert.ToUInt16(tagNameBytes.Count<byte>());
								if (tagNameLength % 2 != 0)
								{
									sevOffSet += Convert.ToUInt16((int)(tagNameLength + 1));
								}
								else
								{
									sevOffSet += tagNameLength;
								}
								sevOffSet += 2;
							}
							else
							{
								sevOffSet += 2;
								string[] tagSplitNames = tagName.Split(new char[]
								{
									'.'
								});
								if (tagSplitNames.Count<string>() == 2)
								{
									for (int j = 0; j < 2; j++)
									{
										sevOffSet += 2;
										string tagSplitName = tagSplitNames[j];
										byte[] TagSplitNameBytes = Encoding.Default.GetBytes(tagSplitName);
										ushort TagSplitNameLength = Convert.ToUInt16(TagSplitNameBytes.Count<byte>());
										if (TagSplitNameLength % 2 != 0)
										{
											sevOffSet += Convert.ToUInt16((int)(TagSplitNameLength + 1));
										}
										else
										{
											sevOffSet += TagSplitNameLength;
										}
									}
									sevOffSet += 2;
								}
							}
						}
					}
				}
				else
				{
					offSets = null;
				}
			}
			return offSets;
		}
		public byte[] GetReadDataReqBytes(uint srcSessionHandle, uint srcToNetWorkConnectionID, string tagName, int eleNums)
		{
			int cipOffSet = 0;
			byte[] bytesReadReqCmdCIP = this.ReadDataReqCommandCIPBytes(srcToNetWorkConnectionID, tagName, eleNums);
			byte[] bytesResult = new byte[1024];
			if (bytesReadReqCmdCIP != null)
			{
				cipOffSet = bytesReadReqCmdCIP.Count<byte>();
				if (cipOffSet > 0)
				{
					this.EncapHeaderCmd = CIPEncapCommands.SEND_UNITDATA;
					this.EncapHeaderDataLength = Convert.ToUInt16(cipOffSet);
					this.EncapHeaderSessionHandle = srcSessionHandle;
					this.EncapHeaderStatus = CIPEncapStatus.Success;
					this.EncapHeaderOptions = 0u;
					BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderCmd)).CopyTo(bytesResult, 0);
					BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderDataLength)).CopyTo(bytesResult, 2);
					BitConverter.GetBytes(this.EncapHeaderSessionHandle).CopyTo(bytesResult, 4);
					BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderStatus)).CopyTo(bytesResult, 8);
					for (int i = 0; i < 8; i++)
					{
						bytesResult[i + 12] = 0;
					}
					BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderOptions)).CopyTo(bytesResult, 20);
					Array.Copy(bytesReadReqCmdCIP, 0, bytesResult, 24, cipOffSet);
				}
			}
			byte[] bResult = new byte[24 + cipOffSet];
			Array.Copy(bytesResult, 0, bResult, 0, 24 + cipOffSet);
			return bResult;
		}
		private byte[] ReadDataReqCommandCIPBytes(uint srcToNetWorkConnectionID, string tagName, int eleNums)
		{
			byte[] bResult = null;
			if (tagName != null)
			{
				byte[] bTempResult = new byte[1024];
				int offset = 0;
				uint InterfaceHandle = 0u;
				ushort Timeout = 0;
				ushort ItemCount = 2;
				ushort ConnAddrItemType = 161;
				ushort ConnAddrItemLength = 4;
				ushort DataItemType = 177;
				if (this.DataSevReqSN >= 65530)
				{
					this.DataSevReqSN = 0;
				}
				this.DataSevReqSN += 1;
				BitConverter.GetBytes(InterfaceHandle).CopyTo(bTempResult, 0);
				BitConverter.GetBytes(Timeout).CopyTo(bTempResult, 4);
				BitConverter.GetBytes(ItemCount).CopyTo(bTempResult, 6);
				BitConverter.GetBytes(ConnAddrItemType).CopyTo(bTempResult, 8);
				BitConverter.GetBytes(ConnAddrItemLength).CopyTo(bTempResult, 10);
				BitConverter.GetBytes(srcToNetWorkConnectionID).CopyTo(bTempResult, 12);
				BitConverter.GetBytes(DataItemType).CopyTo(bTempResult, 16);
				BitConverter.GetBytes(this.DataSevReqSN).CopyTo(bTempResult, 20);
				offset += 22;
				byte SevFlag = 82;
				bTempResult[offset] = SevFlag;
				offset++;
				if (!tagName.Contains('.'))
				{
					byte sevReqPathLength = Convert.ToByte((tagName.Length + 1) / 2 + 1);
					byte ExpSymbol = 145;
					byte[] TagNameBytes = Encoding.Default.GetBytes(tagName);
					byte TagNameLength = Convert.ToByte(TagNameBytes.Count<byte>());
					ushort SevCmdEndValue = Convert.ToUInt16(eleNums);
					bTempResult[offset] = sevReqPathLength;
					offset++;
					bTempResult[offset] = ExpSymbol;
					offset++;
					bTempResult[offset] = TagNameLength;
					offset++;
					TagNameBytes.CopyTo(bTempResult, offset);
					offset += TagNameBytes.Count<byte>();
					if (TagNameLength % 2 != 0)
					{
						bTempResult[offset] = 0;
						offset++;
					}
					BitConverter.GetBytes(SevCmdEndValue).CopyTo(bTempResult, offset);
					offset += 2;
				}
				else
				{
					string[] tagSplitNames = tagName.Split(new char[]
					{
						'.'
					});
					if (tagSplitNames.Count<string>() == 2)
					{
						int tagTotalLen = 0;
						int sevReqPathLenBytesAddr = offset;
						offset++;
						for (int i = 0; i < 2; i++)
						{
							string tagSplitName = tagSplitNames[i];
							byte ExpSymbol = 145;
							byte[] TagSplitNameBytes = Encoding.Default.GetBytes(tagSplitName);
							byte TagSplitNameLength = Convert.ToByte(TagSplitNameBytes.Count<byte>());
							bTempResult[offset] = ExpSymbol;
							offset++;
							bTempResult[offset] = TagSplitNameLength;
							offset++;
							TagSplitNameBytes.CopyTo(bTempResult, offset);
							offset += TagSplitNameBytes.Count<byte>();
							if (TagSplitNameLength % 2 != 0)
							{
								bTempResult[offset] = 0;
								offset++;
								tagTotalLen += (int)(TagSplitNameLength + 1);
							}
							else
							{
								tagTotalLen += (int)TagSplitNameLength;
							}
						}
						byte sevReqPathLength = Convert.ToByte((tagTotalLen + 3) / 2 + 1);
						bTempResult[sevReqPathLenBytesAddr] = sevReqPathLength;
						ushort SevCmdEndValue = Convert.ToUInt16(eleNums);
						BitConverter.GetBytes(SevCmdEndValue).CopyTo(bTempResult, offset);
						offset += 2;
					}
				}
				ushort Reserve = 0;
				ushort Reserve2 = 0;
				BitConverter.GetBytes(Reserve).CopyTo(bTempResult, offset);
				offset += 2;
				BitConverter.GetBytes(Reserve2).CopyTo(bTempResult, offset);
				offset += 2;
				ushort BackBytesLength = Convert.ToUInt16(offset - 20);
				BitConverter.GetBytes(BackBytesLength).CopyTo(bTempResult, 18);
				bResult = new byte[offset];
				Array.Copy(bTempResult, 0, bResult, 0, offset);
			}
			return bResult;
		}
		public byte[] WriteDataReqCommandCIPBytes(uint srcToNetWorkConnectionID, string tagName, int eleNums, WriteDataType datatype)
		{
			byte[] bResult = null;
			byte[] result;
			if (tagName != null)
			{
				byte[] bTempResult = new byte[1024];
				int offset = 0;
				uint InterfaceHandle = 0u;
				ushort Timeout = 1;
				ushort ItemCount = 2;
				ushort ConnAddrItemType = 161;
				ushort ConnAddrItemLength = 4;
				ushort DataItemType = 177;
				BitConverter.GetBytes(InterfaceHandle).CopyTo(bTempResult, 0);
				BitConverter.GetBytes(Timeout).CopyTo(bTempResult, 4);
				BitConverter.GetBytes(ItemCount).CopyTo(bTempResult, 6);
				BitConverter.GetBytes(ConnAddrItemType).CopyTo(bTempResult, 8);
				BitConverter.GetBytes(ConnAddrItemLength).CopyTo(bTempResult, 10);
				BitConverter.GetBytes(srcToNetWorkConnectionID).CopyTo(bTempResult, 12);
				BitConverter.GetBytes(DataItemType).CopyTo(bTempResult, 16);
				offset += 22;
				byte SevFlag = 77;
				bTempResult[offset] = SevFlag;
				offset++;
				if (!tagName.Contains('.'))
				{
					byte sevReqPathLength = Convert.ToByte((tagName.Length + 1) / 2 + 1);
					byte ExpSymbol = 145;
					byte[] TagNameBytes = Encoding.Default.GetBytes(tagName);
					byte TagNameLength = Convert.ToByte(TagNameBytes.Count<byte>());
					bTempResult[offset] = sevReqPathLength;
					offset++;
					bTempResult[offset] = ExpSymbol;
					offset++;
					bTempResult[offset] = TagNameLength;
					offset++;
					TagNameBytes.CopyTo(bTempResult, offset);
					offset += TagNameBytes.Count<byte>();
					if (TagNameLength % 2 != 0)
					{
						bTempResult[offset] = 0;
						offset++;
					}
				}
				else
				{
					string[] tagSplitNames = tagName.Split(new char[]
					{
						'.'
					});
					if (tagSplitNames.Count<string>() == 2)
					{
						int tagTotalLen = 0;
						int sevReqPathLenBytesAddr = offset;
						offset++;
						for (int i = 0; i < 2; i++)
						{
							string tagSplitName = tagSplitNames[i];
							byte ExpSymbol = 145;
							byte[] TagSplitNameBytes = Encoding.Default.GetBytes(tagSplitName);
							byte TagSplitNameLength = Convert.ToByte(TagSplitNameBytes.Count<byte>());
							bTempResult[offset] = ExpSymbol;
							offset++;
							bTempResult[offset] = TagSplitNameLength;
							offset++;
							TagSplitNameBytes.CopyTo(bTempResult, offset);
							offset += TagSplitNameBytes.Count<byte>();
							if (TagSplitNameLength % 2 != 0)
							{
								bTempResult[offset] = 0;
								offset++;
								tagTotalLen += (int)(TagSplitNameLength + 1);
							}
							else
							{
								tagTotalLen += (int)TagSplitNameLength;
							}
						}
						byte sevReqPathLength = Convert.ToByte((tagTotalLen + 3) / 2 + 1);
						bTempResult[sevReqPathLenBytesAddr] = sevReqPathLength;
					}
				}
				BitConverter.GetBytes((ushort)datatype).CopyTo(bTempResult, offset);
				offset += 2;
				ushort SevCmdEndValue = Convert.ToUInt16(eleNums);
				BitConverter.GetBytes(SevCmdEndValue).CopyTo(bTempResult, offset);
				offset += 2;
				bResult = new byte[offset];
				Array.Copy(bTempResult, 0, bResult, 0, offset);
				result = bResult;
			}
			else
			{
				result = bResult;
			}
			return result;
		}
		public byte[] GetWriteDataSendDatasBytes(byte[] sendData, bool IsSigle, byte[] perPare, int behidenum)
		{
			int offset = 0;
			byte[] bTempResult = new byte[1024];
			if (perPare != null)
			{
				Array.Copy(perPare, 0, bTempResult, 0, perPare.Count<byte>());
				offset += perPare.Count<byte>();
				if (!IsSigle)
				{
					ushort Reserve2 = 0;
					BitConverter.GetBytes(behidenum).CopyTo(bTempResult, offset);
					offset += 2;
					BitConverter.GetBytes(Reserve2).CopyTo(bTempResult, offset);
					offset += 2;
					Array.Copy(sendData, 0, bTempResult, offset, sendData.Count<byte>());
					offset += sendData.Count<byte>();
					bTempResult[22] = 83;
				}
				else
				{
					Array.Copy(sendData, 0, bTempResult, offset, sendData.Count<byte>());
					offset += sendData.Count<byte>();
					bTempResult[22] = 77;
				}
				int BackBytesLength = (int)Convert.ToUInt16(offset - 20);
				BitConverter.GetBytes(BackBytesLength).CopyTo(bTempResult, 18);
				if (this.DataSevReqSN >= 65530)
				{
					this.DataSevReqSN = 0;
				}
				this.DataSevReqSN += 1;
				BitConverter.GetBytes(this.DataSevReqSN).CopyTo(bTempResult, 20);
			}
			byte[] bResult = new byte[offset];
			Array.Copy(bTempResult, 0, bResult, 0, offset);
			return bResult;
		}
		public byte[] GetWriteDataReqBytes(uint srcSessionHandle, byte[] sendData, byte[] perPare, bool IsSigle, int behidenum)
		{
			int cipOffSet = 0;
			byte[] bytesSendDatas = this.GetWriteDataSendDatasBytes(sendData, IsSigle, perPare, behidenum);
			byte[] bytesResult = new byte[1024];
			if (bytesSendDatas != null)
			{
				cipOffSet = bytesSendDatas.Count<byte>();
				if (cipOffSet > 0)
				{
					this.EncapHeaderCmd = CIPEncapCommands.SEND_UNITDATA;
					this.EncapHeaderDataLength = Convert.ToUInt16(cipOffSet);
					this.EncapHeaderSessionHandle = srcSessionHandle;
					this.EncapHeaderStatus = CIPEncapStatus.Success;
					this.EncapHeaderOptions = 0u;
					BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderCmd)).CopyTo(bytesResult, 0);
					BitConverter.GetBytes(Convert.ToUInt16(this.EncapHeaderDataLength)).CopyTo(bytesResult, 2);
					BitConverter.GetBytes(this.EncapHeaderSessionHandle).CopyTo(bytesResult, 4);
					BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderStatus)).CopyTo(bytesResult, 8);
					for (int i = 0; i < 8; i++)
					{
						bytesResult[i + 12] = 0;
					}
					BitConverter.GetBytes(Convert.ToUInt32(this.EncapHeaderOptions)).CopyTo(bytesResult, 20);
					Array.Copy(bytesSendDatas, 0, bytesResult, 24, cipOffSet);
				}
			}
			byte[] bResult = new byte[24 + cipOffSet];
			Array.Copy(bytesResult, 0, bResult, 0, 24 + cipOffSet);
			return bResult;
		}
	}
}
