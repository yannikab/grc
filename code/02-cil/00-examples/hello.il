
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
.assembly hello
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module hello
// MVID: {F2B26A3A-E60A-4913-A3FB-C0DF93745999}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x001E0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi hello._
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
    IL_0000:  call       void hello._::_.hello()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.hello() cil managed
  {
    // 
    .maxstack  2
    .locals init (uint8* V_0)
    IL_0000:  ldc.i4     0xf
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      V_0
    IL_0010:  ldloc      V_0
    IL_0016:  ldc.i4     0x0
    IL_001b:  add
    IL_001c:  ldc.i4     0x48
    IL_0021:  stind.i1
    IL_0022:  ldloc      V_0
    IL_0028:  ldc.i4     0x1
    IL_002d:  add
    IL_002e:  ldc.i4     0x65
    IL_0033:  stind.i1
    IL_0034:  ldloc      V_0
    IL_003a:  ldc.i4     0x2
    IL_003f:  add
    IL_0040:  ldc.i4     0x6c
    IL_0045:  stind.i1
    IL_0046:  ldloc      V_0
    IL_004c:  ldc.i4     0x3
    IL_0051:  add
    IL_0052:  ldc.i4     0x6c
    IL_0057:  stind.i1
    IL_0058:  ldloc      V_0
    IL_005e:  ldc.i4     0x4
    IL_0063:  add
    IL_0064:  ldc.i4     0x6f
    IL_0069:  stind.i1
    IL_006a:  ldloc      V_0
    IL_0070:  ldc.i4     0x5
    IL_0075:  add
    IL_0076:  ldc.i4     0x20
    IL_007b:  stind.i1
    IL_007c:  ldloc      V_0
    IL_0082:  ldc.i4     0x6
    IL_0087:  add
    IL_0088:  ldc.i4     0x77
    IL_008d:  stind.i1
    IL_008e:  ldloc      V_0
    IL_0094:  ldc.i4     0x7
    IL_0099:  add
    IL_009a:  ldc.i4     0x6f
    IL_009f:  stind.i1
    IL_00a0:  ldloc      V_0
    IL_00a6:  ldc.i4     0x8
    IL_00ab:  add
    IL_00ac:  ldc.i4     0x72
    IL_00b1:  stind.i1
    IL_00b2:  ldloc      V_0
    IL_00b8:  ldc.i4     0x9
    IL_00bd:  add
    IL_00be:  ldc.i4     0x6c
    IL_00c3:  stind.i1
    IL_00c4:  ldloc      V_0
    IL_00ca:  ldc.i4     0xa
    IL_00cf:  add
    IL_00d0:  ldc.i4     0x64
    IL_00d5:  stind.i1
    IL_00d6:  ldloc      V_0
    IL_00dc:  ldc.i4     0xb
    IL_00e1:  add
    IL_00e2:  ldc.i4     0x21
    IL_00e7:  stind.i1
    IL_00e8:  ldloc      V_0
    IL_00ee:  ldc.i4     0xc
    IL_00f3:  add
    IL_00f4:  ldc.i4     0xa
    IL_00f9:  stind.i1
    IL_00fa:  ldloc      V_0
    IL_0100:  ldc.i4     0xd
    IL_0105:  add
    IL_0106:  ldc.i4     0x0
    IL_010b:  stind.i1
    IL_010c:  ldloc      V_0
    IL_0112:  call       void hello._::_puts(uint8*)
    IL_0117:  ret
  } // end of method _::_.hello

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class hello._


// =============================================================

// 
