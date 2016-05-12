ModbusDecoder requires .Net 4.0 to run

It will decode a float reply from Mdbus.exe, taken from the Monitor view.

Example Mdbus.LOG:

02 05:43:18.677 G  RX 01 04 10 51 24 45 B7 19 71 3F 5F 19 F9 43 0B 59 D1 45 D2 70 B9 
02 05:43:18.725 G  TX 02 04 0B B8 00 08 73 FE 
02 05:43:18.783 G  RX 02 04 10 99 3F 45 9B 89 D2 3F 5C 99 57 43 06 9E 44 45 B4 4B E2 
02 05:43:18.831 G  TX 01 04 0B B8 00 08 73 CD 
02 05:43:18.889 G  RX 01 04 10 4F FA 45 B7 19 3F 3F 5F 19 F9 43 0B 58 AA 45 D2 B7 85 
02 05:43:18.937 G  TX 02 04 0B B8 00 08 73 FE 
02 05:43:18.995 G  RX 02 04 10 B0 BB 45 9B 8B 11 3F 5C 99 46 43 06 B8 81 45 B4 00 FB 
02 05:43:19.043 G  TX 01 04 0B B8 00 08 73 CD 
02 05:43:19.101 G  RX 01 04 10 4E 9E 45 B7 19 82 3F 5F 19 F9 43 0B 56 DB 45 D2 2D A3 

To Decode what is received on Slave ID 1....

02 05:43:18.677 G  <<<<<COPY FROM HERE>>>>>RX 01 04 10 51 24 45 B7 19 71 3F 5F 19 F9 43 0B 59 D1 45 D2 70 B9<<<<<<TO HERE>>>>>>

.....and paste it into ModbusDecoder and press "Decode" 

You should get:

------------------------------------------------------------
04 (0x04) Read Input Registers
------------------------------------------------------------
Original Message:   01 04 10 51 24 45 B7 19 71 3F 5F 19 F9 43 0B 59 D1 45 D2 70 B9
Slave ID:               1 (0x01)
Function Code:          4 (0x04)
Byte Count:            16 (0x10)
Checksum:            70B9
Float Values (4):
       001: 51 24 45 B7 -> 45B75124 -> 5866.143
       002: 19 71 3F 5F -> 3F5F1971 -> 0.871482
       003: 19 F9 43 0B -> 430B19F9 -> 139.1015
       004: 59 D1 45 D2 -> 45D259D1 -> 6731.227

More examples:

FC 0x03 - 200 bytes NOTE: Not Modicon Float
01 03 C8 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 46 AF 2A 00 45 23 10 00 42 A4 33 33 44 D6 E0 00 47 26 B0 00 47 26 B0 00 47 1C 2E 00 47 1C 2E 00 00 00 00 00 00 00 00 00 3F CA 3D 71 44 BF 5C CD 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 66 94 

FC 0x10 - 100 bytes NOTE: Not Modicon Float
01 10 00 64 00 32 64 48 9C 1C B6 48 94 27 C8 48 98 95 47 48 87 F7 BD 42 AC 07 2B 42 AE 57 91 42 AC 89 5E 42 AF DE 29 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 45 C9 F0 4D 45 CA 95 4D 45 C9 23 FE 45 C9 64 DF 42 0A 66 66 42 0C CC CD 42 13 33 33 42 11 33 33 42 9E CC CD 9D A4 

Here, we are slave, and this is the log:
-------------------------------------------------------------
Read Holding Registers (FC=03) - request to read, response with values
RX 01 03 00 00 00 2C 44 17 
TX 01 03 58 01 14 00 00 46 82 62 00 45 47 F0 00 44 EF 00 00 42 47 99 9A 47 26 C9 00 47 1D 38 00 47 1D 3A 00 47 27 F8 00 43 99 33 33 3F B4 7A E1 43 50 33 33 00 00 00 00 00 00 00 00 00 00 00 00 45 59 70 00 00 00 00 00 00 00 00 00 00 00 00 00 43 CA 00 00 41 4C CC CD 41 49 99 9A 2E 20 

Preset Multiple Registers (FC=16) - request to write with values, response to acknowledge
RX 01 10 00 5B 00 10 20 00 00 3F 80 00 00 3F 80 CC CD 42 0C CC CD 41 DC 51 EC 41 2C 1E B8 40 B5 CC CD 40 F4 E1 48 40 FA FB DB 
TX 01 10 00 5B 00 10 B0 16 

Preset Single Register (FC=06) - request to write single register value, repsone to acknowledge
RX 01 06 00 00 04 35 4B 1D 
TX 01 06 00 00 04 35 4B 1D 