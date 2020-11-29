VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} editVehicle 
   Caption         =   "Edit Vehicle"
   ClientHeight    =   8724.001
   ClientLeft      =   108
   ClientTop       =   456
   ClientWidth     =   13068
   OleObjectBlob   =   "editVehicle.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "editVehicle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public LoadActiveVehiclesRow, FullVehiclesRow As Integer

Private Sub ActiveVehicles_Click()

FullVehiclesRow = 5

With Sheets("Active DB")

    Set LoadActiveVehicles = .Cells.Find(What:=ActiveVehicles.Text, After:=Range("C4"), LookAt:=xlWhole, SearchOrder:=xlByRows, SearchDirection:=xlNext)
    LoadActiveVehiclesRow = LoadActiveVehicles.Row
    
    Do While .Cells(LoadActiveVehiclesRow, 5).Value <> ActiveVehicles.Column(1) Or .Cells(LoadActiveVehiclesRow, 6).Value <> ActiveVehicles.Column(2)
        
        SearchRow = LoadActiveVehiclesRow
        
        Set LoadActiveVehicles = .Cells.Find(What:=ActiveVehicles.Column(2), After:=Range("C" & SearchRow), LookAt:=xlWhole, SearchOrder:=xlByRows, SearchDirection:=xlNext)
        LoadActiveVehiclesRow = LoadActiveVehicles.Row
    
    Loop
    
    Do While Sheets("Full DB").Cells(FullVehiclesRow, 5).Value <> .Cells(LoadActiveVehiclesRow, 5).Value Or Sheets("Full DB").Cells(FullVehiclesRow, 6).Value <> .Cells(LoadActiveVehiclesRow, 6).Value
    
        FullVehiclesRow = FullVehiclesRow + 1
        
    Loop
    
    LocationsFinal.Text = .Cells(LoadActiveVehiclesRow, 3).Value
    VehTypeFinal.Text = .Cells(LoadActiveVehiclesRow, 4).Value
    ModelFinal.Text = .Cells(LoadActiveVehiclesRow, 5).Value
    TAGFinal.Text = .Cells(LoadActiveVehiclesRow, 6).Value
    YearFinal.Text = .Cells(LoadActiveVehiclesRow, 7).Value
    
    If .Cells(LoadActiveVehiclesRow, 8).Value = "Gasoline" Then
        gasolineFuel.Value = True
    
    ElseIf .Cells(LoadActiveVehiclesRow, 8).Value = "Ethanol" Then
        ethanolFuel.Value = True
    
    ElseIf .Cells(LoadActiveVehiclesRow, 8).Value = "Flex" Then
        flexFuel.Value = True
    
    ElseIf .Cells(LoadActiveVehiclesRow, 8).Value = "Diesel" Then
        dieselFuel.Value = True
    
    End If
    
    EngineFinal.Text = .Cells(LoadActiveVehiclesRow, 9).Value
    PowerFinal.Text = .Cells(LoadActiveVehiclesRow, 10).Value
    WeightFinal.Text = .Cells(LoadActiveVehiclesRow, 11).Value
    ColorFinal.Text = .Cells(LoadActiveVehiclesRow, 12).Value
    responsibleFinal.Text = .Cells(LoadActiveVehiclesRow, 13).Value
    statusFinal.Text = .Cells(LoadActiveVehiclesRow, 16).Value
    CommentsFinal.Text = .Cells(LoadActiveVehiclesRow, 17).Value

End With

End Sub

Private Sub deleteButton_Click()

result = MsgBox("Are you sure you want to delete the vehicle?", vbYesNoCancel)

If result = vbYes Then
    Sheets("Full DB").Cells(FullVehiclesRow, 14).Value = Date
    Sheets("Full DB").Cells(FullVehiclesRow, 15).Value = Time()
    Sheets("Full DB").Cells(FullVehiclesRow, 16).Value = "Deleted"
    
    Sheets("Active DB").Rows(LoadActiveVehiclesRow).Delete
    
    ActiveVehicles.Clear
    
    With Sheets("Active DB")
    
        linha = 5
        
        Do While .Cells(linha, 1) <> ""
                    
            ActiveVehicles.AddItem
            ActiveVehicles.List(linList, 0) = .Cells(linha, 3)   ' FORD Locations
            ActiveVehicles.List(linList, 1) = .Cells(linha, 5)   ' Vehicle Model
            ActiveVehicles.List(linList, 2) = .Cells(linha, 6)   ' Vehicle TAG
            ActiveVehicles.List(linList, 3) = .Cells(linha, 13)  ' Status
            ActiveVehicles.List(linList, 4) = .Cells(linha, 16)  ' Status
            
            linList = linList + 1
            linha = linha + 1
        
        Loop
    
    End With
    
    LocationsFinal.Text = ""
    VehTypeFinal.Text = ""
    ModelFinal.Text = ""
    TAGFinal.Text = ""
    YearFinal.Text = ""
    
    gasolineFuel.Value = False
    ethanolFuel.Value = False
    flexFuel.Value = False
    dieselFuel.Value = False
    
    EngineFinal.Text = ""
    PowerFinal.Text = ""
    WeightFinal.Text = ""
    ColorFinal.Text = ""
    responsibleFinal.Text = ""
    statusFinal.Text = ""
    CommentsFinal.Text = ""
    
