
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern GrcIO
{
  .publickeytoken = (32 A1 DE C0 6E 10 C1 A8 )                         // 2...n...
  .ver 1:0:0:0
}
.assembly ordchr
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module ordchr
// MVID: {7376E15E-9303-45F4-9BAE-06E578F0D53B}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x001A0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi ordchr._
       extends [mscorlib]System.Object
{
  .method private static void  _puti(int32 i) cil managed
  {
    // 
    .maxstack  1
    IL_0000:  ldarg      i
    IL_0006:  call       void [GrcIO]Grc.IO::PutInt(int32)
    IL_000b:  ret
  } // end of method _::_puti

  .method private static void  _putc(uint8 c) cil managed
  {
    // 
    .maxstack  1
    IL_0000:  ldarg      c
    IL_0006:  call       void [GrcIO]Grc.IO::PutChar(uint8)
    IL_000b:  ret
  } // end of method _::_putc

  .method private static void  _puts(uint8* p) cil managed
  {
    // 
    .maxstack  1
    IL_0000:  ldarg      p
    IL_0006:  call       void [GrcIO]Grc.IO::PutStr(uint8*)
    IL_000b:  ret
  } // end of method _::_puts

  .method private static int32  _geti() cil managed
  {
    // 
    .maxstack  1
    IL_0000:  call       int32 [GrcIO]Grc.IO::GetInt()
    IL_0005:  ret
  } // end of method _::_geti

  .method private static uint8  _getc() cil managed
  {
    // 
    .maxstack  1
    IL_0000:  call       uint8 [GrcIO]Grc.IO::GetChar()
    IL_0005:  ret
  } // end of method _::_getc

  .method private static void  _gets(int32 n,
                                     uint8* p) cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg      n
    IL_0006:  ldarg      p
    IL_000c:  call       void [GrcIO]Grc.IO::GetStr(int32,
                                                    uint8*)
    IL_0011:  ret
  } // end of method _::_gets

  .method private static int32  _abs(int32 i) cil managed
  {
    // 
    .maxstack  1
    IL_0000:  ldarg      i
    IL_0006:  call       int32 [GrcIO]Grc.IO::IntGetAbs(int32)
    IL_000b:  ret
  } // end of method _::_abs

  .method private static int32  _ord(uint8 c) cil managed
  {
    // 
    .maxstack  1
    IL_0000:  ldarg      c
    IL_0006:  call       int32 [GrcIO]Grc.IO::CharGetOrd(uint8)
    IL_000b:  ret
  } // end of method _::_ord

  .method private static uint8  _chr(int32 i) cil managed
  {
    // 
    .maxstack  1
    IL_0000:  ldarg      i
    IL_0006:  call       uint8 [GrcIO]Grc.IO::IntGetChar(int32)
    IL_000b:  ret
  } // end of method _::_chr

  .method private static int32  _strlen(uint8* p) cil managed
  {
    // 
    .maxstack  1
    IL_0000:  ldarg      p
    IL_0006:  call       int32 [GrcIO]Grc.IO::StrLen(uint8*)
    IL_000b:  ret
  } // end of method _::_strlen

  .method private static int32  _strcmp(uint8* p1,
                                        uint8* p2) cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg      p1
    IL_0006:  ldarg      p2
    IL_000c:  call       int32 [GrcIO]Grc.IO::StrCmp(uint8*,
                                                     uint8*)
    IL_0011:  ret
  } // end of method _::_strcmp

  .method private static void  _strcpy(uint8* p2,
                                       uint8* p1) cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg      p2
    IL_0006:  ldarg      p1
    IL_000c:  call       void [GrcIO]Grc.IO::StrCpy(uint8*,
                                                    uint8*)
    IL_0011:  ret
  } // end of method _::_strcpy

  .method private static void  _strcat(uint8* p2,
                                       uint8* p1) cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg      p2
    IL_0006:  ldarg      p1
    IL_000c:  call       void [GrcIO]Grc.IO::StrCat(uint8*,
                                                    uint8*)
    IL_0011:  ret
  } // end of method _::_strcat

  .method private static void  _() cil managed
  {
    .entrypoint
    // 
    .maxstack  0
    IL_0000:  call       void ordchr._::_.ordchr()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.ordchr() cil managed
  {
    // 
    .maxstack  5
    .locals init (int32 V_0,
             uint8 V_1,
             uint8 V_2,
             int32 V_3,
             int32 V_4)
    IL_0000:  ldc.i4     0x20
    IL_0005:  stloc      V_0
    IL_000b:  ldloc      V_0
    IL_0011:  ldc.i4     0x7f
    IL_0016:  blt        IL_0020

    IL_001b:  br         IL_00a0

    IL_0020:  ldloc      V_0
    IL_0026:  call       uint8 ordchr._::_chr(int32)
    IL_002b:  stloc      V_1
    IL_0031:  ldloc      V_1
    IL_0037:  call       void ordchr._::_putc(uint8)
    IL_003c:  ldc.i4     0x20
    IL_0041:  call       void ordchr._::_putc(uint8)
    IL_0046:  ldloc      V_0
    IL_004c:  call       uint8 ordchr._::_chr(int32)
    IL_0051:  stloc      V_2
    IL_0057:  ldloc      V_2
    IL_005d:  call       int32 ordchr._::_ord(uint8)
    IL_0062:  stloc      V_3
    IL_0068:  ldloc      V_3
    IL_006e:  call       void ordchr._::_puti(int32)
    IL_0073:  ldc.i4     0x9
    IL_0078:  call       void ordchr._::_putc(uint8)
    IL_007d:  ldloc      V_0
    IL_0083:  ldc.i4     0x1
    IL_0088:  add
    IL_0089:  stloc      V_4
    IL_008f:  ldloc      V_4
    IL_0095:  stloc      V_0
    IL_009b:  br         IL_000b

    IL_00a0:  ldc.i4     0xa
    IL_00a5:  call       void ordchr._::_putc(uint8)
    IL_00aa:  ret
  } // end of method _::_.ordchr

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class ordchr._


// =============================================================

// 
