
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
.assembly fibonacci
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module fibonacci
// MVID: {053A3CBD-2E65-4C8F-9D23-8279A77E0479}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x001E0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi fibonacci._
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
    IL_0000:  call       void fibonacci._::_.fibonacci()
    IL_0005:  ret
  } // end of method _::_

  .method private static int32  _.fibonacci.fib(int32 n) cil managed
  {
    // 
    .maxstack  5
    .locals init ([0] int32 $2,
             [1] int32 $3,
             [2] int32 $4,
             [3] int32 $5,
             [4] int32 $6)
    IL_0000:  ldarg      n
    IL_0006:  ldc.i4     0x2
    IL_000b:  blt        IL_0015

    IL_0010:  br         IL_0021

    IL_0015:  ldarg      n
    IL_001b:  ret

    IL_001c:  br         IL_0081

    IL_0021:  ldarg      n
    IL_0027:  ldc.i4     0x2
    IL_002c:  sub
    IL_002d:  stloc      $2
    IL_0033:  ldloc      $2
    IL_0039:  call       int32 fibonacci._::_.fibonacci.fib(int32)
    IL_003e:  stloc      $3
    IL_0044:  ldarg      n
    IL_004a:  ldc.i4     0x1
    IL_004f:  sub
    IL_0050:  stloc      $4
    IL_0056:  ldloc      $4
    IL_005c:  call       int32 fibonacci._::_.fibonacci.fib(int32)
    IL_0061:  stloc      $5
    IL_0067:  ldloc      $3
    IL_006d:  ldloc      $5
    IL_0073:  add
    IL_0074:  stloc      $6
    IL_007a:  ldloc      $6
    IL_0080:  ret

    IL_0081:  ret
  } // end of method _::_.fibonacci.fib

  .method private static void  _.fibonacci() cil managed
  {
    // 
    .maxstack  4
    .locals init ([0] int32 i,
             [1] int32 $0,
             [2] int32 $1,
             [3] uint8* _3,
             [4] uint8* _4,
             [5] uint8* _5)
    IL_0000:  ldc.i4     0x5
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      _3
    IL_0010:  ldloc      _3
    IL_0016:  ldc.i4     0x0
    IL_001b:  add
    IL_001c:  ldc.i4     0x66
    IL_0021:  stind.i1
    IL_0022:  ldloc      _3
    IL_0028:  ldc.i4     0x1
    IL_002d:  add
    IL_002e:  ldc.i4     0x69
    IL_0033:  stind.i1
    IL_0034:  ldloc      _3
    IL_003a:  ldc.i4     0x2
    IL_003f:  add
    IL_0040:  ldc.i4     0x62
    IL_0045:  stind.i1
    IL_0046:  ldloc      _3
    IL_004c:  ldc.i4     0x3
    IL_0051:  add
    IL_0052:  ldc.i4     0x28
    IL_0057:  stind.i1
    IL_0058:  ldloc      _3
    IL_005e:  ldc.i4     0x4
    IL_0063:  add
    IL_0064:  ldc.i4     0x0
    IL_0069:  stind.i1
    IL_006a:  ldc.i4     0x4
    IL_006f:  newarr     [mscorlib]System.Byte
    IL_0074:  stloc      _4
    IL_007a:  ldloc      _4
    IL_0080:  ldc.i4     0x0
    IL_0085:  add
    IL_0086:  ldc.i4     0x29
    IL_008b:  stind.i1
    IL_008c:  ldloc      _4
    IL_0092:  ldc.i4     0x1
    IL_0097:  add
    IL_0098:  ldc.i4     0x3a
    IL_009d:  stind.i1
    IL_009e:  ldloc      _4
    IL_00a4:  ldc.i4     0x2
    IL_00a9:  add
    IL_00aa:  ldc.i4     0x20
    IL_00af:  stind.i1
    IL_00b0:  ldloc      _4
    IL_00b6:  ldc.i4     0x3
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x0
    IL_00c1:  stind.i1
    IL_00c2:  ldc.i4     0x3
    IL_00c7:  newarr     [mscorlib]System.Byte
    IL_00cc:  stloc      _5
    IL_00d2:  ldloc      _5
    IL_00d8:  ldc.i4     0x0
    IL_00dd:  add
    IL_00de:  ldc.i4     0xa
    IL_00e3:  stind.i1
    IL_00e4:  ldloc      _5
    IL_00ea:  ldc.i4     0x1
    IL_00ef:  add
    IL_00f0:  ldc.i4     0x0
    IL_00f5:  stind.i1
    IL_00f6:  ldc.i4     0x0
    IL_00fb:  stloc      i
    IL_0101:  ldc.i4     0x0
    IL_0106:  ldc.i4     0x0
    IL_010b:  beq        IL_0115

    IL_0110:  br         IL_0180

    IL_0115:  ldloc      _3
    IL_011b:  call       void fibonacci._::_puts(uint8*)
    IL_0120:  ldloc      i
    IL_0126:  call       void fibonacci._::_puti(int32)
    IL_012b:  ldloc      _4
    IL_0131:  call       void fibonacci._::_puts(uint8*)
    IL_0136:  ldloc      i
    IL_013c:  call       int32 fibonacci._::_.fibonacci.fib(int32)
    IL_0141:  stloc      $0
    IL_0147:  ldloc      $0
    IL_014d:  call       void fibonacci._::_puti(int32)
    IL_0152:  ldloc      _5
    IL_0158:  call       void fibonacci._::_puts(uint8*)
    IL_015d:  ldloc      i
    IL_0163:  ldc.i4     0x1
    IL_0168:  add
    IL_0169:  stloc      $1
    IL_016f:  ldloc      $1
    IL_0175:  stloc      i
    IL_017b:  br         IL_0101

    IL_0180:  ret
  } // end of method _::_.fibonacci

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class fibonacci._


// =============================================================

// 
