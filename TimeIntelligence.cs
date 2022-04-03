var dateColumn = "'DimDate'[DateKey]"
var DisplayFolder = "Time Intelligence"

// Creates time intelligence measures for every selected measure:
foreach (var m in Selected.Measures) {
    // Year-to-date:
    m.Table.AddMeasure(
        m.name + " YTD",                                            // Name
        "TOTALYTD(" + m.DaxObjectName + ", " + dateColumn + ")",    // DAX expression
        m.DisplayFolder                                             //Display Folder
    );

    // Previous year:
    m.Table.AddMeasure(
                m.Name + " PY",                                                                     // Name
                "CALCULATE(" + m.DaxObjectName + ", SAMEPERIODLASTYEAR(" + dateColumn + "))",    // DAX Expression
                m.DisplayFolder                                                                     // Display Folder
        );

    // Year-over-Year
    m.Table.AddMeasure(
        m.Name + " YoY",                            // Name
        m.DaxObjectName + " - [" + m.Name + " PY]", // DAX Expression
        m.DisplayFolder                             // Display Folder
    );

    // Quarter-to-date:
    m.Table.AddMeasure(
        m.Name + " QTD",                                            // Name
        "TOTALQTD(" + m.DaxObjectName + ", " + dateColumn + ")",    // DAX Expression
        m.DisplayFolder                                             // Display Folder
    );

    // Month-to-date:
    m.Table.AddMeasure(
        m.Name + " MTD",                                            // Name
        "TOTALMTD(" + m.DaxObjectName + ", " + dateColumn + ") ",   // DAX Expression
        m.DisplayFolder                                             // Display Folder
    );
}
