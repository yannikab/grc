
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
.assembly qsort
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module qsort
// MVID: {0009374F-EBA0-4B09-BC60-227B55A9A504}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00330000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi qsort._
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
    IL_0000:  call       void qsort._::_.qsort()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.qsort.quicksort(int32* a,
                                                 int32 m,
                                                 int32 n) cil managed
  {
    // 
    .maxstack  22
    .locals init ([0] int32 i,
             [1] int32 j,
             [2] int32 temp,
             [3] int32 $10,
             [4] int32* $11,
             [5] int32 $12,
             [6] int32 $13,
             [7] int32 $14,
             [8] int32* $15,
             [9] int32 $16,
             [10] int32 $17,
             [11] int32* $18,
             [12] int32 $19,
             [13] int32 $20,
             [14] int32 $21,
             [15] int32* $22,
             [16] int32 $23,
             [17] int32 $24,
             [18] int32* $25,
             [19] int32 $26,
             [20] int32* $27,
             [21] int32 $28,
             [22] int32* $29,
             [23] int32 $30,
             [24] int32* $31,
             [25] int32 $32,
             [26] int32 $33)
    IL_0000:  ldarg      n
    IL_0006:  ldarg      m
    IL_000c:  ble        IL_0016

    IL_0011:  br         IL_0017

    IL_0016:  ret

    IL_0017:  ldarg      m
    IL_001d:  stloc      i
    IL_0023:  ldarg      n
    IL_0029:  stloc      j
    IL_002f:  ldloc      i
    IL_0035:  ldloc      j
    IL_003b:  ble        IL_0045

    IL_0040:  br         IL_02ac

    IL_0045:  ldloc      i
    IL_004b:  stloc      $10
    IL_0051:  ldarg      a
    IL_0057:  ldloc      $10
    IL_005d:  ldc.i4     0x4
    IL_0062:  mul
    IL_0063:  add
    IL_0064:  stloc      $11
    IL_006a:  ldarg      m
    IL_0070:  ldarg      n
    IL_0076:  add
    IL_0077:  stloc      $12
    IL_007d:  ldloc      $12
    IL_0083:  ldc.i4     0x2
    IL_0088:  div
    IL_0089:  stloc      $13
    IL_008f:  ldloc      $13
    IL_0095:  stloc      $14
    IL_009b:  ldarg      a
    IL_00a1:  ldloc      $14
    IL_00a7:  ldc.i4     0x4
    IL_00ac:  mul
    IL_00ad:  add
    IL_00ae:  stloc      $15
    IL_00b4:  ldloc      $11
    IL_00ba:  ldind.i4
    IL_00bb:  ldloc      $15
    IL_00c1:  ldind.i4
    IL_00c2:  blt        IL_00cc

    IL_00c7:  br         IL_00ef

    IL_00cc:  ldloc      i
    IL_00d2:  ldc.i4     0x1
    IL_00d7:  add
    IL_00d8:  stloc      $16
    IL_00de:  ldloc      $16
    IL_00e4:  stloc      i
    IL_00ea:  br         IL_0045

    IL_00ef:  ldloc      j
    IL_00f5:  stloc      $17
    IL_00fb:  ldarg      a
    IL_0101:  ldloc      $17
    IL_0107:  ldc.i4     0x4
    IL_010c:  mul
    IL_010d:  add
    IL_010e:  stloc      $18
    IL_0114:  ldarg      m
    IL_011a:  ldarg      n
    IL_0120:  add
    IL_0121:  stloc      $19
    IL_0127:  ldloc      $19
    IL_012d:  ldc.i4     0x2
    IL_0132:  div
    IL_0133:  stloc      $20
    IL_0139:  ldloc      $20
    IL_013f:  stloc      $21
    IL_0145:  ldarg      a
    IL_014b:  ldloc      $21
    IL_0151:  ldc.i4     0x4
    IL_0156:  mul
    IL_0157:  add
    IL_0158:  stloc      $22
    IL_015e:  ldloc      $18
    IL_0164:  ldind.i4
    IL_0165:  ldloc      $22
    IL_016b:  ldind.i4
    IL_016c:  bgt        IL_0176

    IL_0171:  br         IL_0199

    IL_0176:  ldloc      j
    IL_017c:  ldc.i4     0x1
    IL_0181:  sub
    IL_0182:  stloc      $23
    IL_0188:  ldloc      $23
    IL_018e:  stloc      j
    IL_0194:  br         IL_00ef

    IL_0199:  ldloc      i
    IL_019f:  ldloc      j
    IL_01a5:  ble        IL_01af

    IL_01aa:  br         IL_002f

    IL_01af:  ldloc      i
    IL_01b5:  stloc      $24
    IL_01bb:  ldarg      a
    IL_01c1:  ldloc      $24
    IL_01c7:  ldc.i4     0x4
    IL_01cc:  mul
    IL_01cd:  add
    IL_01ce:  stloc      $25
    IL_01d4:  ldloc      $25
    IL_01da:  ldind.i4
    IL_01db:  stloc      temp
    IL_01e1:  ldloc      i
    IL_01e7:  stloc      $26
    IL_01ed:  ldarg      a
    IL_01f3:  ldloc      $26
    IL_01f9:  ldc.i4     0x4
    IL_01fe:  mul
    IL_01ff:  add
    IL_0200:  stloc      $27
    IL_0206:  ldloc      j
    IL_020c:  stloc      $28
    IL_0212:  ldarg      a
    IL_0218:  ldloc      $28
    IL_021e:  ldc.i4     0x4
    IL_0223:  mul
    IL_0224:  add
    IL_0225:  stloc      $29
    IL_022b:  ldloc      $27
    IL_0231:  ldloc      $29
    IL_0237:  ldind.i4
    IL_0238:  stind.i4
    IL_0239:  ldloc      j
    IL_023f:  stloc      $30
    IL_0245:  ldarg      a
    IL_024b:  ldloc      $30
    IL_0251:  ldc.i4     0x4
    IL_0256:  mul
    IL_0257:  add
    IL_0258:  stloc      $31
    IL_025e:  ldloc      $31
    IL_0264:  ldloc      temp
    IL_026a:  stind.i4
    IL_026b:  ldloc      i
    IL_0271:  ldc.i4     0x1
    IL_0276:  add
    IL_0277:  stloc      $32
    IL_027d:  ldloc      $32
    IL_0283:  stloc      i
    IL_0289:  ldloc      j
    IL_028f:  ldc.i4     0x1
    IL_0294:  sub
    IL_0295:  stloc      $33
    IL_029b:  ldloc      $33
    IL_02a1:  stloc      j
    IL_02a7:  br         IL_002f

    IL_02ac:  ldarg      a
    IL_02b2:  ldarg      m
    IL_02b8:  ldloc      j
    IL_02be:  call       void qsort._::_.qsort.quicksort(int32*,
                                                         int32,
                                                         int32)
    IL_02c3:  ldarg      a
    IL_02c9:  ldloc      i
    IL_02cf:  ldarg      n
    IL_02d5:  call       void qsort._::_.qsort.quicksort(int32*,
                                                         int32,
                                                         int32)
    IL_02da:  ret
  } // end of method _::_.qsort.quicksort

  .method private static void  _.qsort.putArray(uint8* msg,
                                                int32 n,
                                                int32* x) cil managed
  {
    // 
    .maxstack  8
    .locals init ([0] int32 i,
             [1] int32 $7,
             [2] int32* $8,
             [3] int32 $9,
             [4] uint8* _4,
             [5] uint8* _5)
    IL_0000:  ldc.i4     0x3
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      _4
    IL_0010:  ldloc      _4
    IL_0016:  ldc.i4     0x0
    IL_001b:  add
    IL_001c:  ldc.i4     0x2c
    IL_0021:  stind.i1
    IL_0022:  ldloc      _4
    IL_0028:  ldc.i4     0x1
    IL_002d:  add
    IL_002e:  ldc.i4     0x20
    IL_0033:  stind.i1
    IL_0034:  ldloc      _4
    IL_003a:  ldc.i4     0x2
    IL_003f:  add
    IL_0040:  ldc.i4     0x0
    IL_0045:  stind.i1
    IL_0046:  ldc.i4     0x3
    IL_004b:  newarr     [mscorlib]System.Byte
    IL_0050:  stloc      _5
    IL_0056:  ldloc      _5
    IL_005c:  ldc.i4     0x0
    IL_0061:  add
    IL_0062:  ldc.i4     0xa
    IL_0067:  stind.i1
    IL_0068:  ldloc      _5
    IL_006e:  ldc.i4     0x1
    IL_0073:  add
    IL_0074:  ldc.i4     0x0
    IL_0079:  stind.i1
    IL_007a:  ldarg      msg
    IL_0080:  call       void qsort._::_puts(uint8*)
    IL_0085:  ldc.i4     0x0
    IL_008a:  stloc      i
    IL_0090:  ldloc      i
    IL_0096:  ldarg      n
    IL_009c:  blt        IL_00a6

    IL_00a1:  br         IL_011a

    IL_00a6:  ldloc      i
    IL_00ac:  ldc.i4     0x0
    IL_00b1:  bgt        IL_00bb

    IL_00b6:  br         IL_00c6

    IL_00bb:  ldloc      _4
    IL_00c1:  call       void qsort._::_puts(uint8*)
    IL_00c6:  ldloc      i
    IL_00cc:  stloc      $7
    IL_00d2:  ldarg      x
    IL_00d8:  ldloc      $7
    IL_00de:  ldc.i4     0x4
    IL_00e3:  mul
    IL_00e4:  add
    IL_00e5:  stloc      $8
    IL_00eb:  ldloc      $8
    IL_00f1:  ldind.i4
    IL_00f2:  call       void qsort._::_puti(int32)
    IL_00f7:  ldloc      i
    IL_00fd:  ldc.i4     0x1
    IL_0102:  add
    IL_0103:  stloc      $9
    IL_0109:  ldloc      $9
    IL_010f:  stloc      i
    IL_0115:  br         IL_0090

    IL_011a:  ldloc      _5
    IL_0120:  call       void qsort._::_puts(uint8*)
    IL_0125:  ret
  } // end of method _::_.qsort.putArray

  .method private static void  _.qsort() cil managed
  {
    // 
    .maxstack  8
    .locals init ([0] int32* a,
             [1] int32 i,
             [2] int32 seed,
             [3] int32 $0,
             [4] int32 $1,
             [5] int32 $2,
             [6] int32 $3,
             [7] int32 $4,
             [8] int32* $5,
             [9] int32 $6,
             [10] uint8* _10,
             [11] uint8* _11)
    IL_0000:  ldc.i4     0x10
    IL_0005:  newarr     [mscorlib]System.Int32
    IL_000a:  stloc      a
    IL_0010:  ldc.i4     0x10
    IL_0015:  newarr     [mscorlib]System.Byte
    IL_001a:  stloc      _10
    IL_0020:  ldloc      _10
    IL_0026:  ldc.i4     0x0
    IL_002b:  add
    IL_002c:  ldc.i4     0x49
    IL_0031:  stind.i1
    IL_0032:  ldloc      _10
    IL_0038:  ldc.i4     0x1
    IL_003d:  add
    IL_003e:  ldc.i4     0x6e
    IL_0043:  stind.i1
    IL_0044:  ldloc      _10
    IL_004a:  ldc.i4     0x2
    IL_004f:  add
    IL_0050:  ldc.i4     0x69
    IL_0055:  stind.i1
    IL_0056:  ldloc      _10
    IL_005c:  ldc.i4     0x3
    IL_0061:  add
    IL_0062:  ldc.i4     0x74
    IL_0067:  stind.i1
    IL_0068:  ldloc      _10
    IL_006e:  ldc.i4     0x4
    IL_0073:  add
    IL_0074:  ldc.i4     0x69
    IL_0079:  stind.i1
    IL_007a:  ldloc      _10
    IL_0080:  ldc.i4     0x5
    IL_0085:  add
    IL_0086:  ldc.i4     0x61
    IL_008b:  stind.i1
    IL_008c:  ldloc      _10
    IL_0092:  ldc.i4     0x6
    IL_0097:  add
    IL_0098:  ldc.i4     0x6c
    IL_009d:  stind.i1
    IL_009e:  ldloc      _10
    IL_00a4:  ldc.i4     0x7
    IL_00a9:  add
    IL_00aa:  ldc.i4     0x20
    IL_00af:  stind.i1
    IL_00b0:  ldloc      _10
    IL_00b6:  ldc.i4     0x8
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x61
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      _10
    IL_00c8:  ldc.i4     0x9
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x72
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      _10
    IL_00da:  ldc.i4     0xa
    IL_00df:  add
    IL_00e0:  ldc.i4     0x72
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      _10
    IL_00ec:  ldc.i4     0xb
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x61
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      _10
    IL_00fe:  ldc.i4     0xc
    IL_0103:  add
    IL_0104:  ldc.i4     0x79
    IL_0109:  stind.i1
    IL_010a:  ldloc      _10
    IL_0110:  ldc.i4     0xd
    IL_0115:  add
    IL_0116:  ldc.i4     0x3a
    IL_011b:  stind.i1
    IL_011c:  ldloc      _10
    IL_0122:  ldc.i4     0xe
    IL_0127:  add
    IL_0128:  ldc.i4     0x20
    IL_012d:  stind.i1
    IL_012e:  ldloc      _10
    IL_0134:  ldc.i4     0xf
    IL_0139:  add
    IL_013a:  ldc.i4     0x0
    IL_013f:  stind.i1
    IL_0140:  ldc.i4     0xf
    IL_0145:  newarr     [mscorlib]System.Byte
    IL_014a:  stloc      _11
    IL_0150:  ldloc      _11
    IL_0156:  ldc.i4     0x0
    IL_015b:  add
    IL_015c:  ldc.i4     0x53
    IL_0161:  stind.i1
    IL_0162:  ldloc      _11
    IL_0168:  ldc.i4     0x1
    IL_016d:  add
    IL_016e:  ldc.i4     0x6f
    IL_0173:  stind.i1
    IL_0174:  ldloc      _11
    IL_017a:  ldc.i4     0x2
    IL_017f:  add
    IL_0180:  ldc.i4     0x72
    IL_0185:  stind.i1
    IL_0186:  ldloc      _11
    IL_018c:  ldc.i4     0x3
    IL_0191:  add
    IL_0192:  ldc.i4     0x74
    IL_0197:  stind.i1
    IL_0198:  ldloc      _11
    IL_019e:  ldc.i4     0x4
    IL_01a3:  add
    IL_01a4:  ldc.i4     0x65
    IL_01a9:  stind.i1
    IL_01aa:  ldloc      _11
    IL_01b0:  ldc.i4     0x5
    IL_01b5:  add
    IL_01b6:  ldc.i4     0x64
    IL_01bb:  stind.i1
    IL_01bc:  ldloc      _11
    IL_01c2:  ldc.i4     0x6
    IL_01c7:  add
    IL_01c8:  ldc.i4     0x20
    IL_01cd:  stind.i1
    IL_01ce:  ldloc      _11
    IL_01d4:  ldc.i4     0x7
    IL_01d9:  add
    IL_01da:  ldc.i4     0x61
    IL_01df:  stind.i1
    IL_01e0:  ldloc      _11
    IL_01e6:  ldc.i4     0x8
    IL_01eb:  add
    IL_01ec:  ldc.i4     0x72
    IL_01f1:  stind.i1
    IL_01f2:  ldloc      _11
    IL_01f8:  ldc.i4     0x9
    IL_01fd:  add
    IL_01fe:  ldc.i4     0x72
    IL_0203:  stind.i1
    IL_0204:  ldloc      _11
    IL_020a:  ldc.i4     0xa
    IL_020f:  add
    IL_0210:  ldc.i4     0x61
    IL_0215:  stind.i1
    IL_0216:  ldloc      _11
    IL_021c:  ldc.i4     0xb
    IL_0221:  add
    IL_0222:  ldc.i4     0x79
    IL_0227:  stind.i1
    IL_0228:  ldloc      _11
    IL_022e:  ldc.i4     0xc
    IL_0233:  add
    IL_0234:  ldc.i4     0x3a
    IL_0239:  stind.i1
    IL_023a:  ldloc      _11
    IL_0240:  ldc.i4     0xd
    IL_0245:  add
    IL_0246:  ldc.i4     0x20
    IL_024b:  stind.i1
    IL_024c:  ldloc      _11
    IL_0252:  ldc.i4     0xe
    IL_0257:  add
    IL_0258:  ldc.i4     0x0
    IL_025d:  stind.i1
    IL_025e:  ldc.i4     0x41
    IL_0263:  stloc      seed
    IL_0269:  ldc.i4     0x0
    IL_026e:  stloc      i
    IL_0274:  ldloc      i
    IL_027a:  ldc.i4     0x10
    IL_027f:  blt        IL_0289

    IL_0284:  br         IL_0333

    IL_0289:  ldloc      seed
    IL_028f:  ldc.i4     0x89
    IL_0294:  mul
    IL_0295:  stloc      $0
    IL_029b:  ldloc      $0
    IL_02a1:  ldc.i4     0xdc
    IL_02a6:  add
    IL_02a7:  stloc      $1
    IL_02ad:  ldloc      $1
    IL_02b3:  ldloc      i
    IL_02b9:  add
    IL_02ba:  stloc      $2
    IL_02c0:  ldloc      $2
    IL_02c6:  ldc.i4     0x65
    IL_02cb:  rem
    IL_02cc:  stloc      $3
    IL_02d2:  ldloc      $3
    IL_02d8:  stloc      seed
    IL_02de:  ldloc      i
    IL_02e4:  stloc      $4
    IL_02ea:  ldloc      a
    IL_02f0:  ldloc      $4
    IL_02f6:  ldc.i4     0x4
    IL_02fb:  mul
    IL_02fc:  add
    IL_02fd:  stloc      $5
    IL_0303:  ldloc      $5
    IL_0309:  ldloc      seed
    IL_030f:  stind.i4
    IL_0310:  ldloc      i
    IL_0316:  ldc.i4     0x1
    IL_031b:  add
    IL_031c:  stloc      $6
    IL_0322:  ldloc      $6
    IL_0328:  stloc      i
    IL_032e:  br         IL_0274

    IL_0333:  ldloc      _10
    IL_0339:  ldc.i4     0x10
    IL_033e:  ldloc      a
    IL_0344:  call       void qsort._::_.qsort.putArray(uint8*,
                                                        int32,
                                                        int32*)
    IL_0349:  ldloc      a
    IL_034f:  ldc.i4     0x0
    IL_0354:  ldc.i4     0xf
    IL_0359:  call       void qsort._::_.qsort.quicksort(int32*,
                                                         int32,
                                                         int32)
    IL_035e:  ldloc      _11
    IL_0364:  ldc.i4     0x10
    IL_0369:  ldloc      a
    IL_036f:  call       void qsort._::_.qsort.putArray(uint8*,
                                                        int32,
                                                        int32*)
    IL_0374:  ret
  } // end of method _::_.qsort

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class qsort._


// =============================================================

// 
