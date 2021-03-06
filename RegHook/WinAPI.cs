﻿using System;
using System.Runtime.InteropServices;

namespace RegHook
{
    class WinAPI
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        internal delegate IntPtr RegOpenKeyEx_Delegate(
            IntPtr hKey,
            string subKey,
            int ulOptions,
            int samDesired,
            ref IntPtr hkResult);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyEx")]
        internal static extern IntPtr RegOpenKeyEx(
            IntPtr hKey,
            string subKey,
            int ulOptions,
            int samDesired,
            ref IntPtr hkResult);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        internal delegate IntPtr RegCreateKeyEx_Delegate(
            IntPtr hKey,
            string subKey,
            IntPtr Reserved,
            string lpClass,
            RegOption dwOptions,
            RegSAM samDesired,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            out IntPtr hkResult,
            out RegResult lpdwDisposition);

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        [Flags]
        public enum RegOption
        {
            NonVolatile = 0x0,
            Volatile = 0x1,
            CreateLink = 0x2,
            BackupRestore = 0x4,
            OpenLink = 0x8
        }

        [Flags]
        public enum RegSAM
        {
            QueryValue = 0x0001,
            SetValue = 0x0002,
            CreateSubKey = 0x0004,
            EnumerateSubKeys = 0x0008,
            Notify = 0x0010,
            CreateLink = 0x0020,
            WOW64_32Key = 0x0200,
            WOW64_64Key = 0x0100,
            WOW64_Res = 0x0300,
            Read = 0x00020019,
            Write = 0x00020006,
            Execute = 0x00020019,
            AllAccess = 0x000f003f
        }

        public enum RegResult
        {
            CreatedNewKey = 0x00000001,
            OpenedExistingKey = 0x00000002
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyEx")]
        internal static extern IntPtr RegCreateKeyEx(
            IntPtr hKey,
            string subKey,
            IntPtr Reserved,
            string lpClass,
            RegOption dwOptions,
            RegSAM samDesired,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            out IntPtr hkResult,
            out RegResult lpdwDisposition);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        internal delegate IntPtr RegCreateKey_Delegate(
            IntPtr hKey,
            string subKey,
            ref IntPtr hkResult);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyA")]
        internal static extern IntPtr RegCreateKey(
            IntPtr hKey,
            string subKey,
            ref IntPtr hkResult);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        internal delegate IntPtr RegDeleteKeyEx_Delegate(
            IntPtr hKey,
            string subKey,
            int samDesired,
            int Reserved);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyEx")]
        internal static extern IntPtr RegDeleteKeyEx(
            IntPtr hKey,
            string subKey,
            int samDesired,
            int Reserved);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        internal delegate IntPtr RegSetValueEx_Delegate(
            IntPtr hKey,
            [MarshalAs (UnmanagedType.LPStr)]
            string lpValueName,
            int lpReserved,
            Microsoft.Win32.RegistryValueKind type,
            IntPtr lpData,
            int lpcbData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        internal delegate IntPtr RegQueryValueEx_Delegate(
            IntPtr hKey,
            string lpValueName,
            int lpReserved,
            ref Microsoft.Win32.RegistryValueKind type,
            IntPtr lpData,
            ref int lpcbData);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "RegQueryValueExW")]
        internal static extern IntPtr RegQueryValueExW(
            IntPtr hKey,
            string lpValueName,
            int lpReserved,
            ref Microsoft.Win32.RegistryValueKind type,
            IntPtr lpData,
            ref int lpcbData);


        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        internal delegate IntPtr RegCloseKey_Delegate(
            IntPtr hKey);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "RegCloseKey")]
        internal static extern IntPtr RegCloseKey(
            IntPtr hKey);

    }
}
