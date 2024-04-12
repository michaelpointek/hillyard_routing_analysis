Sub ExtractUniqueZones()
    Dim wsMaster As Worksheet
    Dim wsAnalysis As Worksheet
    Dim lastRow As Long
    Dim uniqueZones As Object
    Dim cell As Range
    Dim zone As Variant
    Dim zoneIndex As Long
    
    ' Set references to worksheets
    Set wsMaster = ThisWorkbook.Sheets("Master")
    Set wsAnalysis = ThisWorkbook.Sheets("Statistical Analysis")
    
    ' Initialize a dictionary to store unique zones
    Set uniqueZones = CreateObject("Scripting.Dictionary")
    
    ' Find last row in Master sheet
    lastRow = wsMaster.Cells(wsMaster.Rows.Count, "D").End(xlUp).Row
    
    ' Loop through column D to extract unique zone values
    For Each cell In wsMaster.Range("D6:D" & lastRow)
        If Not IsEmpty(cell.Value) And Not uniqueZones.Exists(cell.Value) Then
            uniqueZones.Add cell.Value, cell.Value
        End If
    Next cell
    
    ' Populate unique zone values in Analysis sheet starting from A2
    wsAnalysis.Range("A2").Resize(uniqueZones.Count, 1).Value = Application.Transpose(uniqueZones.Keys)
    
    ' Sort unique zone values in ascending order
    wsAnalysis.Range("A2").Resize(uniqueZones.Count, 1).Sort Key1:=wsAnalysis.Range("A2"), Order1:=xlAscending, Header:=xlNo
    
    ' Clear any remaining data below the unique zone values
    wsAnalysis.Range("A" & uniqueZones.Count + 2 & ":A" & wsAnalysis.Rows.Count).ClearContents
End Sub

