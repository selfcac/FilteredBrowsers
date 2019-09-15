using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedFlowRunner
{
    public class ProcessSecurity
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Security_attributes
        {
            public int Length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        [DllImport("Advapi32.dll", SetLastError = true)]
        static extern bool ConvertStringSecurityDescriptorToSecurityDescriptor(
            string StringSecurityDescriptor, uint StringSDRevision, out IntPtr SecurityDescriptor, out UIntPtr SecurityDescriptorSize);

        private static StructWrapper getSecurityDesc(string sddl)
        {
            uint sd_revision = 1;
            IntPtr sd_ptr = new IntPtr();
            UIntPtr sd_size_ptr = new UIntPtr();
            ConvertStringSecurityDescriptorToSecurityDescriptor(sddl, sd_revision, out sd_ptr, out sd_size_ptr);

            return StructWrapper.FromUnsafePointer(sd_ptr);
        }

        public static StructWrapper getSecurity(string sddl)
        {
            var sa = new Security_attributes();
            sa.bInheritHandle = false;
            sa.Length = Marshal.SizeOf(sa);
            sa.lpSecurityDescriptor = getSecurityDesc(sddl);

            return new StructWrapper(sa);
        }

        public static string getSidByUserName(string username)
        {
            //https://stackoverflow.com/a/1040629/1997873

            NTAccount f = new NTAccount("username");
            SecurityIdentifier s = (SecurityIdentifier)f.Translate(typeof(SecurityIdentifier));
            String sidString = s.ToString();
            return sidString;
        }
    }
}
