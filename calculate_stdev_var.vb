Sub CalculateStdDevAndVar()
    Dim wsMaster As Worksheet
    Dim wsAnalysis As Worksheet
    Dim lastRow As Long
    Dim uniqueZones As Range
    Dim zone As Range
    Dim zoneRow As Long
    Dim stdDevLatFormula As String
    Dim stdDevLonFormula As String
    Dim varLatFormula As String
    Dim varLonFormula As String
    
    ' Set references to worksheets
    Set wsMaster = ThisWorkbook.Sheets("Master")
    Set wsAnalysis = ThisWorkbook.Sheets("Statistical Analysis")
    
    ' Find last row in Master sheet
    lastRow = wsMaster.Cells(wsMaster.Rows.Count, "D").End(xlUp).Row
    
    ' Set range for unique zones
    Set uniqueZones = wsAnalysis.Range("A2:A" & wsAnalysis.Cells(wsAnalysis.Rows.Count, "A").End(xlUp).Row)
    
    ' Loop through unique zones
    For Each zone In uniqueZones
        ' Define formulas for standard deviation and variance for Latitude and Longitude by zone
        stdDevLatFormula = "=STDEV.P(IF(Master!D:D='" & wsAnalysis.Name & "'!A" & zone.Row & ",Master!E:E))"
        stdDevLonFormula = "=STDEV.P(IF(Master!D:D='" & wsAnalysis.Name & "'!A" & zone.Row & ",Master!F:F))"
        varLatFormula = "=VAR.P(IF(Master!D:D='" & wsAnalysis.Name & "'!A" & zone.Row & ",Master!E:E))"
        varLonFormula = "=VAR.P(IF(Master!D:D='" & wsAnalysis.Name & "'!A" & zone.Row & ",Master!F:F))"
        
        ' Find row to populate standard deviation and variance in Analysis sheet
        zoneRow = wsAnalysis.Cells(zone.Row, 1).Row
        
        ' Populate standard deviation and variance formulas in Analysis sheet
        wsAnalysis.Cells(zoneRow, 4).FormulaArray = stdDevLatFormula
        wsAnalysis.Cells(zoneRow, 5).FormulaArray = stdDevLonFormula
        wsAnalysis.Cells(zoneRow, 6).FormulaArray = varLatFormula
        wsAnalysis.Cells(zoneRow, 7).FormulaArray = varLonFormula
    Next zone
    
    ' Copy and paste values for standard deviation and variance
    wsAnalysis.Range("D2:G" & wsAnalysis.Cells(wsAnalysis.Rows.Count, "A").End(xlUp).Row).Copy
    wsAnalysis.Range("D2:G" & wsAnalysis.Cells(wsAnalysis.Rows.Count, "A").End(xlUp).Row).PasteSpecial xlPasteValues
    Application.CutCopyMode = False
End Sub

