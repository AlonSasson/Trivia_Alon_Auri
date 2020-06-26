using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace Trivia_Client
{
    // sends
    class Communicator
    {
        private static NetworkStream ClientSock;

        // Constructor
        public Communicator()
        {
            try
            {
                TcpClient client = new TcpClient();
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8876);
                client.Connect(serverEndPoint);
                ClientSock = client.GetStream();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message); // if there was a problem connecting to the server
                System.Environment.Exit(-1);
            }
        }

        // sends a request to the server and gets back a repsonse and its code
        public static Responses.ResponseInfo sendRequest(byte[] buffer)
        {

            const int CODE_SIZE = 1;
            const int LEN_SIZE = 4;
            const int ERROR_ID = 0;
            Responses.ResponseInfo response = new Responses.ResponseInfo();
            int len = 0;

            try
            {
                ClientSock.Write(buffer, 0, buffer.Length);
                ClientSock.Flush();
            }
            catch(SocketException e)
            {
                return new Responses.ResponseInfo { Code = ERROR_ID, Buffer = new ASCIIEncoding().GetBytes("Failed to send request") };
            }
            try
            {
                buffer = new byte[CODE_SIZE + LEN_SIZE];
                if (ClientSock.Read(buffer, 0, CODE_SIZE) == 0) // if no info was read
                    return new Responses.ResponseInfo { Code = ERROR_ID, Buffer = new ASCIIEncoding().GetBytes("Failed to get response") };
                response.Code = (int)buffer[0];

                if (ClientSock.Read(buffer, CODE_SIZE, LEN_SIZE) == 0) // if no info was read
                    return new Responses.ResponseInfo { Code = ERROR_ID, Buffer = new ASCIIEncoding().GetBytes("Failed to get response") };
                len = BitConverter.ToInt32(buffer, 1);

                buffer = new byte[CODE_SIZE + LEN_SIZE + len];
                if (ClientSock.Read(buffer, CODE_SIZE + LEN_SIZE, len) == 0) // if no info was read
                    return new Responses.ResponseInfo { Code = ERROR_ID, Buffer = new ASCIIEncoding().GetBytes("Failed to get response") };
                response.Buffer = buffer;
            }
            catch (SocketException e)
            {
                response =  new Responses.ResponseInfo { Code = ERROR_ID, Buffer = new ASCIIEncoding().GetBytes("Failed to get response") };
            }
            return response;

        }
    }
}
