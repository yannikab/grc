
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
// MVID: {DCDAAC5E-3F84-4400-A2FE-0C1664FD4AE9}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x001A0000


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
    IL_0000:  call       void mergesort._::_.mergesort()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.mergesort.sort(uint8* t,
                                                int32 a,
                                                int32 b) cil managed
  {
    // 
    .maxstack  19
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3,
             uint8* V_4,
             int32 V_5,
             int32 V_6,
             int32 V_7,
             int32 V_8,
             uint8* V_9,
             int32 V_10,
             uint8* V_11,
             int32 V_12,
             int32 V_13,
             int32 V_14,
             int32 V_15,
             int32 V_16,
             int32 V_17,
             uint8* V_18,
             int32 V_19,
             uint8* V_20,
             int32 V_21,
             int32 V_22,
             uint8* V_23,
             int32 V_24,
             uint8* V_25,
             int32 V_26,
             uint8* V_27,
             int32 V_28,
             uint8* V_29,
             int32 V_30,
             int32 V_31,
             uint8* V_32,
             int32 V_33,
             uint8* V_34,
             int32 V_35,
             int32 V_36)
    IL_0000:  ldc.i4     0x400
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      V_4
    IL_0010:  ldarg      b
    IL_0016:  ldarg      a
    IL_001c:  ble        IL_0026

    IL_0021:  br         IL_0027

    IL_0026:  ret

    IL_0027:  ldarg      a
    IL_002d:  ldarg      b
    IL_0033:  add
    IL_0034:  stloc      V_5
    IL_003a:  ldloc      V_5
    IL_0040:  ldc.i4     0x2
    IL_0045:  div
    IL_0046:  stloc      V_6
    IL_004c:  ldloc      V_6
    IL_0052:  stloc      V_3
    IL_0058:  ldarg      t
    IL_005e:  ldarg      a
    IL_0064:  ldloc      V_3
    IL_006a:  call       void mergesort._::_.mergesort.sort(uint8*,
                                                            int32,
                                                            int32)
    IL_006f:  ldloc      V_3
    IL_0075:  ldc.i4     0x1
    IL_007a:  add
    IL_007b:  stloc      V_7
    IL_0081:  ldarg      t
    IL_0087:  ldloc      V_7
    IL_008d:  ldarg      b
    IL_0093:  call       void mergesort._::_.mergesort.sort(uint8*,
                                                            int32,
                                                            int32)
    IL_0098:  ldloc      V_3
    IL_009e:  stloc      V_0
    IL_00a4:  ldloc      V_0
    IL_00aa:  ldarg      a
    IL_00b0:  bge        IL_00ba

    IL_00b5:  br         IL_0129

    IL_00ba:  ldloc      V_0
    IL_00c0:  stloc      V_8
    IL_00c6:  ldloc      V_4
    IL_00cc:  ldloc      V_8
    IL_00d2:  add
    IL_00d3:  stloc      V_9
    IL_00d9:  ldloc      V_0
    IL_00df:  stloc      V_10
    IL_00e5:  ldarg      t
    IL_00eb:  ldloc      V_10
    IL_00f1:  add
    IL_00f2:  stloc      V_11
    IL_00f8:  ldloc      V_9
    IL_00fe:  ldloc      V_11
    IL_0104:  ldind.i1
    IL_0105:  stind.i1
    IL_0106:  ldloc      V_0
    IL_010c:  ldc.i4     0x1
    IL_0111:  sub
    IL_0112:  stloc      V_12
    IL_0118:  ldloc      V_12
    IL_011e:  stloc      V_0
    IL_0124:  br         IL_00a4

    IL_0129:  ldloc      V_3
    IL_012f:  ldc.i4     0x1
    IL_0134:  add
    IL_0135:  stloc      V_13
    IL_013b:  ldloc      V_13
    IL_0141:  stloc      V_1
    IL_0147:  ldloc      V_1
    IL_014d:  ldarg      b
    IL_0153:  ble        IL_015d

    IL_0158:  br         IL_0204

    IL_015d:  ldarg      b
    IL_0163:  ldloc      V_3
    IL_0169:  add
    IL_016a:  stloc      V_14
    IL_0170:  ldloc      V_14
    IL_0176:  ldc.i4     0x1
    IL_017b:  add
    IL_017c:  stloc      V_15
    IL_0182:  ldloc      V_15
    IL_0188:  ldloc      V_1
    IL_018e:  sub
    IL_018f:  stloc      V_16
    IL_0195:  ldloc      V_16
    IL_019b:  stloc      V_17
    IL_01a1:  ldloc      V_4
    IL_01a7:  ldloc      V_17
    IL_01ad:  add
    IL_01ae:  stloc      V_18
    IL_01b4:  ldloc      V_1
    IL_01ba:  stloc      V_19
    IL_01c0:  ldarg      t
    IL_01c6:  ldloc      V_19
    IL_01cc:  add
    IL_01cd:  stloc      V_20
    IL_01d3:  ldloc      V_18
    IL_01d9:  ldloc      V_20
    IL_01df:  ldind.i1
    IL_01e0:  stind.i1
    IL_01e1:  ldloc      V_1
    IL_01e7:  ldc.i4     0x1
    IL_01ec:  add
    IL_01ed:  stloc      V_21
    IL_01f3:  ldloc      V_21
    IL_01f9:  stloc      V_1
    IL_01ff:  br         IL_0147

    IL_0204:  ldarg      a
    IL_020a:  stloc      V_0
    IL_0210:  ldarg      b
    IL_0216:  stloc      V_1
    IL_021c:  ldarg      a
    IL_0222:  stloc      V_2
    IL_0228:  ldloc      V_2
    IL_022e:  ldarg      b
    IL_0234:  ble        IL_023e

    IL_0239:  br         IL_0390

    IL_023e:  ldloc      V_0
    IL_0244:  stloc      V_22
    IL_024a:  ldloc      V_4
    IL_0250:  ldloc      V_22
    IL_0256:  add
    IL_0257:  stloc      V_23
    IL_025d:  ldloc      V_1
    IL_0263:  stloc      V_24
    IL_0269:  ldloc      V_4
    IL_026f:  ldloc      V_24
    IL_0275:  add
    IL_0276:  stloc      V_25
    IL_027c:  ldloc      V_23
    IL_0282:  ldind.i1
    IL_0283:  ldloc      V_25
    IL_0289:  ldind.i1
    IL_028a:  blt        IL_0294

    IL_028f:  br         IL_0303

    IL_0294:  ldloc      V_2
    IL_029a:  stloc      V_26
    IL_02a0:  ldarg      t
    IL_02a6:  ldloc      V_26
    IL_02ac:  add
    IL_02ad:  stloc      V_27
    IL_02b3:  ldloc      V_0
    IL_02b9:  stloc      V_28
    IL_02bf:  ldloc      V_4
    IL_02c5:  ldloc      V_28
    IL_02cb:  add
    IL_02cc:  stloc      V_29
    IL_02d2:  ldloc      V_27
    IL_02d8:  ldloc      V_29
    IL_02de:  ldind.i1
    IL_02df:  stind.i1
    IL_02e0:  ldloc      V_0
    IL_02e6:  ldc.i4     0x1
    IL_02eb:  add
    IL_02ec:  stloc      V_30
    IL_02f2:  ldloc      V_30
    IL_02f8:  stloc      V_0
    IL_02fe:  br         IL_036d

    IL_0303:  ldloc      V_2
    IL_0309:  stloc      V_31
    IL_030f:  ldarg      t
    IL_0315:  ldloc      V_31
    IL_031b:  add
    IL_031c:  stloc      V_32
    IL_0322:  ldloc      V_1
    IL_0328:  stloc      V_33
    IL_032e:  ldloc      V_4
    IL_0334:  ldloc      V_33
    IL_033a:  add
    IL_033b:  stloc      V_34
    IL_0341:  ldloc      V_32
    IL_0347:  ldloc      V_34
    IL_034d:  ldind.i1
    IL_034e:  stind.i1
    IL_034f:  ldloc      V_1
    IL_0355:  ldc.i4     0x1
    IL_035a:  sub
    IL_035b:  stloc      V_35
    IL_0361:  ldloc      V_35
    IL_0367:  stloc      V_1
    IL_036d:  ldloc      V_2
    IL_0373:  ldc.i4     0x1
    IL_0378:  add
    IL_0379:  stloc      V_36
    IL_037f:  ldloc      V_36
    IL_0385:  stloc      V_2
    IL_038b:  br         IL_0228

    IL_0390:  ret
  } // end of method _::_.mergesort.sort

  .method private static void  _.mergesort() cil managed
  {
    // 
    .maxstack  5
    .locals init (uint8* V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3,
             uint8* V_4,
             uint8* V_5,
             uint8* V_6,
             uint8* V_7,
             uint8* V_8)
    IL_0000:  ldc.i4     0x400
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      V_0
    IL_0010:  ldc.i4     0x17
    IL_0015:  newarr     [mscorlib]System.Byte
    IL_001a:  stloc      V_4
    IL_0020:  ldloc      V_4
    IL_0026:  ldc.i4     0x0
    IL_002b:  add
    IL_002c:  ldc.i4     0x45
    IL_0031:  stind.i1
    IL_0032:  ldloc      V_4
    IL_0038:  ldc.i4     0x1
    IL_003d:  add
    IL_003e:  ldc.i4     0x6e
    IL_0043:  stind.i1
    IL_0044:  ldloc      V_4
    IL_004a:  ldc.i4     0x2
    IL_004f:  add
    IL_0050:  ldc.i4     0x74
    IL_0055:  stind.i1
    IL_0056:  ldloc      V_4
    IL_005c:  ldc.i4     0x3
    IL_0061:  add
    IL_0062:  ldc.i4     0x65
    IL_0067:  stind.i1
    IL_0068:  ldloc      V_4
    IL_006e:  ldc.i4     0x4
    IL_0073:  add
    IL_0074:  ldc.i4     0x72
    IL_0079:  stind.i1
    IL_007a:  ldloc      V_4
    IL_0080:  ldc.i4     0x5
    IL_0085:  add
    IL_0086:  ldc.i4     0x20
    IL_008b:  stind.i1
    IL_008c:  ldloc      V_4
    IL_0092:  ldc.i4     0x6
    IL_0097:  add
    IL_0098:  ldc.i4     0x73
    IL_009d:  stind.i1
    IL_009e:  ldloc      V_4
    IL_00a4:  ldc.i4     0x7
    IL_00a9:  add
    IL_00aa:  ldc.i4     0x74
    IL_00af:  stind.i1
    IL_00b0:  ldloc      V_4
    IL_00b6:  ldc.i4     0x8
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x72
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      V_4
    IL_00c8:  ldc.i4     0x9
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x69
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      V_4
    IL_00da:  ldc.i4     0xa
    IL_00df:  add
    IL_00e0:  ldc.i4     0x6e
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      V_4
    IL_00ec:  ldc.i4     0xb
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x67
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      V_4
    IL_00fe:  ldc.i4     0xc
    IL_0103:  add
    IL_0104:  ldc.i4     0x20
    IL_0109:  stind.i1
    IL_010a:  ldloc      V_4
    IL_0110:  ldc.i4     0xd
    IL_0115:  add
    IL_0116:  ldc.i4     0x74
    IL_011b:  stind.i1
    IL_011c:  ldloc      V_4
    IL_0122:  ldc.i4     0xe
    IL_0127:  add
    IL_0128:  ldc.i4     0x6f
    IL_012d:  stind.i1
    IL_012e:  ldloc      V_4
    IL_0134:  ldc.i4     0xf
    IL_0139:  add
    IL_013a:  ldc.i4     0x20
    IL_013f:  stind.i1
    IL_0140:  ldloc      V_4
    IL_0146:  ldc.i4     0x10
    IL_014b:  add
    IL_014c:  ldc.i4     0x73
    IL_0151:  stind.i1
    IL_0152:  ldloc      V_4
    IL_0158:  ldc.i4     0x11
    IL_015d:  add
    IL_015e:  ldc.i4     0x6f
    IL_0163:  stind.i1
    IL_0164:  ldloc      V_4
    IL_016a:  ldc.i4     0x12
    IL_016f:  add
    IL_0170:  ldc.i4     0x72
    IL_0175:  stind.i1
    IL_0176:  ldloc      V_4
    IL_017c:  ldc.i4     0x13
    IL_0181:  add
    IL_0182:  ldc.i4     0x74
    IL_0187:  stind.i1
    IL_0188:  ldloc      V_4
    IL_018e:  ldc.i4     0x14
    IL_0193:  add
    IL_0194:  ldc.i4     0x3a
    IL_0199:  stind.i1
    IL_019a:  ldloc      V_4
    IL_01a0:  ldc.i4     0x15
    IL_01a5:  add
    IL_01a6:  ldc.i4     0x20
    IL_01ab:  stind.i1
    IL_01ac:  ldloc      V_4
    IL_01b2:  ldc.i4     0x16
    IL_01b7:  add
    IL_01b8:  ldc.i4     0x0
    IL_01bd:  stind.i1
    IL_01be:  ldc.i4     0x17
    IL_01c3:  newarr     [mscorlib]System.Byte
    IL_01c8:  stloc      V_5
    IL_01ce:  ldloc      V_5
    IL_01d4:  ldc.i4     0x0
    IL_01d9:  add
    IL_01da:  ldc.i4     0x53
    IL_01df:  stind.i1
    IL_01e0:  ldloc      V_5
    IL_01e6:  ldc.i4     0x1
    IL_01eb:  add
    IL_01ec:  ldc.i4     0x74
    IL_01f1:  stind.i1
    IL_01f2:  ldloc      V_5
    IL_01f8:  ldc.i4     0x2
    IL_01fd:  add
    IL_01fe:  ldc.i4     0x72
    IL_0203:  stind.i1
    IL_0204:  ldloc      V_5
    IL_020a:  ldc.i4     0x3
    IL_020f:  add
    IL_0210:  ldc.i4     0x69
    IL_0215:  stind.i1
    IL_0216:  ldloc      V_5
    IL_021c:  ldc.i4     0x4
    IL_0221:  add
    IL_0222:  ldc.i4     0x6e
    IL_0227:  stind.i1
    IL_0228:  ldloc      V_5
    IL_022e:  ldc.i4     0x5
    IL_0233:  add
    IL_0234:  ldc.i4     0x67
    IL_0239:  stind.i1
    IL_023a:  ldloc      V_5
    IL_0240:  ldc.i4     0x6
    IL_0245:  add
    IL_0246:  ldc.i4     0x20
    IL_024b:  stind.i1
    IL_024c:  ldloc      V_5
    IL_0252:  ldc.i4     0x7
    IL_0257:  add
    IL_0258:  ldc.i4     0x61
    IL_025d:  stind.i1
    IL_025e:  ldloc      V_5
    IL_0264:  ldc.i4     0x8
    IL_0269:  add
    IL_026a:  ldc.i4     0x66
    IL_026f:  stind.i1
    IL_0270:  ldloc      V_5
    IL_0276:  ldc.i4     0x9
    IL_027b:  add
    IL_027c:  ldc.i4     0x74
    IL_0281:  stind.i1
    IL_0282:  ldloc      V_5
    IL_0288:  ldc.i4     0xa
    IL_028d:  add
    IL_028e:  ldc.i4     0x65
    IL_0293:  stind.i1
    IL_0294:  ldloc      V_5
    IL_029a:  ldc.i4     0xb
    IL_029f:  add
    IL_02a0:  ldc.i4     0x72
    IL_02a5:  stind.i1
    IL_02a6:  ldloc      V_5
    IL_02ac:  ldc.i4     0xc
    IL_02b1:  add
    IL_02b2:  ldc.i4     0x20
    IL_02b7:  stind.i1
    IL_02b8:  ldloc      V_5
    IL_02be:  ldc.i4     0xd
    IL_02c3:  add
    IL_02c4:  ldc.i4     0x73
    IL_02c9:  stind.i1
    IL_02ca:  ldloc      V_5
    IL_02d0:  ldc.i4     0xe
    IL_02d5:  add
    IL_02d6:  ldc.i4     0x6f
    IL_02db:  stind.i1
    IL_02dc:  ldloc      V_5
    IL_02e2:  ldc.i4     0xf
    IL_02e7:  add
    IL_02e8:  ldc.i4     0x72
    IL_02ed:  stind.i1
    IL_02ee:  ldloc      V_5
    IL_02f4:  ldc.i4     0x10
    IL_02f9:  add
    IL_02fa:  ldc.i4     0x74
    IL_02ff:  stind.i1
    IL_0300:  ldloc      V_5
    IL_0306:  ldc.i4     0x11
    IL_030b:  add
    IL_030c:  ldc.i4     0x69
    IL_0311:  stind.i1
    IL_0312:  ldloc      V_5
    IL_0318:  ldc.i4     0x12
    IL_031d:  add
    IL_031e:  ldc.i4     0x6e
    IL_0323:  stind.i1
    IL_0324:  ldloc      V_5
    IL_032a:  ldc.i4     0x13
    IL_032f:  add
    IL_0330:  ldc.i4     0x67
    IL_0335:  stind.i1
    IL_0336:  ldloc      V_5
    IL_033c:  ldc.i4     0x14
    IL_0341:  add
    IL_0342:  ldc.i4     0x3a
    IL_0347:  stind.i1
    IL_0348:  ldloc      V_5
    IL_034e:  ldc.i4     0x15
    IL_0353:  add
    IL_0354:  ldc.i4     0x20
    IL_0359:  stind.i1
    IL_035a:  ldloc      V_5
    IL_0360:  ldc.i4     0x16
    IL_0365:  add
    IL_0366:  ldc.i4     0x0
    IL_036b:  stind.i1
    IL_036c:  ldc.i4     0x3
    IL_0371:  newarr     [mscorlib]System.Byte
    IL_0376:  stloc      V_6
    IL_037c:  ldloc      V_6
    IL_0382:  ldc.i4     0x0
    IL_0387:  add
    IL_0388:  ldc.i4     0xa
    IL_038d:  stind.i1
    IL_038e:  ldloc      V_6
    IL_0394:  ldc.i4     0x1
    IL_0399:  add
    IL_039a:  ldc.i4     0x0
    IL_039f:  stind.i1
    IL_03a0:  ldc.i4     0x3
    IL_03a5:  newarr     [mscorlib]System.Byte
    IL_03aa:  stloc      V_7
    IL_03b0:  ldloc      V_7
    IL_03b6:  ldc.i4     0x0
    IL_03bb:  add
    IL_03bc:  ldc.i4     0xa
    IL_03c1:  stind.i1
    IL_03c2:  ldloc      V_7
    IL_03c8:  ldc.i4     0x1
    IL_03cd:  add
    IL_03ce:  ldc.i4     0x0
    IL_03d3:  stind.i1
    IL_03d4:  ldc.i4     0x17
    IL_03d9:  newarr     [mscorlib]System.Byte
    IL_03de:  stloc      V_8
    IL_03e4:  ldloc      V_8
    IL_03ea:  ldc.i4     0x0
    IL_03ef:  add
    IL_03f0:  ldc.i4     0x45
    IL_03f5:  stind.i1
    IL_03f6:  ldloc      V_8
    IL_03fc:  ldc.i4     0x1
    IL_0401:  add
    IL_0402:  ldc.i4     0x6e
    IL_0407:  stind.i1
    IL_0408:  ldloc      V_8
    IL_040e:  ldc.i4     0x2
    IL_0413:  add
    IL_0414:  ldc.i4     0x74
    IL_0419:  stind.i1
    IL_041a:  ldloc      V_8
    IL_0420:  ldc.i4     0x3
    IL_0425:  add
    IL_0426:  ldc.i4     0x65
    IL_042b:  stind.i1
    IL_042c:  ldloc      V_8
    IL_0432:  ldc.i4     0x4
    IL_0437:  add
    IL_0438:  ldc.i4     0x72
    IL_043d:  stind.i1
    IL_043e:  ldloc      V_8
    IL_0444:  ldc.i4     0x5
    IL_0449:  add
    IL_044a:  ldc.i4     0x20
    IL_044f:  stind.i1
    IL_0450:  ldloc      V_8
    IL_0456:  ldc.i4     0x6
    IL_045b:  add
    IL_045c:  ldc.i4     0x73
    IL_0461:  stind.i1
    IL_0462:  ldloc      V_8
    IL_0468:  ldc.i4     0x7
    IL_046d:  add
    IL_046e:  ldc.i4     0x74
    IL_0473:  stind.i1
    IL_0474:  ldloc      V_8
    IL_047a:  ldc.i4     0x8
    IL_047f:  add
    IL_0480:  ldc.i4     0x72
    IL_0485:  stind.i1
    IL_0486:  ldloc      V_8
    IL_048c:  ldc.i4     0x9
    IL_0491:  add
    IL_0492:  ldc.i4     0x69
    IL_0497:  stind.i1
    IL_0498:  ldloc      V_8
    IL_049e:  ldc.i4     0xa
    IL_04a3:  add
    IL_04a4:  ldc.i4     0x6e
    IL_04a9:  stind.i1
    IL_04aa:  ldloc      V_8
    IL_04b0:  ldc.i4     0xb
    IL_04b5:  add
    IL_04b6:  ldc.i4     0x67
    IL_04bb:  stind.i1
    IL_04bc:  ldloc      V_8
    IL_04c2:  ldc.i4     0xc
    IL_04c7:  add
    IL_04c8:  ldc.i4     0x20
    IL_04cd:  stind.i1
    IL_04ce:  ldloc      V_8
    IL_04d4:  ldc.i4     0xd
    IL_04d9:  add
    IL_04da:  ldc.i4     0x74
    IL_04df:  stind.i1
    IL_04e0:  ldloc      V_8
    IL_04e6:  ldc.i4     0xe
    IL_04eb:  add
    IL_04ec:  ldc.i4     0x6f
    IL_04f1:  stind.i1
    IL_04f2:  ldloc      V_8
    IL_04f8:  ldc.i4     0xf
    IL_04fd:  add
    IL_04fe:  ldc.i4     0x20
    IL_0503:  stind.i1
    IL_0504:  ldloc      V_8
    IL_050a:  ldc.i4     0x10
    IL_050f:  add
    IL_0510:  ldc.i4     0x73
    IL_0515:  stind.i1
    IL_0516:  ldloc      V_8
    IL_051c:  ldc.i4     0x11
    IL_0521:  add
    IL_0522:  ldc.i4     0x6f
    IL_0527:  stind.i1
    IL_0528:  ldloc      V_8
    IL_052e:  ldc.i4     0x12
    IL_0533:  add
    IL_0534:  ldc.i4     0x72
    IL_0539:  stind.i1
    IL_053a:  ldloc      V_8
    IL_0540:  ldc.i4     0x13
    IL_0545:  add
    IL_0546:  ldc.i4     0x74
    IL_054b:  stind.i1
    IL_054c:  ldloc      V_8
    IL_0552:  ldc.i4     0x14
    IL_0557:  add
    IL_0558:  ldc.i4     0x3a
    IL_055d:  stind.i1
    IL_055e:  ldloc      V_8
    IL_0564:  ldc.i4     0x15
    IL_0569:  add
    IL_056a:  ldc.i4     0x20
    IL_056f:  stind.i1
    IL_0570:  ldloc      V_8
    IL_0576:  ldc.i4     0x16
    IL_057b:  add
    IL_057c:  ldc.i4     0x0
    IL_0581:  stind.i1
    IL_0582:  ldloc      V_4
    IL_0588:  call       void mergesort._::_puts(uint8*)
    IL_058d:  ldc.i4     0x400
    IL_0592:  ldloc      V_0
    IL_0598:  call       void mergesort._::_gets(int32,
                                                 uint8*)
    IL_059d:  ldloc      V_0
    IL_05a3:  call       int32 mergesort._::_strlen(uint8*)
    IL_05a8:  stloc      V_1
    IL_05ae:  ldloc      V_1
    IL_05b4:  ldc.i4     0x0
    IL_05b9:  bgt        IL_05c3

    IL_05be:  br         IL_0648

    IL_05c3:  ldloc      V_0
    IL_05c9:  call       int32 mergesort._::_strlen(uint8*)
    IL_05ce:  stloc      V_2
    IL_05d4:  ldloc      V_2
    IL_05da:  ldc.i4     0x1
    IL_05df:  sub
    IL_05e0:  stloc      V_3
    IL_05e6:  ldloc      V_0
    IL_05ec:  ldc.i4     0x0
    IL_05f1:  ldloc      V_3
    IL_05f7:  call       void mergesort._::_.mergesort.sort(uint8*,
                                                            int32,
                                                            int32)
    IL_05fc:  ldloc      V_5
    IL_0602:  call       void mergesort._::_puts(uint8*)
    IL_0607:  ldloc      V_0
    IL_060d:  call       void mergesort._::_puts(uint8*)
    IL_0612:  ldloc      V_6
    IL_0618:  call       void mergesort._::_puts(uint8*)
    IL_061d:  ldloc      V_7
    IL_0623:  call       void mergesort._::_puts(uint8*)
    IL_0628:  ldloc      V_8
    IL_062e:  call       void mergesort._::_puts(uint8*)
    IL_0633:  ldc.i4     0x400
    IL_0638:  ldloc      V_0
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
