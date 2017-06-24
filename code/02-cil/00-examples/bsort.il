
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
.assembly bsort
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module bsort
// MVID: {DF9D0A06-6E6B-4710-BAA0-FAAA95220A77}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x002E0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi bsort._
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
    IL_0000:  call       void bsort._::_.bsort()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.bsort.bsort(int32 n,
                                             int32* x) cil managed
  {
    // 
    .maxstack  10
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3,
             int32* V_4,
             int32 V_5,
             int32 V_6,
             int32* V_7,
             int32 V_8,
             int32* V_9,
             int32 V_10,
             int32 V_11,
             int32* V_12,
             int32 V_13)
    IL_0000:  ldc.i4     0x1
    IL_0005:  stloc      V_0
    IL_000b:  ldloc      V_0
    IL_0011:  ldc.i4     0x0
    IL_0016:  bgt        IL_0020

    IL_001b:  br         IL_0172

    IL_0020:  ldc.i4     0x0
    IL_0025:  stloc      V_0
    IL_002b:  ldc.i4     0x0
    IL_0030:  stloc      V_1
    IL_0036:  ldarg      n
    IL_003c:  ldc.i4     0x1
    IL_0041:  sub
    IL_0042:  stloc      V_2
    IL_0048:  ldloc      V_1
    IL_004e:  ldloc      V_2
    IL_0054:  blt        IL_005e

    IL_0059:  br         IL_000b

    IL_005e:  ldloc      V_1
    IL_0064:  stloc      V_3
    IL_006a:  ldarg      x
    IL_0070:  ldloc      V_3
    IL_0076:  ldc.i4     0x4
    IL_007b:  mul
    IL_007c:  add
    IL_007d:  stloc      V_4
    IL_0083:  ldloc      V_1
    IL_0089:  ldc.i4     0x1
    IL_008e:  add
    IL_008f:  stloc      V_5
    IL_0095:  ldloc      V_5
    IL_009b:  stloc      V_6
    IL_00a1:  ldarg      x
    IL_00a7:  ldloc      V_6
    IL_00ad:  ldc.i4     0x4
    IL_00b2:  mul
    IL_00b3:  add
    IL_00b4:  stloc      V_7
    IL_00ba:  ldloc      V_4
    IL_00c0:  ldind.i4
    IL_00c1:  ldloc      V_7
    IL_00c7:  ldind.i4
    IL_00c8:  bgt        IL_00d2

    IL_00cd:  br         IL_014a

    IL_00d2:  ldloc      V_1
    IL_00d8:  stloc      V_8
    IL_00de:  ldarg      x
    IL_00e4:  ldloc      V_8
    IL_00ea:  ldc.i4     0x4
    IL_00ef:  mul
    IL_00f0:  add
    IL_00f1:  stloc      V_9
    IL_00f7:  ldloc      V_1
    IL_00fd:  ldc.i4     0x1
    IL_0102:  add
    IL_0103:  stloc      V_10
    IL_0109:  ldloc      V_10
    IL_010f:  stloc      V_11
    IL_0115:  ldarg      x
    IL_011b:  ldloc      V_11
    IL_0121:  ldc.i4     0x4
    IL_0126:  mul
    IL_0127:  add
    IL_0128:  stloc      V_12
    IL_012e:  ldloc      V_9
    IL_0134:  ldloc      V_12
    IL_013a:  call       void bsort._::_.bsort.bsort.swap(int32&,
                                                          int32&)
    IL_013f:  ldc.i4     0x1
    IL_0144:  stloc      V_0
    IL_014a:  ldloc      V_1
    IL_0150:  ldc.i4     0x1
    IL_0155:  add
    IL_0156:  stloc      V_13
    IL_015c:  ldloc      V_13
    IL_0162:  stloc      V_1
    IL_0168:  br         IL_0036

    IL_016d:  br         IL_000b

    IL_0172:  ret
  } // end of method _::_.bsort.bsort

  .method private static void  _.bsort.bsort.swap(int32& x,
                                                  int32& y) cil managed
  {
    // 
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  ldarg      x
    IL_0006:  ldind.i4
    IL_0007:  stloc      V_0
    IL_000d:  ldarg      x
    IL_0013:  ldarg      y
    IL_0019:  ldind.i4
    IL_001a:  stind.i4
    IL_001b:  ldarg      y
    IL_0021:  ldloc      V_0
    IL_0027:  stind.i4
    IL_0028:  ret
  } // end of method _::_.bsort.bsort.swap

  .method private static void  _.bsort.putArray(uint8* msg,
                                                int32 n,
                                                int32* x) cil managed
  {
    // 
    .maxstack  8
    .locals init (int32 V_0,
             int32 V_1,
             int32* V_2,
             int32 V_3,
             uint8* V_4,
             uint8* V_5)
    IL_0000:  ldc.i4     0x3
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      V_4
    IL_0010:  ldloc      V_4
    IL_0016:  ldc.i4     0x0
    IL_001b:  add
    IL_001c:  ldc.i4     0x2c
    IL_0021:  stind.i1
    IL_0022:  ldloc      V_4
    IL_0028:  ldc.i4     0x1
    IL_002d:  add
    IL_002e:  ldc.i4     0x20
    IL_0033:  stind.i1
    IL_0034:  ldloc      V_4
    IL_003a:  ldc.i4     0x2
    IL_003f:  add
    IL_0040:  ldc.i4     0x0
    IL_0045:  stind.i1
    IL_0046:  ldc.i4     0x3
    IL_004b:  newarr     [mscorlib]System.Byte
    IL_0050:  stloc      V_5
    IL_0056:  ldloc      V_5
    IL_005c:  ldc.i4     0x0
    IL_0061:  add
    IL_0062:  ldc.i4     0xa
    IL_0067:  stind.i1
    IL_0068:  ldloc      V_5
    IL_006e:  ldc.i4     0x1
    IL_0073:  add
    IL_0074:  ldc.i4     0x0
    IL_0079:  stind.i1
    IL_007a:  ldarg      msg
    IL_0080:  call       void bsort._::_puts(uint8*)
    IL_0085:  ldc.i4     0x0
    IL_008a:  stloc      V_0
    IL_0090:  ldloc      V_0
    IL_0096:  ldarg      n
    IL_009c:  blt        IL_00a6

    IL_00a1:  br         IL_011a

    IL_00a6:  ldloc      V_0
    IL_00ac:  ldc.i4     0x0
    IL_00b1:  bgt        IL_00bb

    IL_00b6:  br         IL_00c6

    IL_00bb:  ldloc      V_4
    IL_00c1:  call       void bsort._::_puts(uint8*)
    IL_00c6:  ldloc      V_0
    IL_00cc:  stloc      V_1
    IL_00d2:  ldarg      x
    IL_00d8:  ldloc      V_1
    IL_00de:  ldc.i4     0x4
    IL_00e3:  mul
    IL_00e4:  add
    IL_00e5:  stloc      V_2
    IL_00eb:  ldloc      V_2
    IL_00f1:  ldind.i4
    IL_00f2:  call       void bsort._::_puti(int32)
    IL_00f7:  ldloc      V_0
    IL_00fd:  ldc.i4     0x1
    IL_0102:  add
    IL_0103:  stloc      V_3
    IL_0109:  ldloc      V_3
    IL_010f:  stloc      V_0
    IL_0115:  br         IL_0090

    IL_011a:  ldloc      V_5
    IL_0120:  call       void bsort._::_puts(uint8*)
    IL_0125:  ret
  } // end of method _::_.bsort.putArray

  .method private static void  _.bsort() cil managed
  {
    // 
    .maxstack  8
    .locals init (int32 V_0,
             int32 V_1,
             int32* V_2,
             int32 V_3,
             int32 V_4,
             int32 V_5,
             int32 V_6,
             int32 V_7,
             int32* V_8,
             int32 V_9,
             uint8* V_10,
             uint8* V_11)
    IL_0000:  ldc.i4     0x10
    IL_0005:  newarr     [mscorlib]System.Int32
    IL_000a:  stloc      V_2
    IL_0010:  ldc.i4     0x10
    IL_0015:  newarr     [mscorlib]System.Byte
    IL_001a:  stloc      V_10
    IL_0020:  ldloc      V_10
    IL_0026:  ldc.i4     0x0
    IL_002b:  add
    IL_002c:  ldc.i4     0x49
    IL_0031:  stind.i1
    IL_0032:  ldloc      V_10
    IL_0038:  ldc.i4     0x1
    IL_003d:  add
    IL_003e:  ldc.i4     0x6e
    IL_0043:  stind.i1
    IL_0044:  ldloc      V_10
    IL_004a:  ldc.i4     0x2
    IL_004f:  add
    IL_0050:  ldc.i4     0x69
    IL_0055:  stind.i1
    IL_0056:  ldloc      V_10
    IL_005c:  ldc.i4     0x3
    IL_0061:  add
    IL_0062:  ldc.i4     0x74
    IL_0067:  stind.i1
    IL_0068:  ldloc      V_10
    IL_006e:  ldc.i4     0x4
    IL_0073:  add
    IL_0074:  ldc.i4     0x69
    IL_0079:  stind.i1
    IL_007a:  ldloc      V_10
    IL_0080:  ldc.i4     0x5
    IL_0085:  add
    IL_0086:  ldc.i4     0x61
    IL_008b:  stind.i1
    IL_008c:  ldloc      V_10
    IL_0092:  ldc.i4     0x6
    IL_0097:  add
    IL_0098:  ldc.i4     0x6c
    IL_009d:  stind.i1
    IL_009e:  ldloc      V_10
    IL_00a4:  ldc.i4     0x7
    IL_00a9:  add
    IL_00aa:  ldc.i4     0x20
    IL_00af:  stind.i1
    IL_00b0:  ldloc      V_10
    IL_00b6:  ldc.i4     0x8
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x61
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      V_10
    IL_00c8:  ldc.i4     0x9
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x72
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      V_10
    IL_00da:  ldc.i4     0xa
    IL_00df:  add
    IL_00e0:  ldc.i4     0x72
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      V_10
    IL_00ec:  ldc.i4     0xb
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x61
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      V_10
    IL_00fe:  ldc.i4     0xc
    IL_0103:  add
    IL_0104:  ldc.i4     0x79
    IL_0109:  stind.i1
    IL_010a:  ldloc      V_10
    IL_0110:  ldc.i4     0xd
    IL_0115:  add
    IL_0116:  ldc.i4     0x3a
    IL_011b:  stind.i1
    IL_011c:  ldloc      V_10
    IL_0122:  ldc.i4     0xe
    IL_0127:  add
    IL_0128:  ldc.i4     0x20
    IL_012d:  stind.i1
    IL_012e:  ldloc      V_10
    IL_0134:  ldc.i4     0xf
    IL_0139:  add
    IL_013a:  ldc.i4     0x0
    IL_013f:  stind.i1
    IL_0140:  ldc.i4     0xf
    IL_0145:  newarr     [mscorlib]System.Byte
    IL_014a:  stloc      V_11
    IL_0150:  ldloc      V_11
    IL_0156:  ldc.i4     0x0
    IL_015b:  add
    IL_015c:  ldc.i4     0x53
    IL_0161:  stind.i1
    IL_0162:  ldloc      V_11
    IL_0168:  ldc.i4     0x1
    IL_016d:  add
    IL_016e:  ldc.i4     0x6f
    IL_0173:  stind.i1
    IL_0174:  ldloc      V_11
    IL_017a:  ldc.i4     0x2
    IL_017f:  add
    IL_0180:  ldc.i4     0x72
    IL_0185:  stind.i1
    IL_0186:  ldloc      V_11
    IL_018c:  ldc.i4     0x3
    IL_0191:  add
    IL_0192:  ldc.i4     0x74
    IL_0197:  stind.i1
    IL_0198:  ldloc      V_11
    IL_019e:  ldc.i4     0x4
    IL_01a3:  add
    IL_01a4:  ldc.i4     0x65
    IL_01a9:  stind.i1
    IL_01aa:  ldloc      V_11
    IL_01b0:  ldc.i4     0x5
    IL_01b5:  add
    IL_01b6:  ldc.i4     0x64
    IL_01bb:  stind.i1
    IL_01bc:  ldloc      V_11
    IL_01c2:  ldc.i4     0x6
    IL_01c7:  add
    IL_01c8:  ldc.i4     0x20
    IL_01cd:  stind.i1
    IL_01ce:  ldloc      V_11
    IL_01d4:  ldc.i4     0x7
    IL_01d9:  add
    IL_01da:  ldc.i4     0x61
    IL_01df:  stind.i1
    IL_01e0:  ldloc      V_11
    IL_01e6:  ldc.i4     0x8
    IL_01eb:  add
    IL_01ec:  ldc.i4     0x72
    IL_01f1:  stind.i1
    IL_01f2:  ldloc      V_11
    IL_01f8:  ldc.i4     0x9
    IL_01fd:  add
    IL_01fe:  ldc.i4     0x72
    IL_0203:  stind.i1
    IL_0204:  ldloc      V_11
    IL_020a:  ldc.i4     0xa
    IL_020f:  add
    IL_0210:  ldc.i4     0x61
    IL_0215:  stind.i1
    IL_0216:  ldloc      V_11
    IL_021c:  ldc.i4     0xb
    IL_0221:  add
    IL_0222:  ldc.i4     0x79
    IL_0227:  stind.i1
    IL_0228:  ldloc      V_11
    IL_022e:  ldc.i4     0xc
    IL_0233:  add
    IL_0234:  ldc.i4     0x3a
    IL_0239:  stind.i1
    IL_023a:  ldloc      V_11
    IL_0240:  ldc.i4     0xd
    IL_0245:  add
    IL_0246:  ldc.i4     0x20
    IL_024b:  stind.i1
    IL_024c:  ldloc      V_11
    IL_0252:  ldc.i4     0xe
    IL_0257:  add
    IL_0258:  ldc.i4     0x0
    IL_025d:  stind.i1
    IL_025e:  ldc.i4     0x41
    IL_0263:  stloc      V_1
    IL_0269:  ldc.i4     0x0
    IL_026e:  stloc      V_0
    IL_0274:  ldloc      V_0
    IL_027a:  ldc.i4     0x10
    IL_027f:  blt        IL_0289

    IL_0284:  br         IL_0333

    IL_0289:  ldloc      V_1
    IL_028f:  ldc.i4     0x89
    IL_0294:  mul
    IL_0295:  stloc      V_3
    IL_029b:  ldloc      V_3
    IL_02a1:  ldc.i4     0xdc
    IL_02a6:  add
    IL_02a7:  stloc      V_4
    IL_02ad:  ldloc      V_4
    IL_02b3:  ldloc      V_0
    IL_02b9:  add
    IL_02ba:  stloc      V_5
    IL_02c0:  ldloc      V_5
    IL_02c6:  ldc.i4     0x65
    IL_02cb:  rem
    IL_02cc:  stloc      V_6
    IL_02d2:  ldloc      V_6
    IL_02d8:  stloc      V_1
    IL_02de:  ldloc      V_0
    IL_02e4:  stloc      V_7
    IL_02ea:  ldloc      V_2
    IL_02f0:  ldloc      V_7
    IL_02f6:  ldc.i4     0x4
    IL_02fb:  mul
    IL_02fc:  add
    IL_02fd:  stloc      V_8
    IL_0303:  ldloc      V_8
    IL_0309:  ldloc      V_1
    IL_030f:  stind.i4
    IL_0310:  ldloc      V_0
    IL_0316:  ldc.i4     0x1
    IL_031b:  add
    IL_031c:  stloc      V_9
    IL_0322:  ldloc      V_9
    IL_0328:  stloc      V_0
    IL_032e:  br         IL_0274

    IL_0333:  ldloc      V_10
    IL_0339:  ldc.i4     0x10
    IL_033e:  ldloc      V_2
    IL_0344:  call       void bsort._::_.bsort.putArray(uint8*,
                                                        int32,
                                                        int32*)
    IL_0349:  ldc.i4     0x10
    IL_034e:  ldloc      V_2
    IL_0354:  call       void bsort._::_.bsort.bsort(int32,
                                                     int32*)
    IL_0359:  ldloc      V_11
    IL_035f:  ldc.i4     0x10
    IL_0364:  ldloc      V_2
    IL_036a:  call       void bsort._::_.bsort.putArray(uint8*,
                                                        int32,
                                                        int32*)
    IL_036f:  ret
  } // end of method _::_.bsort

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class bsort._


// =============================================================

// 