End If

End Sub

Private Sub editButton_Click()

With Sheets("Active DB")

    .Cells(LoadActiveVehiclesRow, 3).Value = LocationsFinal.Text
    .Cells(LoadActiveVehiclesRow, 4).Value = VehTypeFinal.Text
    .Cells(LoadActiveVehiclesRow, 5).Value = ModelFinal.Text
    .Cells(LoadActiveVehiclesRow, 6).Value = TAGFinal.Text
    .Cells(LoadActiveVehiclesRow, 7).Value = YearFinal.Text
    
    If gasolineFuel.Value = True Then
        .Cells(LoadActiveVehiclesRow, 8).Value = "Gasoline"
    
    ElseIf ethanolFuel.Value = True Then
        .Cells(LoadActiveVehiclesRow, 8).Value = "Ethanol"
    
    ElseIf flexFuel.Value = True Then
        .Cells(LoadActiveVehiclesRow, 8).Value = "Flex"
    
    ElseIf dieselFuel.Value = True Then
        .Cells(LoadActiveVehiclesRow, 8).Value = "Diesel"
    
    End If
    
    .Cells(LoadActiveVehiclesRow, 9).Value = EngineFinal.Text
    .Cells(LoadActiveVehiclesRow, 10).Value = PowerFinal.Text
    .Cells(LoadActiveVehiclesRow, 11).Value = WeightFinal.Text
    .Cells(LoadActiveVehiclesRow, 12).Value = ColorFinal.Text
    .Cells(LoadActiveVehiclesRow, 13).Value = responsibleFinal.Text
    .Cells(LoadActiveVehiclesRow, 14).Value = Date
    .Cells(LoadActiveVehiclesRow, 15).Value = Time()
    .Cells(LoadActiveVehiclesRow, 16).Value = statusFinal.Text
    .Cells(LoadActiveVehiclesRow, 17).Value = CommentsFinal.Text

End With

With Sheets("Full DB")

    .Cells(FullVehiclesRow, 3).Value = LocationsFinal.Text
    .Cells(FullVehiclesRow, 4).Value = VehTypeFinal.Text
    .Cells(FullVehiclesRow, 5).Value = ModelFinal.Text
    .Cells(FullVehiclesRow, 6).Value = TAGFinal.Text
    .Cells(FullVehiclesRow, 7).Value = YearFinal.Text
    
    If gasolineFuel.Value = True Then
        .Cells(FullVehiclesRow, 8).Value = "Gasoline"
    
    ElseIf ethanolFuel.Value = True Then
        .Cells(FullVehiclesRow, 8).Value = "Ethanol"
    
    ElseIf flexFuel.Value = True Then
        .Cells(FullVehiclesRow, 8).Value = "Flex"
    
    ElseIf dieselFuel.Value = True Then
        .Cells(FullVehiclesRow, 8).Value = "Diesel"
    
    End If
    
    .Cells(FullVehiclesRow, 9).Value = EngineFinal.Text
    .Cells(FullVehiclesRow, 10).Value = PowerFinal.Text
    .Cells(FullVehiclesRow, 11).Value = WeightFinal.Text
    .Cells(FullVehiclesRow, 12).Value = ColorFinal.Text
    .Cells(FullVehiclesRow, 13).Value = responsibleFinal.Text
    .Cells(FullVehiclesRow, 14).Value = Date
    .Cells(FullVehiclesRow, 15).Value = Time()
    .Cells(FullVehiclesRow, 16).Value = statusFinal.Text
    .Cells(FullVehiclesRow, 17).Value = CommentsFinal.Text

End With

End Sub

Private Sub Load_Vehicles_Click()

With Sheets("Active DB")

    linha = 5
    linList = 0
    
    Do While .Cells(linha, 1) <> ""
                
        ActiveVehicles.AddItem
        ActiveVehicles.List(linList, 0) = .Cells(linha, 3)   ' FORD Locations
        ActiveVehicles.List(linList, 1) = .Cells(linha, 5)   ' Vehicle Model
        ActiveVehicles.List(linList, 2) = .Cells(linha, 6)   ' Vehicle TAG
        ActiveVehicles.List(linList, 3) = .Cells(linha, 13)  ' Status
        ActiveVehicles.List(linList, 4) = .Cells(linha, 16)  ' Status
        
        linList = linList + 1
        linha = linha + 1
    
    Loop

End With

lin1 = 2
lin2 = 2
lin3 = 2

Do While Sheets("Configuration").Cells(lin1, 1) <> ""

    LocationsFinal.AddItem Sheets("Configuration").Cells(lin1, 1).Value
    
    lin1 = lin1 + 1

Loop

Do While Sheets("Configuration").Cells(lin2, 2) <> ""

    VehTypeFinal.AddItem Sheets("Configuration").Cells(lin2, 2).Value
    
    lin2 = lin2 + 1

Loop

Do While Sheets("Configuration").Cells(lin3, 3) <> ""

    statusFinal.AddItem Sheets("Configuration").Cells(lin3, 3).Value
    
    lin3 = lin3 + 1

Loop

End Sub

