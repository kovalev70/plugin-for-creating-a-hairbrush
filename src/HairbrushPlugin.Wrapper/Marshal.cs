namespace HairbrushPlugin.Wrapper
{
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Нужен для реализации метода <see cref="GetActiveObject(string)"/>,
    /// который доступен только в .Net Framework.
    /// </summary>
    public static class Marshal
    {
        /// <summary>
        /// Получить обработчик программы по её ID.
        /// </summary>
        /// <param name="programId">ID программы.</param>
        /// <returns>Обработчик программы.</returns>
        [SecurityCritical]
        public static object GetActiveObject(string programId)
        {
            Guid clsid;
            try
            {
                CLSIDFromProgIDEx(programId, out clsid);
            }
            catch (Exception)
            {
                CLSIDFromProgID(programId, out clsid);
            }

            GetActiveObject(ref clsid, IntPtr.Zero, out var ppunk);
            return ppunk;
        }

        [DllImport("ole32.dll", PreserveSig = false)]
        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        private static extern void CLSIDFromProgIDEx(
            [MarshalAs(UnmanagedType.LPWStr)] string programId,
            out Guid clsid);

        [DllImport("ole32.dll", PreserveSig = false)]
        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        private static extern void CLSIDFromProgID(
            [MarshalAs(UnmanagedType.LPWStr)] string programId,
            out Guid clsid);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        private static extern void GetActiveObject(
            ref Guid rclsid,
            IntPtr reserved,
            [MarshalAs(UnmanagedType.Interface)] out object ppunk);
    }
}
