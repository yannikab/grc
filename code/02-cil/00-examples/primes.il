
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
// MVID: {32B21211-CAD1-483C-BEA6-D324315C7B75}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00540000


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
    .locals init ([0] int32 i,
             [1] int32 $12,
             [2] int32 $13,
             [3] int32 $14,
             [4] int32 $15,
             [5] int32 $16,
             [6] int32 $17)
    IL_0000:  ldarg      n
    IL_0006:  ldc.i4     0x0
    IL_000b:  blt        IL_0015

    IL_0010:  br         IL_0043

    IL_0015:  ldc.i4     0x0
    IL_001a:  ldc.i4     0x1
    IL_001f:  sub
    IL_0020:  stloc      $12
    IL_0026:  ldloc      $12
    IL_002c:  call       int32 primes._::_.primes.prime(int32)
    IL_0031:  stloc      $13
    IL_0037:  ldloc      $13
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
    IL_008f:  stloc      $14
    IL_0095:  ldloc      $14
    IL_009b:  ldc.i4     0x0
    IL_00a0:  beq        IL_00aa

    IL_00a5:  br         IL_00b5

    IL_00aa:  ldc.i4     0x0
    IL_00af:  ret

    IL_00b0:  br         IL_013f

    IL_00b5:  ldc.i4     0x3
    IL_00ba:  stloc      i
    IL_00c0:  ldarg      n
    IL_00c6:  ldc.i4     0x2
    IL_00cb:  div
    IL_00cc:  stloc      $15
    IL_00d2:  ldloc      i
    IL_00d8:  ldloc      $15
    IL_00de:  ble        IL_00e8

    IL_00e3:  br         IL_0139

    IL_00e8:  ldarg      n
    IL_00ee:  ldloc      i
    IL_00f4:  rem
    IL_00f5:  stloc      $16
    IL_00fb:  ldloc      $16
    IL_0101:  ldc.i4     0x0
    IL_0106:  beq        IL_0110

    IL_010b:  br         IL_0116

    IL_0110:  ldc.i4     0x0
    IL_0115:  ret

    IL_0116:  ldloc      i
    IL_011c:  ldc.i4     0x2
    IL_0121:  add
    IL_0122:  stloc      $17
    IL_0128:  ldloc      $17
    IL_012e:  stloc      i
    IL_0134:  br         IL_00c0

    IL_0139:  ldc.i4     0x1
    IL_013e:  ret

    IL_013f:  ret
  } // end of method _::_.primes.prime

  .method private static void  _.primes() cil managed
  {
    // 
    .maxstack  15
    .locals init ([0] int32 counter,
             [1] int32 limit,
             [2] int32 number,
             [3] int32 $0,
             [4] int32 $1,
             [5] int32 $2,
             [6] int32 $3,
             [7] int32 $4,
             [8] int32 $5,
             [9] int32 $6,
             [10] int32 $7,
             [11] int32 $8,
             [12] int32 $9,
             [13] int32 $10,
             [14] int32 $11,
             [15] uint8* _15,
             [16] uint8* _16,
             [17] uint8* _17,
             [18] uint8* _18,
             [19] uint8* _19,
             [20] uint8* _20,
             [21] uint8* _21,
             [22] uint8* _22)
    IL_0000:  ldc.i4     0x8
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      _15
    IL_0010:  ldloc      _15
    IL_0016:  ldc.i4     0x0
    IL_001b:  add
    IL_001c:  ldc.i4     0x4c
    IL_0021:  stind.i1
    IL_0022:  ldloc      _15
    IL_0028:  ldc.i4     0x1
    IL_002d:  add
    IL_002e:  ldc.i4     0x69
    IL_0033:  stind.i1
    IL_0034:  ldloc      _15
    IL_003a:  ldc.i4     0x2
    IL_003f:  add
    IL_0040:  ldc.i4     0x6d
    IL_0045:  stind.i1
    IL_0046:  ldloc      _15
    IL_004c:  ldc.i4     0x3
    IL_0051:  add
    IL_0052:  ldc.i4     0x69
    IL_0057:  stind.i1
    IL_0058:  ldloc      _15
    IL_005e:  ldc.i4     0x4
    IL_0063:  add
    IL_0064:  ldc.i4     0x74
    IL_0069:  stind.i1
    IL_006a:  ldloc      _15
    IL_0070:  ldc.i4     0x5
    IL_0075:  add
    IL_0076:  ldc.i4     0x3a
    IL_007b:  stind.i1
    IL_007c:  ldloc      _15
    IL_0082:  ldc.i4     0x6
    IL_0087:  add
    IL_0088:  ldc.i4     0x20
    IL_008d:  stind.i1
    IL_008e:  ldloc      _15
    IL_0094:  ldc.i4     0x7
    IL_0099:  add
    IL_009a:  ldc.i4     0x0
    IL_009f:  stind.i1
    IL_00a0:  ldc.i4     0xa
    IL_00a5:  newarr     [mscorlib]System.Byte
    IL_00aa:  stloc      _16
    IL_00b0:  ldloc      _16
    IL_00b6:  ldc.i4     0x0
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x50
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      _16
    IL_00c8:  ldc.i4     0x1
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x72
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      _16
    IL_00da:  ldc.i4     0x2
    IL_00df:  add
    IL_00e0:  ldc.i4     0x69
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      _16
    IL_00ec:  ldc.i4     0x3
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x6d
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      _16
    IL_00fe:  ldc.i4     0x4
    IL_0103:  add
    IL_0104:  ldc.i4     0x65
    IL_0109:  stind.i1
    IL_010a:  ldloc      _16
    IL_0110:  ldc.i4     0x5
    IL_0115:  add
    IL_0116:  ldc.i4     0x73
    IL_011b:  stind.i1
    IL_011c:  ldloc      _16
    IL_0122:  ldc.i4     0x6
    IL_0127:  add
    IL_0128:  ldc.i4     0x3a
    IL_012d:  stind.i1
    IL_012e:  ldloc      _16
    IL_0134:  ldc.i4     0x7
    IL_0139:  add
    IL_013a:  ldc.i4     0xa
    IL_013f:  stind.i1
    IL_0140:  ldloc      _16
    IL_0146:  ldc.i4     0x8
    IL_014b:  add
    IL_014c:  ldc.i4     0x0
    IL_0151:  stind.i1
    IL_0152:  ldc.i4     0x3
    IL_0157:  newarr     [mscorlib]System.Byte
    IL_015c:  stloc      _17
    IL_0162:  ldloc      _17
    IL_0168:  ldc.i4     0x0
    IL_016d:  add
    IL_016e:  ldc.i4     0xa
    IL_0173:  stind.i1
    IL_0174:  ldloc      _17
    IL_017a:  ldc.i4     0x1
    IL_017f:  add
    IL_0180:  ldc.i4     0x0
    IL_0185:  stind.i1
    IL_0186:  ldc.i4     0x3
    IL_018b:  newarr     [mscorlib]System.Byte
    IL_0190:  stloc      _18
    IL_0196:  ldloc      _18
    IL_019c:  ldc.i4     0x0
    IL_01a1:  add
    IL_01a2:  ldc.i4     0xa
    IL_01a7:  stind.i1
    IL_01a8:  ldloc      _18
    IL_01ae:  ldc.i4     0x1
    IL_01b3:  add
    IL_01b4:  ldc.i4     0x0
    IL_01b9:  stind.i1
    IL_01ba:  ldc.i4     0x3
    IL_01bf:  newarr     [mscorlib]System.Byte
    IL_01c4:  stloc      _19
    IL_01ca:  ldloc      _19
    IL_01d0:  ldc.i4     0x0
    IL_01d5:  add
    IL_01d6:  ldc.i4     0xa
    IL_01db:  stind.i1
    IL_01dc:  ldloc      _19
    IL_01e2:  ldc.i4     0x1
    IL_01e7:  add
    IL_01e8:  ldc.i4     0x0
    IL_01ed:  stind.i1
    IL_01ee:  ldc.i4     0x3
    IL_01f3:  newarr     [mscorlib]System.Byte
    IL_01f8:  stloc      _20
    IL_01fe:  ldloc      _20
    IL_0204:  ldc.i4     0x0
    IL_0209:  add
    IL_020a:  ldc.i4     0xa
    IL_020f:  stind.i1
    IL_0210:  ldloc      _20
    IL_0216:  ldc.i4     0x1
    IL_021b:  add
    IL_021c:  ldc.i4     0x0
    IL_0221:  stind.i1
    IL_0222:  ldc.i4     0xa
    IL_0227:  newarr     [mscorlib]System.Byte
    IL_022c:  stloc      _21
    IL_0232:  ldloc      _21
    IL_0238:  ldc.i4     0x0
    IL_023d:  add
    IL_023e:  ldc.i4     0xa
    IL_0243:  stind.i1
    IL_0244:  ldloc      _21
    IL_024a:  ldc.i4     0x1
    IL_024f:  add
    IL_0250:  ldc.i4     0x54
    IL_0255:  stind.i1
    IL_0256:  ldloc      _21
    IL_025c:  ldc.i4     0x2
    IL_0261:  add
    IL_0262:  ldc.i4     0x6f
    IL_0267:  stind.i1
    IL_0268:  ldloc      _21
    IL_026e:  ldc.i4     0x3
    IL_0273:  add
    IL_0274:  ldc.i4     0x74
    IL_0279:  stind.i1
    IL_027a:  ldloc      _21
    IL_0280:  ldc.i4     0x4
    IL_0285:  add
    IL_0286:  ldc.i4     0x61
    IL_028b:  stind.i1
    IL_028c:  ldloc      _21
    IL_0292:  ldc.i4     0x5
    IL_0297:  add
    IL_0298:  ldc.i4     0x6c
    IL_029d:  stind.i1
    IL_029e:  ldloc      _21
    IL_02a4:  ldc.i4     0x6
    IL_02a9:  add
    IL_02aa:  ldc.i4     0x3a
    IL_02af:  stind.i1
    IL_02b0:  ldloc      _21
    IL_02b6:  ldc.i4     0x7
    IL_02bb:  add
    IL_02bc:  ldc.i4     0x20
    IL_02c1:  stind.i1
    IL_02c2:  ldloc      _21
    IL_02c8:  ldc.i4     0x8
    IL_02cd:  add
    IL_02ce:  ldc.i4     0x0
    IL_02d3:  stind.i1
    IL_02d4:  ldc.i4     0x3
    IL_02d9:  newarr     [mscorlib]System.Byte
    IL_02de:  stloc      _22
    IL_02e4:  ldloc      _22
    IL_02ea:  ldc.i4     0x0
    IL_02ef:  add
    IL_02f0:  ldc.i4     0xa
    IL_02f5:  stind.i1
    IL_02f6:  ldloc      _22
    IL_02fc:  ldc.i4     0x1
    IL_0301:  add
    IL_0302:  ldc.i4     0x0
    IL_0307:  stind.i1
    IL_0308:  ldloc      _15
    IL_030e:  call       void primes._::_puts(uint8*)
    IL_0313:  call       int32 primes._::_geti()
    IL_0318:  stloc      $0
    IL_031e:  ldloc      $0
    IL_0324:  stloc      limit
    IL_032a:  ldloc      _16
    IL_0330:  call       void primes._::_puts(uint8*)
    IL_0335:  ldc.i4     0x0
    IL_033a:  stloc      counter
    IL_0340:  ldloc      limit
    IL_0346:  ldc.i4     0x2
    IL_034b:  bge        IL_0355

    IL_0350:  br         IL_0388

    IL_0355:  ldloc      counter
    IL_035b:  ldc.i4     0x1
    IL_0360:  add
    IL_0361:  stloc      $1
    IL_0367:  ldloc      $1
    IL_036d:  stloc      counter
    IL_0373:  ldc.i4     0x2
    IL_0378:  call       void primes._::_puti(int32)
    IL_037d:  ldloc      _17
    IL_0383:  call       void primes._::_puts(uint8*)
    IL_0388:  ldloc      limit
    IL_038e:  ldc.i4     0x3
    IL_0393:  bge        IL_039d

    IL_0398:  br         IL_03d0

    IL_039d:  ldloc      counter
    IL_03a3:  ldc.i4     0x1
    IL_03a8:  add
    IL_03a9:  stloc      $2
    IL_03af:  ldloc      $2
    IL_03b5:  stloc      counter
    IL_03bb:  ldc.i4     0x3
    IL_03c0:  call       void primes._::_puti(int32)
    IL_03c5:  ldloc      _18
    IL_03cb:  call       void primes._::_puts(uint8*)
    IL_03d0:  ldc.i4     0x6
    IL_03d5:  stloc      number
    IL_03db:  ldloc      number
    IL_03e1:  ldloc      limit
    IL_03e7:  ble        IL_03f1

    IL_03ec:  br         IL_0526

    IL_03f1:  ldloc      number
    IL_03f7:  ldc.i4     0x1
    IL_03fc:  sub
    IL_03fd:  stloc      $3
    IL_0403:  ldloc      $3
    IL_0409:  call       int32 primes._::_.primes.prime(int32)
    IL_040e:  stloc      $4
    IL_0414:  ldloc      $4
    IL_041a:  ldc.i4     0x1
    IL_041f:  beq        IL_0429

    IL_0424:  br         IL_046f

    IL_0429:  ldloc      counter
    IL_042f:  ldc.i4     0x1
    IL_0434:  add
    IL_0435:  stloc      $5
    IL_043b:  ldloc      $5
    IL_0441:  stloc      counter
    IL_0447:  ldloc      number
    IL_044d:  ldc.i4     0x1
    IL_0452:  sub
    IL_0453:  stloc      $6
    IL_0459:  ldloc      $6
    IL_045f:  call       void primes._::_puti(int32)
    IL_0464:  ldloc      _19
    IL_046a:  call       void primes._::_puts(uint8*)
    IL_046f:  ldloc      number
    IL_0475:  ldloc      limit
    IL_047b:  bne.un     IL_0485

    IL_0480:  br         IL_0503

    IL_0485:  ldloc      number
    IL_048b:  ldc.i4     0x1
    IL_0490:  add
    IL_0491:  stloc      $7
    IL_0497:  ldloc      $7
    IL_049d:  call       int32 primes._::_.primes.prime(int32)
    IL_04a2:  stloc      $8
    IL_04a8:  ldloc      $8
    IL_04ae:  ldc.i4     0x1
    IL_04b3:  beq        IL_04bd

    IL_04b8:  br         IL_0503

    IL_04bd:  ldloc      counter
    IL_04c3:  ldc.i4     0x1
    IL_04c8:  add
    IL_04c9:  stloc      $9
    IL_04cf:  ldloc      $9
    IL_04d5:  stloc      counter
    IL_04db:  ldloc      number
    IL_04e1:  ldc.i4     0x1
    IL_04e6:  add
    IL_04e7:  stloc      $10
    IL_04ed:  ldloc      $10
    IL_04f3:  call       void primes._::_puti(int32)
    IL_04f8:  ldloc      _20
    IL_04fe:  call       void primes._::_puts(uint8*)
    IL_0503:  ldloc      number
    IL_0509:  ldc.i4     0x6
    IL_050e:  add
    IL_050f:  stloc      $11
    IL_0515:  ldloc      $11
    IL_051b:  stloc      number
    IL_0521:  br         IL_03db

    IL_0526:  ldloc      _21
    IL_052c:  call       void primes._::_puts(uint8*)
    IL_0531:  ldloc      counter
    IL_0537:  call       void primes._::_puti(int32)
    IL_053c:  ldloc      _22
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
