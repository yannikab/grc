
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
.assembly strcpycat
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module strcpycat
// MVID: {BA139064-DFB9-454B-B8BE-E50FDBBE4DA0}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x001F0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi strcpycat._
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
    IL_0000:  call       void strcpycat._::_.strcpycat()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.strcpycat() cil managed
  {
    // 
    .maxstack  2
    .locals init (uint8* V_0,
             uint8* V_1,
             uint8* V_2,
             uint8* V_3,
             uint8* V_4,
             uint8* V_5,
             uint8* V_6)
    IL_0000:  ldc.i4     0x400
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      V_0
    IL_0010:  ldc.i4     0x6
    IL_0015:  newarr     [mscorlib]System.Byte
    IL_001a:  stloc      V_1
    IL_0020:  ldloc      V_1
    IL_0026:  ldc.i4     0x0
    IL_002b:  add
    IL_002c:  ldc.i4     0x68
    IL_0031:  stind.i1
    IL_0032:  ldloc      V_1
    IL_0038:  ldc.i4     0x1
    IL_003d:  add
    IL_003e:  ldc.i4     0x65
    IL_0043:  stind.i1
    IL_0044:  ldloc      V_1
    IL_004a:  ldc.i4     0x2
    IL_004f:  add
    IL_0050:  ldc.i4     0x6c
    IL_0055:  stind.i1
    IL_0056:  ldloc      V_1
    IL_005c:  ldc.i4     0x3
    IL_0061:  add
    IL_0062:  ldc.i4     0x6c
    IL_0067:  stind.i1
    IL_0068:  ldloc      V_1
    IL_006e:  ldc.i4     0x4
    IL_0073:  add
    IL_0074:  ldc.i4     0x6f
    IL_0079:  stind.i1
    IL_007a:  ldloc      V_1
    IL_0080:  ldc.i4     0x5
    IL_0085:  add
    IL_0086:  ldc.i4     0x0
    IL_008b:  stind.i1
    IL_008c:  ldc.i4     0x3
    IL_0091:  newarr     [mscorlib]System.Byte
    IL_0096:  stloc      V_2
    IL_009c:  ldloc      V_2
    IL_00a2:  ldc.i4     0x0
    IL_00a7:  add
    IL_00a8:  ldc.i4     0xa
    IL_00ad:  stind.i1
    IL_00ae:  ldloc      V_2
    IL_00b4:  ldc.i4     0x1
    IL_00b9:  add
    IL_00ba:  ldc.i4     0x0
    IL_00bf:  stind.i1
    IL_00c0:  ldc.i4     0x7
    IL_00c5:  newarr     [mscorlib]System.Byte
    IL_00ca:  stloc      V_3
    IL_00d0:  ldloc      V_3
    IL_00d6:  ldc.i4     0x0
    IL_00db:  add
    IL_00dc:  ldc.i4     0x20
    IL_00e1:  stind.i1
    IL_00e2:  ldloc      V_3
    IL_00e8:  ldc.i4     0x1
    IL_00ed:  add
    IL_00ee:  ldc.i4     0x74
    IL_00f3:  stind.i1
    IL_00f4:  ldloc      V_3
    IL_00fa:  ldc.i4     0x2
    IL_00ff:  add
    IL_0100:  ldc.i4     0x68
    IL_0105:  stind.i1
    IL_0106:  ldloc      V_3
    IL_010c:  ldc.i4     0x3
    IL_0111:  add
    IL_0112:  ldc.i4     0x65
    IL_0117:  stind.i1
    IL_0118:  ldloc      V_3
    IL_011e:  ldc.i4     0x4
    IL_0123:  add
    IL_0124:  ldc.i4     0x72
    IL_0129:  stind.i1
    IL_012a:  ldloc      V_3
    IL_0130:  ldc.i4     0x5
    IL_0135:  add
    IL_0136:  ldc.i4     0x65
    IL_013b:  stind.i1
    IL_013c:  ldloc      V_3
    IL_0142:  ldc.i4     0x6
    IL_0147:  add
    IL_0148:  ldc.i4     0x0
    IL_014d:  stind.i1
    IL_014e:  ldc.i4     0x3
    IL_0153:  newarr     [mscorlib]System.Byte
    IL_0158:  stloc      V_4
    IL_015e:  ldloc      V_4
    IL_0164:  ldc.i4     0x0
    IL_0169:  add
    IL_016a:  ldc.i4     0xa
    IL_016f:  stind.i1
    IL_0170:  ldloc      V_4
    IL_0176:  ldc.i4     0x1
    IL_017b:  add
    IL_017c:  ldc.i4     0x0
    IL_0181:  stind.i1
    IL_0182:  ldc.i4     0x9
    IL_0187:  newarr     [mscorlib]System.Byte
    IL_018c:  stloc      V_5
    IL_0192:  ldloc      V_5
    IL_0198:  ldc.i4     0x0
    IL_019d:  add
    IL_019e:  ldc.i4     0x63
    IL_01a3:  stind.i1
    IL_01a4:  ldloc      V_5
    IL_01aa:  ldc.i4     0x1
    IL_01af:  add
    IL_01b0:  ldc.i4     0x6c
    IL_01b5:  stind.i1
    IL_01b6:  ldloc      V_5
    IL_01bc:  ldc.i4     0x2
    IL_01c1:  add
    IL_01c2:  ldc.i4     0x6f
    IL_01c7:  stind.i1
    IL_01c8:  ldloc      V_5
    IL_01ce:  ldc.i4     0x3
    IL_01d3:  add
    IL_01d4:  ldc.i4     0x62
    IL_01d9:  stind.i1
    IL_01da:  ldloc      V_5
    IL_01e0:  ldc.i4     0x4
    IL_01e5:  add
    IL_01e6:  ldc.i4     0x62
    IL_01eb:  stind.i1
    IL_01ec:  ldloc      V_5
    IL_01f2:  ldc.i4     0x5
    IL_01f7:  add
    IL_01f8:  ldc.i4     0x65
    IL_01fd:  stind.i1
    IL_01fe:  ldloc      V_5
    IL_0204:  ldc.i4     0x6
    IL_0209:  add
    IL_020a:  ldc.i4     0x72
    IL_020f:  stind.i1
    IL_0210:  ldloc      V_5
    IL_0216:  ldc.i4     0x7
    IL_021b:  add
    IL_021c:  ldc.i4     0x21
    IL_0221:  stind.i1
    IL_0222:  ldloc      V_5
    IL_0228:  ldc.i4     0x8
    IL_022d:  add
    IL_022e:  ldc.i4     0x0
    IL_0233:  stind.i1
    IL_0234:  ldc.i4     0x3
    IL_0239:  newarr     [mscorlib]System.Byte
    IL_023e:  stloc      V_6
    IL_0244:  ldloc      V_6
    IL_024a:  ldc.i4     0x0
    IL_024f:  add
    IL_0250:  ldc.i4     0xa
    IL_0255:  stind.i1
    IL_0256:  ldloc      V_6
    IL_025c:  ldc.i4     0x1
    IL_0261:  add
    IL_0262:  ldc.i4     0x0
    IL_0267:  stind.i1
    IL_0268:  ldloc      V_0
    IL_026e:  ldloc      V_1
    IL_0274:  call       void strcpycat._::_strcpy(uint8*,
                                                   uint8*)
    IL_0279:  ldloc      V_0
    IL_027f:  call       void strcpycat._::_puts(uint8*)
    IL_0284:  ldloc      V_2
    IL_028a:  call       void strcpycat._::_puts(uint8*)
    IL_028f:  ldloc      V_0
    IL_0295:  ldloc      V_3
    IL_029b:  call       void strcpycat._::_strcat(uint8*,
                                                   uint8*)
    IL_02a0:  ldloc      V_0
    IL_02a6:  call       void strcpycat._::_puts(uint8*)
    IL_02ab:  ldloc      V_4
    IL_02b1:  call       void strcpycat._::_puts(uint8*)
    IL_02b6:  ldloc      V_0
    IL_02bc:  ldloc      V_5
    IL_02c2:  call       void strcpycat._::_strcpy(uint8*,
                                                   uint8*)
    IL_02c7:  ldloc      V_0
    IL_02cd:  call       void strcpycat._::_puts(uint8*)
    IL_02d2:  ldloc      V_6
    IL_02d8:  call       void strcpycat._::_puts(uint8*)
    IL_02dd:  ret
  } // end of method _::_.strcpycat

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class strcpycat._


// =============================================================

// 
