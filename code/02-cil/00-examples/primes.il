
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
.assembly primes
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module primes
// MVID: {DEF7B568-5C2B-45D6-B19E-C519A267A176}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x006A0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi primes._
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
    IL_0000:  call       void primes._::_.primes()
    IL_0005:  ret
  } // end of method _::_

  .method private static int32  _.primes.prime(int32 n) cil managed
  {
    // 
    .maxstack  21
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3,
             int32 V_4,
             int32 V_5,
             int32 V_6)
    IL_0000:  ldarg      n
    IL_0006:  ldc.i4     0x0
    IL_000b:  blt        IL_0015

    IL_0010:  br         IL_0043

    IL_0015:  ldc.i4     0x0
    IL_001a:  ldc.i4     0x1
    IL_001f:  sub
    IL_0020:  stloc      V_1
    IL_0026:  ldloc      V_1
    IL_002c:  call       int32 primes._::_.primes.prime(int32)
    IL_0031:  stloc      V_2
    IL_0037:  ldloc      V_2
    IL_003d:  ret

    IL_003e:  br         IL_013f

    IL_0043:  ldarg      n
    IL_0049:  ldc.i4     0x2
    IL_004e:  blt        IL_0058

    IL_0053:  br         IL_0063

    IL_0058:  ldc.i4     0x0
    IL_005d:  ret

    IL_005e:  br         IL_013f

    IL_0063:  ldarg      n
    IL_0069:  ldc.i4     0x2
    IL_006e:  beq        IL_0078

    IL_0073:  br         IL_0083

    IL_0078:  ldc.i4     0x1
    IL_007d:  ret

    IL_007e:  br         IL_013f

    IL_0083:  ldarg      n
    IL_0089:  ldc.i4     0x2
    IL_008e:  rem
    IL_008f:  stloc      V_3
    IL_0095:  ldloc      V_3
    IL_009b:  ldc.i4     0x0
    IL_00a0:  beq        IL_00aa

    IL_00a5:  br         IL_00b5

    IL_00aa:  ldc.i4     0x0
    IL_00af:  ret

    IL_00b0:  br         IL_013f

    IL_00b5:  ldc.i4     0x3
    IL_00ba:  stloc      V_0
    IL_00c0:  ldarg      n
    IL_00c6:  ldc.i4     0x2
    IL_00cb:  div
    IL_00cc:  stloc      V_4
    IL_00d2:  ldloc      V_0
    IL_00d8:  ldloc      V_4
    IL_00de:  ble        IL_00e8

    IL_00e3:  br         IL_0139

    IL_00e8:  ldarg      n
    IL_00ee:  ldloc      V_0
    IL_00f4:  rem
    IL_00f5:  stloc      V_5
    IL_00fb:  ldloc      V_5
    IL_0101:  ldc.i4     0x0
    IL_0106:  beq        IL_0110

    IL_010b:  br         IL_0116

    IL_0110:  ldc.i4     0x0
    IL_0115:  ret

    IL_0116:  ldloc      V_0
    IL_011c:  ldc.i4     0x2
    IL_0121:  add
    IL_0122:  stloc      V_6
    IL_0128:  ldloc      V_6
    IL_012e:  stloc      V_0
    IL_0134:  br         IL_00c0

    IL_0139:  ldc.i4     0x1
    IL_013e:  ret

    IL_013f:  ret
  } // end of method _::_.primes.prime

  .method private static void  _.primes() cil managed
  {
    // 
    .maxstack  15
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3,
             int32 V_4,
             int32 V_5,
             int32 V_6,
             int32 V_7,
             int32 V_8,
             int32 V_9,
             int32 V_10,
             int32 V_11,
             int32 V_12,
             int32 V_13,
             int32 V_14,
             uint8* V_15,
             uint8* V_16,
             uint8* V_17,
             uint8* V_18,
             uint8* V_19,
             uint8* V_20,
             uint8* V_21,
             uint8* V_22)
    IL_0000:  ldc.i4     0x8
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      V_15
    IL_0010:  ldloc      V_15
    IL_0016:  ldc.i4     0x0
    IL_001b:  add
    IL_001c:  ldc.i4     0x4c
    IL_0021:  stind.i1
    IL_0022:  ldloc      V_15
    IL_0028:  ldc.i4     0x1
    IL_002d:  add
    IL_002e:  ldc.i4     0x69
    IL_0033:  stind.i1
    IL_0034:  ldloc      V_15
    IL_003a:  ldc.i4     0x2
    IL_003f:  add
    IL_0040:  ldc.i4     0x6d
    IL_0045:  stind.i1
    IL_0046:  ldloc      V_15
    IL_004c:  ldc.i4     0x3
    IL_0051:  add
    IL_0052:  ldc.i4     0x69
    IL_0057:  stind.i1
    IL_0058:  ldloc      V_15
    IL_005e:  ldc.i4     0x4
    IL_0063:  add
    IL_0064:  ldc.i4     0x74
    IL_0069:  stind.i1
    IL_006a:  ldloc      V_15
    IL_0070:  ldc.i4     0x5
    IL_0075:  add
    IL_0076:  ldc.i4     0x3a
    IL_007b:  stind.i1
    IL_007c:  ldloc      V_15
    IL_0082:  ldc.i4     0x6
    IL_0087:  add
    IL_0088:  ldc.i4     0x20
    IL_008d:  stind.i1
    IL_008e:  ldloc      V_15
    IL_0094:  ldc.i4     0x7
    IL_0099:  add
    IL_009a:  ldc.i4     0x0
    IL_009f:  stind.i1
    IL_00a0:  ldc.i4     0xa
    IL_00a5:  newarr     [mscorlib]System.Byte
    IL_00aa:  stloc      V_16
    IL_00b0:  ldloc      V_16
    IL_00b6:  ldc.i4     0x0
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x50
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      V_16
    IL_00c8:  ldc.i4     0x1
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x72
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      V_16
    IL_00da:  ldc.i4     0x2
    IL_00df:  add
    IL_00e0:  ldc.i4     0x69
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      V_16
    IL_00ec:  ldc.i4     0x3
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x6d
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      V_16
    IL_00fe:  ldc.i4     0x4
    IL_0103:  add
    IL_0104:  ldc.i4     0x65
    IL_0109:  stind.i1
    IL_010a:  ldloc      V_16
    IL_0110:  ldc.i4     0x5
    IL_0115:  add
    IL_0116:  ldc.i4     0x73
    IL_011b:  stind.i1
    IL_011c:  ldloc      V_16
    IL_0122:  ldc.i4     0x6
    IL_0127:  add
    IL_0128:  ldc.i4     0x3a
    IL_012d:  stind.i1
    IL_012e:  ldloc      V_16
    IL_0134:  ldc.i4     0x7
    IL_0139:  add
    IL_013a:  ldc.i4     0xa
    IL_013f:  stind.i1
    IL_0140:  ldloc      V_16
    IL_0146:  ldc.i4     0x8
    IL_014b:  add
    IL_014c:  ldc.i4     0x0
    IL_0151:  stind.i1
    IL_0152:  ldc.i4     0x3
    IL_0157:  newarr     [mscorlib]System.Byte
    IL_015c:  stloc      V_17
    IL_0162:  ldloc      V_17
    IL_0168:  ldc.i4     0x0
    IL_016d:  add
    IL_016e:  ldc.i4     0xa
    IL_0173:  stind.i1
    IL_0174:  ldloc      V_17
    IL_017a:  ldc.i4     0x1
    IL_017f:  add
    IL_0180:  ldc.i4     0x0
    IL_0185:  stind.i1
    IL_0186:  ldc.i4     0x3
    IL_018b:  newarr     [mscorlib]System.Byte
    IL_0190:  stloc      V_18
    IL_0196:  ldloc      V_18
    IL_019c:  ldc.i4     0x0
    IL_01a1:  add
    IL_01a2:  ldc.i4     0xa
    IL_01a7:  stind.i1
    IL_01a8:  ldloc      V_18
    IL_01ae:  ldc.i4     0x1
    IL_01b3:  add
    IL_01b4:  ldc.i4     0x0
    IL_01b9:  stind.i1
    IL_01ba:  ldc.i4     0x3
    IL_01bf:  newarr     [mscorlib]System.Byte
    IL_01c4:  stloc      V_19
    IL_01ca:  ldloc      V_19
    IL_01d0:  ldc.i4     0x0
    IL_01d5:  add
    IL_01d6:  ldc.i4     0xa
    IL_01db:  stind.i1
    IL_01dc:  ldloc      V_19
    IL_01e2:  ldc.i4     0x1
    IL_01e7:  add
    IL_01e8:  ldc.i4     0x0
    IL_01ed:  stind.i1
    IL_01ee:  ldc.i4     0x3
    IL_01f3:  newarr     [mscorlib]System.Byte
    IL_01f8:  stloc      V_20
    IL_01fe:  ldloc      V_20
    IL_0204:  ldc.i4     0x0
    IL_0209:  add
    IL_020a:  ldc.i4     0xa
    IL_020f:  stind.i1
    IL_0210:  ldloc      V_20
    IL_0216:  ldc.i4     0x1
    IL_021b:  add
    IL_021c:  ldc.i4     0x0
    IL_0221:  stind.i1
    IL_0222:  ldc.i4     0xa
    IL_0227:  newarr     [mscorlib]System.Byte
    IL_022c:  stloc      V_21
    IL_0232:  ldloc      V_21
    IL_0238:  ldc.i4     0x0
    IL_023d:  add
    IL_023e:  ldc.i4     0xa
    IL_0243:  stind.i1
    IL_0244:  ldloc      V_21
    IL_024a:  ldc.i4     0x1
    IL_024f:  add
    IL_0250:  ldc.i4     0x54
    IL_0255:  stind.i1
    IL_0256:  ldloc      V_21
    IL_025c:  ldc.i4     0x2
    IL_0261:  add
    IL_0262:  ldc.i4     0x6f
    IL_0267:  stind.i1
    IL_0268:  ldloc      V_21
    IL_026e:  ldc.i4     0x3
    IL_0273:  add
    IL_0274:  ldc.i4     0x74
    IL_0279:  stind.i1
    IL_027a:  ldloc      V_21
    IL_0280:  ldc.i4     0x4
    IL_0285:  add
    IL_0286:  ldc.i4     0x61
    IL_028b:  stind.i1
    IL_028c:  ldloc      V_21
    IL_0292:  ldc.i4     0x5
    IL_0297:  add
    IL_0298:  ldc.i4     0x6c
    IL_029d:  stind.i1
    IL_029e:  ldloc      V_21
    IL_02a4:  ldc.i4     0x6
    IL_02a9:  add
    IL_02aa:  ldc.i4     0x3a
    IL_02af:  stind.i1
    IL_02b0:  ldloc      V_21
    IL_02b6:  ldc.i4     0x7
    IL_02bb:  add
    IL_02bc:  ldc.i4     0x20
    IL_02c1:  stind.i1
    IL_02c2:  ldloc      V_21
    IL_02c8:  ldc.i4     0x8
    IL_02cd:  add
    IL_02ce:  ldc.i4     0x0
    IL_02d3:  stind.i1
    IL_02d4:  ldc.i4     0x3
    IL_02d9:  newarr     [mscorlib]System.Byte
    IL_02de:  stloc      V_22
    IL_02e4:  ldloc      V_22
    IL_02ea:  ldc.i4     0x0
    IL_02ef:  add
    IL_02f0:  ldc.i4     0xa
    IL_02f5:  stind.i1
    IL_02f6:  ldloc      V_22
    IL_02fc:  ldc.i4     0x1
    IL_0301:  add
    IL_0302:  ldc.i4     0x0
    IL_0307:  stind.i1
    IL_0308:  ldloc      V_15
    IL_030e:  call       void primes._::_puts(uint8*)
    IL_0313:  call       int32 primes._::_geti()
    IL_0318:  stloc      V_3
    IL_031e:  ldloc      V_3
    IL_0324:  stloc      V_1
    IL_032a:  ldloc      V_16
    IL_0330:  call       void primes._::_puts(uint8*)
    IL_0335:  ldc.i4     0x0
    IL_033a:  stloc      V_0
    IL_0340:  ldloc      V_1
    IL_0346:  ldc.i4     0x2
    IL_034b:  bge        IL_0355

    IL_0350:  br         IL_0388

    IL_0355:  ldloc      V_0
    IL_035b:  ldc.i4     0x1
    IL_0360:  add
    IL_0361:  stloc      V_4
    IL_0367:  ldloc      V_4
    IL_036d:  stloc      V_0
    IL_0373:  ldc.i4     0x2
    IL_0378:  call       void primes._::_puti(int32)
    IL_037d:  ldloc      V_17
    IL_0383:  call       void primes._::_puts(uint8*)
    IL_0388:  ldloc      V_1
    IL_038e:  ldc.i4     0x3
    IL_0393:  bge        IL_039d

    IL_0398:  br         IL_03d0

    IL_039d:  ldloc      V_0
    IL_03a3:  ldc.i4     0x1
    IL_03a8:  add
    IL_03a9:  stloc      V_5
    IL_03af:  ldloc      V_5
    IL_03b5:  stloc      V_0
    IL_03bb:  ldc.i4     0x3
    IL_03c0:  call       void primes._::_puti(int32)
    IL_03c5:  ldloc      V_18
    IL_03cb:  call       void primes._::_puts(uint8*)
    IL_03d0:  ldc.i4     0x6
    IL_03d5:  stloc      V_2
    IL_03db:  ldloc      V_2
    IL_03e1:  ldloc      V_1
    IL_03e7:  ble        IL_03f1

    IL_03ec:  br         IL_0526

    IL_03f1:  ldloc      V_2
    IL_03f7:  ldc.i4     0x1
    IL_03fc:  sub
    IL_03fd:  stloc      V_6
    IL_0403:  ldloc      V_6
    IL_0409:  call       int32 primes._::_.primes.prime(int32)
    IL_040e:  stloc      V_7
    IL_0414:  ldloc      V_7
    IL_041a:  ldc.i4     0x1
    IL_041f:  beq        IL_0429

    IL_0424:  br         IL_046f

    IL_0429:  ldloc      V_0
    IL_042f:  ldc.i4     0x1
    IL_0434:  add
    IL_0435:  stloc      V_8
    IL_043b:  ldloc      V_8
    IL_0441:  stloc      V_0
    IL_0447:  ldloc      V_2
    IL_044d:  ldc.i4     0x1
    IL_0452:  sub
    IL_0453:  stloc      V_9
    IL_0459:  ldloc      V_9
    IL_045f:  call       void primes._::_puti(int32)
    IL_0464:  ldloc      V_19
    IL_046a:  call       void primes._::_puts(uint8*)
    IL_046f:  ldloc      V_2
    IL_0475:  ldloc      V_1
    IL_047b:  bne.un     IL_0485

    IL_0480:  br         IL_0503

    IL_0485:  ldloc      V_2
    IL_048b:  ldc.i4     0x1
    IL_0490:  add
    IL_0491:  stloc      V_10
    IL_0497:  ldloc      V_10
    IL_049d:  call       int32 primes._::_.primes.prime(int32)
    IL_04a2:  stloc      V_11
    IL_04a8:  ldloc      V_11
    IL_04ae:  ldc.i4     0x1
    IL_04b3:  beq        IL_04bd

    IL_04b8:  br         IL_0503

    IL_04bd:  ldloc      V_0
    IL_04c3:  ldc.i4     0x1
    IL_04c8:  add
    IL_04c9:  stloc      V_12
    IL_04cf:  ldloc      V_12
    IL_04d5:  stloc      V_0
    IL_04db:  ldloc      V_2
    IL_04e1:  ldc.i4     0x1
    IL_04e6:  add
    IL_04e7:  stloc      V_13
    IL_04ed:  ldloc      V_13
    IL_04f3:  call       void primes._::_puti(int32)
    IL_04f8:  ldloc      V_20
    IL_04fe:  call       void primes._::_puts(uint8*)
    IL_0503:  ldloc      V_2
    IL_0509:  ldc.i4     0x6
    IL_050e:  add
    IL_050f:  stloc      V_14
    IL_0515:  ldloc      V_14
    IL_051b:  stloc      V_2
    IL_0521:  br         IL_03db

    IL_0526:  ldloc      V_21
    IL_052c:  call       void primes._::_puts(uint8*)
    IL_0531:  ldloc      V_0
    IL_0537:  call       void primes._::_puti(int32)
    IL_053c:  ldloc      V_22
    IL_0542:  call       void primes._::_puts(uint8*)
    IL_0547:  ret
  } // end of method _::_.primes

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class primes._


// =============================================================

// 
