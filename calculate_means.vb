Sub CalculateMeans()
    Dim wsMaster As Worksheet
    Dim wsAnalysis As Worksheet
    Dim lastRow As Long
    Dim uniqueZones As Range
    Dim zone As Range
    Dim zoneRow As Long
    Dim meanLat As Double, meanLon As Double
    
    ' Set references to worksheets
    Set wsMaster = ThisWorkbook.Sheets("Master")
    Set wsAnalysis = ThisWorkbook.Sheets("Statistical Analysis")
    
    ' Find last row in Master sheet
    lastRow = wsMaster.Cells(wsMaster.Rows.Count, "D").End(xlUp).Row
    
    ' Set range for unique zones
    Set uniqueZones = wsAnalysis.Range("A2:A" & wsAnalysis.Cells(wsAnalysis.Rows.Count, "A").End(xlUp).Row)
    
    ' Loop through unique zones
    For Each zone In uniqueZones
        ' Calculate mean for Latitude and Longitude by zone
        meanLat = Application.WorksheetFunction.AverageIf(wsMaster.Range("D6:D" & lastRow), zone.Value, wsMaster.Range("E6:E" & lastRow))
        meanLon = Application.WorksheetFunction.AverageIf(wsMaster.Range("D6:D" & lastRow), zone.Value, wsMaster.Range("F6:F" & lastRow))
        
        ' Find row to populate means in Analysis sheet
        zoneRow = wsAnalysis.Cells(zone.Row, 1).Row
        
        ' Populate means in Analysis sheet
        wsAnalysis.Cells(zoneRow, 2).Value = meanLat
        wsAnalysis.Cells(zoneRow, 3).Value = meanLon
    Next zone
End Sub

