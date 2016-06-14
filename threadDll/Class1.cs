using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace threadDll
{
    [Guid("C837242B-B65E-4086-AE40-CEFC66E45104")]
    
    public interface IThreadCreatorClass
    {
        void CreateThread();
    }
    [Guid("221EA595-3764-4D33-9F8D-DD5F9871D0A0")]
    [ProgId("netThreader")]
    public class ThreadCreatorClass:IThreadCreatorClass
    {
        public void WorkThreadFunction()
        {
            
            try
            {
                using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\_todelete\trace.txt"))
                {
                    for (int i = 0; i < 10000000; i++)
                    {

                        file.WriteLine(DateTime.Now);
                        //Thread.Sleep(1000);

                    }
                    file.WriteLine("Ended everything: "+DateTime.Now);
                }
               
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

        public void CreateThread()
        {
            Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
            thread.Start();
        }
    }
}
