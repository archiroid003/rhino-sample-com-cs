using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino4;
using RhinoScript4;
using Rhino.Geometry;

namespace rhinoCOM
{

    class Program
    {
        static void Main()
        {
            IRhino5Interface m_RhinoInterface = null;
            RhinoScript rs = null;

            Type type = Type.GetTypeFromProgID("Rhino5.Interface");
            object obj = Activator.CreateInstance(type);
            m_RhinoInterface = (IRhino5Interface)obj;

            m_RhinoInterface.IsInitialized();
            m_RhinoInterface.Visible = 1;

            rs = m_RhinoInterface.GetScriptObject();

            double[] pt_1 = { 0, 0, 0 };
            double[] pt_2 = { 100, 100, 100 };

            //rs.AddPoint(pt_1);

            rs.AddLine(pt_1, pt_2);
        }
    }


}
