using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//using Rhino4;
//using RhinoScript4;
using Rhino;
using RhinoScript;

namespace rhinoCOM
{

    class Program
    {
        static void Main()
        {
            //dynamic m_RhinoInterface = null;
            //RhinoScript.RhinoScript rs = null;

            //string rhinoId = "Rhino5.Interface";
            ////string rhinoId = "Rhino.Interface";
            ////string rhinoId = "Rhino.Application";
            //Type type = Type.GetTypeFromProgID(rhinoId);
            //m_RhinoInterface = Activator.CreateInstance(type);

            //var test = m_RhinoInterface.IsInitialized();
            //m_RhinoInterface.Visible = 1;

            //Console.WriteLine(test);

            ////Rhino TLB 取得
            ////IRhino5Interface m_RhinoInterface = null;
            ////Type type = Type.GetTypeFromProgID("Rhino5.Interface");
            ////object obj = Activator.CreateInstance(type);
            ////m_RhinoInterface = (IRhino5Interface)obj;
            ////m_RhinoInterface.IsInitialized();
            ////m_RhinoInterface.Visible = 1;

            //var test2 = m_RhinoInterface.GetScriptObject();
            //Console.WriteLine(test2);

            //rs = test2;

            //double[] pt_1 = { 0, 0, 0 };
            //double[] pt_2 = { 100, 100, 100 };


            //rs.AddLine(pt_1, pt_2);

            RhinoScript.RhinoScript rs = null;

            // Try creating an instance of Rhino
            dynamic rhino = null;
            try
            {
                //string rhinoId = "Rhino.Application";
                string rhinoId = "Rhino.Interface";
                System.Type type = System.Type.GetTypeFromProgID(rhinoId);
                rhino = System.Activator.CreateInstance(type);
            }
            catch
            {
            }

            if (null == rhino)
            {
                Console.WriteLine("Failed to create Rhino application");
                return;
            }

            // Wait until Rhino is initialized before calling into it
            const int bail_milliseconds = 15 * 1000;
            int time_waiting = 0;
            while (0 == rhino.IsInitialized())
            {
                Thread.Sleep(100);
                time_waiting += 100;
                if (time_waiting > bail_milliseconds)
                {
                    Console.WriteLine("Rhino initialization failed");
                    return;
                }
            }

            //rhino.Visible = 1;

            rs = rhino.GetScriptObject();

            double[] pt_1 = { 0, 0, 0 };
            double[] pt_2 = { 100, 100, 100 };

            rs.AddLine(pt_1, pt_2);
        }
    }


}
