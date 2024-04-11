Sub ClearForms()
    Dim wsMaster As Worksheet
    Dim wsStatisticalAnalysis As Worksheet
    Dim wsZoneRecommendation As Worksheet
    Dim lastRowMaster As Long
    Dim lastRowStat As Long
    Dim lastRowZone As Long
    
    ' Set references to worksheets
    Set wsMaster = ThisWorkbook.Sheets("Master")
    Set wsStatisticalAnalysis = ThisWorkbook.Sheets("Statistical Analysis")
    Set wsZoneRecommendation = ThisWorkbook.Sheets("Zone Recommendation")
    
    ' Find last row in Master tab column F
    lastRowMaster = wsMaster.Cells(wsMaster.Rows.Count, "F").End(xlUp).Row
    
    ' Clear forms on Master tab
    If lastRowMaster >= 6 Then
        wsMaster.Range("A6:F" & lastRowMaster).ClearContents
    End If
    
    ' Find last row in Statistical Analysis tab column G
    lastRowStat = wsStatisticalAnalysis.Cells(wsStatisticalAnalysis.Rows.Count, "G").End(xlUp).Row
    
    ' Clear forms on Statistical Analysis tab
    If lastRowStat >= 2 Then
        wsStatisticalAnalysis.Range("A2:G" & lastRowStat).ClearContents
    End If
    
    ' Find last row in Zone Recommendation tab column F
    lastRowZone = wsZoneRecommendation.Cells(wsZoneRecommendation.Rows.Count, "G").End(xlUp).Row
    
    ' Clear forms on Zone Recommendation tab
    If lastRowZone >= 6 Then
        wsZoneRecommendation.Range("A6:G" & lastRowZone).ClearContents
        ' Remove fill color from column G
        wsZoneRecommendation.Range("G6:G" & lastRowZone).Interior.Pattern = xlNone
    End If
End Sub

