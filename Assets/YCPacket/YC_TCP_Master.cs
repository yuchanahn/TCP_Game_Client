using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;


class YC_TCP_Master
{
    string ip = "127.0.0.1";
    int port = 51234;
    
    ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();

    private TcpClient socketConnection;
    private Thread clientReceiveThread;

    bool sock_connect = false;

    public YC_TCP_Master(string i, int p)
    {
        ip = i;
        port = p;

        ConnectToTcpServer();
    }

    
    public void SocketDisconnet()
    {   
        if (sock_connect)
        {
            socketConnection.Close();
            clientReceiveThread.Abort();
        }
    }


    private void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine("On client connect exception " + e);
        }
    }
    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient(ip, port);
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    sock_connect = true;
                    int length;
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        byte[] b_data = new byte[length];
                        Array.Copy(bytes, 0, b_data, 0, length);
                        YC.YCPacket.read(b_data, b_data.Length);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Console.WriteLine("Socket exception: " + socketException);
        }
    }

    Action act;
    public void run()
    {
        while (!actions.IsEmpty)
        {
            if (actions.TryDequeue(out act)) act();
        }
    }

    public void DoMainThread(Action a)
    {
        actions.Enqueue(a);
    }

    public void send(YC.IPacket_t packet)
    {
        if (socketConnection == null)
        {
            Console.WriteLine("Server Closed");
            return;
        }
        try
        {
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                var buf = YC.YCPacket.Get_YCPacket_Format(packet);
                stream.Write(buf, 0, buf.Length);
            }
        }
        catch (SocketException socketException)
        {
            Console.WriteLine("Socket exception: " + socketException);
        }
    }
}
