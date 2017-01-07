using System;
using System.Text;

namespace Commander360Test.Console
{
    public class ClientLogic : IServerCallback
    {
        #region UpdateData
        public void UpdateData(double result)
        {
            System.Console.WriteLine("{0} -- > {1}", DateTime.Now, result);
        }
        #endregion

        #region UploadData
        public void UploadData(byte[] buffer)
        {
            System.Console.WriteLine("{0} --> {1}", DateTime.Now, Encoding.ASCII.GetString(buffer));
        } 
        #endregion
    }
}
