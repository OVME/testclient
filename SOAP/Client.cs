using System.Net.Sockets;
using SOAP.ServiceReference1;


namespace SOAP
{
    public class Client
    {
        public TheradPoolWebServiceSoapClient Tclient { get; set; }

        public Client()
        {
            Tclient = new TheradPoolWebServiceSoapClient("TheradPoolWebServiceSoap");
            Tclient.Open();
        }

        public string GetRId(string reqString)
        {
            
            string idstring = Tclient.GetRId(reqString);

            return idstring;
        }

        public string GetStatus(long id)
        {

            string status = Tclient.Status(id);

            return status;
        }

        public string GetProcessStatus(long pid)
        {
            string procStat = Tclient.JobState(pid);
            return procStat;
        }

        public string GetResult(long id)
        {

            string result = Tclient.Result(id);

            return result;
        }

        public void CloseConnection()
        {
            Tclient.Close();
        }

    }
}
