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

02 05:43:18.677 G  RX <<<<<COPY FROM HERE>>>>>01 04 10 51 24 45 B7 19 71 3F 5F 19 F9 43 0B 59 D1 45 D2 70 B9<<<<<<TO HERE>>>>>>

.....and paste it into ModbusDecoder and press "Decode" 

You should get:

Slave ID:               01
Function Code:          04
Number of data bytes    10

Float Values:           51 24 45 B7 -> 45B75124 -> 5866,143
                        19 71 3F 5F -> 3F5F1971 -> 0,871482
                        19 F9 43 0B -> 430B19F9 -> 139,1015
                        59 D1 45 D2 -> 45D259D1 -> 6731,227
