using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace DataAccess.EthernetIPFunc
{
	public class EthernetIPClient
	{
		private string f_serverip;
		private int f_serverport;
		private bool f_eipisconnected = false;
		private int f_connecttimeout = 1000;
		private int f_connectCnt = 1;
		private int f_sleep = 50;
		private ushort f_prioritylevel = 0;
		private uint sessionHandle = 0u;
		private uint toNetWorkConnectionID = 0u;
		private string f_tagname = "";
		private int f_elemnums = 0;
		public byte[] galRecvBytesResult = null;
		private byte[] galRecvBytesMidResult = new byte[65535];
		private int galRecvBytesNum = 0;
		private int galSendBytesNum = 0;
		private ConnEncapPacket connEnPacket = new ConnEncapPacket();
		private Socket f_socket;
		private byte[] tcpAsyReadBuffer = new byte[1024];
		private byte[] tcpAsyWriteBuffer = new byte[0];
		public Socket F_Socket
		{
			get
			{
				return this.f_socket;
			}
			set
			{
				this.f_socket = value;
			}
		}
		public string F_ServerIP
		{
			get
			{
				return this.f_serverip;
			}
			set
			{
				this.f_serverip = value;
			}
		}
		public int F_ServerPort
		{
			get
			{
				return this.f_serverport;
			}
			set
			{
				this.f_serverport = value;
			}
		}
		public ushort F_PriorityLevel
		{
			set
			{
				this.f_prioritylevel = value;
			}
		}
		public bool F_EIPIsConnected
		{
			get
			{
				return this.f_eipisconnected;
			}
			set
			{
				this.f_eipisconnected = value;
			}
		}
		public EthernetIPClient(string ip, int port)
		{
			this.f_serverip = ip;
			this.f_serverport = port;
		}
		~EthernetIPClient()
		{
			this.Dispose();
		}
		public void Dispose()
		{
			try
			{
				if (this.f_socket != null && this.f_socket.Connected)
				{
					this.f_socket.Shutdown(SocketShutdown.Both);
					Thread.Sleep(10);
					this.f_socket.Close();
				}
			}
			catch
			{
				this.f_eipisconnected = false;
			}
			this.f_eipisconnected = false;
		}
		private void ClientExceptionHandle()
		{
			this.Dispose();
			this.f_eipisconnected = false;
		}
		public bool StartClient()
		{
			this.Dispose();
			bool result;
			if (this.f_serverip != null)
			{
				try
				{
					this.f_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					this.f_socket.ReceiveTimeout = 2000;
					this.f_socket.SendTimeout = 2000;
					IAsyncResult waitConnect = this.f_socket.BeginConnect(IPAddress.Parse(this.f_serverip), this.f_serverport, new AsyncCallback(this.ConnectCallBack), null);
					if (waitConnect.AsyncWaitHandle.WaitOne(this.f_connecttimeout, false))
					{
						result = this.f_socket.Connected;
						return result;
					}
				}
				catch (Exception e)
				{
					string saveMsg = e.ToString();
					this.ClientExceptionHandle();
				}
			}
			result = false;
			return result;
		}
		private void ConnectCallBack(IAsyncResult iar)
		{
			if (this.f_socket != null)
			{
				try
				{
					this.f_socket.EndConnect(iar);
				}
				catch (Exception e)
				{
					string saveMsg = e.ToString();
					this.ClientExceptionHandle();
				}
			}
		}
		public bool SendTagName(string srcTagName, int srcElemNums, bool hasString = true)
		{
			int sendCnt = 0;
			bool result;
			while (true)
			{
				Thread.Sleep(this.f_sleep);
				if (this.f_socket == null)
				{
					break;
				}
				if (!this.f_socket.Connected)
				{
					break;
				}
				this.f_tagname = srcTagName;
				this.f_elemnums = srcElemNums;
				byte[] bytesSend = this.connEnPacket.GetReadDataReqBytes(this.sessionHandle, this.toNetWorkConnectionID, this.f_tagname, this.f_elemnums);
				if (bytesSend != null)
				{
					try
					{
						this.f_socket.Send(bytesSend, bytesSend.Length, SocketFlags.None);
						Array.Clear(this.tcpAsyReadBuffer, 0, this.tcpAsyReadBuffer.Length);
						int countRecv = this.f_socket.Receive(this.tcpAsyReadBuffer, this.tcpAsyReadBuffer.Length, SocketFlags.None);
						bool readAll = false;
						while (!readAll)
						{
							readAll = true;
							if (countRecv > 0)
							{
                                //if (this.tcpAsyReadBuffer[0] == 112)
                                //{
                                //	short cutSize;
                                //	if (!srcTagName.Contains('.'))
                                //	{
                                //		cutSize = 54;
                                //	}
                                //	else
                                //	{
                                //		cutSize = 52;
                                //	}
                                //	if (countRecv >= 54)
                                //	{
                                //		short tzValue = BitConverter.ToInt16(this.tcpAsyReadBuffer, 46);
                                //		short tzStatusValue = BitConverter.ToInt16(this.tcpAsyReadBuffer, 48);
                                //		short tzDataTypeValue = BitConverter.ToInt16(this.tcpAsyReadBuffer, 50);
                                //		if (tzValue == 210)
                                //		{
                                //			if (tzStatusValue == 0)
                                //			{
                                //				Array.Copy(this.tcpAsyReadBuffer, (int)cutSize, this.galRecvBytesMidResult, this.galRecvBytesNum, countRecv - (int)cutSize);
                                //				this.galRecvBytesNum += countRecv - (int)cutSize;
                                //				this.galRecvBytesResult = new byte[this.galRecvBytesNum];
                                //				Array.Copy(this.galRecvBytesMidResult, 0, this.galRecvBytesResult, 0, this.galRecvBytesNum);
                                //				this.galRecvBytesNum = 0;
                                //				result = true;
                                //				return result;
                                //			}
                                //			if (tzStatusValue == 6)
                                //			{
                                //				byte[] sendReadBytes = this.connEnPacket.GetReadDataReqBytes(this.sessionHandle, this.toNetWorkConnectionID, this.f_tagname, this.f_elemnums);
                                //				short fisrtSendBytesLength = Convert.ToInt16(sendReadBytes.Count<byte>());
                                //				short secdStartBytesIndex = Convert.ToInt16(this.galRecvBytesNum + countRecv - (int)cutSize);
                                //				BitConverter.GetBytes(secdStartBytesIndex).CopyTo(sendReadBytes, (int)(fisrtSendBytesLength - 4));
                                //				Array.Copy(this.tcpAsyReadBuffer, (int)cutSize, this.galRecvBytesMidResult, this.galRecvBytesNum, countRecv - (int)cutSize);
                                //				this.galRecvBytesNum += countRecv - (int)cutSize;
                                //				this.f_socket.Send(sendReadBytes, sendReadBytes.Length, SocketFlags.None);
                                //				Array.Clear(this.tcpAsyReadBuffer, 0, this.tcpAsyReadBuffer.Length);
                                //				countRecv = this.f_socket.Receive(this.tcpAsyReadBuffer, this.tcpAsyReadBuffer.Length, SocketFlags.None);
                                //				readAll = false;
                                //			}
                                //		}
                                //	}
                                //}

                                //接受字节结果处理
                                if (tcpAsyReadBuffer[0] == 112)    //0x70
                                {
                                    Int16 tzValue = 0;
                                    Int16 tzStatusValue = 0;
                                    Int16 tzDataTypeValue = 0;
                                    Int16 cutSize = 0;
                                    if (hasString)
                                        cutSize = 54;
                                    else cutSize = 52;
                                    if (countRecv >= cutSize)
                                    {
                                        tzValue = BitConverter.ToInt16(tcpAsyReadBuffer, 46);
                                        tzStatusValue = BitConverter.ToInt16(tcpAsyReadBuffer, 48);
                                        tzDataTypeValue = BitConverter.ToInt16(tcpAsyReadBuffer, 50);
                                        if (tzValue == 210)
                                        {
                                            if (tzStatusValue == 0)
                                            {
                                                Array.Copy(tcpAsyReadBuffer, cutSize, galRecvBytesMidResult, galRecvBytesNum, countRecv - cutSize);
                                                galRecvBytesNum += countRecv - cutSize;
                                                galRecvBytesResult = new byte[galRecvBytesNum];
                                                Array.Copy(galRecvBytesMidResult, 0, galRecvBytesResult, 0, galRecvBytesNum);
                                                galRecvBytesNum = 0;
                                               
                                                return true;  //读取成功
                                            }
                                            else if (tzStatusValue == 6)
                                            {
                                                byte[] sendReadBytes = connEnPacket.GetReadDataReqBytes(sessionHandle, toNetWorkConnectionID, f_tagname, f_elemnums);

                                                Int16 fisrtSendBytesLength = Convert.ToInt16(sendReadBytes.Count());
                                                Int16 secdStartBytesIndex = Convert.ToInt16(galRecvBytesNum + countRecv - cutSize);
                                                BitConverter.GetBytes(secdStartBytesIndex).CopyTo(sendReadBytes, fisrtSendBytesLength - 4);

                                                Array.Copy(tcpAsyReadBuffer, cutSize, galRecvBytesMidResult, galRecvBytesNum, countRecv - cutSize);
                                                galRecvBytesNum += countRecv - cutSize;

                                                f_socket.Send(sendReadBytes, sendReadBytes.Length, SocketFlags.None);
                                                Array.Clear(tcpAsyReadBuffer, 0, tcpAsyReadBuffer.Length);
                                                countRecv = f_socket.Receive(tcpAsyReadBuffer, tcpAsyReadBuffer.Length, 0);
                                                readAll = false;

                                            }
                                        }
                                    }
                                }
                            }
						}
					}
					catch
					{
					}
				}
				if (sendCnt >= this.f_connectCnt)
				{
					break;
				}
				sendCnt++;
			}
			result = false;
			return result;
		}
		public bool SendSession()
		{
			int sendCnt = 0;
			bool result;
			while (true)
			{
				Thread.Sleep(this.f_sleep);
				if (this.f_socket == null)
				{
					break;
				}
				if (!this.f_socket.Connected)
				{
					break;
				}
				if (this.f_eipisconnected)
				{
					break;
				}
				byte[] byteSend = this.connEnPacket.GetRegSessionHeadArray();
				if (byteSend != null)
				{
					try
					{
						this.f_socket.Send(byteSend, byteSend.Length, SocketFlags.None);
						Array.Clear(this.tcpAsyReadBuffer, 0, this.tcpAsyReadBuffer.Length);
						int countRecv = this.f_socket.Receive(this.tcpAsyReadBuffer, this.tcpAsyReadBuffer.Length, SocketFlags.None);
						if (this.tcpAsyReadBuffer[0] == 101)
						{
							if (countRecv == 28)
							{
								this.sessionHandle = this.connEnPacket.GetSessionHandle(this.tcpAsyReadBuffer);
								result = true;
								return result;
							}
						}
					}
					catch
					{
					}
				}
				if (sendCnt >= this.f_connectCnt)
				{
					break;
				}
				sendCnt++;
			}
			result = false;
			return result;
		}
		public bool SendFwdOpen()
		{
			int sendCnt = 0;
			bool result;
			while (true)
			{
				Thread.Sleep(this.f_sleep);
				if (this.f_socket == null)
				{
					break;
				}
				if (!this.f_socket.Connected)
				{
					break;
				}
				if (this.f_eipisconnected)
				{
					break;
				}
				byte[] bytesFwdOpenSend = this.connEnPacket.GetFwdOpenReqBytes(this.sessionHandle);
				if (bytesFwdOpenSend != null)
				{
					if (this.sessionHandle != 0u)
					{
						try
						{
							this.f_socket.Send(bytesFwdOpenSend, bytesFwdOpenSend.Length, SocketFlags.None);
							Array.Clear(this.tcpAsyReadBuffer, 0, this.tcpAsyReadBuffer.Length);
							int countRecv = this.f_socket.Receive(this.tcpAsyReadBuffer, this.tcpAsyReadBuffer.Length, SocketFlags.None);
							if (this.tcpAsyReadBuffer[0] == 111)
							{
								if (countRecv == 70)
								{
									this.f_eipisconnected = true;
									this.toNetWorkConnectionID = this.connEnPacket.GetTONetWorkConnectionID(this.tcpAsyReadBuffer);
									result = true;
									return result;
								}
							}
						}
						catch
						{
						}
					}
				}
				if (sendCnt >= this.f_connectCnt)
				{
					break;
				}
				sendCnt++;
			}
			result = false;
			return result;
		}
		public bool SendFwdClose()
		{
			int sendCnt = 0;
			bool result;
			while (true)
			{
				Thread.Sleep(this.f_sleep);
				if (this.f_socket == null)
				{
					break;
				}
				if (!this.f_socket.Connected)
				{
					break;
				}
				if (!this.f_eipisconnected)
				{
					break;
				}
				byte[] bytesFwdCloseSend = this.connEnPacket.GetFwdCloseReqBytes(this.sessionHandle, this.toNetWorkConnectionID);
				if (bytesFwdCloseSend != null)
				{
					if (this.sessionHandle != 0u)
					{
						try
						{
							this.f_socket.Send(bytesFwdCloseSend, bytesFwdCloseSend.Length, SocketFlags.None);
							Array.Clear(this.tcpAsyReadBuffer, 0, this.tcpAsyReadBuffer.Length);
							int countRecv = this.f_socket.Receive(this.tcpAsyReadBuffer, this.tcpAsyReadBuffer.Length, SocketFlags.None);
							if (this.tcpAsyReadBuffer[0] == 111)
							{
								if (countRecv == 56)
								{
									this.f_eipisconnected = false;
									result = true;
									return result;
								}
							}
						}
						catch
						{
						}
					}
				}
				if (sendCnt >= this.f_connectCnt)
				{
					break;
				}
				sendCnt++;
			}
			result = false;
			return result;
		}
		public bool SendUnloadSession()
		{
			int sendCnt = 0;
			bool result;
			while (true)
			{
				Thread.Sleep(this.f_sleep);
				if (this.f_socket == null)
				{
					break;
				}
				if (!this.f_socket.Connected)
				{
					break;
				}
				byte[] byteUnloadSession = this.connEnPacket.GetUnloadRegSessionHeadArray();
				if (byteUnloadSession != null)
				{
					if (this.sessionHandle != 0u)
					{
						try
						{
							this.f_socket.Send(byteUnloadSession, byteUnloadSession.Length, SocketFlags.None);
							Array.Clear(this.tcpAsyReadBuffer, 0, this.tcpAsyReadBuffer.Length);
							int countRecv = this.f_socket.Receive(this.tcpAsyReadBuffer, this.tcpAsyReadBuffer.Length, SocketFlags.None);
							if (this.tcpAsyReadBuffer[0] == 102)
							{
								if (countRecv == 24)
								{
									result = true;
									return result;
								}
							}
						}
						catch
						{
						}
					}
				}
				if (sendCnt >= this.f_connectCnt)
				{
					break;
				}
				sendCnt++;
			}
			result = false;
			return result;
		}
		public bool WriteTagData(string srcTagName, int srcElemNums, byte[] data, WriteDataType datatype)
		{
			int sendCnt = 0;
			bool result;
			while (true)
			{
				Thread.Sleep(this.f_sleep);
				if (this.f_socket == null)
				{
					break;
				}
				if (!this.f_socket.Connected)
				{
					break;
				}
				this.f_tagname = srcTagName;
				this.f_elemnums = srcElemNums;
				this.galSendBytesNum = 0;
				byte[] perSend = this.connEnPacket.WriteDataReqCommandCIPBytes(this.toNetWorkConnectionID, this.f_tagname, this.f_elemnums, datatype);
				bool f_WriteOnece = data.Count<byte>() + perSend.Count<byte>() <= 516;
				byte[] bytesSend;
				if (f_WriteOnece)
				{
					bytesSend = this.connEnPacket.GetWriteDataReqBytes(this.sessionHandle, data, perSend, true, 0);
				}
				else
				{
					int count = 516 - perSend.Count<byte>() - 4;
					byte[] Send = new byte[count];
					Array.Copy(data, this.galSendBytesNum, Send, 0, count);
					bytesSend = this.connEnPacket.GetWriteDataReqBytes(this.sessionHandle, Send, perSend, false, this.galSendBytesNum);
					this.galSendBytesNum += count;
				}
				if (bytesSend != null)
				{
					try
					{
						this.f_socket.Send(bytesSend, bytesSend.Length, SocketFlags.None);
						Array.Clear(this.tcpAsyReadBuffer, 0, this.tcpAsyReadBuffer.Length);
						int countRecv = this.f_socket.Receive(this.tcpAsyReadBuffer, this.tcpAsyReadBuffer.Length, SocketFlags.None);
						bool SendAll = false;
						while (!SendAll)
						{
							SendAll = true;
							if (countRecv > 0)
							{
								if (this.tcpAsyReadBuffer[0] == 112)
								{
									if (countRecv >= 50)
									{
										short tzValue = BitConverter.ToInt16(this.tcpAsyReadBuffer, 46);
										short tzStatusValue = BitConverter.ToInt16(this.tcpAsyReadBuffer, 48);
										if (tzValue == 205)
										{
											if (tzStatusValue == 0)
											{
												this.galSendBytesNum = 0;
												result = true;
												return result;
											}
										}
										else
										{
											if (tzValue == 211)
											{
												int count = 516 - perSend.Count<byte>() - 4;
												if (count + this.galSendBytesNum > data.Count<byte>())
												{
													count = data.Count<byte>() - this.galSendBytesNum;
												}
												byte[] Send = new byte[count];
												Array.Copy(data, this.galSendBytesNum, Send, 0, count);
												bytesSend = this.connEnPacket.GetWriteDataReqBytes(this.sessionHandle, Send, perSend, false, this.galSendBytesNum);
												this.galSendBytesNum += count;
												this.f_socket.Send(bytesSend, bytesSend.Length, SocketFlags.None);
												Array.Clear(this.tcpAsyReadBuffer, 0, this.tcpAsyReadBuffer.Length);
												countRecv = this.f_socket.Receive(this.tcpAsyReadBuffer, this.tcpAsyReadBuffer.Length, SocketFlags.None);
												if (this.galSendBytesNum >= data.Count<byte>())
												{
													this.galSendBytesNum = 0;
													result = true;
													return result;
												}
												SendAll = false;
											}
										}
									}
								}
							}
						}
					}
					catch(Exception ex)
					{
                        string temp = ex.Message;
					}
				}
				if (sendCnt >= this.f_connectCnt)
				{
					break;
				}
				sendCnt++;
			}
			result = false;
			return result;
		}
	}
	public enum WriteDataType : ushort
	{
		WRITE_INT = 195,
		WRITE_DINT,
		WRITE_REAL = 202,
		WRITE_BYTE = 194,
		WREITE_BOOL = 193,
		WREITE_LONG = 196
	}
	
}
