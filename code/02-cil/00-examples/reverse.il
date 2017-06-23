
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
.assembly reverse
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module reverse
// MVID: {F4950B9A-EA56-4737-B5EF-AF753C865923}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00200000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi reverse._
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

  .method private static void  _() cil managed
  {
    .entrypoint
    // 
    .maxstack  0
    IL_0000:  call       void reverse._::_.reverse()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.reverse.rev(uint8* s,
                                             uint8* r) cil managed
  {
    // 
    .maxstack  6
    .locals init ([0] int32 i,
             [1] int32 l,
             [2] int32 $0,
             [3] int32 $1,
             [4] uint8* $2,
             [5] int32 $3,
             [6] int32 $4,
             [7] int32 $5,
             [8] uint8* $6,
             [9] int32 $7,
             [10] int32 $8,
             [11] uint8* $9)
    IL_0000:  ldarg      s
    IL_0006:  call       int32 reverse._::_strlen(uint8*)
    IL_000b:  stloc      $0
    IL_0011:  ldloc      $0
    IL_0017:  stloc      l
    IL_001d:  ldc.i4     0x0
    IL_0022:  stloc      i
    IL_0028:  ldloc      i
    IL_002e:  ldloc      l
    IL_0034:  blt        IL_003e

    IL_0039:  br         IL_00d2

    IL_003e:  ldloc      i
    IL_0044:  stloc      $1
    IL_004a:  ldarg      r
    IL_0050:  ldloc      $1
    IL_0056:  add
    IL_0057:  stloc      $2
    IL_005d:  ldloc      l
    IL_0063:  ldloc      i
    IL_0069:  sub
    IL_006a:  stloc      $3
    IL_0070:  ldloc      $3
    IL_0076:  ldc.i4     0x1
    IL_007b:  sub
    IL_007c:  stloc      $4
    IL_0082:  ldloc      $4
    IL_0088:  stloc      $5
    IL_008e:  ldarg      s
    IL_0094:  ldloc      $5
    IL_009a:  add
    IL_009b:  stloc      $6
    IL_00a1:  ldloc      $2
    IL_00a7:  ldloc      $6
    IL_00ad:  ldind.i1
    IL_00ae:  stind.i1
    IL_00af:  ldloc      i
    IL_00b5:  ldc.i4     0x1
    IL_00ba:  add
    IL_00bb:  stloc      $7
    IL_00c1:  ldloc      $7
    IL_00c7:  stloc      i
    IL_00cd:  br         IL_0028

    IL_00d2:  ldloc      i
    IL_00d8:  stloc      $8
    IL_00de:  ldarg      r
    IL_00e4:  ldloc      $8
    IL_00ea:  add
    IL_00eb:  stloc      $9
    IL_00f1:  ldloc      $9
    IL_00f7:  ldc.i4     0x0
    IL_00fc:  stind.i1
    IL_00fd:  ret
  } // end of method _::_.reverse.rev

  .method private static void  _.reverse() cil managed
  {
    // 
    .maxstack  2
    .locals init ([0] uint8* r,
             [1] uint8* _1)
    IL_0000:  ldc.i4     0x20
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      r
    IL_0010:  ldc.i4     0xf
    IL_0015:  newarr     [mscorlib]System.Byte
    IL_001a:  stloc      _1
    IL_0020:  ldloc      _1
    IL_0026:  ldc.i4     0x0
    IL_002b:  add
    IL_002c:  ldc.i4     0xa
    IL_0031:  stind.i1
    IL_0032:  ldloc      _1
    IL_0038:  ldc.i4     0x1
    IL_003d:  add
    IL_003e:  ldc.i4     0x21
    IL_0043:  stind.i1
    IL_0044:  ldloc      _1
    IL_004a:  ldc.i4     0x2
    IL_004f:  add
    IL_0050:  ldc.i4     0x64
    IL_0055:  stind.i1
    IL_0056:  ldloc      _1
    IL_005c:  ldc.i4     0x3
    IL_0061:  add
    IL_0062:  ldc.i4     0x6c
    IL_0067:  stind.i1
    IL_0068:  ldloc      _1
    IL_006e:  ldc.i4     0x4
    IL_0073:  add
    IL_0074:  ldc.i4     0x72
    IL_0079:  stind.i1
    IL_007a:  ldloc      _1
    IL_0080:  ldc.i4     0x5
    IL_0085:  add
    IL_0086:  ldc.i4     0x6f
    IL_008b:  stind.i1
    IL_008c:  ldloc      _1
    IL_0092:  ldc.i4     0x6
    IL_0097:  add
    IL_0098:  ldc.i4     0x77
    IL_009d:  stind.i1
    IL_009e:  ldloc      _1
    IL_00a4:  ldc.i4     0x7
    IL_00a9:  add
    IL_00aa:  ldc.i4     0x20
    IL_00af:  stind.i1
    IL_00b0:  ldloc      _1
    IL_00b6:  ldc.i4     0x8
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x6f
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      _1
    IL_00c8:  ldc.i4     0x9
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x6c
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      _1
    IL_00da:  ldc.i4     0xa
    IL_00df:  add
    IL_00e0:  ldc.i4     0x6c
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      _1
    IL_00ec:  ldc.i4     0xb
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x65
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      _1
    IL_00fe:  ldc.i4     0xc
    IL_0103:  add
    IL_0104:  ldc.i4     0x48
    IL_0109:  stind.i1
    IL_010a:  ldloc      _1
    IL_0110:  ldc.i4     0xd
    IL_0115:  add
    IL_0116:  ldc.i4     0x0
    IL_011b:  stind.i1
    IL_011c:  ldloc      _1
    IL_0122:  ldloc      r
    IL_0128:  call       void reverse._::_.reverse.rev(uint8*,
                                                       uint8*)
    IL_012d:  ldloc      r
    IL_0133:  call       void reverse._::_puts(uint8*)
    IL_0138:  ret
  } // end of method _::_.reverse

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class reverse._


// =============================================================

// 
