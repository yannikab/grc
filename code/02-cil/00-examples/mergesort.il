
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
.assembly mergesort
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module mergesort
// MVID: {68AD34AA-5185-4C5D-BE38-A890D5F377A4}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00710000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi mergesort._
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
    IL_0000:  call       void mergesort._::_.mergesort()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.mergesort.sort(uint8* t,
                                                int32 a,
                                                int32 b) cil managed
  {
    // 
    .maxstack  19
    .locals init ([0] int32 i,
             [1] int32 j,
             [2] int32 k,
             [3] int32 m,
             [4] uint8* s,
             [5] int32 $3,
             [6] int32 $4,
             [7] int32 $5,
             [8] int32 $6,
             [9] uint8* $7,
             [10] int32 $8,
             [11] uint8* $9,
             [12] int32 $10,
             [13] int32 $11,
             [14] int32 $12,
             [15] int32 $13,
             [16] int32 $14,
             [17] int32 $15,
             [18] uint8* $16,
             [19] int32 $17,
             [20] uint8* $18,
             [21] int32 $19,
             [22] int32 $20,
             [23] uint8* $21,
             [24] int32 $22,
             [25] uint8* $23,
             [26] int32 $24,
             [27] uint8* $25,
             [28] int32 $26,
             [29] uint8* $27,
             [30] int32 $28,
             [31] int32 $29,
             [32] uint8* $30,
             [33] int32 $31,
             [34] uint8* $32,
             [35] int32 $33,
             [36] int32 $34)
    IL_0000:  ldc.i4     0x400
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      s
    IL_0010:  ldarg      b
    IL_0016:  ldarg      a
    IL_001c:  ble        IL_0026

    IL_0021:  br         IL_0027

    IL_0026:  ret

    IL_0027:  ldarg      a
    IL_002d:  ldarg      b
    IL_0033:  add
    IL_0034:  stloc      $3
    IL_003a:  ldloc      $3
    IL_0040:  ldc.i4     0x2
    IL_0045:  div
    IL_0046:  stloc      $4
    IL_004c:  ldloc      $4
    IL_0052:  stloc      m
    IL_0058:  ldarg      t
    IL_005e:  ldarg      a
    IL_0064:  ldloc      m
    IL_006a:  call       void mergesort._::_.mergesort.sort(uint8*,
                                                            int32,
                                                            int32)
    IL_006f:  ldloc      m
    IL_0075:  ldc.i4     0x1
    IL_007a:  add
    IL_007b:  stloc      $5
    IL_0081:  ldarg      t
    IL_0087:  ldloc      $5
    IL_008d:  ldarg      b
    IL_0093:  call       void mergesort._::_.mergesort.sort(uint8*,
                                                            int32,
                                                            int32)
    IL_0098:  ldloc      m
    IL_009e:  stloc      i
    IL_00a4:  ldloc      i
    IL_00aa:  ldarg      a
    IL_00b0:  bge        IL_00ba

    IL_00b5:  br         IL_0129

    IL_00ba:  ldloc      i
    IL_00c0:  stloc      $6
    IL_00c6:  ldloc      s
    IL_00cc:  ldloc      $6
    IL_00d2:  add
    IL_00d3:  stloc      $7
    IL_00d9:  ldloc      i
    IL_00df:  stloc      $8
    IL_00e5:  ldarg      t
    IL_00eb:  ldloc      $8
    IL_00f1:  add
    IL_00f2:  stloc      $9
    IL_00f8:  ldloc      $7
    IL_00fe:  ldloc      $9
    IL_0104:  ldind.i1
    IL_0105:  stind.i1
    IL_0106:  ldloc      i
    IL_010c:  ldc.i4     0x1
    IL_0111:  sub
    IL_0112:  stloc      $10
    IL_0118:  ldloc      $10
    IL_011e:  stloc      i
    IL_0124:  br         IL_00a4

    IL_0129:  ldloc      m
    IL_012f:  ldc.i4     0x1
    IL_0134:  add
    IL_0135:  stloc      $11
    IL_013b:  ldloc      $11
    IL_0141:  stloc      j
    IL_0147:  ldloc      j
    IL_014d:  ldarg      b
    IL_0153:  ble        IL_015d

    IL_0158:  br         IL_0204

    IL_015d:  ldarg      b
    IL_0163:  ldloc      m
    IL_0169:  add
    IL_016a:  stloc      $12
    IL_0170:  ldloc      $12
    IL_0176:  ldc.i4     0x1
    IL_017b:  add
    IL_017c:  stloc      $13
    IL_0182:  ldloc      $13
    IL_0188:  ldloc      j
    IL_018e:  sub
    IL_018f:  stloc      $14
    IL_0195:  ldloc      $14
    IL_019b:  stloc      $15
    IL_01a1:  ldloc      s
    IL_01a7:  ldloc      $15
    IL_01ad:  add
    IL_01ae:  stloc      $16
    IL_01b4:  ldloc      j
    IL_01ba:  stloc      $17
    IL_01c0:  ldarg      t
    IL_01c6:  ldloc      $17
    IL_01cc:  add
    IL_01cd:  stloc      $18
    IL_01d3:  ldloc      $16
    IL_01d9:  ldloc      $18
    IL_01df:  ldind.i1
    IL_01e0:  stind.i1
    IL_01e1:  ldloc      j
    IL_01e7:  ldc.i4     0x1
    IL_01ec:  add
    IL_01ed:  stloc      $19
    IL_01f3:  ldloc      $19
    IL_01f9:  stloc      j
    IL_01ff:  br         IL_0147

    IL_0204:  ldarg      a
    IL_020a:  stloc      i
    IL_0210:  ldarg      b
    IL_0216:  stloc      j
    IL_021c:  ldarg      a
    IL_0222:  stloc      k
    IL_0228:  ldloc      k
    IL_022e:  ldarg      b
    IL_0234:  ble        IL_023e

    IL_0239:  br         IL_0390

    IL_023e:  ldloc      i
    IL_0244:  stloc      $20
    IL_024a:  ldloc      s
    IL_0250:  ldloc      $20
    IL_0256:  add
    IL_0257:  stloc      $21
    IL_025d:  ldloc      j
    IL_0263:  stloc      $22
    IL_0269:  ldloc      s
    IL_026f:  ldloc      $22
    IL_0275:  add
    IL_0276:  stloc      $23
    IL_027c:  ldloc      $21
    IL_0282:  ldind.i1
    IL_0283:  ldloc      $23
    IL_0289:  ldind.i1
    IL_028a:  blt        IL_0294

    IL_028f:  br         IL_0303

    IL_0294:  ldloc      k
    IL_029a:  stloc      $24
    IL_02a0:  ldarg      t
    IL_02a6:  ldloc      $24
    IL_02ac:  add
    IL_02ad:  stloc      $25
    IL_02b3:  ldloc      i
    IL_02b9:  stloc      $26
    IL_02bf:  ldloc      s
    IL_02c5:  ldloc      $26
    IL_02cb:  add
    IL_02cc:  stloc      $27
    IL_02d2:  ldloc      $25
    IL_02d8:  ldloc      $27
    IL_02de:  ldind.i1
    IL_02df:  stind.i1
    IL_02e0:  ldloc      i
    IL_02e6:  ldc.i4     0x1
    IL_02eb:  add
    IL_02ec:  stloc      $28
    IL_02f2:  ldloc      $28
    IL_02f8:  stloc      i
    IL_02fe:  br         IL_036d

    IL_0303:  ldloc      k
    IL_0309:  stloc      $29
    IL_030f:  ldarg      t
    IL_0315:  ldloc      $29
    IL_031b:  add
    IL_031c:  stloc      $30
    IL_0322:  ldloc      j
    IL_0328:  stloc      $31
    IL_032e:  ldloc      s
    IL_0334:  ldloc      $31
    IL_033a:  add
    IL_033b:  stloc      $32
    IL_0341:  ldloc      $30
    IL_0347:  ldloc      $32
    IL_034d:  ldind.i1
    IL_034e:  stind.i1
    IL_034f:  ldloc      j
    IL_0355:  ldc.i4     0x1
    IL_035a:  sub
    IL_035b:  stloc      $33
    IL_0361:  ldloc      $33
    IL_0367:  stloc      j
    IL_036d:  ldloc      k
    IL_0373:  ldc.i4     0x1
    IL_0378:  add
    IL_0379:  stloc      $34
    IL_037f:  ldloc      $34
    IL_0385:  stloc      k
    IL_038b:  br         IL_0228

    IL_0390:  ret
  } // end of method _::_.mergesort.sort

  .method private static void  _.mergesort() cil managed
  {
    // 
    .maxstack  5
    .locals init ([0] uint8* b,
             [1] int32 $0,
             [2] int32 $1,
             [3] int32 $2,
             [4] uint8* _4,
             [5] uint8* _5,
             [6] uint8* _6,
             [7] uint8* _7,
             [8] uint8* _8)
    IL_0000:  ldc.i4     0x400
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      b
    IL_0010:  ldc.i4     0x17
    IL_0015:  newarr     [mscorlib]System.Byte
    IL_001a:  stloc      _4
    IL_0020:  ldloc      _4
    IL_0026:  ldc.i4     0x0
    IL_002b:  add
    IL_002c:  ldc.i4     0x45
    IL_0031:  stind.i1
    IL_0032:  ldloc      _4
    IL_0038:  ldc.i4     0x1
    IL_003d:  add
    IL_003e:  ldc.i4     0x6e
    IL_0043:  stind.i1
    IL_0044:  ldloc      _4
    IL_004a:  ldc.i4     0x2
    IL_004f:  add
    IL_0050:  ldc.i4     0x74
    IL_0055:  stind.i1
    IL_0056:  ldloc      _4
    IL_005c:  ldc.i4     0x3
    IL_0061:  add
    IL_0062:  ldc.i4     0x65
    IL_0067:  stind.i1
    IL_0068:  ldloc      _4
    IL_006e:  ldc.i4     0x4
    IL_0073:  add
    IL_0074:  ldc.i4     0x72
    IL_0079:  stind.i1
    IL_007a:  ldloc      _4
    IL_0080:  ldc.i4     0x5
    IL_0085:  add
    IL_0086:  ldc.i4     0x20
    IL_008b:  stind.i1
    IL_008c:  ldloc      _4
    IL_0092:  ldc.i4     0x6
    IL_0097:  add
    IL_0098:  ldc.i4     0x73
    IL_009d:  stind.i1
    IL_009e:  ldloc      _4
    IL_00a4:  ldc.i4     0x7
    IL_00a9:  add
    IL_00aa:  ldc.i4     0x74
    IL_00af:  stind.i1
    IL_00b0:  ldloc      _4
    IL_00b6:  ldc.i4     0x8
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x72
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      _4
    IL_00c8:  ldc.i4     0x9
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x69
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      _4
    IL_00da:  ldc.i4     0xa
    IL_00df:  add
    IL_00e0:  ldc.i4     0x6e
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      _4
    IL_00ec:  ldc.i4     0xb
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x67
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      _4
    IL_00fe:  ldc.i4     0xc
    IL_0103:  add
    IL_0104:  ldc.i4     0x20
    IL_0109:  stind.i1
    IL_010a:  ldloc      _4
    IL_0110:  ldc.i4     0xd
    IL_0115:  add
    IL_0116:  ldc.i4     0x74
    IL_011b:  stind.i1
    IL_011c:  ldloc      _4
    IL_0122:  ldc.i4     0xe
    IL_0127:  add
    IL_0128:  ldc.i4     0x6f
    IL_012d:  stind.i1
    IL_012e:  ldloc      _4
    IL_0134:  ldc.i4     0xf
    IL_0139:  add
    IL_013a:  ldc.i4     0x20
    IL_013f:  stind.i1
    IL_0140:  ldloc      _4
    IL_0146:  ldc.i4     0x10
    IL_014b:  add
    IL_014c:  ldc.i4     0x73
    IL_0151:  stind.i1
    IL_0152:  ldloc      _4
    IL_0158:  ldc.i4     0x11
    IL_015d:  add
    IL_015e:  ldc.i4     0x6f
    IL_0163:  stind.i1
    IL_0164:  ldloc      _4
    IL_016a:  ldc.i4     0x12
    IL_016f:  add
    IL_0170:  ldc.i4     0x72
    IL_0175:  stind.i1
    IL_0176:  ldloc      _4
    IL_017c:  ldc.i4     0x13
    IL_0181:  add
    IL_0182:  ldc.i4     0x74
    IL_0187:  stind.i1
    IL_0188:  ldloc      _4
    IL_018e:  ldc.i4     0x14
    IL_0193:  add
    IL_0194:  ldc.i4     0x3a
    IL_0199:  stind.i1
    IL_019a:  ldloc      _4
    IL_01a0:  ldc.i4     0x15
    IL_01a5:  add
    IL_01a6:  ldc.i4     0x20
    IL_01ab:  stind.i1
    IL_01ac:  ldloc      _4
    IL_01b2:  ldc.i4     0x16
    IL_01b7:  add
    IL_01b8:  ldc.i4     0x0
    IL_01bd:  stind.i1
    IL_01be:  ldc.i4     0x17
    IL_01c3:  newarr     [mscorlib]System.Byte
    IL_01c8:  stloc      _5
    IL_01ce:  ldloc      _5
    IL_01d4:  ldc.i4     0x0
    IL_01d9:  add
    IL_01da:  ldc.i4     0x53
    IL_01df:  stind.i1
    IL_01e0:  ldloc      _5
    IL_01e6:  ldc.i4     0x1
    IL_01eb:  add
    IL_01ec:  ldc.i4     0x74
    IL_01f1:  stind.i1
    IL_01f2:  ldloc      _5
    IL_01f8:  ldc.i4     0x2
    IL_01fd:  add
    IL_01fe:  ldc.i4     0x72
    IL_0203:  stind.i1
    IL_0204:  ldloc      _5
    IL_020a:  ldc.i4     0x3
    IL_020f:  add
    IL_0210:  ldc.i4     0x69
    IL_0215:  stind.i1
    IL_0216:  ldloc      _5
    IL_021c:  ldc.i4     0x4
    IL_0221:  add
    IL_0222:  ldc.i4     0x6e
    IL_0227:  stind.i1
    IL_0228:  ldloc      _5
    IL_022e:  ldc.i4     0x5
    IL_0233:  add
    IL_0234:  ldc.i4     0x67
    IL_0239:  stind.i1
    IL_023a:  ldloc      _5
    IL_0240:  ldc.i4     0x6
    IL_0245:  add
    IL_0246:  ldc.i4     0x20
    IL_024b:  stind.i1
    IL_024c:  ldloc      _5
    IL_0252:  ldc.i4     0x7
    IL_0257:  add
    IL_0258:  ldc.i4     0x61
    IL_025d:  stind.i1
    IL_025e:  ldloc      _5
    IL_0264:  ldc.i4     0x8
    IL_0269:  add
    IL_026a:  ldc.i4     0x66
    IL_026f:  stind.i1
    IL_0270:  ldloc      _5
    IL_0276:  ldc.i4     0x9
    IL_027b:  add
    IL_027c:  ldc.i4     0x74
    IL_0281:  stind.i1
    IL_0282:  ldloc      _5
    IL_0288:  ldc.i4     0xa
    IL_028d:  add
    IL_028e:  ldc.i4     0x65
    IL_0293:  stind.i1
    IL_0294:  ldloc      _5
    IL_029a:  ldc.i4     0xb
    IL_029f:  add
    IL_02a0:  ldc.i4     0x72
    IL_02a5:  stind.i1
    IL_02a6:  ldloc      _5
    IL_02ac:  ldc.i4     0xc
    IL_02b1:  add
    IL_02b2:  ldc.i4     0x20
    IL_02b7:  stind.i1
    IL_02b8:  ldloc      _5
    IL_02be:  ldc.i4     0xd
    IL_02c3:  add
    IL_02c4:  ldc.i4     0x73
    IL_02c9:  stind.i1
    IL_02ca:  ldloc      _5
    IL_02d0:  ldc.i4     0xe
    IL_02d5:  add
    IL_02d6:  ldc.i4     0x6f
    IL_02db:  stind.i1
    IL_02dc:  ldloc      _5
    IL_02e2:  ldc.i4     0xf
    IL_02e7:  add
    IL_02e8:  ldc.i4     0x72
    IL_02ed:  stind.i1
    IL_02ee:  ldloc      _5
    IL_02f4:  ldc.i4     0x10
    IL_02f9:  add
    IL_02fa:  ldc.i4     0x74
    IL_02ff:  stind.i1
    IL_0300:  ldloc      _5
    IL_0306:  ldc.i4     0x11
    IL_030b:  add
    IL_030c:  ldc.i4     0x69
    IL_0311:  stind.i1
    IL_0312:  ldloc      _5
    IL_0318:  ldc.i4     0x12
    IL_031d:  add
    IL_031e:  ldc.i4     0x6e
    IL_0323:  stind.i1
    IL_0324:  ldloc      _5
    IL_032a:  ldc.i4     0x13
    IL_032f:  add
    IL_0330:  ldc.i4     0x67
    IL_0335:  stind.i1
    IL_0336:  ldloc      _5
    IL_033c:  ldc.i4     0x14
    IL_0341:  add
    IL_0342:  ldc.i4     0x3a
    IL_0347:  stind.i1
    IL_0348:  ldloc      _5
    IL_034e:  ldc.i4     0x15
    IL_0353:  add
    IL_0354:  ldc.i4     0x20
    IL_0359:  stind.i1
    IL_035a:  ldloc      _5
    IL_0360:  ldc.i4     0x16
    IL_0365:  add
    IL_0366:  ldc.i4     0x0
    IL_036b:  stind.i1
    IL_036c:  ldc.i4     0x3
    IL_0371:  newarr     [mscorlib]System.Byte
    IL_0376:  stloc      _6
    IL_037c:  ldloc      _6
    IL_0382:  ldc.i4     0x0
    IL_0387:  add
    IL_0388:  ldc.i4     0xa
    IL_038d:  stind.i1
    IL_038e:  ldloc      _6
    IL_0394:  ldc.i4     0x1
    IL_0399:  add
    IL_039a:  ldc.i4     0x0
    IL_039f:  stind.i1
    IL_03a0:  ldc.i4     0x3
    IL_03a5:  newarr     [mscorlib]System.Byte
    IL_03aa:  stloc      _7
    IL_03b0:  ldloc      _7
    IL_03b6:  ldc.i4     0x0
    IL_03bb:  add
    IL_03bc:  ldc.i4     0xa
    IL_03c1:  stind.i1
    IL_03c2:  ldloc      _7
    IL_03c8:  ldc.i4     0x1
    IL_03cd:  add
    IL_03ce:  ldc.i4     0x0
    IL_03d3:  stind.i1
    IL_03d4:  ldc.i4     0x17
    IL_03d9:  newarr     [mscorlib]System.Byte
    IL_03de:  stloc      _8
    IL_03e4:  ldloc      _8
    IL_03ea:  ldc.i4     0x0
    IL_03ef:  add
    IL_03f0:  ldc.i4     0x45
    IL_03f5:  stind.i1
    IL_03f6:  ldloc      _8
    IL_03fc:  ldc.i4     0x1
    IL_0401:  add
    IL_0402:  ldc.i4     0x6e
    IL_0407:  stind.i1
    IL_0408:  ldloc      _8
    IL_040e:  ldc.i4     0x2
    IL_0413:  add
    IL_0414:  ldc.i4     0x74
    IL_0419:  stind.i1
    IL_041a:  ldloc      _8
    IL_0420:  ldc.i4     0x3
    IL_0425:  add
    IL_0426:  ldc.i4     0x65
    IL_042b:  stind.i1
    IL_042c:  ldloc      _8
    IL_0432:  ldc.i4     0x4
    IL_0437:  add
    IL_0438:  ldc.i4     0x72
    IL_043d:  stind.i1
    IL_043e:  ldloc      _8
    IL_0444:  ldc.i4     0x5
    IL_0449:  add
    IL_044a:  ldc.i4     0x20
    IL_044f:  stind.i1
    IL_0450:  ldloc      _8
    IL_0456:  ldc.i4     0x6
    IL_045b:  add
    IL_045c:  ldc.i4     0x73
    IL_0461:  stind.i1
    IL_0462:  ldloc      _8
    IL_0468:  ldc.i4     0x7
    IL_046d:  add
    IL_046e:  ldc.i4     0x74
    IL_0473:  stind.i1
    IL_0474:  ldloc      _8
    IL_047a:  ldc.i4     0x8
    IL_047f:  add
    IL_0480:  ldc.i4     0x72
    IL_0485:  stind.i1
    IL_0486:  ldloc      _8
    IL_048c:  ldc.i4     0x9
    IL_0491:  add
    IL_0492:  ldc.i4     0x69
    IL_0497:  stind.i1
    IL_0498:  ldloc      _8
    IL_049e:  ldc.i4     0xa
    IL_04a3:  add
    IL_04a4:  ldc.i4     0x6e
    IL_04a9:  stind.i1
    IL_04aa:  ldloc      _8
    IL_04b0:  ldc.i4     0xb
    IL_04b5:  add
    IL_04b6:  ldc.i4     0x67
    IL_04bb:  stind.i1
    IL_04bc:  ldloc      _8
    IL_04c2:  ldc.i4     0xc
    IL_04c7:  add
    IL_04c8:  ldc.i4     0x20
    IL_04cd:  stind.i1
    IL_04ce:  ldloc      _8
    IL_04d4:  ldc.i4     0xd
    IL_04d9:  add
    IL_04da:  ldc.i4     0x74
    IL_04df:  stind.i1
    IL_04e0:  ldloc      _8
    IL_04e6:  ldc.i4     0xe
    IL_04eb:  add
    IL_04ec:  ldc.i4     0x6f
    IL_04f1:  stind.i1
    IL_04f2:  ldloc      _8
    IL_04f8:  ldc.i4     0xf
    IL_04fd:  add
    IL_04fe:  ldc.i4     0x20
    IL_0503:  stind.i1
    IL_0504:  ldloc      _8
    IL_050a:  ldc.i4     0x10
    IL_050f:  add
    IL_0510:  ldc.i4     0x73
    IL_0515:  stind.i1
    IL_0516:  ldloc      _8
    IL_051c:  ldc.i4     0x11
    IL_0521:  add
    IL_0522:  ldc.i4     0x6f
    IL_0527:  stind.i1
    IL_0528:  ldloc      _8
    IL_052e:  ldc.i4     0x12
    IL_0533:  add
    IL_0534:  ldc.i4     0x72
    IL_0539:  stind.i1
    IL_053a:  ldloc      _8
    IL_0540:  ldc.i4     0x13
    IL_0545:  add
    IL_0546:  ldc.i4     0x74
    IL_054b:  stind.i1
    IL_054c:  ldloc      _8
    IL_0552:  ldc.i4     0x14
    IL_0557:  add
    IL_0558:  ldc.i4     0x3a
    IL_055d:  stind.i1
    IL_055e:  ldloc      _8
    IL_0564:  ldc.i4     0x15
    IL_0569:  add
    IL_056a:  ldc.i4     0x20
    IL_056f:  stind.i1
    IL_0570:  ldloc      _8
    IL_0576:  ldc.i4     0x16
    IL_057b:  add
    IL_057c:  ldc.i4     0x0
    IL_0581:  stind.i1
    IL_0582:  ldloc      _4
    IL_0588:  call       void mergesort._::_puts(uint8*)
    IL_058d:  ldc.i4     0x400
    IL_0592:  ldloc      b
    IL_0598:  call       void mergesort._::_gets(int32,
                                                 uint8*)
    IL_059d:  ldloc      b
    IL_05a3:  call       int32 mergesort._::_strlen(uint8*)
    IL_05a8:  stloc      $0
    IL_05ae:  ldloc      $0
    IL_05b4:  ldc.i4     0x0
    IL_05b9:  bgt        IL_05c3

    IL_05be:  br         IL_0648

    IL_05c3:  ldloc      b
    IL_05c9:  call       int32 mergesort._::_strlen(uint8*)
    IL_05ce:  stloc      $1
    IL_05d4:  ldloc      $1
    IL_05da:  ldc.i4     0x1
    IL_05df:  sub
    IL_05e0:  stloc      $2
    IL_05e6:  ldloc      b
    IL_05ec:  ldc.i4     0x0
    IL_05f1:  ldloc      $2
    IL_05f7:  call       void mergesort._::_.mergesort.sort(uint8*,
                                                            int32,
                                                            int32)
    IL_05fc:  ldloc      _5
    IL_0602:  call       void mergesort._::_puts(uint8*)
    IL_0607:  ldloc      b
    IL_060d:  call       void mergesort._::_puts(uint8*)
    IL_0612:  ldloc      _6
    IL_0618:  call       void mergesort._::_puts(uint8*)
    IL_061d:  ldloc      _7
    IL_0623:  call       void mergesort._::_puts(uint8*)
    IL_0628:  ldloc      _8
    IL_062e:  call       void mergesort._::_puts(uint8*)
    IL_0633:  ldc.i4     0x400
    IL_0638:  ldloc      b
    IL_063e:  call       void mergesort._::_gets(int32,
                                                 uint8*)
    IL_0643:  br         IL_059d

    IL_0648:  ret
  } // end of method _::_.mergesort

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class mergesort._


// =============================================================

// 
