Sub CopyDataToZoneRecommendation()
    Dim wsMaster As Worksheet
    Dim wsZoneRecommendation As Worksheet
    Dim lastRow As Long
    Dim i As Long
    
    ' Set references to worksheets
    Set wsMaster = ThisWorkbook.Sheets("Master")
    Set wsZoneRecommendation = ThisWorkbook.Sheets("Zone Recommendation")
    
    ' Find last row in Master sheet
    lastRow = wsMaster.Cells(wsMaster.Rows.Count, "A").End(xlUp).Row
    
    ' Copy data from Master tab to Zone Recommendation tab
    For i = 6 To lastRow ' Starting from row 6 in Master tab
        ' Copy specified columns (A, B, D, E, F) from Master tab
        wsMaster.Range("A" & i & ":B" & i & ",D" & i & ":F" & i).Copy
        ' Paste into corresponding columns (A, B, C, D, E) in Zone Recommendation tab
        wsZoneRecommendation.Cells(wsZoneRecommendation.Rows.Count, "A").End(xlUp).Offset(1, 0).PasteSpecial xlPasteValues
    Next i
    
End Sub

