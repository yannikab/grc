
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
.assembly hanoi
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module hanoi
// MVID: {4834CA9C-E7B7-4089-810C-31EBE333EBBF}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x001E0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi hanoi._
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
    IL_0000:  call       void hanoi._::_.hanoi()
    IL_0005:  ret
  } // end of method _::_

  .method private static void  _.hanoi.solve(int32 rings,
                                             uint8* source,
                                             uint8* target,
                                             uint8* auxiliary,
                                             int32& i) cil managed
  {
    // 
    .maxstack  7
    .locals init (int32 V_0,
             int32 V_1)
    IL_0000:  ldarg      rings
    IL_0006:  ldc.i4     0x1
    IL_000b:  bge        IL_0015

    IL_0010:  br         IL_0096

    IL_0015:  ldarg      rings
    IL_001b:  ldc.i4     0x1
    IL_0020:  sub
    IL_0021:  stloc      V_0
    IL_0027:  ldloc      V_0
    IL_002d:  ldarg      source
    IL_0033:  ldarg      auxiliary
    IL_0039:  ldarg      target
    IL_003f:  ldarg      i
    IL_0045:  call       void hanoi._::_.hanoi.solve(int32,
                                                     uint8*,
                                                     uint8*,
                                                     uint8*,
                                                     int32&)
    IL_004a:  ldarg      source
    IL_0050:  ldarg      target
    IL_0056:  ldarg      i
    IL_005c:  call       void hanoi._::_.hanoi.solve.move(uint8*,
                                                          uint8*,
                                                          int32&)
    IL_0061:  ldarg      rings
    IL_0067:  ldc.i4     0x1
    IL_006c:  sub
    IL_006d:  stloc      V_1
    IL_0073:  ldloc      V_1
    IL_0079:  ldarg      auxiliary
    IL_007f:  ldarg      target
    IL_0085:  ldarg      source
    IL_008b:  ldarg      i
    IL_0091:  call       void hanoi._::_.hanoi.solve(int32,
                                                     uint8*,
                                                     uint8*,
                                                     uint8*,
                                                     int32&)
    IL_0096:  ret
  } // end of method _::_.hanoi.solve

  .method private static void  _.hanoi.solve.move(uint8* source,
                                                  uint8* target,
                                                  int32& i) cil managed
  {
    // 
    .maxstack  2
    .locals init (int32 V_0,
             uint8* V_1,
             uint8* V_2,
             uint8* V_3,
             uint8* V_4)
    IL_0000:  ldc.i4     0x3
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      V_1
    IL_0010:  ldloc      V_1
    IL_0016:  ldc.i4     0x0
    IL_001b:  add
    IL_001c:  ldc.i4     0x3a
    IL_0021:  stind.i1
    IL_0022:  ldloc      V_1
    IL_0028:  ldc.i4     0x1
    IL_002d:  add
    IL_002e:  ldc.i4     0x20
    IL_0033:  stind.i1
    IL_0034:  ldloc      V_1
    IL_003a:  ldc.i4     0x2
    IL_003f:  add
    IL_0040:  ldc.i4     0x0
    IL_0045:  stind.i1
    IL_0046:  ldc.i4     0xd
    IL_004b:  newarr     [mscorlib]System.Byte
    IL_0050:  stloc      V_2
    IL_0056:  ldloc      V_2
    IL_005c:  ldc.i4     0x0
    IL_0061:  add
    IL_0062:  ldc.i4     0x4d
    IL_0067:  stind.i1
    IL_0068:  ldloc      V_2
    IL_006e:  ldc.i4     0x1
    IL_0073:  add
    IL_0074:  ldc.i4     0x6f
    IL_0079:  stind.i1
    IL_007a:  ldloc      V_2
    IL_0080:  ldc.i4     0x2
    IL_0085:  add
    IL_0086:  ldc.i4     0x76
    IL_008b:  stind.i1
    IL_008c:  ldloc      V_2
    IL_0092:  ldc.i4     0x3
    IL_0097:  add
    IL_0098:  ldc.i4     0x69
    IL_009d:  stind.i1
    IL_009e:  ldloc      V_2
    IL_00a4:  ldc.i4     0x4
    IL_00a9:  add
    IL_00aa:  ldc.i4     0x6e
    IL_00af:  stind.i1
    IL_00b0:  ldloc      V_2
    IL_00b6:  ldc.i4     0x5
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x67
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      V_2
    IL_00c8:  ldc.i4     0x6
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x20
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      V_2
    IL_00da:  ldc.i4     0x7
    IL_00df:  add
    IL_00e0:  ldc.i4     0x66
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      V_2
    IL_00ec:  ldc.i4     0x8
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x72
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      V_2
    IL_00fe:  ldc.i4     0x9
    IL_0103:  add
    IL_0104:  ldc.i4     0x6f
    IL_0109:  stind.i1
    IL_010a:  ldloc      V_2
    IL_0110:  ldc.i4     0xa
    IL_0115:  add
    IL_0116:  ldc.i4     0x6d
    IL_011b:  stind.i1
    IL_011c:  ldloc      V_2
    IL_0122:  ldc.i4     0xb
    IL_0127:  add
    IL_0128:  ldc.i4     0x20
    IL_012d:  stind.i1
    IL_012e:  ldloc      V_2
    IL_0134:  ldc.i4     0xc
    IL_0139:  add
    IL_013a:  ldc.i4     0x0
    IL_013f:  stind.i1
    IL_0140:  ldc.i4     0x5
    IL_0145:  newarr     [mscorlib]System.Byte
    IL_014a:  stloc      V_3
    IL_0150:  ldloc      V_3
    IL_0156:  ldc.i4     0x0
    IL_015b:  add
    IL_015c:  ldc.i4     0x20
    IL_0161:  stind.i1
    IL_0162:  ldloc      V_3
    IL_0168:  ldc.i4     0x1
    IL_016d:  add
    IL_016e:  ldc.i4     0x74
    IL_0173:  stind.i1
    IL_0174:  ldloc      V_3
    IL_017a:  ldc.i4     0x2
    IL_017f:  add
    IL_0180:  ldc.i4     0x6f
    IL_0185:  stind.i1
    IL_0186:  ldloc      V_3
    IL_018c:  ldc.i4     0x3
    IL_0191:  add
    IL_0192:  ldc.i4     0x20
    IL_0197:  stind.i1
    IL_0198:  ldloc      V_3
    IL_019e:  ldc.i4     0x4
    IL_01a3:  add
    IL_01a4:  ldc.i4     0x0
    IL_01a9:  stind.i1
    IL_01aa:  ldc.i4     0x4
    IL_01af:  newarr     [mscorlib]System.Byte
    IL_01b4:  stloc      V_4
    IL_01ba:  ldloc      V_4
    IL_01c0:  ldc.i4     0x0
    IL_01c5:  add
    IL_01c6:  ldc.i4     0x2e
    IL_01cb:  stind.i1
    IL_01cc:  ldloc      V_4
    IL_01d2:  ldc.i4     0x1
    IL_01d7:  add
    IL_01d8:  ldc.i4     0xa
    IL_01dd:  stind.i1
    IL_01de:  ldloc      V_4
    IL_01e4:  ldc.i4     0x2
    IL_01e9:  add
    IL_01ea:  ldc.i4     0x0
    IL_01ef:  stind.i1
    IL_01f0:  ldarg      i
    IL_01f6:  ldind.i4
    IL_01f7:  call       void hanoi._::_puti(int32)
    IL_01fc:  ldarg      i
    IL_0202:  ldind.i4
    IL_0203:  ldc.i4     0x1
    IL_0208:  add
    IL_0209:  stloc      V_0
    IL_020f:  ldarg      i
    IL_0215:  ldloc      V_0
    IL_021b:  stind.i4
    IL_021c:  ldloc      V_1
    IL_0222:  call       void hanoi._::_puts(uint8*)
    IL_0227:  ldloc      V_2
    IL_022d:  call       void hanoi._::_puts(uint8*)
    IL_0232:  ldarg      source
    IL_0238:  call       void hanoi._::_puts(uint8*)
    IL_023d:  ldloc      V_3
    IL_0243:  call       void hanoi._::_puts(uint8*)
    IL_0248:  ldarg      target
    IL_024e:  call       void hanoi._::_puts(uint8*)
    IL_0253:  ldloc      V_4
    IL_0259:  call       void hanoi._::_puts(uint8*)
    IL_025e:  ret
  } // end of method _::_.hanoi.solve.move

  .method private static void  _.hanoi() cil managed
  {
    // 
    .maxstack  5
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             uint8* V_3,
             uint8* V_4,
             uint8* V_5,
             uint8* V_6)
    IL_0000:  ldc.i4     0x8
    IL_0005:  newarr     [mscorlib]System.Byte
    IL_000a:  stloc      V_3
    IL_0010:  ldloc      V_3
    IL_0016:  ldc.i4     0x0
    IL_001b:  add
    IL_001c:  ldc.i4     0x52
    IL_0021:  stind.i1
    IL_0022:  ldloc      V_3
    IL_0028:  ldc.i4     0x1
    IL_002d:  add
    IL_002e:  ldc.i4     0x69
    IL_0033:  stind.i1
    IL_0034:  ldloc      V_3
    IL_003a:  ldc.i4     0x2
    IL_003f:  add
    IL_0040:  ldc.i4     0x6e
    IL_0045:  stind.i1
    IL_0046:  ldloc      V_3
    IL_004c:  ldc.i4     0x3
    IL_0051:  add
    IL_0052:  ldc.i4     0x67
    IL_0057:  stind.i1
    IL_0058:  ldloc      V_3
    IL_005e:  ldc.i4     0x4
    IL_0063:  add
    IL_0064:  ldc.i4     0x73
    IL_0069:  stind.i1
    IL_006a:  ldloc      V_3
    IL_0070:  ldc.i4     0x5
    IL_0075:  add
    IL_0076:  ldc.i4     0x3a
    IL_007b:  stind.i1
    IL_007c:  ldloc      V_3
    IL_0082:  ldc.i4     0x6
    IL_0087:  add
    IL_0088:  ldc.i4     0x20
    IL_008d:  stind.i1
    IL_008e:  ldloc      V_3
    IL_0094:  ldc.i4     0x7
    IL_0099:  add
    IL_009a:  ldc.i4     0x0
    IL_009f:  stind.i1
    IL_00a0:  ldc.i4     0x5
    IL_00a5:  newarr     [mscorlib]System.Byte
    IL_00aa:  stloc      V_4
    IL_00b0:  ldloc      V_4
    IL_00b6:  ldc.i4     0x0
    IL_00bb:  add
    IL_00bc:  ldc.i4     0x6c
    IL_00c1:  stind.i1
    IL_00c2:  ldloc      V_4
    IL_00c8:  ldc.i4     0x1
    IL_00cd:  add
    IL_00ce:  ldc.i4     0x65
    IL_00d3:  stind.i1
    IL_00d4:  ldloc      V_4
    IL_00da:  ldc.i4     0x2
    IL_00df:  add
    IL_00e0:  ldc.i4     0x66
    IL_00e5:  stind.i1
    IL_00e6:  ldloc      V_4
    IL_00ec:  ldc.i4     0x3
    IL_00f1:  add
    IL_00f2:  ldc.i4     0x74
    IL_00f7:  stind.i1
    IL_00f8:  ldloc      V_4
    IL_00fe:  ldc.i4     0x4
    IL_0103:  add
    IL_0104:  ldc.i4     0x0
    IL_0109:  stind.i1
    IL_010a:  ldc.i4     0x6
    IL_010f:  newarr     [mscorlib]System.Byte
    IL_0114:  stloc      V_5
    IL_011a:  ldloc      V_5
    IL_0120:  ldc.i4     0x0
    IL_0125:  add
    IL_0126:  ldc.i4     0x72
    IL_012b:  stind.i1
    IL_012c:  ldloc      V_5
    IL_0132:  ldc.i4     0x1
    IL_0137:  add
    IL_0138:  ldc.i4     0x69
    IL_013d:  stind.i1
    IL_013e:  ldloc      V_5
    IL_0144:  ldc.i4     0x2
    IL_0149:  add
    IL_014a:  ldc.i4     0x67
    IL_014f:  stind.i1
    IL_0150:  ldloc      V_5
    IL_0156:  ldc.i4     0x3
    IL_015b:  add
    IL_015c:  ldc.i4     0x68
    IL_0161:  stind.i1
    IL_0162:  ldloc      V_5
    IL_0168:  ldc.i4     0x4
    IL_016d:  add
    IL_016e:  ldc.i4     0x74
    IL_0173:  stind.i1
    IL_0174:  ldloc      V_5
    IL_017a:  ldc.i4     0x5
    IL_017f:  add
    IL_0180:  ldc.i4     0x0
    IL_0185:  stind.i1
    IL_0186:  ldc.i4     0x7
    IL_018b:  newarr     [mscorlib]System.Byte
    IL_0190:  stloc      V_6
    IL_0196:  ldloc      V_6
    IL_019c:  ldc.i4     0x0
    IL_01a1:  add
    IL_01a2:  ldc.i4     0x6d
    IL_01a7:  stind.i1
    IL_01a8:  ldloc      V_6
    IL_01ae:  ldc.i4     0x1
    IL_01b3:  add
    IL_01b4:  ldc.i4     0x69
    IL_01b9:  stind.i1
    IL_01ba:  ldloc      V_6
    IL_01c0:  ldc.i4     0x2
    IL_01c5:  add
    IL_01c6:  ldc.i4     0x64
    IL_01cb:  stind.i1
    IL_01cc:  ldloc      V_6
    IL_01d2:  ldc.i4     0x3
    IL_01d7:  add
    IL_01d8:  ldc.i4     0x64
    IL_01dd:  stind.i1
    IL_01de:  ldloc      V_6
    IL_01e4:  ldc.i4     0x4
    IL_01e9:  add
    IL_01ea:  ldc.i4     0x6c
    IL_01ef:  stind.i1
    IL_01f0:  ldloc      V_6
    IL_01f6:  ldc.i4     0x5
    IL_01fb:  add
    IL_01fc:  ldc.i4     0x65
    IL_0201:  stind.i1
    IL_0202:  ldloc      V_6
    IL_0208:  ldc.i4     0x6
    IL_020d:  add
    IL_020e:  ldc.i4     0x0
    IL_0213:  stind.i1
    IL_0214:  ldloc      V_3
    IL_021a:  call       void hanoi._::_puts(uint8*)
    IL_021f:  call       int32 hanoi._::_geti()
    IL_0224:  stloc      V_2
    IL_022a:  ldloc      V_2
    IL_0230:  stloc      V_1
    IL_0236:  ldloc      V_1
    IL_023c:  ldloc      V_4
    IL_0242:  ldloc      V_5
    IL_0248:  ldloc      V_6
    IL_024e:  ldloca     V_0
    IL_0254:  call       void hanoi._::_.hanoi.solve(int32,
                                                     uint8*,
                                                     uint8*,
                                                     uint8*,
                                                     int32&)
    IL_0259:  ret
  } // end of method _::_.hanoi

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method _::.ctor

} // end of class hanoi._


// =============================================================

// 
