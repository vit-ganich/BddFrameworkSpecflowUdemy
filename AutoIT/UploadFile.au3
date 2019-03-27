; 1. Create a loop to wait for file upload
; 2. Bring the upload dialog in focus
; 3. Provide the file path to the upload dialog
; 4. Click on Upload button

$count = 0
Sleep(3000)

While $count <> 10

   $firefox = WinActivate("File Upload")
   $chrome = WinActivate("Open")
   $ie = WinActivate("Choose File to Upload")

   If $firefox <> 0 Then
	  ControlFocus("File Upload","","Edit1")
	  Sleep(500)
	  ControlSetText("File Upload","","Edit1",$CmdLine[1])
	  Sleep(500)
	  ControlClick("File Upload","","Button1")
	  Exit

   ElseIf $chrome <> 0 Then
	  ControlFocus("Open","","Edit1")
	  Sleep(500)
	  ControlSetText("Open","","Edit1",$CmdLine[1])
	  Sleep(500)
	  ControlClick("Open","","Button1")
	  Exit

   ElseIf $ie <> 0 Then
	  ControlFocus("Choose File to Upload", "", "Edit1")
	  Sleep(500)
	  ControlSetText("Choose File to Upload", "", "Edit1", $CmdLine[1])
	  Sleep(500)
	  ControlClick("Choose File to Upload", "", "Button1")
   EndIf

   Sleep(1000)
   $count  = $count + 1
WEnd