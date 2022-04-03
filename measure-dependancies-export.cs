string tsv = "Measure\tDependsOnTable\tType";  // TSV file header row

// Loop through all measures:
foreach(var m in Model.AllMeasures) {

    var allReferences = m.DependsOn.Deep();

    var allTableReferences = allReferences.OfType<Table>()
        .Concat(allReferences.OfType<Column>().Select(c => c.Table)).Distinct();

    foreach (var t in allTableReferences)
        tsv += string.Format("\r\n{0}\t{1}\tTable", m.Name, t.Name);
    
    var allMeasureReferences = allReferences.OfType<Measure>().Distinct();

    foreach (var m2 in allMeasureReferences)
        tsv += string.Format("\r\n{0}\t{1}\tMeasure", m.Name, m2.Name);
}

tsv.Output();
