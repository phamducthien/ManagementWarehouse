﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Util.Pattern
{
    public class RuntimePolicyHelper
    {
        static RuntimePolicyHelper()
        {
            var clrRuntimeInfo =
                (ICLRRuntimeInfo) RuntimeEnvironment.GetRuntimeInterfaceAsObject(
                    Guid.Empty,
                    typeof(ICLRRuntimeInfo).GUID);
            try
            {
                clrRuntimeInfo.BindAsLegacyV2Runtime();
                LegacyV2RuntimeEnabledSuccessfully = true;
            }
            catch (COMException)
            {
                // This occurs with an HRESULT meaning 
                // "A different runtime was already bound to the legacy CLR version 2 activation policy."
                LegacyV2RuntimeEnabledSuccessfully = false;
            }
        }

        public static bool LegacyV2RuntimeEnabledSuccessfully { get; }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
        private interface ICLRRuntimeInfo
        {
            void xGetVersionString();
            void xGetRuntimeDirectory();
            void xIsLoaded();
            void xIsLoadable();
            void xLoadErrorString();
            void xLoadLibrary();
            void xGetProcAddress();
            void xGetInterface();
            void xSetDefaultStartupFlags();
            void xGetDefaultStartupFlags();

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            void BindAsLegacyV2Runtime();
        }
    }
}