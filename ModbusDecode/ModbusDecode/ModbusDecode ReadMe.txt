ModbusDecoder requires .Net 4.0 to run

It will decode a message received or transmitted by Mdbus.exe, taken from the Monitor view.

Summary of function codes:
------------------------------------------------------------
01 (0x01) Read Coils
02 (0x02) Read Discrete Inputs
03 (0x03) Read Holding Registers
04 (0x04) Read Input Registers
05 (0x05) Write Single Coil 
06 (0x06) Write Single Register
07 (0x07) Read Exception Status (Serial Line only) 
08 (0x08) Diagnostics (Serial Line only)
11 (0x0B) Get Comm Event Counter (Serial Line only)
12 (0x0C) Get Comm Event Log (Serial Line only)
15 (0x0F) Write Multiple Coils
16 (0x10) Write Multiple registers
17 (0x11) Report Server ID (Serial Line only)
20 (0x14) Read File Record
21 (0x15) Write File Record
22 (0x16) Mask Write Register
23 (0x17) Read/Write Multiple registers
24 (0x18) Read FIFO Queue ..

References:
http://www.modbus.org/specs.php
http://www.simplymodbus.ca/FAQ.htm

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

You should get (Note that we are master):

------------------------------------------------------------
04 (0x04) Read Input Registers
------------------------------------------------------------
Original Message:   RX 01 04 10 51 24 45 B7 19 71 3F 5F 19 F9 43 0B 59 D1 45 D2 70 B9
Message Type:       Receive
Message Role:       Response
Slave ID:               1 (0x01)
Function Code:          4 (0x04)
Byte Count:            16 (0x10)
Checksum:            70B9 (GOOD)
Float Values (4):
       001: 51 24 45 B7 -> 45B75124 -> 5866,143
       002: 19 71 3F 5F -> 3F5F1971 -> 0,871482
       003: 19 F9 43 0B -> 430B19F9 -> 139,1015
       004: 59 D1 45 D2 -> 45D259D1 -> 6731,227

------------------------------------------------------------
FC 3 and 10 examples:
------------------------------------------------------------

FC 0x03 - 200 bytes NOTE: Not Modicon Float. Response is Received (RX) by Master (or transmitted (RX) by slave)
RX 01 03 C8 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 46 AF 2A 00 45 23 10 00 42 A4 33 33 44 D6 E0 00 47 26 B0 00 47 26 B0 00 47 1C 2E 00 47 1C 2E 00 00 00 00 00 00 00 00 00 3F CA 3D 71 44 BF 5C CD 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 66 94 

FC 0x10 - 100 bytes NOTE: Not Modicon Float. Master transmits (TX) request (or slave receives (RX) request)
TX 01 10 00 64 00 32 64 48 9C 1C B6 48 94 27 C8 48 98 95 47 48 87 F7 BD 42 AC 07 2B 42 AE 57 91 42 AC 89 5E 42 AF DE 29 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 45 C9 F0 4D 45 CA 95 4D 45 C9 23 FE 45 C9 64 DF 42 0A 66 66 42 0C CC CD 42 13 33 33 42 11 33 33 42 9E CC CD 9D A4 

The following examples assumes we are slave;
------------------------------------------------------------
01 (0x01) Read Coils - request to read coil #20 - #56 (Start = 0x13 + 1, Length is 0x25 = 37)
------------------------------------------------------------
RX 11 01 00 13 00 25 0E 84
TX 11 01 05 CD 6B B2 0E 1B 45 E6

------------------------------------------------------------
02 (0x02) Read Discrete Inputs
------------------------------------------------------------
RX 11 02 00 C4 00 16 BA A9
TX 11 02 03 AC DB 35 20 18

------------------------------------------------------------
03 (0x03) Read Holding Registers - request to read, response with values
------------------------------------------------------------
RX 11 03 00 6B 00 03 76 87
TX 11 03 06 AE 41 56 52 43 40 49 AD

RX 01 03 00 00 00 2C 44 17 
TX 01 03 58 01 14 00 00 46 82 62 00 45 47 F0 00 44 EF 00 00 42 47 99 9A 47 26 C9 00 47 1D 38 00 47 1D 3A 00 47 27 F8 00 43 99 33 33 3F B4 7A E1 43 50 33 33 00 00 00 00 00 00 00 00 00 00 00 00 45 59 70 00 00 00 00 00 00 00 00 00 00 00 00 00 43 CA 00 00 41 4C CC CD 41 49 99 9A 2E 20 

------------------------------------------------------------
04 (0x04) Read Input Registers
------------------------------------------------------------
RX 11 04 00 08 00 01 B2 98
TX 11 04 02 00 0A F8 F4

------------------------------------------------------------
05 (0x05) Write Single Coil 
------------------------------------------------------------
RX 11 05 00 AC FF 00 4E 8B
TX 11 05 00 AC FF 00 4E 8B

------------------------------------------------------------
06 (0x06) Write Single Register - request to write single register value, repsone to acknowledge
------------------------------------------------------------
RX 01 06 00 00 04 35 4B 1D 
TX 01 06 00 00 04 35 4B 1D 

------------------------------------------------------------
15 (0x0F) Write Multiple Coils - This command is writing the contents of a series of 10 discrete coils from #20 to #29 to the slave device with address 17
------------------------------------------------------------
RX 11 0F 00 13 00 0A 02 CD 01 BF 0B
TX 11 0F 00 13 00 0A 26 99

------------------------------------------------------------
16 (0x10) Write Multiple registers- request to write values, response to acknowledge
------------------------------------------------------------
RX 01 10 00 5B 00 10 20 00 00 3F 80 00 00 3F 80 CC CD 42 0C CC CD 41 DC 51 EC 41 2C 1E B8 40 B5 CC CD 40 F4 E1 48 40 FA FB DB 
TX 01 10 00 5B 00 10 B0 16 

------------------------------------------------------------
Exception example
------------------------------------------------------------
0A 81 02 B0 53

------------------------------------------------------------
About Modicon format for floats and long integers
------------------------------------------------------------
According to mdbus documentation, Modicon format Lng. and Flt. means,
"The least significant bytes are sent in the first register and the most significant bytes in the second register of a pair."
Meaning we have to swap the byte pairs before converting to the value we want. This is visualized when the values are printed like this:

51 24 45 B7 -> 45B75124 -> 5866,143 (swapping the two byte pairs)
