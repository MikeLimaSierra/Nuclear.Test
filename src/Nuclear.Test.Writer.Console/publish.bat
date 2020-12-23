@ECHO OFF

SET sn_exe="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe"
SET key=..\KeyPair.snk
SET bin=..\..\bin\Nuclear.Test.Writer.Console\AnyCPU\Release\netstandard2.0\
SET publish=..\..\publish\Nuclear.Test.Writer.Console\netstandard2.0\
SET dll=Nuclear.Test.Writer.Console.dll
SET pdb=Nuclear.Test.Writer.Console.pdb
SET xml=Nuclear.Test.Writer.Console.xml
SET deps=Nuclear.Test.Writer.Console.deps.json

REM delete publish dir
RMDIR /S /Q %publish%

REM resign assembly
%sn_exe% -Ra %bin%%dll% %key%

REM verify assembly in bin
%sn_exe% -vf %bin%%dll%

REM copy output to publish dir
robocopy %bin% %publish% %dll% %pdb% %xml% %deps%

REM verify assembly in publish
%sn_exe% -vf %publish%%dll%