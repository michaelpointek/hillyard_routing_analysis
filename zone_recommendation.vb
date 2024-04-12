Sub CalculateZoneRecommendation()
    Dim wsZoneRecommendation As Worksheet
    Dim wsStatisticalAnalysis As Worksheet
    Dim lastRowZone As Long
    Dim lastRowStat As Long
    Dim currentZone As Range
    Dim lat As Double
    Dim lon As Double
    Dim meanLat As Double
    Dim meanLon As Double
    Dim minDistance As Double
    Dim closestZone As String
    Dim i As Long
    Dim j As Long
    Dim reviewStatus As String
    
    ' Set references to worksheets
    Set wsZoneRecommendation = ThisWorkbook.Sheets("Zone Recommendation")
    Set wsStatisticalAnalysis = ThisWorkbook.Sheets("Statistical Analysis")
    
    ' Find last row in Zone Recommendation tab
    lastRowZone = wsZoneRecommendation.Cells(wsZoneRecommendation.Rows.Count, "D").End(xlUp).Row
    
    ' Find last row in Statistical Analysis tab
    lastRowStat = wsStatisticalAnalysis.Cells(wsStatisticalAnalysis.Rows.Count, "A").End(xlUp).Row
    
    ' Loop through each row in Zone Recommendation tab starting from row 6
    For i = 6 To lastRowZone
        ' Reset variables
        closestZone = ""
        minDistance = 999999 ' Set a very high initial value
        
        ' Get latitude and longitude values
        lat = wsZoneRecommendation.Cells(i, 4).Value
        lon = wsZoneRecommendation.Cells(i, 5).Value
        
        ' Loop through each zone in Statistical Analysis tab
        For j = 2 To lastRowStat ' Starting from row 2 in Statistical Analysis tab
            Set currentZone = wsStatisticalAnalysis.Cells(j, 1)
            
            ' Get mean latitude and longitude for the current zone
            meanLat = wsStatisticalAnalysis.Cells(j, 2).Value
            meanLon = wsStatisticalAnalysis.Cells(j, 3).Value
            
            ' Calculate distance between the current point and the mean point of the zone
            Dim distance As Double
            distance = Sqr((lat - meanLat) ^ 2 + (lon - meanLon) ^ 2)
            
            ' Check if the distance is the smallest so far
            If distance < minDistance Then
                minDistance = distance
                closestZone = currentZone.Value
            End If
        Next j
        
        ' Write the closest zone to the Zone Recommendation tab
        wsZoneRecommendation.Cells(i, 6).Value = closestZone
        
        ' Compare values in column F and column C
        If wsZoneRecommendation.Cells(i, 6).Value = wsZoneRecommendation.Cells(i, 3).Value Then
            ' If values are the same, set review status to "No Change"
            reviewStatus = "No Change"
        Else
            ' If values are different, set review status to "REVIEW NEEDED" and highlight cell in orange
            reviewStatus = "REVIEW NEEDED"
            wsZoneRecommendation.Cells(i, 7).Interior.Color = RGB(255, 192, 0) ' Orange color
        End If
        
        ' Write review status to column G
        wsZoneRecommendation.Cells(i, 7).Value = reviewStatus
    Next i
End Sub

